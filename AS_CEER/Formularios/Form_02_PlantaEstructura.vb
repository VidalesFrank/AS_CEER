Public Class Form_02_PlantaEstructura
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Form_00_Principal.Proyecto.Edificio.Dimension_Longitud = Convert.ToSingle(T_LargoE.Text)
            Form_00_Principal.Proyecto.Edificio.Dimension_Transversal = Convert.ToSingle(T_AnchoE.Text)
        Catch ex As Exception
        Finally
            Me.Close()
        End Try
    End Sub
End Class