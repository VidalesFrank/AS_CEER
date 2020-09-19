Imports excel = Microsoft.Office.Interop.Excel

Public Class Form1
    Public Shared Proyecto As New Proyecto
    Function ALR(ByVal Va As Double, ByVal Num_Pisos As Integer, ByVal Area_P As Double)
        Dim P As New excel.Application
        If Num_Pisos < 12 Then
            If Area_P <= 600 Then
                ALR = P.WorksheetFunction.NormInv(Va, 4.5, 1.9)
            Else
                ALR = P.WorksheetFunction.NormInv(Va, 1.42, 0.32)
            End If
        Else
            ALR = P.WorksheetFunction.NormInv(Va, 8.3, 3.1)
        End If
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Forma_Muro.Refresh()
        AddHandler Forma_Muro.Paint, AddressOf Me.PictureBox_Paint
        Tabla_Datos.ColumnHeadersDefaultCellStyle.Font = New Font(Tabla_Datos.Font, FontStyle.Bold)
        Tabla_Resultados.ColumnHeadersDefaultCellStyle.Font = New Font(Tabla_Resultados.Font, FontStyle.Bold)
    End Sub
    Private Sub Tipo_Muro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tipo_Muro.SelectedIndexChanged
        Try
            Forma_Muro.Refresh()
            AddHandler Forma_Muro.Paint, AddressOf Me.PictureBox_Paint
            If Tipo_Muro.Text <> "Muro Rectangular" Then
                T_Lw2.ReadOnly = False
                T_tw2.ReadOnly = False
            Else
                T_Lw2.ReadOnly = True
                T_tw2.ReadOnly = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub PictureBox_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim CenX As Single = Convert.ToInt16(Math.Round(Forma_Muro.Width() / 2, 0))
        Dim CenY As Single = Convert.ToInt16(Math.Round(Forma_Muro.Height() / 2, 0))
        Dim Esc As Single = Math.Min(Forma_Muro.Height(), Forma_Muro.Width()) - 60
        Dim PenB As New Pen(Color.Black)
        Dim PenG As New Pen(Color.FromArgb(121, 121, 121))
        Dim FillR As New SolidBrush(Color.FromArgb(210, 210, 210))
        Dim Letra As New Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim CorB As New SolidBrush(Color.Black)
        Dim CorA As New SolidBrush(Color.FromArgb(0, 0, 255))
        Dim CorR As New SolidBrush(Color.Red)
        Dim PenR As New Pen(Color.Red)
        Dim PenA As New Pen(Color.FromArgb(0, 0, 255))
        Dim LetraE As New Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel)

        If Tipo_Muro.Text = "Muro Rectangular" Then
            g.FillRectangle(FillR, Convert.ToSingle(CenX - 0.1 * Esc), Convert.ToSingle(CenY - 0.48 * Esc), Convert.ToSingle(0.2 * Esc), Convert.ToSingle(0.96 * Esc))
            g.DrawRectangle(PenB, Convert.ToSingle(CenX - 0.1 * Esc), Convert.ToSingle(CenY - 0.48 * Esc), Convert.ToSingle(0.2 * Esc), Convert.ToSingle(0.96 * Esc))

            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.2 * Esc), Convert.ToSingle(CenY - 0.48 * Esc), Convert.ToSingle(CenX - 0.28 * Esc), Convert.ToSingle(CenY - 0.48 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.2 * Esc), Convert.ToSingle(CenY + 0.48 * Esc), Convert.ToSingle(CenX - 0.28 * Esc), Convert.ToSingle(CenY + 0.48 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.24 * Esc), Convert.ToSingle(CenY - 0.48 * Esc), Convert.ToSingle(CenX - 0.24 * Esc), Convert.ToSingle(CenY - 0.04 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.24 * Esc), Convert.ToSingle(CenY + 0.03 * Esc), Convert.ToSingle(CenX - 0.24 * Esc), Convert.ToSingle(CenY + 0.48 * Esc))
            g.DrawString("Lw", Letra, CorB, New PointF(CenX - 0.27 * Esc, Convert.ToSingle(CenY - 0.03 * Esc)))

            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.1 * Esc), Convert.ToSingle(CenY - 0.525 * Esc), Convert.ToSingle(CenX + 0.1 * Esc), Convert.ToSingle(CenY - 0.525 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.1 * Esc), Convert.ToSingle(CenY - 0.5 * Esc), Convert.ToSingle(CenX - 0.1 * Esc), Convert.ToSingle(CenY - 0.55 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.1 * Esc), Convert.ToSingle(CenY - 0.5 * Esc), Convert.ToSingle(CenX + 0.1 * Esc), Convert.ToSingle(CenY - 0.55 * Esc))
            g.DrawString("tw", Letra, CorB, New PointF(CenX - 0.03 * Esc, CenY - 0.57 * Esc))

        ElseIf Tipo_Muro.Text = "Muro en T" Then
            Dim Punto1 As New PointF(CenX - Esc / 2, CenY - 0.47 * Esc)
            Dim Punto2 As New PointF(CenX + Esc / 2, CenY - 0.47 * Esc)
            Dim Punto3 As New PointF(CenX + Esc / 2, CenY - 0.35 * Esc)
            Dim Punto4 As New PointF(CenX + 0.1 * Esc, CenY - 0.35 * Esc)
            Dim Punto5 As New PointF(CenX + 0.1 * Esc, CenY + 0.47 * Esc)
            Dim Punto6 As New PointF(CenX - 0.1 * Esc, CenY + 0.47 * Esc)
            Dim Punto7 As New PointF(CenX - 0.1 * Esc, CenY - 0.35 * Esc)
            Dim Punto8 As New PointF(CenX - Esc / 2, CenY - 0.35 * Esc)

            Dim Muro As PointF() = {Punto1, Punto2, Punto3, Punto4, Punto5, Punto6, Punto7, Punto8}

            g.FillPolygon(FillR, Muro)
            g.DrawPolygon(PenB, Muro)

            g.DrawLine(PenB, Convert.ToSingle(CenX - Esc / 2), Convert.ToSingle(CenY - 0.49 * Esc), Convert.ToSingle(CenX - Esc / 2), Convert.ToSingle(CenY - 0.55 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + Esc / 2), Convert.ToSingle(CenY - 0.49 * Esc), Convert.ToSingle(CenX + Esc / 2), Convert.ToSingle(CenY - 0.55 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - Esc / 2), Convert.ToSingle(CenY - 0.52 * Esc), Convert.ToSingle(CenX + Esc / 2), Convert.ToSingle(CenY - 0.52 * Esc))
            g.DrawString("Lw2", Letra, CorB, New PointF(CenX - 0.03 * Esc, CenY - 0.57 * Esc))

            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.55 * Esc), Convert.ToSingle(CenY - 0.47 * Esc), Convert.ToSingle(CenX - 0.55 * Esc), Convert.ToSingle(CenY - 0.05 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.55 * Esc), Convert.ToSingle(CenY + 0.03 * Esc), Convert.ToSingle(CenX - 0.55 * Esc), Convert.ToSingle(CenY + 0.47 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.52 * Esc), Convert.ToSingle(CenY - 0.47 * Esc), Convert.ToSingle(CenX - 0.58 * Esc), Convert.ToSingle(CenY - 0.47 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.52 * Esc), Convert.ToSingle(CenY + 0.47 * Esc), Convert.ToSingle(CenX - 0.58 * Esc), Convert.ToSingle(CenY + 0.47 * Esc))
            g.DrawString("Lw", Letra, CorB, New PointF(CenX - 0.58 * Esc, CenY - 0.04 * Esc))

            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.55 * Esc), Convert.ToSingle(CenY - 0.47 * Esc), Convert.ToSingle(CenX + 0.55 * Esc), Convert.ToSingle(CenY - 0.43 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.55 * Esc), Convert.ToSingle(CenY - 0.38 * Esc), Convert.ToSingle(CenX + 0.55 * Esc), Convert.ToSingle(CenY - 0.35 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.52 * Esc), Convert.ToSingle(CenY - 0.47 * Esc), Convert.ToSingle(CenX + 0.58 * Esc), Convert.ToSingle(CenY - 0.47 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.52 * Esc), Convert.ToSingle(CenY - 0.35 * Esc), Convert.ToSingle(CenX + 0.58 * Esc), Convert.ToSingle(CenY - 0.35 * Esc))
            g.DrawString("tw2", Letra, CorB, New PointF(CenX + 0.52 * Esc, CenY - 0.43 * Esc))

            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.1 * Esc), Convert.ToSingle(CenY + 0.535 * Esc), Convert.ToSingle(CenX + 0.1 * Esc), Convert.ToSingle(CenY + 0.535 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.1 * Esc), Convert.ToSingle(CenY + 0.5 * Esc), Convert.ToSingle(CenX - 0.1 * Esc), Convert.ToSingle(CenY + 0.56 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.1 * Esc), Convert.ToSingle(CenY + 0.5 * Esc), Convert.ToSingle(CenX + 0.1 * Esc), Convert.ToSingle(CenY + 0.56 * Esc))
            g.DrawString("tw", Letra, CorB, New PointF(CenX - 0.03 * Esc, CenY + 0.485 * Esc))

        ElseIf Tipo_Muro.Text = "Muro en L" Then
            Dim Punto1 As New PointF(CenX - 0.47 * Esc, CenY - 0.47 * Esc)
            Dim Punto2 As New PointF(CenX - 0.27 * Esc, CenY - 0.47 * Esc)
            Dim Punto3 As New PointF(CenX - 0.27 * Esc, CenY + 0.29 * Esc)
            Dim Punto4 As New PointF(CenX + 0.25 * Esc, CenY + 0.29 * Esc)
            Dim Punto5 As New PointF(CenX + 0.25 * Esc, CenY + 0.47 * Esc)
            Dim Punto6 As New PointF(CenX - 0.47 * Esc, CenY + 0.47 * Esc)

            Dim Muro As PointF() = {Punto1, Punto2, Punto3, Punto4, Punto5, Punto6}

            g.FillPolygon(FillR, Muro)
            g.DrawPolygon(PenB, Muro)

            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.47 * Esc), Convert.ToSingle(CenY - 0.5 * Esc), Convert.ToSingle(CenX - 0.27 * Esc), Convert.ToSingle(CenY - 0.5 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.47 * Esc), Convert.ToSingle(CenY - 0.48 * Esc), Convert.ToSingle(CenX - 0.47 * Esc), Convert.ToSingle(CenY - 0.52 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.27 * Esc), Convert.ToSingle(CenY - 0.48 * Esc), Convert.ToSingle(CenX - 0.27 * Esc), Convert.ToSingle(CenY - 0.52 * Esc))
            g.DrawString("tw", Letra, CorB, New PointF(CenX - 0.39 * Esc, CenY - 0.55 * Esc))

            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.52 * Esc), Convert.ToSingle(CenY - 0.47 * Esc), Convert.ToSingle(CenX - 0.52 * Esc), Convert.ToSingle(CenY - 0.05 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.52 * Esc), Convert.ToSingle(CenY + 0.03 * Esc), Convert.ToSingle(CenX - 0.52 * Esc), Convert.ToSingle(CenY + 0.47 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.55 * Esc), Convert.ToSingle(CenY - 0.47 * Esc), Convert.ToSingle(CenX - 0.49 * Esc), Convert.ToSingle(CenY - 0.47 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.55 * Esc), Convert.ToSingle(CenY + 0.47 * Esc), Convert.ToSingle(CenX - 0.49 * Esc), Convert.ToSingle(CenY + 0.47 * Esc))
            g.DrawString("Lw", Letra, CorB, New PointF(CenX - 0.56 * Esc, CenY - 0.04 * Esc))

            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.47 * Esc), Convert.ToSingle(CenY + 0.53 * Esc), Convert.ToSingle(CenX + 0.25 * Esc), Convert.ToSingle(CenY + 0.53 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.47 * Esc), Convert.ToSingle(CenY + 0.5 * Esc), Convert.ToSingle(CenX - 0.47 * Esc), Convert.ToSingle(CenY + 0.56 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.25 * Esc), Convert.ToSingle(CenY + 0.5 * Esc), Convert.ToSingle(CenX + 0.25 * Esc), Convert.ToSingle(CenY + 0.56 * Esc))
            g.DrawString("Lw2", Letra, CorB, New PointF(CenX - 0.16 * Esc, CenY + 0.49 * Esc))

            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.28 * Esc), Convert.ToSingle(CenY + 0.47 * Esc), Convert.ToSingle(CenX + 0.36 * Esc), Convert.ToSingle(CenY + 0.47 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.28 * Esc), Convert.ToSingle(CenY + 0.29 * Esc), Convert.ToSingle(CenX + 0.36 * Esc), Convert.ToSingle(CenY + 0.29 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.32 * Esc), Convert.ToSingle(CenY + 0.29 * Esc), Convert.ToSingle(CenX + 0.32 * Esc), Convert.ToSingle(CenY + 0.35 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.32 * Esc), Convert.ToSingle(CenY + 0.41 * Esc), Convert.ToSingle(CenX + 0.32 * Esc), Convert.ToSingle(CenY + 0.47 * Esc))
            g.DrawString("tw2", Letra, CorB, New PointF(CenX + 0.29 * Esc, CenY + 0.35 * Esc))

        ElseIf Tipo_Muro.Text = "Muro en C" Then
            Dim Punto1 As New PointF(CenX - 0.4 * Esc, CenY - 0.4 * Esc)
            Dim Punto2 As New PointF(CenX - 0.25 * Esc, CenY - 0.4 * Esc)
            Dim Punto3 As New PointF(CenX - 0.25 * Esc, CenY + 0.25 * Esc)
            Dim Punto4 As New PointF(CenX + 0.25 * Esc, CenY + 0.25 * Esc)
            Dim Punto5 As New PointF(CenX + 0.25 * Esc, CenY - 0.4 * Esc)
            Dim Punto6 As New PointF(CenX + 0.4 * Esc, CenY - 0.4 * Esc)
            Dim Punto7 As New PointF(CenX + 0.4 * Esc, CenY + 0.4 * Esc)
            Dim Punto8 As New PointF(CenX - 0.4 * Esc, CenY + 0.4 * Esc)

            Dim Muro As PointF() = {Punto1, Punto2, Punto3, Punto4, Punto5, Punto6, Punto7, Punto8}

            g.FillPolygon(FillR, Muro)
            g.DrawPolygon(PenB, Muro)

            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.455 * Esc), Convert.ToSingle(CenY - 0.4 * Esc), Convert.ToSingle(CenX - 0.455 * Esc), Convert.ToSingle(CenY - 0.05 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.455 * Esc), Convert.ToSingle(CenY + 0.03 * Esc), Convert.ToSingle(CenX - 0.455 * Esc), Convert.ToSingle(CenY + 0.4 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.48 * Esc), Convert.ToSingle(CenY - 0.4 * Esc), Convert.ToSingle(CenX - 0.43 * Esc), Convert.ToSingle(CenY - 0.4 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.48 * Esc), Convert.ToSingle(CenY + 0.4 * Esc), Convert.ToSingle(CenX - 0.43 * Esc), Convert.ToSingle(CenY + 0.4 * Esc))
            g.DrawString("Lw", Letra, CorB, New PointF(CenX - 0.485 * Esc, CenY - 0.04 * Esc))

            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.4 * Esc), Convert.ToSingle(CenY + 0.48 * Esc), Convert.ToSingle(CenX + 0.4 * Esc), Convert.ToSingle(CenY + 0.48 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.4 * Esc), Convert.ToSingle(CenY + 0.45 * Esc), Convert.ToSingle(CenX - 0.4 * Esc), Convert.ToSingle(CenY + 0.51 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.4 * Esc), Convert.ToSingle(CenY + 0.45 * Esc), Convert.ToSingle(CenX + 0.4 * Esc), Convert.ToSingle(CenY + 0.51 * Esc))
            g.DrawString("Lw2", Letra, CorB, New PointF(CenX - 0.04 * Esc, CenY + 0.43 * Esc))

            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.45 * Esc), Convert.ToSingle(CenY + 0.25 * Esc), Convert.ToSingle(CenX + 0.5 * Esc), Convert.ToSingle(CenY + 0.25 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.45 * Esc), Convert.ToSingle(CenY + 0.4 * Esc), Convert.ToSingle(CenX + 0.5 * Esc), Convert.ToSingle(CenY + 0.4 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.475 * Esc), Convert.ToSingle(CenY + 0.25 * Esc), Convert.ToSingle(CenX + 0.475 * Esc), Convert.ToSingle(CenY + 0.3 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.475 * Esc), Convert.ToSingle(CenY + 0.36 * Esc), Convert.ToSingle(CenX + 0.475 * Esc), Convert.ToSingle(CenY + 0.4 * Esc))
            g.DrawString("tw2", Letra, CorB, New PointF(CenX + 0.445 * Esc, CenY + 0.305 * Esc))

            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.4 * Esc), Convert.ToSingle(CenY - 0.44 * Esc), Convert.ToSingle(CenX - 0.25 * Esc), Convert.ToSingle(CenY - 0.44 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.4 * Esc), Convert.ToSingle(CenY - 0.42 * Esc), Convert.ToSingle(CenX - 0.4 * Esc), Convert.ToSingle(CenY - 0.46 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX - 0.25 * Esc), Convert.ToSingle(CenY - 0.42 * Esc), Convert.ToSingle(CenX - 0.25 * Esc), Convert.ToSingle(CenY - 0.46 * Esc))
            g.DrawString("tw", Letra, CorB, New PointF(CenX - 0.35 * Esc, CenY - 0.49 * Esc))

            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.4 * Esc), Convert.ToSingle(CenY - 0.44 * Esc), Convert.ToSingle(CenX + 0.25 * Esc), Convert.ToSingle(CenY - 0.44 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.4 * Esc), Convert.ToSingle(CenY - 0.42 * Esc), Convert.ToSingle(CenX + 0.4 * Esc), Convert.ToSingle(CenY - 0.46 * Esc))
            g.DrawLine(PenB, Convert.ToSingle(CenX + 0.25 * Esc), Convert.ToSingle(CenY - 0.42 * Esc), Convert.ToSingle(CenX + 0.25 * Esc), Convert.ToSingle(CenY - 0.46 * Esc))
            g.DrawString("tw", Letra, CorB, New PointF(CenX + 0.3 * Esc, CenY - 0.49 * Esc))
        End If

        g.DrawString("1", LetraE, CorR, New PointF(CenX - 0.015 * Esc, CenY - 0.15 * Esc))
        g.DrawLine(PenR, CenX, CenY, CenX, Convert.ToSingle(CenY - 0.1 * Esc))
        g.DrawLine(PenR, Convert.ToSingle(CenX - 0.02 * Esc), Convert.ToSingle(CenY - 0.08 * Esc), CenX, Convert.ToSingle(CenY - 0.1 * Esc))
        g.DrawLine(PenR, Convert.ToSingle(CenX + 0.02 * Esc), Convert.ToSingle(CenY - 0.08 * Esc), CenX, Convert.ToSingle(CenY - 0.1 * Esc))

        g.DrawString("3", LetraE, CorA, New PointF(CenX + 0.11 * Esc, CenY - 0.025 * Esc))
        g.DrawLine(PenA, CenX, CenY, Convert.ToSingle(CenX + 0.1 * Esc), CenY)
        g.DrawLine(PenA, Convert.ToSingle(CenX + 0.08 * Esc), Convert.ToSingle(CenY + 0.02 * Esc), Convert.ToSingle(CenX + 0.1 * Esc), CenY)
        g.DrawLine(PenA, Convert.ToSingle(CenX + 0.08 * Esc), Convert.ToSingle(CenY - 0.02 * Esc), Convert.ToSingle(CenX + 0.1 * Esc), CenY)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For k = 1 To Convert.ToInt32(T_Cantidad.Text)
            Dim Nombre As String = Convert.ToString(T_Name.Text)
            If Convert.ToInt32(T_Cantidad.Text) > 1 Then
                Nombre = Nombre & "_" & k
            End If

            Dim err As Integer = 0
            If Proyecto.Edificio.ListaMuros.Exists(Function(x) x.Name = T_Name.Text) = True Then
                Dim style = MsgBoxStyle.Critical
                MsgBox("Muro existente", style, "Elemento Duplicado")
                err = 1
            End If
            If err = 0 Then
                Tabla_Datos.Refresh()
                Tabla_Datos.Rows.Add()

                Dim Muro_ As New Muro

                '---------- Asignación de Propiedades ------------
                Muro_.Name = Nombre
                Muro_.T_Muro = Convert.ToString(Tipo_Muro.Text)
                Muro_.Lw = Convert.ToSingle(T_Lw.Text)
                Muro_.tw = Convert.ToSingle(T_tw.Text)
                Muro_.Direccion = Convert.ToString(Direccion.Text)
                If Muro_.T_Muro = "Muro Rectangular" Then
                    Muro_.Lw2 = 0
                    Muro_.tw2 = 0
                    T_Lw2.Text = 0
                    T_tw2.Text = 0
                Else
                    Muro_.Lw2 = Convert.ToSingle(T_Lw2.Text)
                    Muro_.tw2 = Convert.ToSingle(T_tw2.Text)
                End If
                If Muro_.T_Muro = "Muro en C" Then
                    If Muro_.Direccion = "X" Then
                        Muro_.Porcentaje_Vb = 2 * Muro_.Lw ^ 2 * Muro_.tw
                        Muro_.Porcentaje_Vb_Y = Muro_.Lw2 ^ 2 * Muro_.tw2
                        Muro_.AreaX = 2 * Muro_.Lw * Muro_.tw
                        Muro_.AreaY = Muro_.Lw2 * Muro_.tw2
                    Else
                        Muro_.Porcentaje_Vb = Muro_.Lw2 ^ 2 * Muro_.tw2
                        Muro_.Porcentaje_Vb_Y = 2 * Muro_.Lw ^ 2 * Muro_.tw
                        Muro_.AreaY = 2 * Muro_.Lw * Muro_.tw
                        Muro_.AreaX = Muro_.Lw2 * Muro_.tw2
                    End If
                Else
                    If Muro_.Direccion = "X" Then
                        Muro_.Porcentaje_Vb = Muro_.Lw ^ 2 * Muro_.tw
                        Muro_.Porcentaje_Vb_Y = Muro_.Lw2 ^ 2 * Muro_.tw2
                        Muro_.AreaX = Muro_.Lw * Muro_.tw
                        Muro_.AreaY = Muro_.Lw2 * Muro_.tw2
                    Else
                        Muro_.Porcentaje_Vb = Muro_.Lw2 ^ 2 * Muro_.tw2
                        Muro_.Porcentaje_Vb_Y = Muro_.Lw ^ 2 * Muro_.tw
                        Muro_.AreaY = Muro_.Lw * Muro_.tw
                        Muro_.AreaX = Muro_.Lw2 * Muro_.tw2
                    End If
                End If
                Muro_.Confinamiento = C_Confinamiento.Text

                Proyecto.Edificio.AreaM_X += Muro_.AreaX
                Proyecto.Edificio.AreaM_Y += Muro_.AreaY

                Dim Col_Lw2 As Integer = 5
                Dim Col_tw2 As Integer = 6
                Dim Col_Sx As Integer = 5
                Dim Col_Sy As Integer = 6

                Dim ContX As Single = 0
                Dim ContY As Single = 0

                Proyecto.Edificio.ListaMuros.Add(Muro_)

                If Proyecto.Edificio.ListaMuros.Exists(Function(x) x.T_Muro = "Muro en T") Or Proyecto.Edificio.ListaMuros.Exists(Function(x) x.T_Muro = "Muro en L") Or Proyecto.Edificio.ListaMuros.Exists(Function(x) x.T_Muro = "Muro en C") Then
                    If Tabla_Datos.Columns.Count = 7 Then
                        Tabla_Datos.Columns.Add("Columns7", "Longitud (Lw2)")
                        Tabla_Datos.Columns.Add("Columns8", "Espesor (tw2)")
                        Tabla_Datos.Columns(5).HeaderText = "Longitud (Lw2)"
                        Tabla_Datos.Columns(6).HeaderText = "Espesor (tw2)"
                        Tabla_Datos.Columns(7).HeaderText = "Sismo X (%)"
                        Tabla_Datos.Columns(8).HeaderText = "Sismo Y (%)"
                    End If
                    Col_Sx = 7
                    Col_Sy = 8
                End If

                For j = 0 To Proyecto.Edificio.ListaMuros.Count - 1
                    ContX += Proyecto.Edificio.ListaMuros(j).Porcentaje_Vb
                    ContY += Proyecto.Edificio.ListaMuros(j).Porcentaje_Vb_Y
                Next
                Proyecto.Edificio.Vb_X = ContX
                Proyecto.Edificio.Vb_Y = ContY

                For i = 0 To Proyecto.Edificio.ListaMuros.Count - 1
                    If Proyecto.Edificio.Vb_X = 0 Then
                        Proyecto.Edificio.ListaMuros(i).SismoX = 0
                    Else
                        Proyecto.Edificio.ListaMuros(i).SismoX = Proyecto.Edificio.ListaMuros(i).Porcentaje_Vb / Proyecto.Edificio.Vb_X
                    End If

                    If Proyecto.Edificio.Vb_Y = 0 Then
                        Proyecto.Edificio.ListaMuros(i).SismoY = 0
                    Else
                        Proyecto.Edificio.ListaMuros(i).SismoY = Proyecto.Edificio.ListaMuros(i).Porcentaje_Vb_Y / Proyecto.Edificio.Vb_Y
                    End If

                    Tabla_Datos.Rows(i).Cells(0).Value = Proyecto.Edificio.ListaMuros(i).Name
                    Tabla_Datos.Rows(i).Cells(1).Value = Proyecto.Edificio.ListaMuros(i).T_Muro
                    Tabla_Datos.Rows(i).Cells(2).Value = Proyecto.Edificio.ListaMuros(i).Direccion
                    Tabla_Datos.Rows(i).Cells(3).Value = Proyecto.Edificio.ListaMuros(i).Lw
                    Tabla_Datos.Rows(i).Cells(4).Value = Proyecto.Edificio.ListaMuros(i).tw
                    Tabla_Datos.Rows(i).Cells(Col_Sx).Value = Math.Round(Proyecto.Edificio.ListaMuros(i).SismoX * 100, 2)
                    Tabla_Datos.Rows(i).Cells(Col_Sy).Value = Math.Round(Proyecto.Edificio.ListaMuros(i).SismoY * 100, 2)

                    If Col_Sx = 7 Then
                        If Proyecto.Edificio.ListaMuros(i).T_Muro <> "Muro Rectangular" Then
                            Tabla_Datos.Rows(i).Cells(5).Value = Proyecto.Edificio.ListaMuros(i).Lw2
                            Tabla_Datos.Rows(i).Cells(6).Value = Proyecto.Edificio.ListaMuros(i).tw2
                        Else
                            Tabla_Datos.Rows(i).Cells(5).Value = ""
                            Tabla_Datos.Rows(i).Cells(6).Value = ""
                        End If
                    End If
                Next
            End If
        Next
        '--------------------------- Asignar Calificaciones Bases --------------------------
        Proyecto.Edificio.Indicador.Densidad_Max = 15
        Proyecto.Edificio.Indicador.Num_Pisos_Max = 5
        Proyecto.Edificio.Indicador.Factor_Forma_Max = 5
        Proyecto.Edificio.Indicador.Ar_Max = 20
        Proyecto.Edificio.Indicador.ALR_Max = 20
        Proyecto.Edificio.Indicador.Amenaza_Max = 10
        Proyecto.Edificio.Indicador.Esbeltez_Max = 15
        Proyecto.Edificio.Indicador.Confinamiento_Max = 10

        Proyecto.Edificio.Indicador.Densidad_Int = 10
        Proyecto.Edificio.Indicador.Num_Pisos_Int = 2
        Proyecto.Edificio.Indicador.Factor_Forma_Int = 2
        Proyecto.Edificio.Indicador.Ar_Int = 10
        Proyecto.Edificio.Indicador.ALR_Int = 10
        Proyecto.Edificio.Indicador.Amenaza_Int = 5
        Proyecto.Edificio.Indicador.Esbeltez_Int = 10
        Proyecto.Edificio.Indicador.Confinamiento_Int = 5

        Proyecto.Edificio.Indicador.Densidad_Min = 5
        Proyecto.Edificio.Indicador.Num_Pisos_Min = 0
        Proyecto.Edificio.Indicador.Factor_Forma_Min = 0
        Proyecto.Edificio.Indicador.Ar_Min = 0
        Proyecto.Edificio.Indicador.ALR_Min = 5
        Proyecto.Edificio.Indicador.Amenaza_Min = 0
        Proyecto.Edificio.Indicador.Esbeltez_Min = 0
        Proyecto.Edificio.Indicador.Confinamiento_Min = 0

        Proyecto.Edificio.Porcentaje_FSMuros = Convert.ToSingle(Form5.T_PFS.Text)
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Try
        Dim style = MsgBoxStyle.Information
        Dim Err As Integer = 0

        If T_Area.Text = String.Empty And T_NP.Text = String.Empty Then
            MsgBox("Falta Ingresar el Número de Pisos y el Área de la Planta", style, "Faltan Datos")
            Err = 1
        ElseIf T_NP.Text = String.Empty Then
            MsgBox("Falta Ingresar el Número de Pisos", style, "Faltan Datos")
            Err = 1
        ElseIf T_Area.Text = String.Empty Then
            MsgBox("Falta Ingresar el Área", style, "Faltan Datos")
            Err = 1
        End If

        If Err = 0 Then
            Dim ALR_ = 0.2
            If Proyecto.Edificio.Op_Cargas <> "Ya" Then
                Dim Ale As New Random()
                Dim Va As Single = Ale.Next(0.0000001, 99.99999999) / 100
                ALR_ = ALR(Va, Convert.ToInt32(T_NP.Text), Convert.ToSingle(T_Area.Text))
            End If

            For i = 0 To Proyecto.Edificio.ListaMuros.Count - 1
                Form2.Tabla_Cargas.Rows.Add()
            Next
            For i = 0 To Proyecto.Edificio.ListaMuros.Count - 1
                Form2.Tabla_Cargas.Rows(i).Cells(0).Value = Proyecto.Edificio.ListaMuros(i).Name

                If Proyecto.Edificio.Op_Cargas = "Ya" Then
                    Form2.Tabla_Cargas.Rows(i).Cells(1).Value = Proyecto.Edificio.ListaMuros(i).CM
                    Form2.Tabla_Cargas.Rows(i).Cells(2).Value = Proyecto.Edificio.ListaMuros(i).CD
                Else
                    Form2.Tabla_Cargas.Rows(i).Cells(1).Value = Math.Round(0.9 * ALR_ * Convert.ToSingle(T_fc.Text) * (Proyecto.Edificio.ListaMuros(i).Lw * Proyecto.Edificio.ListaMuros(i).tw + Proyecto.Edificio.ListaMuros(i).Lw2 * Proyecto.Edificio.ListaMuros(i).tw2) * 1000, 0)
                    Form2.Tabla_Cargas.Rows(i).Cells(2).Value = Math.Round(ALR_ * Convert.ToSingle(T_fc.Text) * (Proyecto.Edificio.ListaMuros(i).Lw * Proyecto.Edificio.ListaMuros(i).tw + Proyecto.Edificio.ListaMuros(i).Lw2 * Proyecto.Edificio.ListaMuros(i).tw2) * 1000, 0)
                End If
            Next
            Form2.Show()
        End If
        'Catch ex As Exception
        'Finally
        '    
        'End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Tabla_Resultados.Rows.Clear()
        Proyecto.Edificio.ListaMuros_Protagonicos.Clear()

        Dim Col_Sx As Integer = 5
        If Tabla_Datos.Columns.Count = 7 Then
            Tabla_Datos.Sort(Tabla_Datos.Columns(5), System.Windows.Forms.SortOrder.Ascending)
        Else
            Tabla_Datos.Sort(Tabla_Datos.Columns(7), System.Windows.Forms.SortOrder.Ascending)
            Col_Sx = 7
        End If

        Dim Area_Est As Single = Convert.ToSingle(T_Area.Text)
        Proyecto.Edificio.Num_P = Convert.ToSingle(T_NP.Text)
        Proyecto.Edificio.Hn = Convert.ToSingle(T_Hn.Text)
        Proyecto.Edificio.Ht = Proyecto.Edificio.Hn * Proyecto.Edificio.Num_P
        Proyecto.Edificio.Area = Area_Est
        If Op_fc_Nominal.Checked = True Then
            Proyecto.Edificio.Op_fc = "Nominal"
        Else
            Proyecto.Edificio.Op_fc = "Medido"
        End If
        Proyecto.Edificio.fc = Convert.ToSingle(T_fc.Text)
        Dim ALR_ = 0.2
        If Proyecto.Edificio.Op_Cargas <> "Ya" Then
            Dim Ale As New Random()
            Dim Va As Single = Ale.Next(0.0000001, 99.99999999) / 100
            ALR_ = ALR(Va, Proyecto.Edificio.Num_P, Proyecto.Edificio.Area)
        End If
        Dim Max_ALR As Single = 0
        Dim Esbeltez_Total As Single = 0

        Dim Suma As Single = 0

        For i = 0 To Proyecto.Edificio.ListaMuros.Count - 1
            If Suma <= Proyecto.Edificio.Porcentaje_FSMuros / 100 Then
                Dim Muro_P As New Muro
                Muro_P.Name = Tabla_Datos.Rows(i).Cells(0).Value
                Muro_P.Lw = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).Lw
                Muro_P.tw = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).tw
                Muro_P.Lw2 = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).Lw2
                Muro_P.tw2 = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).tw2
                Muro_P.Direccion = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).Direccion
                Muro_P.T_Muro = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).T_Muro
                Muro_P.Porcentaje_Vb = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).Porcentaje_Vb
                Muro_P.Porcentaje_Vb_Y = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).Porcentaje_Vb_Y
                Muro_P.AreaX = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).AreaX
                Muro_P.AreaY = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).AreaY
                Muro_P.SismoX = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).SismoX
                Muro_P.SismoY = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).SismoY
                Muro_P.Esbeltez = Proyecto.Edificio.Hn / Math.Max(Muro_P.tw, Muro_P.tw2)
                Esbeltez_Total += Muro_P.Esbeltez

                If Muro_P.Direccion = "X" Then
                    Muro_P.AR_X = Proyecto.Edificio.Ht / Muro_P.Lw
                    If Muro_P.T_Muro = "Muro Rectangular" Then
                        Muro_P.AR_Y = 0
                    Else
                        Muro_P.AR_Y = Proyecto.Edificio.Ht / Muro_P.Lw2
                    End If
                Else
                    Muro_P.AR_Y = Proyecto.Edificio.Ht / Muro_P.Lw
                    If Muro_P.T_Muro = "Muro Rectangular" Then
                        Muro_P.AR_X = 0
                    Else
                        Muro_P.AR_X = Proyecto.Edificio.Ht / Muro_P.Lw2
                    End If
                End If

                If Math.Max(Muro_P.AR_X, Muro_P.AR_Y) <= 3 Then
                    Muro_P.Tipo_Muro = "Largo"
                ElseIf 3 < Math.Max(Muro_P.AR_X, Muro_P.AR_Y) And Math.Max(Muro_P.AR_X, Muro_P.AR_Y) <= 9 Then
                    Muro_P.Tipo_Muro = "Intermedio"
                ElseIf Math.Max(Muro_P.AR_X, Muro_P.AR_Y) > 9 Then
                    Muro_P.Tipo_Muro = "Corto"
                End If

                If Proyecto.Edificio.Op_Cargas = "Ya" Then
                    Muro_P.CM = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).CM
                    Muro_P.CD = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).CD

                    Muro_P.ALR_CM = Proyecto.Edificio.ListaMuros(i).CM / (Proyecto.Edificio.fc * 1000 * (Muro_P.Lw * Muro_P.tw + Muro_P.Lw2 * Muro_P.tw2))
                    Muro_P.ALR_CU = Proyecto.Edificio.ListaMuros(i).CD / (Proyecto.Edificio.fc * 1000 * (Muro_P.Lw * Muro_P.tw + Muro_P.Lw2 * Muro_P.tw2))
                Else
                    Muro_P.ALR_CM = ALR_ * 0.9
                    Muro_P.ALR_CU = ALR_
                End If

                If Muro_P.ALR_CU <= 10 Then
                    Muro_P.Nivel_Carga = "Bajo"
                ElseIf 10 < Muro_P.ALR_CU And Muro_P.ALR_CU <= 20 Then
                    Muro_P.Nivel_Carga = "Medio"
                ElseIf Muro_P.ALR_CU > 20 Then
                    Muro_P.Nivel_Carga = "Alto"
                End If

                If Muro_P.ALR_CU / 100 > Max_ALR Then
                    Max_ALR = Muro_P.ALR_CU / 100
                End If
                Muro_P.Confinamiento = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).Confinamiento

                Proyecto.Edificio.ListaMuros_Protagonicos.Add(Muro_P)
            Else
                Exit For
            End If
            Suma += Proyecto.Edificio.ListaMuros_Protagonicos(Proyecto.Edificio.ListaMuros_Protagonicos.Count - 1).SismoX
        Next

        For i = 0 To Proyecto.Edificio.ListaMuros_Protagonicos.Count - 1
            Tabla_Resultados.Rows.Add()
        Next

        For i = 0 To Proyecto.Edificio.ListaMuros_Protagonicos.Count - 1
            Tabla_Resultados.Rows(i).Cells(0).Value = Proyecto.Edificio.ListaMuros_Protagonicos(i).Name
            Tabla_Resultados.Rows(i).Cells(1).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).SismoX * 100, 2)
            Tabla_Resultados.Rows(i).Cells(2).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).SismoY * 100, 2)
            Tabla_Resultados.Rows(i).Cells(3).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).Esbeltez, 2)
            Tabla_Resultados.Rows(i).Cells(4).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).AR_X, 1)
            Tabla_Resultados.Rows(i).Cells(5).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).AR_Y, 1)
            Tabla_Resultados.Rows(i).Cells(6).Value = Proyecto.Edificio.ListaMuros_Protagonicos(i).Tipo_Muro
            Tabla_Resultados.Rows(i).Cells(7).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).ALR_CM, 2)
            Tabla_Resultados.Rows(i).Cells(8).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).ALR_CU, 2)
            Tabla_Resultados.Rows(i).Cells(9).Value = Proyecto.Edificio.ListaMuros_Protagonicos(i).Nivel_Carga
            Tabla_Resultados.Rows(i).Cells(12).Value = Proyecto.Edificio.ListaMuros_Protagonicos(i).Confinamiento
        Next

        '------------------ Densidades de Muros ----------------
        Proyecto.Edificio.Densidad_X = Math.Round(Proyecto.Edificio.AreaM_X / Proyecto.Edificio.Area * 100, 2)
        Proyecto.Edificio.Densidad_Y = Math.Round(Proyecto.Edificio.AreaM_Y / Proyecto.Edificio.Area * 100, 2)
        Tabla_Resultados.Rows(0).Cells(10).Value = Proyecto.Edificio.Densidad_X
        Tabla_Resultados.Rows(0).Cells(11).Value = Proyecto.Edificio.Densidad_Y

        '------------------------ CLASIFICACIÓN DEL GRADO DE VULNERABILIDAD ---------------------------
        Dim Num_Largos As Integer = 0
        Dim Num_Intermedios As Integer = 0
        Dim Num_Cortos As Integer = 0
        Dim Num_Confinados As Integer = 0

        For i = 0 To Proyecto.Edificio.ListaMuros_Protagonicos.Count - 1
            If Proyecto.Edificio.ListaMuros_Protagonicos(i).Tipo_Muro = "Largo" Then
                Num_Largos += 1
            End If
            If Proyecto.Edificio.ListaMuros_Protagonicos(i).Tipo_Muro = "Intermedio" Then
                Num_Intermedios += 1
            End If
            If Proyecto.Edificio.ListaMuros_Protagonicos(i).Tipo_Muro = "Corto" Then
                Num_Cortos += 1
            End If
            If Proyecto.Edificio.ListaMuros_Protagonicos(i).Confinamiento = "Si" Then
                Num_Confinados += 1
            End If
        Next

        L_Grado.Visible = True
        TabControl1.SelectedIndex = 1

        '--------------------- ÍNDICE DE CALIFICACIÓN ESTRUCTURAL (ICE) -------------------------
        Dim ICE As Single = 0
        Dim Cal_Densidad As String = ""
        Dim Cal_ALR As String = ""
        P_1.Visible = True
        P_2.Visible = True
        P_3.Visible = True
        P_4.Visible = True
        P_5.Visible = True
        P_6.Visible = True

        '------------------------- CÁLCULO DE PESO PARA LA DENSIDAD ------------------------
        If Math.Max(Proyecto.Edificio.Densidad_X, Proyecto.Edificio.Densidad_Y) < 2 Then
            Proyecto.Edificio.Densidad = "Baja"
            Cal_Densidad = "Baja"
            Proyecto.Edificio.Calificaciones.Peso_Densidad = Proyecto.Edificio.Indicador.Densidad_Max
        ElseIf 2 <= Math.Max(Proyecto.Edificio.Densidad_X, Proyecto.Edificio.Densidad_Y) And Math.Max(Proyecto.Edificio.Densidad_X, Proyecto.Edificio.Densidad_Y) <= 3 Then
            Proyecto.Edificio.Densidad = "Media"
            Cal_Densidad = "Media"
            Proyecto.Edificio.Calificaciones.Peso_Densidad = Proyecto.Edificio.Indicador.Densidad_Int
        ElseIf Math.Max(Proyecto.Edificio.Densidad_X, Proyecto.Edificio.Densidad_Y) > 3 Then
            Proyecto.Edificio.Densidad = "Alta"
            Cal_Densidad = "Alta"
            Proyecto.Edificio.Calificaciones.Peso_Densidad = Proyecto.Edificio.Indicador.Densidad_Min
        End If
        Proyecto.Edificio.Calificaciones.Calificacion_Densidad = "Densidad " + Cal_Densidad
        L_D.Text = Proyecto.Edificio.Calificaciones.Calificacion_Densidad
        L_D.Visible = True
        Console.WriteLine(Proyecto.Edificio.Calificaciones.Peso_Densidad)
        ICE += Proyecto.Edificio.Calificaciones.Peso_Densidad

        '---------------------- CÁLCULO DE PESO PARA EL NUMERO DE PISOS -------------------
        If Proyecto.Edificio.Num_P < 10 Then
            Proyecto.Edificio.Calificaciones.Peso_NumPisos = Proyecto.Edificio.Indicador.Num_Pisos_Min
        ElseIf 10 <= Proyecto.Edificio.Num_P And Proyecto.Edificio.Num_P <= 15 Then
            Proyecto.Edificio.Calificaciones.Peso_NumPisos = Proyecto.Edificio.Indicador.Num_Pisos_Int
        ElseIf Proyecto.Edificio.Num_P > 15 Then
            Proyecto.Edificio.Calificaciones.Peso_NumPisos = Proyecto.Edificio.Indicador.Num_Pisos_Max
        End If
        Console.WriteLine(Proyecto.Edificio.Calificaciones.Peso_NumPisos)
        ICE += Proyecto.Edificio.Calificaciones.Peso_NumPisos

        '---------------------- CÁLCULO DE PESO PARA EL FACTOR DE FORMA -------------------
        Dim Factor_Forma As Single = Proyecto.Edificio.Dimension_Longitud / Proyecto.Edificio.Dimension_Transversal
        If Factor_Forma < 1.5 Then
            Proyecto.Edificio.Calificaciones.Peso_FactorForma = Proyecto.Edificio.Indicador.Factor_Forma_Min
            Proyecto.Edificio.Calificaciones.Calificacion_FactorForma = "Planta de Forma Cuadrada"
        ElseIf 1.5 <= Factor_Forma And Factor_Forma < 4 Then
            Proyecto.Edificio.Calificaciones.Peso_FactorForma = Proyecto.Edificio.Indicador.Factor_Forma_Int
            Proyecto.Edificio.Calificaciones.Calificacion_FactorForma = "Planta de Forma Rectangular"
        ElseIf Factor_Forma >= 4 Then
            Proyecto.Edificio.Calificaciones.Peso_FactorForma = Proyecto.Edificio.Indicador.Factor_Forma_Max
            Proyecto.Edificio.Calificaciones.Calificacion_FactorForma = "Planta de Forma Alargada"
        End If
        L_FF.Text = Proyecto.Edificio.Calificaciones.Calificacion_FactorForma
        L_FF.Visible = True
        Console.WriteLine(Proyecto.Edificio.Calificaciones.Peso_FactorForma)
        ICE += Proyecto.Edificio.Calificaciones.Peso_FactorForma

        '---------------------------- CÁLCULO DE PESO PARA LA Ar -----------------------------
        Dim Porcentaje_Largos As Single = Num_Largos / Proyecto.Edificio.ListaMuros_Protagonicos.Count()
        Dim Porcentaje_Intermedios As Single = Num_Intermedios / Proyecto.Edificio.ListaMuros_Protagonicos.Count()
        Dim Porcentaje_Cortos As Single = Num_Cortos / Proyecto.Edificio.ListaMuros_Protagonicos.Count()
        If Porcentaje_Cortos >= 0.8 Then
            Proyecto.Edificio.Calificaciones.Calificacion_Ar = "Se Tienen Muros Cortos"
            Proyecto.Edificio.Calificaciones.Peso_Ar = Proyecto.Edificio.Indicador.Ar_Max
        ElseIf Porcentaje_Cortos >= 0.6 And Porcentaje_Intermedios <= 0.2 Then
            Proyecto.Edificio.Calificaciones.Calificacion_Ar = "Se Tienen Muros Cortos e Intermedios"
            Proyecto.Edificio.Calificaciones.Peso_Ar = Proyecto.Edificio.Indicador.Ar_Int
        ElseIf Porcentaje_Intermedios < 0.2 And Porcentaje_Largos < 0.2 And Porcentaje_Cortos >= 0.5 Then
            Proyecto.Edificio.Calificaciones.Calificacion_Ar = "Se Tienen Muros Cortos, Intermedios y Largos"
            Proyecto.Edificio.Calificaciones.Peso_Ar = Proyecto.Edificio.Indicador.Ar_Min
        End If
        L_Ar.Text = Proyecto.Edificio.Calificaciones.Calificacion_Ar
        L_Ar.Visible = True
        Console.WriteLine(Proyecto.Edificio.Calificaciones.Peso_Ar)
        ICE += Proyecto.Edificio.Calificaciones.Peso_Ar

        '---------------------------- CÁLCULO DE PESO PARA EL ALR -----------------------------
        If Max_ALR <= 0.1 Then
            Proyecto.Edificio.ALR = "Baja"
            Cal_ALR = "Menor al 10%"
            Proyecto.Edificio.Calificaciones.Peso_ALR = Proyecto.Edificio.Indicador.ALR_Min
        ElseIf 0.1 < Max_ALR And Max_ALR <= 0.2 Then
            Proyecto.Edificio.ALR = "Media"
            Cal_ALR = "Entre 10 % y 20%"
            Proyecto.Edificio.Calificaciones.Peso_ALR = Proyecto.Edificio.Indicador.ALR_Int
        ElseIf Max_ALR > 0.2 Then
            Proyecto.Edificio.ALR = "Alta"
            Cal_ALR = "Mayor al 20%"
            Proyecto.Edificio.Calificaciones.Peso_ALR = Proyecto.Edificio.Indicador.ALR_Max
        End If
        Proyecto.Edificio.Calificaciones.Calificacion_ALR = "Relación de Carga Axial " + Cal_ALR
        L_ALR.Text = Proyecto.Edificio.Calificaciones.Calificacion_ALR
        L_ALR.Visible = True
        Console.WriteLine(Proyecto.Edificio.Calificaciones.Peso_ALR)
        ICE += Proyecto.Edificio.Calificaciones.Peso_ALR

        '---------------------------- CÁLCULO DE PESO PARA LA AMENAZA -----------------------------
        Proyecto.Edificio.Amenaza = C_Nivel_Amenaza.Text
        If C_Nivel_Amenaza.Text = "Alta" Then
            Proyecto.Edificio.Calificaciones.Peso_Amenaza = Proyecto.Edificio.Indicador.Amenaza_Max
        ElseIf C_Nivel_Amenaza.Text = "Media" Then
            Proyecto.Edificio.Calificaciones.Peso_Amenaza = Proyecto.Edificio.Indicador.Amenaza_Int
        ElseIf C_Nivel_Amenaza.Text = "Baja" Then
            Proyecto.Edificio.Calificaciones.Peso_Amenaza = Proyecto.Edificio.Indicador.Amenaza_Min
        End If
        Proyecto.Edificio.Calificaciones.Calificacion_Amenaza = "Nivel de Amenaza Sísmica " + C_Nivel_Amenaza.Text
        L_Na.Text = Proyecto.Edificio.Calificaciones.Calificacion_Amenaza
        L_Na.Visible = True
        Console.WriteLine(Proyecto.Edificio.Calificaciones.Peso_Amenaza)
        ICE += Proyecto.Edificio.Calificaciones.Peso_Amenaza

        '---------------------------- CÁLCULO DE PESO PARA LA ESBELTEZ -----------------------------
        Dim Esbeltez_Promedio As Single = Esbeltez_Total / Proyecto.Edificio.ListaMuros_Protagonicos.Count()
        If Esbeltez_Promedio > 24 Then
            Proyecto.Edificio.Calificaciones.Calificacion_Esbeltez = "Se Tienen Muros Esbeltos"
            P_7.Visible = True
            L_Es.Visible = True
            Proyecto.Edificio.Calificaciones.Peso_Esbeltez = Proyecto.Edificio.Indicador.Esbeltez_Max
        ElseIf 24 >= Esbeltez_Promedio And Esbeltez_Promedio > 16 Then
            Proyecto.Edificio.Calificaciones.Peso_Esbeltez = Proyecto.Edificio.Indicador.Esbeltez_Int
        ElseIf Esbeltez_Promedio <= 16 Then
            Proyecto.Edificio.Calificaciones.Peso_Esbeltez = Proyecto.Edificio.Indicador.Esbeltez_Min
        End If
        L_Es.Text = Proyecto.Edificio.Calificaciones.Calificacion_Esbeltez
        Console.WriteLine(Proyecto.Edificio.Calificaciones.Peso_Esbeltez)
        ICE += Proyecto.Edificio.Calificaciones.Peso_Esbeltez

        '---------------------------- CÁLCULO DE PESO PARA EL CONFINAMIENTO -----------------------------
        Dim Porcentaje_Confinamiento As Single = Num_Confinados / Proyecto.Edificio.ListaMuros_Protagonicos.Count()
        If Porcentaje_Confinamiento <= 0.1 Then
            Proyecto.Edificio.Calificaciones.Calificacion_Confinamiento = "Muros Sin Confinamiento"
            Proyecto.Edificio.Calificaciones.Peso_Confinamiento = Proyecto.Edificio.Indicador.Confinamiento_Max
        ElseIf 0.1 < Porcentaje_Confinamiento And Porcentaje_Confinamiento <= 0.2 Then
            Proyecto.Edificio.Calificaciones.Calificacion_Confinamiento = "Menos del 20% de los Muros son Confinados"
            Proyecto.Edificio.Calificaciones.Peso_Confinamiento = Proyecto.Edificio.Indicador.Confinamiento_Int
        ElseIf Porcentaje_Confinamiento > 0.2 Then
            Proyecto.Edificio.Calificaciones.Calificacion_Confinamiento = "Muros Confinados"
            Proyecto.Edificio.Calificaciones.Peso_Confinamiento = Proyecto.Edificio.Indicador.Confinamiento_Min
        End If
        L_C.Text = Proyecto.Edificio.Calificaciones.Calificacion_Confinamiento
        L_C.Visible = True
        Console.WriteLine(Proyecto.Edificio.Calificaciones.Peso_Confinamiento)
        ICE += Proyecto.Edificio.Calificaciones.Peso_Confinamiento

        Console.WriteLine(ICE)
        Proyecto.Edificio.Calificaciones.ICE = ICE

        L_Grado.Text = "ICE= " + Convert.ToString(Proyecto.Edificio.Calificaciones.ICE)
        If Proyecto.Edificio.Calificaciones.ICE <= 50 Then
            B_Rojo.Visible = True
            B_Amarillo.Visible = True
            B_Verde.Visible = False
            L_Grado.ForeColor = Color.Green
        ElseIf Proyecto.Edificio.Calificaciones.ICE > 50 And Proyecto.Edificio.Calificaciones.ICE <= 70 Then
            B_Rojo.Visible = True
            B_Amarillo.Visible = False
            B_Verde.Visible = True
            L_Grado.ForeColor = Color.FromArgb(208, 203, 0)
        ElseIf Proyecto.Edificio.Calificaciones.ICE > 70 Then
            B_Rojo.Visible = False
            B_Amarillo.Visible = True
            B_Verde.Visible = True
            L_Grado.ForeColor = Color.Red
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Fi As Integer
        For i = 0 To Proyecto.Edificio.ListaMuros.Count() - 1
            If T_Name.Text = Tabla_Datos.Rows(i).Cells(0).Value Then
                Fi = i
            End If
        Next

        Proyecto.Edificio.ListaMuros(Proyecto.Edificio.ListaMuros.FindIndex(Function(x) x.Name = T_Name.Text)).Lw = Convert.ToSingle(T_Lw.Text)
        Proyecto.Edificio.ListaMuros(Proyecto.Edificio.ListaMuros.FindIndex(Function(x) x.Name = T_Name.Text)).tw = Convert.ToSingle(T_tw.Text)
        Tabla_Datos.Rows(Fi).Cells(3).Value = Proyecto.Edificio.ListaMuros(Proyecto.Edificio.ListaMuros.FindIndex(Function(x) x.Name = T_Name.Text)).Lw
        Tabla_Datos.Rows(Fi).Cells(4).Value = Proyecto.Edificio.ListaMuros(Proyecto.Edificio.ListaMuros.FindIndex(Function(x) x.Name = T_Name.Text)).tw

        If Proyecto.Edificio.ListaMuros(Proyecto.Edificio.ListaMuros.FindIndex(Function(x) x.Name = T_Name.Text)).T_Muro <> "Muro Rectangular" Then
            Proyecto.Edificio.ListaMuros(Proyecto.Edificio.ListaMuros.FindIndex(Function(x) x.Name = T_Name.Text)).Lw2 = Convert.ToSingle(T_Lw2.Text)
            Proyecto.Edificio.ListaMuros(Proyecto.Edificio.ListaMuros.FindIndex(Function(x) x.Name = T_Name.Text)).tw2 = Convert.ToSingle(T_tw2.Text)
            Tabla_Datos.Rows(Fi).Cells(5).Value = Proyecto.Edificio.ListaMuros(Proyecto.Edificio.ListaMuros.FindIndex(Function(x) x.Name = T_Name.Text)).Lw2
            Tabla_Datos.Rows(Fi).Cells(6).Value = Proyecto.Edificio.ListaMuros(Proyecto.Edificio.ListaMuros.FindIndex(Function(x) x.Name = T_Name.Text)).tw2
        End If
    End Sub

    Private Sub ÍndiceDeCalificaciónEstructuralICEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÍndiceDeCalificaciónEstructuralICEToolStripMenuItem.Click
        If Form5.WindowState = FormWindowState.Minimized Then
            Form5.WindowState = FormWindowState.Normal
        End If
        Try
            For i = 0 To 6
                Form5.Tabla_PesoICE.Rows.Add()
            Next

            Form5.Tabla_PesoICE.Rows(0).Cells(0).Value = "Densidad"
            Form5.Tabla_PesoICE.Rows(1).Cells(0).Value = "No. Pisos"
            Form5.Tabla_PesoICE.Rows(2).Cells(0).Value = "Factor de Forma"
            Form5.Tabla_PesoICE.Rows(3).Cells(0).Value = "Ar"
            Form5.Tabla_PesoICE.Rows(4).Cells(0).Value = "ALR"
            Form5.Tabla_PesoICE.Rows(5).Cells(0).Value = "Amenaza"
            Form5.Tabla_PesoICE.Rows(6).Cells(0).Value = "Esbeltez"
            Form5.Tabla_PesoICE.Rows(7).Cells(0).Value = "Confinamiento"

            If Proyecto.Edificio.Indicador.T_Mod <> "Si" Then
                Proyecto.Edificio.Indicador.Densidad_Max = 15
                Proyecto.Edificio.Indicador.Num_Pisos_Max = 5
                Proyecto.Edificio.Indicador.Factor_Forma_Max = 5
                Proyecto.Edificio.Indicador.Ar_Max = 20
                Proyecto.Edificio.Indicador.ALR_Max = 20
                Proyecto.Edificio.Indicador.Amenaza_Max = 10
                Proyecto.Edificio.Indicador.Esbeltez_Max = 15
                Proyecto.Edificio.Indicador.Confinamiento_Max = 10

                Proyecto.Edificio.Indicador.Densidad_Int = 10
                Proyecto.Edificio.Indicador.Num_Pisos_Int = 2
                Proyecto.Edificio.Indicador.Factor_Forma_Int = 2
                Proyecto.Edificio.Indicador.Ar_Int = 10
                Proyecto.Edificio.Indicador.ALR_Int = 10
                Proyecto.Edificio.Indicador.Amenaza_Int = 5
                Proyecto.Edificio.Indicador.Esbeltez_Int = 10
                Proyecto.Edificio.Indicador.Confinamiento_Int = 5

                Proyecto.Edificio.Indicador.Densidad_Min = 5
                Proyecto.Edificio.Indicador.Num_Pisos_Min = 0
                Proyecto.Edificio.Indicador.Factor_Forma_Min = 0
                Proyecto.Edificio.Indicador.Ar_Min = 0
                Proyecto.Edificio.Indicador.ALR_Min = 5
                Proyecto.Edificio.Indicador.Amenaza_Min = 0
                Proyecto.Edificio.Indicador.Esbeltez_Min = 0
                Proyecto.Edificio.Indicador.Confinamiento_Min = 0
            Else
                Form5.T_PFS.Text = Proyecto.Edificio.Porcentaje_FSMuros
            End If

            Form5.Tabla_PesoICE.Rows(0).Cells(1).Value = Proyecto.Edificio.Indicador.Densidad_Max
            Form5.Tabla_PesoICE.Rows(1).Cells(1).Value = Proyecto.Edificio.Indicador.Num_Pisos_Max
            Form5.Tabla_PesoICE.Rows(2).Cells(1).Value = Proyecto.Edificio.Indicador.Factor_Forma_Max
            Form5.Tabla_PesoICE.Rows(3).Cells(1).Value = Proyecto.Edificio.Indicador.Ar_Max
            Form5.Tabla_PesoICE.Rows(4).Cells(1).Value = Proyecto.Edificio.Indicador.ALR_Max
            Form5.Tabla_PesoICE.Rows(5).Cells(1).Value = Proyecto.Edificio.Indicador.Amenaza_Max
            Form5.Tabla_PesoICE.Rows(6).Cells(1).Value = Proyecto.Edificio.Indicador.Esbeltez_Max
            Form5.Tabla_PesoICE.Rows(7).Cells(1).Value = Proyecto.Edificio.Indicador.Confinamiento_Max

            Form5.Tabla_PesoICE.Rows(0).Cells(2).Value = Proyecto.Edificio.Indicador.Densidad_Int
            Form5.Tabla_PesoICE.Rows(1).Cells(2).Value = Proyecto.Edificio.Indicador.Num_Pisos_Int
            Form5.Tabla_PesoICE.Rows(2).Cells(2).Value = Proyecto.Edificio.Indicador.Factor_Forma_Int
            Form5.Tabla_PesoICE.Rows(3).Cells(2).Value = Proyecto.Edificio.Indicador.Ar_Int
            Form5.Tabla_PesoICE.Rows(4).Cells(2).Value = Proyecto.Edificio.Indicador.ALR_Int
            Form5.Tabla_PesoICE.Rows(5).Cells(2).Value = Proyecto.Edificio.Indicador.Amenaza_Int
            Form5.Tabla_PesoICE.Rows(6).Cells(2).Value = Proyecto.Edificio.Indicador.Esbeltez_Int
            Form5.Tabla_PesoICE.Rows(7).Cells(2).Value = Proyecto.Edificio.Indicador.Confinamiento_Int

            Form5.Tabla_PesoICE.Rows(0).Cells(3).Value = Proyecto.Edificio.Indicador.Densidad_Min
            Form5.Tabla_PesoICE.Rows(1).Cells(3).Value = Proyecto.Edificio.Indicador.Num_Pisos_Min
            Form5.Tabla_PesoICE.Rows(2).Cells(3).Value = Proyecto.Edificio.Indicador.Factor_Forma_Min
            Form5.Tabla_PesoICE.Rows(3).Cells(3).Value = Proyecto.Edificio.Indicador.Ar_Min
            Form5.Tabla_PesoICE.Rows(4).Cells(3).Value = Proyecto.Edificio.Indicador.ALR_Min
            Form5.Tabla_PesoICE.Rows(5).Cells(3).Value = Proyecto.Edificio.Indicador.Amenaza_Min
            Form5.Tabla_PesoICE.Rows(6).Cells(3).Value = Proyecto.Edificio.Indicador.Esbeltez_Min
            Form5.Tabla_PesoICE.Rows(7).Cells(3).Value = Proyecto.Edificio.Indicador.Confinamiento_Min
        Catch ex As Exception
        Finally
            Form5.Show()
        End Try
    End Sub

    Sub SaveAs()
        Dim SaveAs As New SaveFileDialog
        SaveAs.Filter = "Archivo|*.ceer"
        SaveAs.Title = "Guardar Archivo"
        SaveAs.ShowDialog()
        If SaveAs.FileName <> String.Empty Then
            Funciones_Programa.Serializar(SaveAs.FileName, Proyecto)
        End If
    End Sub
    Sub Open()
        Dim Open As New OpenFileDialog
        Open.Filter = "Archivo|*.ceer"
        Open.Title = "Abrir Archivo"
        Open.ShowDialog()

        If Open.FileName <> String.Empty Then
            Proyecto = Funciones_Programa.DeSerializar(Of Proyecto)(Open.FileName)

            Rellenar()
        End If
    End Sub
    Private Sub GuardarProyectoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarProyectoToolStripMenuItem.Click
        SaveAs()
    End Sub
    Private Sub AbrirProyectoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirProyectoToolStripMenuItem.Click
        Open()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form3.Show()
    End Sub

    Private Sub IngresarImagenDelProyectoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarImagenDelProyectoToolStripMenuItem.Click
        If Form7.WindowState = FormWindowState.Minimized Then
            Form7.WindowState = FormWindowState.Normal
        Else
            Form7.Show()
        End If

    End Sub


    Public Sub Limpiar()
        T_Name.Text = ""
        Tipo_Muro.Text = "Muro Rectangular"
        Direccion.Text = "X"
        T_Lw.Text = ""
        T_tw.Text = ""
        T_Lw2.Text = ""
        T_tw2.Text = ""
        T_Cantidad.Text = ""
        C_Confinamiento.Text = "No"
        T_Hn.Text = ""
        T_NP.Text = ""
        T_fc.Text = ""
        T_Area.Text = ""
        C_Nivel_Amenaza.Text = "Alta"
        Form3.T_AnchoE.Text = ""
        Form3.T_LargoE.Text = ""

        Form2.Tabla_Cargas.Rows.Clear()
        Tabla_Datos.Rows.Clear()
        Tabla_Resultados.Rows.Clear()
        Proyecto.Edificio.ListaMuros.Clear()
        Proyecto.Edificio.ListaMuros_Protagonicos.Clear()
    End Sub
    Public Sub Rellenar()
        T_Hn.Text = Proyecto.Edificio.Hn
        T_NP.Text = Proyecto.Edificio.Num_P
        If Proyecto.Edificio.Op_fc = "Nominal" Then
            Op_fc_Medido.Checked = False
            Op_fc_Nominal.Checked = True
        Else
            Op_fc_Nominal.Checked = False
            Op_fc_Medido.Checked = True
        End If
        T_fc.Text = Proyecto.Edificio.fc
        T_Area.Text = Proyecto.Edificio.Area
        C_Nivel_Amenaza.Text = Proyecto.Edificio.Amenaza

        Form3.T_AnchoE.Text = Proyecto.Edificio.Dimension_Transversal
        Form3.T_LargoE.Text = Proyecto.Edificio.Dimension_Longitud

        Dim Muros_C As String = ""

        For i = 0 To Proyecto.Edificio.ListaMuros.Count() - 1
            Tabla_Datos.Rows.Add()
            If Proyecto.Edificio.ListaMuros(0).Lw2 <> 0 Then
                Muros_C = "Si"
            End If
        Next

        For i = 0 To Proyecto.Edificio.ListaMuros.Count() - 1
            Tabla_Datos.Rows(i).Cells(0).Value = Proyecto.Edificio.ListaMuros(i).Name
            Tabla_Datos.Rows(i).Cells(1).Value = Proyecto.Edificio.ListaMuros(i).T_Muro
            Tabla_Datos.Rows(i).Cells(2).Value = Proyecto.Edificio.ListaMuros(i).Direccion
            Tabla_Datos.Rows(i).Cells(3).Value = Proyecto.Edificio.ListaMuros(i).Lw
            Tabla_Datos.Rows(i).Cells(4).Value = Proyecto.Edificio.ListaMuros(i).tw
            Tabla_Datos.Rows(i).Cells(5).Value = Math.Round(Proyecto.Edificio.ListaMuros(i).SismoX, 2)
            Tabla_Datos.Rows(i).Cells(6).Value = Math.Round(Proyecto.Edificio.ListaMuros(i).SismoY, 2)
            If Muros_C = "Si" Then
                Tabla_Datos.Rows(i).Cells(5).Value = Proyecto.Edificio.ListaMuros(i).Lw2
                Tabla_Datos.Rows(i).Cells(6).Value = Proyecto.Edificio.ListaMuros(i).tw2
                Tabla_Datos.Rows(i).Cells(7).Value = Math.Round(Proyecto.Edificio.ListaMuros(i).SismoX, 2)
                Tabla_Datos.Rows(i).Cells(8).Value = Math.Round(Proyecto.Edificio.ListaMuros(i).SismoY, 2)
            End If
        Next

        For i = 0 To Proyecto.Edificio.ListaMuros_Protagonicos.Count - 1
            Tabla_Resultados.Rows.Add()
        Next

        For i = 0 To Proyecto.Edificio.ListaMuros_Protagonicos.Count - 1
            Tabla_Resultados.Rows(i).Cells(0).Value = Proyecto.Edificio.ListaMuros_Protagonicos(i).Name
            Tabla_Resultados.Rows(i).Cells(1).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).SismoX, 2)
            Tabla_Resultados.Rows(i).Cells(2).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).SismoY, 2)
            Tabla_Resultados.Rows(i).Cells(3).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).Esbeltez, 2)
            Tabla_Resultados.Rows(i).Cells(4).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).AR_X, 1)
            Tabla_Resultados.Rows(i).Cells(5).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).AR_Y, 1)
            Tabla_Resultados.Rows(i).Cells(6).Value = Proyecto.Edificio.ListaMuros_Protagonicos(i).Tipo_Muro
            Tabla_Resultados.Rows(i).Cells(7).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).ALR_CM, 2)
            Tabla_Resultados.Rows(i).Cells(8).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).ALR_CU, 2)
            Tabla_Resultados.Rows(i).Cells(9).Value = Proyecto.Edificio.ListaMuros_Protagonicos(i).Nivel_Carga
            Tabla_Resultados.Rows(i).Cells(12).Value = Proyecto.Edificio.ListaMuros_Protagonicos(i).Confinamiento
        Next
        Tabla_Resultados.Rows(0).Cells(10).Value = Proyecto.Edificio.Densidad_X
        Tabla_Resultados.Rows(0).Cells(11).Value = Proyecto.Edificio.Densidad_Y

        P_1.Visible = True
        P_2.Visible = True
        P_3.Visible = True
        P_4.Visible = True
        P_5.Visible = True
        P_6.Visible = True

        '------------------------- CÁLCULO DE PESO PARA LA DENSIDAD ------------------------

        L_D.Text = Proyecto.Edificio.Calificaciones.Calificacion_Densidad
        L_D.Visible = True

        '---------------------- CÁLCULO DE PESO PARA EL NUMERO DE PISOS -------------------

        '---------------------- CÁLCULO DE PESO PARA EL FACTOR DE FORMA -------------------
        L_FF.Text = Proyecto.Edificio.Calificaciones.Calificacion_FactorForma
        L_FF.Visible = True

        '---------------------------- CÁLCULO DE PESO PARA LA Ar -----------------------------
        L_Ar.Text = Proyecto.Edificio.Calificaciones.Calificacion_Ar
        L_Ar.Visible = True


        '---------------------------- CÁLCULO DE PESO PARA EL ALR -----------------------------
        L_ALR.Text = Proyecto.Edificio.Calificaciones.Calificacion_ALR
        L_ALR.Visible = True

        '---------------------------- CÁLCULO DE PESO PARA LA AMENAZA -----------------------------
        L_Na.Text = Proyecto.Edificio.Calificaciones.Calificacion_Amenaza
        L_Na.Visible = True

        '---------------------------- CÁLCULO DE PESO PARA LA ESBELTEZ -----------------------------
        If Proyecto.Edificio.Calificaciones.Calificacion_Esbeltez <> String.Empty Then
            L_Es.Visible = True
        End If
        L_Es.Text = Proyecto.Edificio.Calificaciones.Calificacion_Esbeltez

        '---------------------------- CÁLCULO DE PESO PARA EL CONFINAMIENTO -----------------------------
        L_C.Text = Proyecto.Edificio.Calificaciones.Calificacion_Confinamiento
        L_C.Visible = True


        L_Grado.Text = "ICE= " + Convert.ToString(Proyecto.Edificio.Calificaciones.ICE)
        If Proyecto.Edificio.Calificaciones.ICE <= 50 Then
            B_Rojo.Visible = True
            B_Amarillo.Visible = True
            B_Verde.Visible = False
            L_Grado.ForeColor = Color.Green
        ElseIf Proyecto.Edificio.Calificaciones.ICE > 50 And Proyecto.Edificio.Calificaciones.ICE <= 70 Then
            B_Rojo.Visible = True
            B_Amarillo.Visible = False
            B_Verde.Visible = True
            L_Grado.ForeColor = Color.FromArgb(208, 203, 0)
        ElseIf Proyecto.Edificio.Calificaciones.ICE > 70 Then
            B_Rojo.Visible = False
            B_Amarillo.Visible = True
            B_Verde.Visible = True
            L_Grado.ForeColor = Color.Red
        End If

        Form5.Tabla_PesoICE.Rows(0).Cells(1).Value = Proyecto.Edificio.Indicador.Densidad_Max
        Form5.Tabla_PesoICE.Rows(1).Cells(1).Value = Proyecto.Edificio.Indicador.Num_Pisos_Max
        Form5.Tabla_PesoICE.Rows(2).Cells(1).Value = Proyecto.Edificio.Indicador.Factor_Forma_Max
        Form5.Tabla_PesoICE.Rows(3).Cells(1).Value = Proyecto.Edificio.Indicador.Ar_Max
        Form5.Tabla_PesoICE.Rows(4).Cells(1).Value = Proyecto.Edificio.Indicador.ALR_Max
        Form5.Tabla_PesoICE.Rows(5).Cells(1).Value = Proyecto.Edificio.Indicador.Amenaza_Max
        Form5.Tabla_PesoICE.Rows(6).Cells(1).Value = Proyecto.Edificio.Indicador.Esbeltez_Max
        Form5.Tabla_PesoICE.Rows(7).Cells(1).Value = Proyecto.Edificio.Indicador.Confinamiento_Max

        Form5.Tabla_PesoICE.Rows(0).Cells(2).Value = Proyecto.Edificio.Indicador.Densidad_Int
        Form5.Tabla_PesoICE.Rows(1).Cells(2).Value = Proyecto.Edificio.Indicador.Num_Pisos_Int
        Form5.Tabla_PesoICE.Rows(2).Cells(2).Value = Proyecto.Edificio.Indicador.Factor_Forma_Int
        Form5.Tabla_PesoICE.Rows(3).Cells(2).Value = Proyecto.Edificio.Indicador.Ar_Int
        Form5.Tabla_PesoICE.Rows(4).Cells(2).Value = Proyecto.Edificio.Indicador.ALR_Int
        Form5.Tabla_PesoICE.Rows(5).Cells(2).Value = Proyecto.Edificio.Indicador.Amenaza_Int
        Form5.Tabla_PesoICE.Rows(6).Cells(2).Value = Proyecto.Edificio.Indicador.Esbeltez_Int
        Form5.Tabla_PesoICE.Rows(7).Cells(2).Value = Proyecto.Edificio.Indicador.Confinamiento_Int

        Form5.Tabla_PesoICE.Rows(0).Cells(3).Value = Proyecto.Edificio.Indicador.Densidad_Min
        Form5.Tabla_PesoICE.Rows(1).Cells(3).Value = Proyecto.Edificio.Indicador.Num_Pisos_Min
        Form5.Tabla_PesoICE.Rows(2).Cells(3).Value = Proyecto.Edificio.Indicador.Factor_Forma_Min
        Form5.Tabla_PesoICE.Rows(3).Cells(3).Value = Proyecto.Edificio.Indicador.Ar_Min
        Form5.Tabla_PesoICE.Rows(4).Cells(3).Value = Proyecto.Edificio.Indicador.ALR_Min
        Form5.Tabla_PesoICE.Rows(5).Cells(3).Value = Proyecto.Edificio.Indicador.Amenaza_Min
        Form5.Tabla_PesoICE.Rows(6).Cells(3).Value = Proyecto.Edificio.Indicador.Esbeltez_Min
        Form5.Tabla_PesoICE.Rows(7).Cells(3).Value = Proyecto.Edificio.Indicador.Confinamiento_Min
        Form5.T_PFS.Text = Proyecto.Edificio.Porcentaje_FSMuros

    End Sub

    Private Sub NuevoProyectoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoProyectoToolStripMenuItem.Click
        Limpiar()
    End Sub

    Private Sub AcercaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaToolStripMenuItem.Click
        Form8.Show()
    End Sub

    Public Sub AyudaGlobo(ByVal Globo As ToolTip, ByVal Boton As ComboBox, ByVal Mensaje As String)
        Globo.RemoveAll()
        Globo.SetToolTip(Boton, Mensaje)
        Globo.InitialDelay = 100
        Globo.IsBalloon = False
    End Sub
    Private Sub Direccion_MouseEnter(sender As Object, e As EventArgs) Handles Direccion.MouseEnter
        AyudaGlobo(Tool_Info, Direccion, "(1) Corresponde a la dirección principal del Muro" + Environment.NewLine + "Debe coincidir con la dirección que tiene el muro en planta")
        'Form3.Show()


    End Sub
End Class
