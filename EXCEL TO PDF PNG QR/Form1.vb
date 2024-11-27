Imports OfficeOpenXml
Imports System.IO
Imports QRCoder
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Reflection


Public Class form1
    Private isLoading As Boolean = True ' Flag para evitar disparar el evento al cargar
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        isLoading = False
        conversiones()
    End Sub
    Private Sub LoadExcelData()
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial
        Dim filePath As String = OpenFileDialog1.FileName ' Cambia a la ruta de tu archivo Excel.
        Using package As New ExcelPackage(New FileInfo(filePath))
            Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets(0)
            Dim dt As New DataTable()

            ' Leer encabezadosssd
            For Each headerCell In worksheet.Cells(1, 1, 1, worksheet.Dimension.End.Column)
                dt.Columns.Add(headerCell.Text)
            Next

            ' Leer filas
            For i As Integer = 2 To worksheet.Dimension.End.Row
                Dim row As DataRow = dt.NewRow()
                For j As Integer = 1 To worksheet.Dimension.End.Column
                    row(j - 1) = worksheet.Cells(i, j).Text
                Next
                dt.Rows.Add(row)
            Next

            DataGridView1.DataSource = dt
        End Using
        ' Ajustar el ancho de las columnas automáticamente
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        ' Ajustar la altura de las filas automáticamente
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

    End Sub

    Private Function GenerateQRCode(data As String) As Bitmap
        Dim qrGenerator As New QRCodeGenerator()
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q)
        Dim qrCode As New QRCode(qrCodeData)

        ' Return qrCode.GetGraphic(20, Color.Black, Color.White, False)
        Return qrCode.GetGraphic(20, Color.Black, Color.White, drawQuietZones:=0)

    End Function
    Private Sub GenerateAndExportQRCodes1()
        ' Configuración inicial de la barra de progreso
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = DataGridView1.Rows.Count
        ProgressBar1.Value = 0
        ProgressBar1.Step = 1

        Using pdfDocument As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, txtMargenes.Value, txtMargenes.Value, txtMargenes.Value, txtMargenes.Value)
            ' Ajustar el tamaño de la página según sea necesario
            pdfDocument.SetPageSize(New iTextSharp.text.Rectangle(txtAnchoEtiq.Text, txtAltoEtiq.Value))

            Using pdfWriter As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDocument, New FileStream("output.pdf", FileMode.Create))
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
                        qrImage.ScaleAbsolute(anchoDisponible, anchoDisponible) ' Cuadrado: ancho = alto

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
                        Dim textData As String = String.Join(" | ", row.Cells.Cast(Of DataGridViewCell).Select(Function(c)
                                                                                                                   If c.Value IsNot Nothing Then
                                                                                                                       Return c.Value.ToString()
                                                                                                                   Else
                                                                                                                       Return String.Empty
                                                                                                                   End If
                                                                                                               End Function))
                        ' Celda con el texto concatenado
                        'Dim fuente As String = "iTextSharp.text.Font.FontFamily." & cmbFont.Text
                        'Dim selectedFontName As String = cmbFont.SelectedItem.ToString()
                        ' Determinar la familia de fuentes seleccionada en el ComboBox
                        ' Determinar la familia de fuentes seleccionada en el ComboBox
                        ' Determinar la familia de fuentes seleccionada en el ComboBox
                        Dim selectedFontFamily As iTextSharp.text.Font.FontFamily
                        Dim fontStyle As Integer = iTextSharp.text.Font.NORMAL ' Estilo predeterminado: Normal

                        If cmbFont.SelectedItem IsNot Nothing Then
                            Dim selectedFontName As String = cmbFont.SelectedItem.ToString() ' Renombrada a selectedFontName

                            ' Determinar el tipo de fuente
                            If selectedFontName.Contains("Courier") Then
                                selectedFontFamily = iTextSharp.text.Font.FontFamily.COURIER
                            ElseIf selectedFontName.Contains("Helvetica") Then
                                selectedFontFamily = iTextSharp.text.Font.FontFamily.HELVETICA
                            ElseIf selectedFontName.Contains("Times-Roman") Then
                                selectedFontFamily = iTextSharp.text.Font.FontFamily.TIMES_ROMAN
                            Else
                                ' Fuente predeterminada
                                selectedFontFamily = iTextSharp.text.Font.FontFamily.COURIER
                            End If

                            ' Determinar el estilo según el texto seleccionado
                            If cbxNegrita.Checked Then
                                fontStyle = iTextSharp.text.Font.BOLD ' Opción combinada
                            ElseIf selectedFontName.Contains("Italic") Then
                                fontStyle = fontStyle Or iTextSharp.text.Font.ITALIC ' Oblique se trata como Italic
                            End If
                        Else
                            ' Fuente y estilo predeterminados
                            selectedFontFamily = iTextSharp.text.Font.FontFamily.HELVETICA
                            fontStyle = iTextSharp.text.Font.NORMAL
                        End If

                        ' Crear la fuente con el estilo seleccionado
                        Dim tamanofuente As Single = txtTamanoFuente.Value
                        Dim textFont As New iTextSharp.text.Font(selectedFontFamily, tamanofuente, fontStyle) 'iTextSharp.text.Font.FontFamily.HELVETICA
                        Dim textCell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(textData, textFont))
                        textCell.Border = iTextSharp.text.Rectangle.BOX
                        textCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                        textCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
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

        ' Reiniciar la barra de progreso
        ProgressBar1.Value = ProgressBar1.Minimum
    End Sub

    Private Sub GenerateAndExportQRCodes()
        ' Configuración inicial de la barra de progreso
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = DataGridView1.Rows.Count
        ProgressBar1.Value = 0
        ProgressBar1.Step = 1

        ' Ruta del archivo de salida
        Dim outputFilePath As String = "output.pdf"

        Try
            Using pdfDocument As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, txtMargenes.Value, txtMargenes.Value, txtMargenes.Value, txtMargenes.Value)
                ' Ajustar el tamaño de la página según sea necesario
                pdfDocument.SetPageSize(New iTextSharp.text.Rectangle(txtAnchoEtiq.Text, txtAltoEtiq.Value))

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
                            qrImage.ScaleAbsolute(anchoDisponible, anchoDisponible) ' Cuadrado: ancho = alto

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
                            Dim textData As String = String.Join(" | ", row.Cells.Cast(Of DataGridViewCell).Select(Function(c)
                                                                                                                       If c.Value IsNot Nothing Then
                                                                                                                           Return c.Value.ToString()
                                                                                                                       Else
                                                                                                                           Return String.Empty
                                                                                                                       End If
                                                                                                                   End Function))

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
                            Dim textFont As New iTextSharp.text.Font(selectedFontFamily, tamanofuente, fontStyle)
                            Dim textCell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(textData, textFont))
                            textCell.Border = iTextSharp.text.Rectangle.BOX
                            textCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            textCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
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

    Private Sub UpdatePreview()
        Try
            ' Asegúrate de que los valores sean válidos antes de usarlos
            Dim alto As Integer = Convert.ToInt32(txtAltoEtiq.Value)
            If alto <= 0 Then
                Throw New ArgumentException("El alto debe ser mayor que cero.")
            End If

            Dim ancho As Integer = Convert.ToInt32(txtAnchoEtiq.Value)
            If ancho <= 0 Then
                Throw New ArgumentException("El ancho debe ser mayor que cero.")
            End If

            ' Obtener valores de márgenes y otros controles
            Dim margin As Integer = 0
            If Integer.TryParse(txtMargenes.Text, margin) AndAlso margin >= 0 Then
                ' Si es válido, continúa
            Else
                Throw New ArgumentException("El margen no es válido.")
            End If

            ' Calcular el tamaño disponible para el QR
            Dim qrWidth As Integer = ancho - 2 * margin
            Dim qrHeight As Integer = qrWidth ' Mantener proporción cuadrada para el QR

            ' Crear un bitmap para la etiqueta
            Dim previewBitmap As New Bitmap(ancho, alto)

            ' Dibujar la etiqueta en el bitmap
            Using g As Graphics = Graphics.FromImage(previewBitmap)
                ' Rellenar el fondo
                g.Clear(Color.White)

                ' Dibujar un borde (opcional)
                Dim pen As New Pen(Color.Black, 2)
                g.DrawRectangle(pen, 0, 0, ancho - 1, alto - 1)

                ' Asegúrate de que la segunda fila exista
                If DataGridView1.Rows.Count > 1 Then
                    Dim row As DataGridViewRow = DataGridView1.Rows(1) ' Obtén la segunda fila (índice 1)

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
                    g.DrawImage(qrImage, margin, margin, qrWidth, qrHeight) ' Dibujar QR ajustado a los márgenes

                    ' Concatenar texto
                    Dim textData As String = String.Join(" | ", row.Cells.Cast(Of DataGridViewCell).Select(Function(c)
                                                                                                               If c.Value IsNot Nothing Then
                                                                                                                   Return c.Value.ToString()
                                                                                                               Else
                                                                                                                   Return String.Empty
                                                                                                               End If
                                                                                                           End Function))

                    ' Dibujar el texto de la etiqueta debajo del código QR
                    Dim textMargin As Integer = margin + qrHeight + 10 ' Margen para el texto (después del QR)
                    Dim fontStylo As FontStyle = FontStyle.Regular  ' Estilo por defecto

                    ' Si el CheckBox está marcado, aplicar negrita
                    If cbxNegrita.Checked Then
                        fontStylo = FontStyle.Bold
                    End If
                    Dim font As New System.Drawing.Font(cmbFont.Text, txtTamanoFuente.Value, fontStylo)

                    ' Crear un área delimitada para el texto (bajo el QR)
                    Dim textRectangle As New RectangleF(margin, textMargin, ancho - 2 * margin, alto - textMargin - margin)

                    ' Dibujar el texto en el área delimitada con saltos de línea automáticos
                    Dim stringFormat As New StringFormat()
                    stringFormat.Alignment = StringAlignment.Center ' Alinear texto horizontalmente al centro
                    stringFormat.LineAlignment = StringAlignment.Near ' Alinear texto verticalmente desde la parte superior

                    g.DrawString(textData, font, Brushes.Black, textRectangle, stringFormat)
                End If
            End Using

            ' Mostrar el bitmap en el PictureBox
            pbPreview.Image = previewBitmap
            pbPreview.SizeMode = PictureBoxSizeMode.CenterImage ' Ajusta el tamaño de la imagen al centro del PictureBox
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al actualizar la vista previa: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ProgressBar1.Visible = True
        GenerateAndExportQRCodes()

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        OpenFileDialog1.ShowDialog()
        TextBox1.Text = OpenFileDialog1.FileName

        LoadExcelData()
        UpdatePreview()
    End Sub



    Private Sub btnUpdatePreview_Click(sender As Object, e As EventArgs) Handles btnUpdatePreview.Click
        UpdatePreview()

    End Sub
    Private Sub txtMargenes_ValueChanged(sender As Object, e As EventArgs) Handles txtMargenes.ValueChanged
        If isLoading Then Return

        UpdatePreview()
    End Sub
    Private Sub conversiones()
        lblcmancho.Text = Math.Round(txtAnchoEtiq.Value / 72 * 2.54, 2) & " cm"
        lblcmalto.Text = Math.Round(txtAltoEtiq.Value / 72 * 2.54, 2) & " cm"
    End Sub
    Private Sub txtAnchoEtiq_ValueChanged(sender As Object, e As EventArgs) Handles txtAnchoEtiq.ValueChanged
        If isLoading Then Return
        UpdatePreview()
        conversiones()
    End Sub

    Private Sub txtAltoEtiq_ValueChanged(sender As Object, e As EventArgs) Handles txtAltoEtiq.ValueChanged
        ' Solo ejecuta si no estamos en el proceso de carga
        If isLoading Then Return

        ' Ahora el evento solo se ejecutará cuando cambie el valor de txtAltoEtiq
        ' Realiza la acción que desees aquí
        UpdatePreview()
        conversiones()
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







    '  Private Sub updatepreview(sender As Object, e As EventArgs) Handles cbxNegrita.CheckedChanged, txtTamanoFuente.Click, cmbFont.SelectedValueChanged, txtAnchoEtiq.Click, txtAltoEtiq.Click
    '  UpdatePreview()
    ' End Sub

End Class