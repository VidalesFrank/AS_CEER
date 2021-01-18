Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form_07_EspectroNSR
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim OpCiudad As String = C_Ciudades.Text
        Dim TSuelo As String = C_Suelo.Text
        Dim Aa As Double
        Dim Av As Double
        Dim Fa As Double
        Dim Fv As Double
        Dim I As Double
        Dim Sa As Double

        Dim MatrizAmenaza(32, 3)
        MatrizAmenaza(1, 1) = "Arauca"
        MatrizAmenaza(1, 2) = 0.15
        MatrizAmenaza(1, 3) = 0.15
        MatrizAmenaza(2, 1) = "Armenia"
        MatrizAmenaza(2, 2) = 0.25
        MatrizAmenaza(2, 3) = 0.25
        MatrizAmenaza(3, 1) = "Barranquilla"
        MatrizAmenaza(3, 2) = 0.1
        MatrizAmenaza(3, 3) = 0.1
        MatrizAmenaza(4, 1) = "Bogotá"
        MatrizAmenaza(4, 2) = 0.15
        MatrizAmenaza(4, 3) = 0.2
        MatrizAmenaza(5, 1) = "Bucaramanga"
        MatrizAmenaza(5, 2) = 0.25
        MatrizAmenaza(5, 3) = 0.25
        MatrizAmenaza(6, 1) = "Cali"
        MatrizAmenaza(6, 2) = 0.25
        MatrizAmenaza(6, 3) = 0.25
        MatrizAmenaza(7, 1) = "Cartagena"
        MatrizAmenaza(7, 2) = 0.1
        MatrizAmenaza(7, 3) = 0.1
        MatrizAmenaza(8, 1) = "Cucuta"
        MatrizAmenaza(8, 2) = 0.35
        MatrizAmenaza(8, 3) = 0.3
        MatrizAmenaza(9, 1) = "Florencia"
        MatrizAmenaza(9, 2) = 0.2
        MatrizAmenaza(9, 3) = 0.15
        MatrizAmenaza(10, 1) = "Ibague"
        MatrizAmenaza(10, 2) = 0.2
        MatrizAmenaza(10, 3) = 0.2
        MatrizAmenaza(11, 1) = "Leticia"
        MatrizAmenaza(11, 2) = 0.05
        MatrizAmenaza(11, 3) = 0.05
        MatrizAmenaza(12, 1) = "Manizales"
        MatrizAmenaza(12, 2) = 0.25
        MatrizAmenaza(12, 3) = 0.25
        MatrizAmenaza(13, 1) = "Medellín"
        MatrizAmenaza(13, 2) = 0.15
        MatrizAmenaza(13, 3) = 0.2
        MatrizAmenaza(14, 1) = "Mitú"
        MatrizAmenaza(14, 2) = 0.05
        MatrizAmenaza(14, 3) = 0.05
        MatrizAmenaza(15, 1) = "Mocoa"
        MatrizAmenaza(15, 2) = 0.3
        MatrizAmenaza(15, 3) = 0.25
        MatrizAmenaza(16, 1) = "Monteria"
        MatrizAmenaza(16, 2) = 0.1
        MatrizAmenaza(16, 3) = 0.15
        MatrizAmenaza(17, 1) = "Neiva"
        MatrizAmenaza(17, 2) = 0.25
        MatrizAmenaza(17, 3) = 0.25
        MatrizAmenaza(18, 1) = "Pasto"
        MatrizAmenaza(18, 2) = 0.25
        MatrizAmenaza(18, 3) = 0.25
        MatrizAmenaza(19, 1) = "Pereira"
        MatrizAmenaza(19, 2) = 0.25
        MatrizAmenaza(19, 3) = 0.25
        MatrizAmenaza(20, 1) = "Popayan"
        MatrizAmenaza(20, 2) = 0.25
        MatrizAmenaza(20, 3) = 0.2
        MatrizAmenaza(21, 1) = "Puerto Carreño"
        MatrizAmenaza(21, 2) = 0.05
        MatrizAmenaza(21, 3) = 0.05
        MatrizAmenaza(22, 1) = "Puerto Inirida"
        MatrizAmenaza(22, 2) = 0.05
        MatrizAmenaza(22, 3) = 0.05
        MatrizAmenaza(23, 1) = "Quibdo"
        MatrizAmenaza(23, 2) = 0.35
        MatrizAmenaza(23, 3) = 0.35
        MatrizAmenaza(24, 1) = "Rioacha"
        MatrizAmenaza(24, 2) = 0.1
        MatrizAmenaza(24, 3) = 0.15
        MatrizAmenaza(25, 1) = "San Andrés"
        MatrizAmenaza(25, 2) = 0.1
        MatrizAmenaza(25, 3) = 0.1
        MatrizAmenaza(26, 1) = "Santa Marta"
        MatrizAmenaza(26, 2) = 0.15
        MatrizAmenaza(26, 3) = 0.1
        MatrizAmenaza(27, 1) = "San Jose del Guaviare"
        MatrizAmenaza(27, 2) = 0.05
        MatrizAmenaza(27, 3) = 0.05
        MatrizAmenaza(28, 1) = "Sincelejo"
        MatrizAmenaza(28, 2) = 0.1
        MatrizAmenaza(28, 3) = 0.15
        MatrizAmenaza(29, 1) = "Tunja"
        MatrizAmenaza(29, 2) = 0.2
        MatrizAmenaza(29, 3) = 0.2
        MatrizAmenaza(30, 1) = "Valledupar"
        MatrizAmenaza(30, 2) = 0.1
        MatrizAmenaza(30, 3) = 0.1
        MatrizAmenaza(31, 1) = "Villavicencio"
        MatrizAmenaza(31, 2) = 0.35
        MatrizAmenaza(31, 3) = 0.3
        MatrizAmenaza(32, 1) = "Yopal"
        MatrizAmenaza(32, 2) = 0.3
        MatrizAmenaza(32, 3) = 0.2

        For j = 1 To 32
            If OpCiudad = MatrizAmenaza(j, 1) Then
                Aa = MatrizAmenaza(j, 2)
                Av = MatrizAmenaza(j, 3)
            End If
        Next

        If TSuelo = "A" Then
            Fa = 0.8
        ElseIf TSuelo = "B" Then
            Fa = 1
        ElseIf TSuelo = "C" Then
            If Aa <= 0.2 Then
                Fa = 1.2
            ElseIf Aa > 0.2 And Aa <= 0.4 Then
                Fa = 1.2 - (Aa - 0.2)
            ElseIf Aa > 0.4 Then
                Fa = 1
            End If
        ElseIf TSuelo = "D" Then
            If Aa <= 0.1 Then
                Fa = 1.6
            ElseIf Aa > 0.1 And Aa <= 0.3 Then
                Fa = 1.6 - 2 * (Aa - 0.1)
            ElseIf Aa > 0.3 Then
                Fa = 1.2 - (Aa - 0.3)
            End If
        ElseIf TSuelo = "E" Then
            If Aa <= 0.1 Then
                Fa = 2.5
            ElseIf Aa > 0.1 And Aa <= 0.2 Then
                Fa = 2.5 - 8 * (Aa - 0.1)
            ElseIf Aa > 0.2 And Aa <= 0.3 Then
                Fa = 1.7 - 5 * (Aa - 0.2)
            ElseIf Aa > 0.3 And Aa <= 0.4 Then
                Fa = 1.2 - 3 * (Aa - 0.3)
            ElseIf Aa > 0.4 Then
                Fa = 0.9
            End If
        End If

        If TSuelo = "A" Then
            Fv = 0.8
        ElseIf TSuelo = "B" Then
            Fv = 1
        ElseIf TSuelo = "C" Then
            If Av <= 0.1 Then
                Fv = 1.7
            ElseIf Av > 0.1 Then
                Fv = 1.7 - (Av - 0.1)
            End If
        ElseIf TSuelo = "D" Then
            If Av <= 0.1 Then
                Fv = 2.4
            ElseIf Av > 0.1 And Av <= 0.2 Then
                Fv = 2.4 - 4 * (Av - 0.1)
            ElseIf Av > 0.2 And Av <= 0.4 Then
                Fv = 2 - 2 * (Av - 0.2)
            ElseIf Av > 0.4 Then
                Fv = 1.6 - (Av - 0.4)
            End If
        ElseIf TSuelo = "E" Then
            If Av <= 0.1 Then
                Fv = 3.5
            ElseIf Av > 0.1 And Av <= 0.2 Then
                Fv = 3.5 - 3 * (Av - 0.1)
            ElseIf Av > 0.2 And Av <= 0.4 Then
                Fv = 3.2 - 4 * (Av - 0.2)
            ElseIf Av > 0.4 Then
                Fv = 2.4
            End If
        End If
        If C_Importancia.Text = "I" Then
            I = 1
        ElseIf C_Importancia.Text = "II" Then
            I = 1.1
        ElseIf C_Importancia.Text = "III" Then
            I = 1.25
        ElseIf C_Importancia.Text = "IV" Then
            I = 1.5
        End If

        Tabla_Resumen.Rows.Clear()
        Tabla_Resumen.Rows.Add()
        Tabla_Resumen.Rows.Add()
        Tabla_Resumen.Rows.Add()
        Tabla_Resumen.Rows.Add()
        Tabla_Resumen.Rows(0).Cells(0).Value = "Aa"
        Tabla_Resumen.Rows(1).Cells(0).Value = "Av"
        Tabla_Resumen.Rows(2).Cells(0).Value = "Fa"
        Tabla_Resumen.Rows(3).Cells(0).Value = "Fv"
        Tabla_Resumen.Rows(4).Cells(0).Value = "I"
        Tabla_Resumen.Rows(0).Cells(1).Value = Aa
        Tabla_Resumen.Rows(1).Cells(1).Value = Av
        Tabla_Resumen.Rows(2).Cells(1).Value = Fa
        Tabla_Resumen.Rows(3).Cells(1).Value = Fv
        Tabla_Resumen.Rows(4).Cells(1).Value = I

        Dim T0 As Single = 0.1 * Av * Fv / (Aa * Fa)
        Dim Tc As Double = 0.48 * Av * Fv / (Aa * Fa)
        Dim TL As Double = 2.4 * Fv
        Sa = 2.5 * Aa * Fa * I
        Dim TablaSa(200, 2)
        Dim TablaSd(200, 2)
        Dim k = 2
        TablaSa(1, 1) = 0
        TablaSa(1, 2) = Sa
        TablaSd(1, 1) = 0
        TablaSd(1, 2) = 0

        '(TL + 1) Step (Tc / 8)
        For j = 0 To 5 Step 0.026

            If j <= Tc Then
                TablaSa(k, 1) = j
                TablaSa(k, 2) = Sa

                TablaSd(k, 1) = j
                TablaSd(k, 2) = 0.62 * Aa * Fa * I * j ^ 2

                k += 1
            ElseIf j > Tc And j <= TL Then
                TablaSa(k, 1) = j
                TablaSa(k, 2) = 1.2 * Av * Fv * I / (j)

                TablaSd(k, 1) = j
                TablaSd(k, 2) = 0.3 * Av * Fv * I * j

                k += 1
            ElseIf j > TL Then
                TablaSa(k, 1) = j
                TablaSa(k, 2) = 1.2 * Av * Fv * I * TL / (j * j)

                TablaSd(k, 1) = j
                TablaSd(k, 2) = 0.3 * Av * Fv * I * TL

                k += 1
            End If
        Next

        Espectro.Series.Clear()
        Dim Serie_Sa As New Series
        Dim Serie_Sd As New Series
        Dim Demandas As New Series
        Espectro.Series.Add(Serie_Sa)
        Espectro.Series.Add(Serie_Sd)
        Espectro.ChartAreas(0).BackColor = Color.White
        Espectro.ChartAreas(0).AxisY.Maximum = Math.Round(Sa * 1.1 + 0.05, 1)
        Serie_Sa.BorderWidth = 2
        Serie_Sa.ChartType = SeriesChartType.Spline

        Serie_Sd.BorderWidth = 2
        Serie_Sd.ChartType = SeriesChartType.Spline

        For j = 1 To k
            If TablaSa(j, 2) <> 0 Then
                Serie_Sa.Points.AddXY(TablaSa(j, 1), TablaSa(j, 2))
            End If
            If TablaSd(j, 2) <> 0 Then
                Serie_Sd.Points.AddXY(TablaSd(j, 1), TablaSd(j, 2))
                Console.WriteLine(TablaSd(j, 1) & " , " & TablaSd(j, 2))

            End If
        Next

    End Sub

End Class