Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Form1.Proyecto.Edificio.Dimension_Longitud = Convert.ToSingle(T_LargoE.Text)
            Form1.Proyecto.Edificio.Dimension_Transversal = Convert.ToSingle(T_AnchoE.Text)
        Catch ex As Exception
        Finally
            Me.Close()
        End Try
    End Sub
End Class