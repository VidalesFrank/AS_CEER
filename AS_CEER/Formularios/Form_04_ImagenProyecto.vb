<Serializable>
Public Class Form_04_ImagenProyecto
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form_00_Principal.Proyecto.Imagen = P_Imagen.Image
        Me.Close()
    End Sub
End Class