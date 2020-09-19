Public Class Form7
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Dialog As New OpenFileDialog
        Dialog.Filter = "Imagenes |*.jpg"
        Dialog.Title = "Insertar Imagen"
        Dialog.ShowDialog()

        If Dialog.FileName <> String.Empty Then
            Form6.P_Imagen.ImageLocation = Dialog.FileName
            Form6.P_Imagen.SizeMode = PictureBoxSizeMode.StretchImage
            Form6.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Form1.Proyecto.Nombre = T_NameProjet.Text
            Form1.Proyecto.Direccion = T_Direction.Text
            Form1.Proyecto.Ciudad = T_City.Text
            Form1.Proyecto.Departamento = T_Department.Text
            Form1.Proyecto.Imagen = Form6.P_Imagen

            If Op_1984.Checked Then
                Form1.Proyecto.Año_Construccion = Op_1984.Text
            ElseIf Op_1998.Checked Then
                Form1.Proyecto.Año_Construccion = Op_1998.Text
            ElseIf Op_2010.Checked Then
                Form1.Proyecto.Año_Construccion = Op_2010.Text
            ElseIf Op_2020.Checked Then
                Form1.Proyecto.Año_Construccion = Op_2020.Text
            End If
        Catch ex As Exception
        Finally
            Me.WindowState = FormWindowState.Minimized
        End Try
    End Sub
End Class