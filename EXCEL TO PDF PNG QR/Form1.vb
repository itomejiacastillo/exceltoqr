Imports OfficeOpenXml
Imports System.IO
Imports QRCoder
Imports Org.BouncyCastle.Crypto
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        LoadExcelData()
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

        Using pdfDocument As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0)
            ' Ajustar el tamaño de la página según sea necesario
            pdfDocument.SetPageSize(New iTextSharp.text.Rectangle(txtAnchoEtiq.Text, txtAltoEtiq.Text))

            Using pdfWriter As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDocument, New FileStream("output.pdf", FileMode.Create))
                pdfDocument.Open()

                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        ' Concatenar los datos para el código QR
                        Dim qrData As String = String.Join("<ht>", row.Cells.Cast(Of DataGridViewCell).Select(Function(c)
                                                                                                                  If c.Value IsNot Nothing Then
                                                                                                                      Return c.Value.ToString()
                                                                                                                  Else
                                                                                                                      Return String.Empty
                                                                                                                  End If
                                                                                                              End Function)) & vbCrLf

                        ' Generar el código QR para los datos concatenados
                        Dim qrCodeImage As Bitmap = GenerateQRCode(qrData)

                        ' Convertir la imagen QR a un objeto iTextSharp imagen
                        Dim qrImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(qrCodeImage, System.Drawing.Imaging.ImageFormat.Png)

                        ' Ajustar el tamaño de la imagen QR
                        qrImage.ScaleAbsolute(200.0F, 200.0F)

                        ' Crear una tabla para organizar el QR y el texto
                        Dim table As New iTextSharp.text.pdf.PdfPTable(1)
                        table.WidthPercentage = 100
                        table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER

                        ' Celda con el código QR
                        Dim qrCell As New iTextSharp.text.pdf.PdfPCell(qrImage)
                        qrCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                        qrCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                        qrCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                        table.AddCell(qrCell)

                        ' Concatenar los datos para el texto
                        Dim textData As String = String.Join(" ", row.Cells.Cast(Of DataGridViewCell).Select(Function(c)
                                                                                                                 If c.Value IsNot Nothing Then
                                                                                                                     Return c.Value.ToString()
                                                                                                                 Else
                                                                                                                     Return String.Empty
                                                                                                                 End If
                                                                                                             End Function))

                        ' Celda con el texto concatenado
                        Dim textFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)
                        Dim textCell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(textData, textFont))
                        textCell.Border = iTextSharp.text.Rectangle.NO_BORDER
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




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ProgressBar1.Visible = True
        GenerateAndExportQRCodes()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        OpenFileDialog1.ShowDialog()
        TextBox1.Text = OpenFileDialog1.FileName
    End Sub


End Class