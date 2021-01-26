<Serializable>
Public Class Form_05_AspectosGenerales
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If IsNothing(Form_00_Principal.Proyecto.Imagen) Then
            Dim Dialog As New OpenFileDialog
            Dialog.Filter = "Imagenes |*.jpg"
            Dialog.Title = "Insertar Imagen"
            Dialog.ShowDialog()
            Form_00_Principal.Proyecto.Ruta_Imagen = Dialog.FileName

            If Dialog.FileName <> String.Empty Then
                Form_04_ImagenProyecto.P_Imagen.ImageLocation = Dialog.FileName
                Form_04_ImagenProyecto.P_Imagen.SizeMode = PictureBoxSizeMode.StretchImage
                Form_04_ImagenProyecto.Show()
            End If
        Else
            Form_04_ImagenProyecto.P_Imagen.Image = Form_00_Principal.Proyecto.Imagen
            Form_04_ImagenProyecto.P_Imagen.SizeMode = PictureBoxSizeMode.StretchImage
            Form_04_ImagenProyecto.Show()
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Form_00_Principal.Proyecto.Nombre = T_NameProjet.Text
            Form_00_Principal.Proyecto.Direccion = T_Direction.Text
            Form_00_Principal.Proyecto.Ciudad = T_City.Text
            Form_00_Principal.Proyecto.Departamento = T_Department.Text

            If Op_1984.Checked Then
                Form_00_Principal.Proyecto.Año_Construccion = 1
            ElseIf Op_1998.Checked Then
                Form_00_Principal.Proyecto.Año_Construccion = 2
            ElseIf Op_2010.Checked Then
                Form_00_Principal.Proyecto.Año_Construccion = 3
            ElseIf Op_2020.Checked Then
                Form_00_Principal.Proyecto.Año_Construccion = 4
            End If
        Catch ex As Exception
        Finally
            Me.Close()
        End Try
    End Sub
End Class