Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Form1.ListaMuros(0).AreaE = Convert.ToSingle(T_AnchoE.Text) * Convert.ToSingle(T_LargoE.Text)
            Form1.ListaMuros(0).Op_Area = "Ya"
        Catch ex As Exception

        Finally
            Me.WindowState = FormWindowState.Minimized
        End Try
    End Sub
End Class