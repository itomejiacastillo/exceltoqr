Imports OfficeOpenXml
Imports System.IO
Imports QRCoder
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Drawing

Public Class form1
    Private Sub LoadExcelData()
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial
        Dim filePath As String = OpenFileDialog1.FileName ' Cambia a la ruta de tu archivo Excel
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
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Function GenerateQRCode(data As String) As Bitmap
        Dim qrGenerator As New QRCodeGenerator()
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q)
        Dim qrCode As New QRCode(qrCodeData)
        Return qrCode.GetGraphic(20)
    End Function





    Private Sub GenerateAndExportQRCodes()
        ' Configuración inicial de la barra de progreso
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = DataGridView1.Rows.Count
        ProgressBar1.Value = 0
        ProgressBar1.Step = 1

        Using pdfDocument As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 1, 1, 1, 1)
            ' Ajustar el tamaño de la página según sea necesario
            pdfDocument.SetPageSize(New iTextSharp.text.Rectangle(txtAnchoEtiq.Text, txtAltoEtiq.Text))

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
                        Dim anchoDisponible As Single = pdfDocument.PageSize.Width - pdfDocument.LeftMargin

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
                        Dim textFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)
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

    Private Sub UpdatePreview1()
        ' Obtener ancho y alto de la etiqueta
        Dim labelWidth As Integer = Integer.Parse(txtAnchoEtiq.Text)
        Dim labelHeight As Integer = Integer.Parse(txtAltoEtiq.Text)

        ' Definir márgenes (en píxeles) alrededor del código QR
        Dim margin As Integer = txtMargenHorizontal.Text ' Margen desde el borde de la etiqueta

        ' Calcular el tamaño disponible para el QR
        Dim qrWidth As Integer = labelWidth - 2 * margin ' Espacio disponible para el código QR en el ancho
        Dim qrHeight As Integer = labelWidth - 2 * margin ' Espacio disponible para el código QR en el alto

        ' Crear un bitmap para la etiqueta
        Dim previewBitmap As New Bitmap(labelWidth, labelHeight)

        ' Dibujar la etiqueta en el bitmap
        Using g As Graphics = Graphics.FromImage(previewBitmap)
            ' Rellenar el fondo
            g.Clear(Color.White)

            ' Dibujar un borde (opcional)
            Dim pen As New Pen(Color.Black, 2)
            g.DrawRectangle(pen, 0, 0, labelWidth - 1, labelHeight - 1)

            ' Asegúrate de que la segunda fila existe
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

                ' Calcular el tamaño del QR en función del tamaño disponible
                ' Usar el tamaño disponible para que el QR se ajuste al área

                Dim qrCode As New QRCode(qrCodeData)
                Dim qrImage As Bitmap = qrCode.GetGraphic(Math.Min(qrWidth, qrHeight) / 20) ' Ajusta el tamaño del QR dinámicamente

                ' Verificar que la imagen no sea nula
                If qrImage IsNot Nothing Then
                    ' Dibujar la imagen QR sobre el bitmap de la etiqueta
                    g.DrawImage(qrImage, margin, margin, qrWidth, qrHeight) ' Ajusta las coordenadas y tamaño según los márgenes
                Else
                    MessageBox.Show("Hubo un error al generar el código QR.")
                End If
                ' Concatenar texto
                Dim textData As String = String.Join(" | ", row.Cells.Cast(Of DataGridViewCell).Select(Function(c)
                                                                                                           If c.Value IsNot Nothing Then
                                                                                                               Return c.Value.ToString()
                                                                                                           Else
                                                                                                               Return String.Empty
                                                                                                           End If
                                                                                                       End Function))

                ' Dibujar el texto de la etiqueta debajo del código QR
                Dim textMargin As Integer = margin + qrHeight + 5 ' Márgenes para el texto (ajustado después del QR)
                Dim text As String = textData ' Puedes cambiar esto para usar los datos de la fila
                Dim font As New System.Drawing.Font("Arial", 10, FontStyle.Regular)
                Dim textSize As SizeF = g.MeasureString(text, font)

                ' Asegurarse de que el texto no se desborde y que se ajuste dentro de la etiqueta
                'If textSize.Width <= labelWidth - 2 * margin Then
                ' Dibujar el texto centrado en la etiqueta debajo del QR
                g.DrawString(text, font, Brushes.Black, New PointF((labelWidth - textSize.Width) / 2, textMargin))
                'Else
                'MessageBox.Show("El texto es demasiado largo para ajustarse a la etiqueta.")
                'End If

            Else
                MessageBox.Show("No hay suficientes filas en el DataGridView.")
            End If

        End Using

        ' Mostrar el bitmap en el PictureBox
        pbPreview.Image = previewBitmap
        pbPreview.SizeMode = PictureBoxSizeMode.CenterImage ' Ajusta el tamaño de la imagen al centro del PictureBox
    End Sub
    Private Sub UpdatePreview()
        ' Obtener ancho y alto de la etiqueta
        Dim labelWidth As Integer = Integer.Parse(txtAnchoEtiq.Text)
        Dim labelHeight As Integer = Integer.Parse(txtAltoEtiq.Text)

        ' Definir márgenes (en píxeles) alrededor del código QR
        Dim margin As Integer = Integer.Parse(txtMargenHorizontal.Text) ' Margen desde el borde de la etiqueta

        ' Calcular el tamaño disponible para el QR
        Dim qrWidth As Integer = labelWidth - 2 * margin ' Espacio disponible para el código QR en el ancho
        Dim qrHeight As Integer = qrWidth ' Mantener proporción cuadrada para el QR

        ' Crear un bitmap para la etiqueta
        Dim previewBitmap As New Bitmap(labelWidth, labelHeight)

        ' Dibujar la etiqueta en el bitmap
        Using g As Graphics = Graphics.FromImage(previewBitmap)
            ' Rellenar el fondo
            g.Clear(Color.White)

            ' Dibujar un borde (opcional)
            Dim pen As New Pen(Color.Black, 2)
            g.DrawRectangle(pen, 0, 0, labelWidth - 1, labelHeight - 1)

            ' Asegúrate de que la segunda fila existe
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
                Dim qrImage As Bitmap = qrCode.GetGraphic(20)
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
                Dim text As String = textData ' Puedes cambiar esto para usar los datos de la fila
                Dim font As New System.Drawing.Font("Arial", 10, FontStyle.Regular)

                ' Crear un área delimitada para el texto (bajo el QR)
                Dim textRectangle As New RectangleF(margin, textMargin, labelWidth - 2 * margin, labelHeight - textMargin - margin)

                ' Dibujar el texto en el área delimitada con saltos de línea automáticos
                Dim stringFormat As New StringFormat()
                stringFormat.Alignment = StringAlignment.Center ' Alinear texto horizontalmente al centro
                stringFormat.LineAlignment = StringAlignment.Near ' Alinear texto verticalmente desde la parte superior

                g.DrawString(text, font, Brushes.Black, textRectangle, stringFormat)

            Else
                MessageBox.Show("No hay suficientes filas en el DataGridView.")
            End If
        End Using

        ' Mostrar el bitmap en el PictureBox
        pbPreview.Image = previewBitmap
        pbPreview.SizeMode = PictureBoxSizeMode.CenterImage ' Ajusta el tamaño de la imagen al centro del PictureBox
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

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtQRAncho.Text = txtAnchoEtiq.Text - txtMargenHorizontal.Text
        txtQRAlto.Text = txtQRAncho.Text
        'UpdatePreview()

    End Sub
End Class