Imports ExcelDataReader
Imports OfficeOpenXml
Imports System.IO
Imports QRCoder
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Reflection
Imports System.Text
Public Class form1
    Private isLoading As Boolean = True ' Flag para evitar disparar el evento al cargar
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        isLoading = False
    End Sub
    Private hojasExcel As DataSet = Nothing
    Private Function SelectSheetDialog(sheetNames As List(Of String)) As String
        Dim frm As New Form With {.Text = "Selecciona una hoja", .Size = New Size(300, 150)}
        Dim cmb As New ComboBox With {.Dock = DockStyle.Top, .DropDownStyle = ComboBoxStyle.DropDownList}
        Dim btn As New Button With {.Text = "Aceptar", .Dock = DockStyle.Bottom}

        cmb.Items.AddRange(sheetNames.ToArray())
        'cmb.SelectedIndex = 0 ' ✅ Forzar una selección inicial

        frm.Controls.Add(cmb)
        frm.Controls.Add(btn)

        Dim selectedSheet As String = Nothing
        AddHandler btn.Click, Sub()
                                  selectedSheet = cmb.SelectedItem?.ToString()
                                  frm.Close()
                              End Sub

        frm.ShowDialog(Me) ' ✅ Asegura que esté al frente

        Return selectedSheet
    End Function


    Private Sub LoadExcelData()
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)

        If OpenFileDialog1.ShowDialog() <> DialogResult.OK Then Exit Sub

        Dim filePath As String = OpenFileDialog1.FileName
        TextBox1.Text = filePath
        Using stream As FileStream = File.Open(filePath, FileMode.Open, FileAccess.Read)
            Using reader As IExcelDataReader = ExcelReaderFactory.CreateReader(stream)
                Dim conf As New ExcelDataSetConfiguration() With {
                .ConfigureDataTable = Function(__) New ExcelDataTableConfiguration() With {
                    .UseHeaderRow = True
                }
            }

                hojasExcel = reader.AsDataSet(conf)
            End Using
        End Using

        ComboBoxHojas.Items.Clear()

        If hojasExcel.Tables.Count = 1 Then
            ' ✅ Solo una hoja, la cargamos directamente
            DataGridView1.DataSource = hojasExcel.Tables(0)
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            Button2.Enabled = True
            ComboBoxHojas.Enabled = True
            For Each hoja As DataTable In hojasExcel.Tables
                ComboBoxHojas.Items.Add(hoja.TableName)
            Next
            ComboBoxHojas.SelectedIndex = 0
        ElseIf hojasExcel.Tables.Count > 1 Then
            ' ✅ Varias hojas: llenar ComboBox y esperar selección
            For Each hoja As DataTable In hojasExcel.Tables
                ComboBoxHojas.Items.Add(hoja.TableName)
            Next

            ComboBoxHojas.Enabled = True
            ' El usuario ahora debe presionar otro botón para cargar la hoja
        End If
    End Sub

    Private Function GenerateQRCode(data As String) As Bitmap
        Dim qrGenerator As New QRCodeGenerator()
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q)
        Dim qrCode As New QRCode(qrCodeData)

        ' Return qrCode.GetGraphic(20, Color.Black, Color.White, False)
        Return qrCode.GetGraphic(20, Color.Black, Color.White, drawQuietZones:=0)

    End Function
    Private Sub GenerateAndExportQRCodes()
        ' Configuración inicial de la barra de progreso
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = DataGridView1.Rows.Count
        ProgressBar1.Value = 0
        ProgressBar1.Step = 1

        ' Ruta del archivo de salida
        Dim outputFilePath As String = "output.pdf"

        Try
            Dim dpiX As Single
            Using g As Graphics = Me.CreateGraphics()
                dpiX = g.DpiX / 2.54
            End Using
            Dim margenes As Single = (txtMargenes.Value / 2.54) * 72
            Dim anchoetiqueta As Single = (txtAnchoEtiq.Value / 2.54) * 72
            Dim altoetiqueta As Single = (txtAltoEtiq.Value / 2.54) * 72
            Using pdfDocument As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, margenes, margenes, margenes, margenes)
                ' Ajustar el tamaño de la página según sea necesario
                pdfDocument.SetPageSize(New iTextSharp.text.Rectangle(anchoetiqueta, altoetiqueta))

                ' Intentar crear el archivo PDF
                Using pdfWriter As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDocument, New FileStream(outputFilePath, FileMode.Create))
                    pdfDocument.Open()

                    For Each row As DataGridViewRow In DataGridView1.Rows
                        If Not row.IsNewRow Then
                            ' Concatenar los datos para el código QR
                            Dim qrData As String = String.Join(vbTab, row.Cells.Cast(Of DataGridViewCell).Select(Function(c)
                                                                                                                     If c.Value IsNot Nothing Then
                                                                                                                         Return c.Value.ToString()
                                                                                                                     Else
                                                                                                                         Return String.Empty
                                                                                                                     End If
                                                                                                                 End Function))

                            ' Generar el código QR para los datos concatenados
                            Dim qrCodeImage As Bitmap = GenerateQRCode(qrData)

                            ' Convertir la imagen QR a un objeto iTextSharp imagen
                            Dim qrImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(qrCodeImage, System.Drawing.Imaging.ImageFormat.Png)

                            ' Obtener el ancho disponible de la tabla en puntos
                            Dim anchoDisponible As Single = pdfDocument.PageSize.Width - pdfDocument.LeftMargin - pdfDocument.RightMargin

                            ' Ajustar el tamaño del QR al 100% del ancho disponible en la celda
                            Dim qrSize As Single

                            If RadioButtonQRFullSize.Checked Then
                                qrSize = anchoDisponible ' 100% del ancho
                                NumericQRWidth.Enabled = False
                            ElseIf RadioButtonQRCustom.Checked Then
                                NumericQRWidth.Enabled = True
                                ' Convertir cm a puntos (1 cm = 72 / 2.54 puntos)
                                qrSize = (NumericQRWidth.Value / 2.54) * 72
                            End If

                            qrImage.ScaleAbsolute(qrSize, qrSize)
                            ' Crear una tabla para organizar el QR y el texto
                            Dim table As New iTextSharp.text.pdf.PdfPTable(1)
                            table.WidthPercentage = 100
                            table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER

                            ' Celda con el código QR
                            Dim qrCell As New iTextSharp.text.pdf.PdfPCell(qrImage)
                            qrCell.Border = iTextSharp.text.Rectangle.BOX
                            qrCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            qrCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                            table.AddCell(qrCell)

                            ' Concatenar los datos para el texto
                            'Dim textData As String = String.Join(" | ", row.Cells.Cast(Of DataGridViewCell).Select(Function(c)
                            'If c.Value IsNot Nothing Then
                            '     Return c.Value.ToString()
                            '  Else
                            '       Return String.Empty
                            '    End If
                            ' End Function))
                            ' Construir el texto con encabezado y valor por cada celda
                            Dim textBuilder As New System.Text.StringBuilder()
                            For Each cell As DataGridViewCell In row.Cells
                                If cell.Value IsNot Nothing Then
                                    Dim columnName As String = DataGridView1.Columns(cell.ColumnIndex).HeaderText
                                    Dim cellValue As String = cell.Value.ToString()

                                    textBuilder.AppendLine(columnName)
                                    textBuilder.AppendLine(cellValue)
                                End If
                            Next

                            Dim textData As String = textBuilder.ToString().TrimEnd()

                            ' Determinar la familia de fuentes seleccionada en el ComboBox
                            Dim selectedFontFamily As iTextSharp.text.Font.FontFamily
                            Dim fontStyle As Integer = iTextSharp.text.Font.NORMAL ' Estilo predeterminado: Normal

                            If cmbFont.SelectedItem IsNot Nothing Then
                                Dim selectedFontName As String = cmbFont.SelectedItem.ToString()

                                ' Determinar el tipo de fuente
                                If selectedFontName.Contains("Courier") Then
                                    selectedFontFamily = iTextSharp.text.Font.FontFamily.COURIER
                                ElseIf selectedFontName.Contains("Helvetica") Then
                                    selectedFontFamily = iTextSharp.text.Font.FontFamily.HELVETICA
                                ElseIf selectedFontName.Contains("Times-Roman") Then
                                    selectedFontFamily = iTextSharp.text.Font.FontFamily.TIMES_ROMAN
                                Else
                                    selectedFontFamily = iTextSharp.text.Font.FontFamily.COURIER
                                End If

                                ' Determinar el estilo según el texto seleccionado
                                If cbxNegrita.Checked Then
                                    fontStyle = iTextSharp.text.Font.BOLD
                                ElseIf selectedFontName.Contains("Italic") Then
                                    fontStyle = fontStyle Or iTextSharp.text.Font.ITALIC
                                End If
                            Else
                                selectedFontFamily = iTextSharp.text.Font.FontFamily.HELVETICA
                                fontStyle = iTextSharp.text.Font.NORMAL
                            End If

                            ' Crear la fuente con el estilo seleccionado
                            Dim tamanofuente As Single = txtTamanoFuente.Value
                            Dim tamanofuenteheader As Single = txttamanoheader.Value
                            Dim textFont As New iTextSharp.text.Font(selectedFontFamily, tamanofuente, fontStyle)
                            'Dim textCell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(textData, textFont))
                            ' Crear estilos separados para encabezados y datos
                            Dim negritaheader As Integer = iTextSharp.text.Font.NORMAL ' Estilo predeterminado: Normal
                            If cbxnegritaheader.Checked Then
                                negritaheader = iTextSharp.text.Font.BOLD
                            End If
                            Dim headerFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, tamanofuenteheader, negritaheader)
                            Dim valueFont As New iTextSharp.text.Font(selectedFontFamily, tamanofuente, fontStyle)

                            Dim phrase As New iTextSharp.text.Phrase()

                            For Each cell As DataGridViewCell In row.Cells
                                If cell.Value IsNot Nothing Then
                                    Dim columnName As String = DataGridView1.Columns(cell.ColumnIndex).HeaderText
                                    Dim cellValue As String = cell.Value.ToString()

                                    ' Encabezado en negrita
                                    phrase.Add(New iTextSharp.text.Chunk(columnName & vbLf, headerFont))
                                    ' Valor en fuente normal
                                    phrase.Add(New iTextSharp.text.Chunk(cellValue & vbLf, valueFont))
                                End If
                            Next

                            Dim textCell As New iTextSharp.text.pdf.PdfPCell(phrase)
                            textCell.Border = iTextSharp.text.Rectangle.BOX
                            textCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                            textCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP

                            'textCell.Border = iTextSharp.text.Rectangle.BOX
                            'textCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            'textCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                            table.AddCell(textCell)
                            pdfDocument.Add(table)
                            pdfDocument.NewPage()

                            ' Actualizar la barra de progreso
                            ProgressBar1.PerformStep()
                            Application.DoEvents() ' Permitir que la UI se actualice
                        End If
                    Next

                    pdfDocument.Close()
                End Using
            End Using

            ' Mostrar mensaje de éxito con opción de abrir el archivo
            Form2.Show()

        Catch ex As IOException
            ' Si el archivo está en uso, muestra un mensaje al usuario y no cierra el programa
            If ex.Message.Contains("because it is being used by another process") Then
                MessageBox.Show("El archivo PDF de salida está en uso por otro programa. Por favor, ciérralo y vuelve a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                ' Si el error es diferente, muestra un mensaje genérico
                MessageBox.Show("Ocurrió un error al generar el archivo PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ' Captura cualquier otro tipo de excepción y muestra el mensaje
            MessageBox.Show("Ocurrió un error inesperado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Reiniciar la barra de progreso
        ProgressBar1.Value = ProgressBar1.Minimum
    End Sub
    Private filactual As Integer = 0
    Private Sub UpdatePreview()
        If isLoading Then Exit Sub ' ⛔ Previene ejecución prematura
        If DataGridView1.Rows.Count = 0 OrElse filactual >= DataGridView1.Rows.Count Then Exit Sub

        Dim dpiX As Single
        Using g As Graphics = Me.CreateGraphics()
            dpiX = g.DpiX / 2.54
        End Using

        Try
            ' Asegúrate de que los valores sean válidos antes de usarlos
            Dim altoetiqueta As Integer = Convert.ToInt32(txtAltoEtiq.Value * dpiX)
            If altoetiqueta <= 0 Then
                Throw New ArgumentException("El alto debe ser mayor que cero.")
            End If

            Dim anchoetiqueta As Integer = Convert.ToInt32(txtAnchoEtiq.Value * dpiX)
            If anchoetiqueta <= 0 Then
                Throw New ArgumentException("El ancho debe ser mayor que cero.")
            End If

            ' Obtener valores de márgenes y otros controles
            Dim margenes As Integer = txtMargenes.Value * dpiX
            If margenes >= 0 Then
                ' Si es válido, continúa
            Else
                Throw New ArgumentException("El margen no es válido.")
            End If

            ' Calcular el tamaño disponible para el QR
            Dim qrWidth As Integer
            If RadioButtonQRFullSize.Checked Then
                qrWidth = anchoetiqueta - 2 * margenes
            Else
                qrWidth = Convert.ToInt32(NumericQRWidth.Value * dpiX)
            End If
            Dim qrHeight As Integer = qrWidth ' Cuadrado

            ' Crear un bitmap para la etiqueta
            Dim previewBitmap As New Bitmap(anchoetiqueta, altoetiqueta)

            ' Dibujar la etiqueta en el bitmap
            Using g As Graphics = Graphics.FromImage(previewBitmap)
                ' Rellenar el fondo
                g.Clear(Color.White)

                ' Dibujar un borde (opcional)
                Dim pen As New Pen(Color.Black, 2)
                g.DrawRectangle(pen, 0, 0, anchoetiqueta - 1, altoetiqueta - 1)

                ' Asegúrate de que la segunda fila exista
                If DataGridView1.Rows.Count > 1 Then
                    Dim row As DataGridViewRow = DataGridView1.Rows(filactual) ' Obtén la segunda fila (índice 1)

                    ' Concatenar los datos para el código QR
                    Dim qrData As String = String.Join(vbTab, row.Cells.Cast(Of DataGridViewCell).Select(Function(c)
                                                                                                             If c.Value IsNot Nothing Then
                                                                                                                 Return c.Value.ToString()
                                                                                                             Else
                                                                                                                 Return String.Empty
                                                                                                             End If
                                                                                                         End Function))

                    ' Crear una instancia de la clase QRCodeGenerator
                    Dim qrGenerator As New QRCodeGenerator()
                    Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q)

                    ' Crear la imagen QR y ajustarla al tamaño disponible
                    Dim qrCode As New QRCode(qrCodeData)
                    Dim qrImage As Bitmap = qrCode.GetGraphic(20, Color.Black, Color.White, drawQuietZones:=0)
                    g.DrawImage(qrImage, margenes, margenes, qrWidth, qrHeight) ' Dibujar QR ajustado a los márgenes

                    Dim textMargin As Integer = margenes + qrHeight + 10
                    Dim xTexto As Single = margenes
                    Dim yTexto As Single = textMargin
                    Dim anchoTexto As Single = anchoetiqueta - 2 * margenes

                    ' Fuente para encabezados
                    Dim headerFontStyle As FontStyle = FontStyle.Regular
                    If cbxnegritaheader.Checked Then headerFontStyle = FontStyle.Bold
                    Dim headerFont As New System.Drawing.Font("Helvetica", txttamanoheader.Value, headerFontStyle)

                    ' Fuente para valores
                    Dim bodyFontStyle As FontStyle = FontStyle.Regular
                    If cbxNegrita.Checked Then bodyFontStyle = FontStyle.Bold
                    Dim bodyFont As New System.Drawing.Font(cmbFont.Text, txtTamanoFuente.Value, bodyFontStyle)

                    ' Pincel de texto
                    Dim brush As Brush = Brushes.Black

                    ' Recorrer cada celda
                    For Each cell As DataGridViewCell In row.Cells
                        If cell.Value IsNot Nothing Then
                            Dim columnName As String = DataGridView1.Columns(cell.ColumnIndex).HeaderText
                            Dim cellValue As String = cell.Value.ToString()

                            ' Medir altura de cada bloque de texto para ir sumando Y
                            Dim headerSize As SizeF = g.MeasureString(columnName, headerFont, CInt(anchoTexto))
                            Dim valueSize As SizeF = g.MeasureString(cellValue, bodyFont, CInt(anchoTexto))

                            ' Dibujar encabezado
                            g.DrawString(columnName, headerFont, brush, New RectangleF(xTexto, yTexto, anchoTexto, headerSize.Height))
                            yTexto += headerSize.Height

                            ' Dibujar valor
                            g.DrawString(cellValue, bodyFont, brush, New RectangleF(xTexto, yTexto, anchoTexto, valueSize.Height))
                            yTexto += valueSize.Height
                        End If
                    Next

                End If
            End Using

            ' Mostrar el bitmap en el PictureBox
            pbPreview.Image = previewBitmap
            pbPreview.SizeMode = PictureBoxSizeMode.CenterImage ' Ajusta el tamaño de la imagen al centro del PictureBox
        Catch ex As Exception
            MessageBox.Show("Esta es la última etiqueta de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ProgressBar1.Visible = True
        GenerateAndExportQRCodes()
    End Sub
    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        LoadExcelData()
        UpdatePreview()
    End Sub
    Private Sub btnUpdatePreview_Click(sender As Object, e As EventArgs)
        UpdatePreview()

    End Sub
    Private Sub txtMargenes_ValueChanged(sender As Object, e As EventArgs) Handles txtMargenes.ValueChanged
        If isLoading Then Return

        UpdatePreview()
    End Sub

    Private Sub txtAnchoEtiq_ValueChanged(sender As Object, e As EventArgs) Handles txtAnchoEtiq.ValueChanged
        If isLoading Then Return
        UpdatePreview()
    End Sub
    Private Sub txtAltoEtiq_ValueChanged(sender As Object, e As EventArgs) Handles txtAltoEtiq.ValueChanged
        ' Solo ejecuta si no estamos en el proceso de carga
        If isLoading Then Return

        ' Ahora el evento solo se ejecutará cuando cambie el valor de txtAltoEtiq
        ' Realiza la acción que desees aquí
        UpdatePreview()
    End Sub

    Private Sub cmbFont_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbFont.SelectedValueChanged
        If isLoading Then Return
        UpdatePreview()
    End Sub

    Private Sub cbxNegrita_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNegrita.CheckedChanged
        If isLoading Then Return
        UpdatePreview()
    End Sub

    Private Sub txtTamanoFuente_ValueChanged(sender As Object, e As EventArgs) Handles txtTamanoFuente.ValueChanged
        If isLoading Then Return
        UpdatePreview()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ultimoIndice As Integer = DataGridView1.RowCount - 1
        filactual = filactual + 1
        UpdatePreview()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If filactual = 0 Then
            MessageBox.Show("Esta es la primera etiqueta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            filactual = filactual - 1
            UpdatePreview()
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        filactual = 0
        UpdatePreview()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim ultimoIndice As Integer = DataGridView1.RowCount - 1
        filactual = ultimoIndice

        UpdatePreview()

    End Sub

    Private Sub CargarHoja()
        If hojasExcel Is Nothing Then
            MessageBox.Show("Primero selecciona un archivo Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If ComboBoxHojas.SelectedItem Is Nothing Then
            MessageBox.Show("Selecciona una hoja del libro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim hojaSeleccionada = ComboBoxHojas.SelectedItem.ToString
        Dim tabla = hojasExcel.Tables(hojaSeleccionada)

        DataGridView1.DataSource = tabla
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Button2.Enabled = True
    End Sub

    Private Sub ComboBoxHojas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxHojas.SelectedIndexChanged
        CargarHoja()
        UpdatePreview()
    End Sub

    Private Sub cbxnegritaheader_CheckedChanged(sender As Object, e As EventArgs) Handles cbxnegritaheader.CheckedChanged
        UpdatePreview()
    End Sub

    Private Sub txttamanoheader_ValueChanged(sender As Object, e As EventArgs) Handles txttamanoheader.ValueChanged
        UpdatePreview()
    End Sub

    Private Sub NumericQRWidth_ValueChanged(sender As Object, e As EventArgs) Handles NumericQRWidth.ValueChanged
        UpdatePreview()
    End Sub

    Private Sub RadioButtonQRCustom_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonQRCustom.CheckedChanged
        UpdatePreview()
        If RadioButtonQRFullSize.Checked = True Then
            NumericQRWidth.Enabled = False
        Else
            NumericQRWidth.Enabled = True
        End If
    End Sub

    Private Sub RadioButtonQRFullSize_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonQRFullSize.CheckedChanged
        UpdatePreview()
        If RadioButtonQRFullSize.Checked = True Then
            NumericQRWidth.Enabled = False
        Else
            NumericQRWidth.Enabled = True
        End If
    End Sub
End Class