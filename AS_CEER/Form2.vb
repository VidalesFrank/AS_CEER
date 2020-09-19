Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Form1.Proyecto.Edificio.Op_Cargas = "Ya"
            For i = 0 To Tabla_Cargas.Rows.Count - 2
                Form1.Proyecto.Edificio.ListaMuros(i).CM = Convert.ToSingle(Tabla_Cargas.Rows(i).Cells(1).Value)
                Form1.Proyecto.Edificio.ListaMuros(i).CD = Convert.ToSingle(Tabla_Cargas.Rows(i).Cells(2).Value)
            Next
        Catch ex As Exception
        Finally
            Me.Close()
        End Try
    End Sub

End Class