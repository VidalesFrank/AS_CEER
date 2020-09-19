Public Class Form5
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Err = 0
        Dim Total As Single = 0
        For i = 0 To 7
            Total += Convert.ToSingle(Tabla_PesoICE.Rows(i).Cells(1).Value)
        Next

        If Total > 100 Then
            Dim style = MsgBoxStyle.Critical
            MsgBox("El peso total es de " & Total & "%, el porcentaje máximo debe ser 100%", style, "Datos Invalidos")
            Err = 1
        End If

        If Convert.ToSingle(T_PFS.Text) > 100 Or Convert.ToSingle(T_PFS.Text) < 50 Then
            Dim style = MsgBoxStyle.Critical
            MsgBox("El Porcentaje de Fuerza Sísmica debe estar entre 50% y 100%", style, "Datos Invalidos")
            Err = 1
        End If

        If Err = 0 Then
            Try
                Form1.Proyecto.Edificio.Indicador.Densidad_Max = Tabla_PesoICE.Rows(0).Cells(1).Value
                Form1.Proyecto.Edificio.Indicador.Num_Pisos_Max = Tabla_PesoICE.Rows(1).Cells(1).Value
                Form1.Proyecto.Edificio.Indicador.Factor_Forma_Max = Tabla_PesoICE.Rows(2).Cells(1).Value
                Form1.Proyecto.Edificio.Indicador.Ar_Max = Tabla_PesoICE.Rows(3).Cells(1).Value
                Form1.Proyecto.Edificio.Indicador.ALR_Max = Tabla_PesoICE.Rows(4).Cells(1).Value
                Form1.Proyecto.Edificio.Indicador.Amenaza_Max = Tabla_PesoICE.Rows(5).Cells(1).Value
                Form1.Proyecto.Edificio.Indicador.Esbeltez_Max = Tabla_PesoICE.Rows(6).Cells(1).Value
                Form1.Proyecto.Edificio.Indicador.Confinamiento_Max = Tabla_PesoICE.Rows(7).Cells(1).Value

                Form1.Proyecto.Edificio.Indicador.Densidad_Int = Tabla_PesoICE.Rows(0).Cells(2).Value
                Form1.Proyecto.Edificio.Indicador.Num_Pisos_Int = Tabla_PesoICE.Rows(1).Cells(2).Value
                Form1.Proyecto.Edificio.Indicador.Factor_Forma_Int = Tabla_PesoICE.Rows(2).Cells(2).Value
                Form1.Proyecto.Edificio.Indicador.Ar_Int = Tabla_PesoICE.Rows(3).Cells(2).Value
                Form1.Proyecto.Edificio.Indicador.ALR_Int = Tabla_PesoICE.Rows(4).Cells(2).Value
                Form1.Proyecto.Edificio.Indicador.Amenaza_Int = Tabla_PesoICE.Rows(5).Cells(2).Value
                Form1.Proyecto.Edificio.Indicador.Esbeltez_Int = Tabla_PesoICE.Rows(6).Cells(2).Value
                Form1.Proyecto.Edificio.Indicador.Confinamiento_Int = Tabla_PesoICE.Rows(7).Cells(2).Value

                Form1.Proyecto.Edificio.Indicador.Densidad_Min = Tabla_PesoICE.Rows(0).Cells(3).Value
                Form1.Proyecto.Edificio.Indicador.Num_Pisos_Min = Tabla_PesoICE.Rows(1).Cells(3).Value
                Form1.Proyecto.Edificio.Indicador.Factor_Forma_Min = Tabla_PesoICE.Rows(2).Cells(3).Value
                Form1.Proyecto.Edificio.Indicador.Ar_Min = Tabla_PesoICE.Rows(3).Cells(3).Value
                Form1.Proyecto.Edificio.Indicador.ALR_Min = Tabla_PesoICE.Rows(4).Cells(3).Value
                Form1.Proyecto.Edificio.Indicador.Amenaza_Min = Tabla_PesoICE.Rows(5).Cells(3).Value
                Form1.Proyecto.Edificio.Indicador.Esbeltez_Min = Tabla_PesoICE.Rows(6).Cells(3).Value
                Form1.Proyecto.Edificio.Indicador.Confinamiento_Min = Tabla_PesoICE.Rows(7).Cells(3).Value

            Catch ex As Exception
            Finally
                Form1.Proyecto.Edificio.Indicador.T_Mod = "Si"
                Form1.Proyecto.Edificio.Porcentaje_FSMuros = Convert.ToSingle(T_PFS.Text)
                Me.WindowState = FormWindowState.Minimized
            End Try
        End If
    End Sub

    Public Sub AyudaGlobo(ByVal Globo As ToolTip, ByVal Boton As PictureBox, ByVal Mensaje As String)
        Globo.RemoveAll()
        Globo.SetToolTip(Boton, Mensaje)
        Globo.InitialDelay = 100
        Globo.IsBalloon = False
    End Sub

    Private Sub T_PFS_MouseEnter(sender As Object, e As EventArgs) Handles T_PFS.MouseEnter
        AyudaGlobo(Tool_Ayuda, P_Info, "Corresponde al Porcentaje de Fuerza Sísmica que Toman los Muros Principales del Proyecto" + Environment.NewLine + "Debe estar entre 50% y 100%")
    End Sub
End Class