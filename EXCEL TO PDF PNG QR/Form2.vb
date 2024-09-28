Imports System.IO

Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim startInfo As New ProcessStartInfo()
            startInfo.FileName = "output.pdf"
            startInfo.UseShellExecute = True
            Process.Start(startInfo)
        Catch ex As Exception
            MessageBox.Show("No se pudo abrir el archivo PDF. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Mostrar el SaveFileDialog para que el usuario elija dónde guardar el archivo
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf"
        saveFileDialog.Title = "Guardar archivo como"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                ' Mover o copiar el archivo a la nueva ubicación
                Dim newFilePath As String = saveFileDialog.FileName

                ' Usar File.Copy para copiar o File.Move para mover el archivo
                File.Copy("output.pdf", newFilePath, True) ' True permite sobrescribir si ya existe

                ' Informar al usuario que la operación fue exitosa
                MessageBox.Show("El archivo PDF ha sido guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Catch ex As Exception
                MessageBox.Show("No se pudo guardar el archivo PDF. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If
    End Sub
End Class