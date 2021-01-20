﻿Imports System.Windows.Forms.DataVisualization.Charting
Imports excel = Microsoft.Office.Interop.Excel
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class Form_00_Principal
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
        Tabla_Datos.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Arial", 10, FontStyle.Bold)
        Tabla_Resultados.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Arial", 10, FontStyle.Bold)
        Tipo_Muro.Text = "Muro Rectangular"
        Direccion.Text = "X"
        C_Confinamiento.Text = "No"
        C_Nivel_Amenaza.Text = "Alta"

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
        Dim Letra As New System.Drawing.Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim CorB As New SolidBrush(Color.Black)
        Dim CorA As New SolidBrush(Color.FromArgb(0, 0, 255))
        Dim CorR As New SolidBrush(Color.Red)
        Dim PenR As New Pen(Color.Red)
        Dim PenA As New Pen(Color.FromArgb(0, 0, 255))
        Dim LetraE As New System.Drawing.Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel)

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

            If Proyecto.Edificio.ListaMuros.Exists(Function(x) x.Name = Nombre) = True Then
                Dim style = MsgBoxStyle.Critical
                MsgBox("Muro existente", style, "Elemento Duplicado")
            Else
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
                        Muro_.Porcentaje_Vb_X = 2 * Muro_.Lw ^ 2 * Muro_.tw
                        Muro_.Porcentaje_Vb_Y = Muro_.Lw2 ^ 2 * Muro_.tw2
                        Muro_.AreaX = 2 * Muro_.Lw * Muro_.tw
                        Muro_.AreaY = Muro_.Lw2 * Muro_.tw2
                    Else
                        Muro_.Porcentaje_Vb_X = Muro_.Lw2 ^ 2 * Muro_.tw2
                        Muro_.Porcentaje_Vb_Y = 2 * Muro_.Lw ^ 2 * Muro_.tw
                        Muro_.AreaY = 2 * Muro_.Lw * Muro_.tw
                        Muro_.AreaX = Muro_.Lw2 * Muro_.tw2
                    End If
                Else
                    If Muro_.Direccion = "X" Then
                        Muro_.Porcentaje_Vb_X = Muro_.Lw ^ 2 * Muro_.tw
                        Muro_.Porcentaje_Vb_Y = Muro_.Lw2 ^ 2 * Muro_.tw2
                        Muro_.AreaX = Muro_.Lw * Muro_.tw
                        Muro_.AreaY = Muro_.Lw2 * Muro_.tw2
                    Else
                        Muro_.Porcentaje_Vb_X = Muro_.Lw2 ^ 2 * Muro_.tw2
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
                        Tabla_Datos.Columns(5).HeaderText = "Longitud (Lw2) (m)"
                        Tabla_Datos.Columns(6).HeaderText = "Espesor (tw2) (m)"
                        Tabla_Datos.Columns(7).HeaderText = "Sismo X (%)"
                        Tabla_Datos.Columns(8).HeaderText = "Sismo Y (%)"
                    End If
                    Col_Sx = 7
                    Col_Sy = 8
                End If

                For j = 0 To Proyecto.Edificio.ListaMuros.Count - 1
                    ContX += Proyecto.Edificio.ListaMuros(j).Porcentaje_Vb_X
                    ContY += Proyecto.Edificio.ListaMuros(j).Porcentaje_Vb_Y
                Next
                Proyecto.Edificio.Vb_X = ContX
                Proyecto.Edificio.Vb_Y = ContY

                For i = 0 To Proyecto.Edificio.ListaMuros.Count - 1
                    If Proyecto.Edificio.Vb_X = 0 Then
                        Proyecto.Edificio.ListaMuros(i).SismoX = 0
                    Else
                        Proyecto.Edificio.ListaMuros(i).SismoX = Proyecto.Edificio.ListaMuros(i).Porcentaje_Vb_X / Proyecto.Edificio.Vb_X
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
            If Proyecto.Edificio.Op_Cargas = False Then
                Dim Ale As New Random()
                Dim Va As Single = Ale.Next(0.0000001, 99.99999999) / 100
                ALR_ = ALR(Va, Convert.ToInt32(T_NP.Text), Convert.ToSingle(T_Area.Text)) / 100
            End If

            For i = 0 To Proyecto.Edificio.ListaMuros.Count - 1
                Form_01_Cargas.Tabla_Cargas.Rows.Add()
            Next
            For i = 0 To Proyecto.Edificio.ListaMuros.Count - 1
                Form_01_Cargas.Tabla_Cargas.Rows(i).Cells(0).Value = Proyecto.Edificio.ListaMuros(i).Name

                If Proyecto.Edificio.Op_Cargas = True Then
                    Form_01_Cargas.Tabla_Cargas.Rows(i).Cells(1).Value = Proyecto.Edificio.ListaMuros(i).CM
                    Form_01_Cargas.Tabla_Cargas.Rows(i).Cells(2).Value = Proyecto.Edificio.ListaMuros(i).CD
                Else
                    Form_01_Cargas.Tabla_Cargas.Rows(i).Cells(1).Value = Math.Round(0.9 * ALR_ * Convert.ToSingle(T_fc.Text) * (Proyecto.Edificio.ListaMuros(i).Lw * Proyecto.Edificio.ListaMuros(i).tw + Proyecto.Edificio.ListaMuros(i).Lw2 * Proyecto.Edificio.ListaMuros(i).tw2) * 1000, 0)
                    Form_01_Cargas.Tabla_Cargas.Rows(i).Cells(2).Value = Math.Round(ALR_ * Convert.ToSingle(T_fc.Text) * (Proyecto.Edificio.ListaMuros(i).Lw * Proyecto.Edificio.ListaMuros(i).tw + Proyecto.Edificio.ListaMuros(i).Lw2 * Proyecto.Edificio.ListaMuros(i).tw2) * 1000, 0)
                End If
            Next
            Form_01_Cargas.Show()
        End If
        'Catch ex As Exception
        'Finally
        '    
        'End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Proyecto.Edificio.ListaMuros.Exists(Function(P) P.Tipo_Muro = "Muro en C") Or Proyecto.Edificio.ListaMuros.Exists(Function(P) P.Tipo_Muro = "Muro en T") Or Proyecto.Edificio.ListaMuros.Exists(Function(P) P.Tipo_Muro = "Muro en L") Then
            Proyecto.Edificio.Solo_MRectangulares = False
        Else
            Proyecto.Edificio.Solo_MRectangulares = True
        End If

        Tabla_Resultados.Rows.Clear()
        Proyecto.Edificio.ListaMuros_Protagonicos.Clear()

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
        If Proyecto.Edificio.Op_Cargas <> True Then
            Dim Ale As New Random()
            Dim Va As Single = Ale.Next(0.0000001, 99.99999999) / 100
            ALR_ = ALR(Va, Proyecto.Edificio.Num_P, Proyecto.Edificio.Area)
        End If
        Dim Max_ALR As Single = 0
        Dim Esbeltez_Total As Single = 0

        Dim OrdenLista_SismoX = Proyecto.Edificio.ListaMuros.OrderByDescending(Function(P) P.SismoX)
        Dim OrdenLista_SismoY = Proyecto.Edificio.ListaMuros.OrderByDescending(Function(P) P.SismoY)

        Dim sumaX As Single = 0
        Dim sumaY As Single = 0
        Dim Lista_New_X As New List(Of Muro)
        Dim Lista_New_Y As New List(Of Muro)

        Dim Porcentaje_Fuerzas As Single = Proyecto.Edificio.Porcentaje_FSMuros
        If Proyecto.Edificio.Op_Porcentaje_Fuerzas = False Then
            Porcentaje_Fuerzas = 65
        End If

        For i = 0 To Proyecto.Edificio.ListaMuros.Count - 1
            If sumaX <= Porcentaje_Fuerzas / 100 And OrdenLista_SismoX(i).Direccion = "X" Then
                Dim Muro_P As New Muro
                Muro_P = OrdenLista_SismoX(i)

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

                If Proyecto.Edificio.Op_Cargas = True Then
                    Muro_P.CM = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).CM
                    Muro_P.CD = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).CD

                    Muro_P.ALR_CM = Muro_P.CM / (Proyecto.Edificio.fc * 1000 * (Muro_P.Lw * Muro_P.tw + Muro_P.Lw2 * Muro_P.tw2))
                    Muro_P.ALR_CU = Muro_P.CD / (Proyecto.Edificio.fc * 1000 * (Muro_P.Lw * Muro_P.tw + Muro_P.Lw2 * Muro_P.tw2))
                Else
                    Muro_P.ALR_CM = ALR_ * 0.9
                    Muro_P.ALR_CU = ALR_
                End If

                If Muro_P.ALR_CU <= 0.1 Then
                    Muro_P.Nivel_Carga = "Bajo"
                ElseIf 0.1 < Muro_P.ALR_CU And Muro_P.ALR_CU <= 0.2 Then
                    Muro_P.Nivel_Carga = "Medio"
                ElseIf Muro_P.ALR_CU > 0.2 Then
                    Muro_P.Nivel_Carga = "Alto"
                End If

                If Muro_P.ALR_CU > Max_ALR Then
                    Max_ALR = Muro_P.ALR_CU
                End If

                sumaX += Muro_P.SismoX
                sumaY += Muro_P.SismoY
                Lista_New_X.Add(Muro_P)
            End If
            If sumaY <= Porcentaje_Fuerzas / 100 And OrdenLista_SismoY(i).Direccion = "Y" Then
                Dim Muro_P As New Muro
                Muro_P = OrdenLista_SismoY(i)

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

                If Proyecto.Edificio.Op_Cargas = True Then
                    Muro_P.CM = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).CM
                    Muro_P.CD = Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Muro_P.Name).CD

                    Muro_P.ALR_CM = Muro_P.CM / (Proyecto.Edificio.fc * 1000 * (Muro_P.Lw * Muro_P.tw + Muro_P.Lw2 * Muro_P.tw2))
                    Muro_P.ALR_CU = Muro_P.CD / (Proyecto.Edificio.fc * 1000 * (Muro_P.Lw * Muro_P.tw + Muro_P.Lw2 * Muro_P.tw2))
                Else
                    Muro_P.ALR_CM = ALR_ * 0.9
                    Muro_P.ALR_CU = ALR_
                End If

                If Muro_P.ALR_CU <= 0.1 Then
                    Muro_P.Nivel_Carga = "Bajo"
                ElseIf 0.1 < Muro_P.ALR_CU And Muro_P.ALR_CU <= 0.2 Then
                    Muro_P.Nivel_Carga = "Medio"
                ElseIf Muro_P.ALR_CU > 0.2 Then
                    Muro_P.Nivel_Carga = "Alto"
                End If

                If Muro_P.ALR_CU > Max_ALR Then
                    Max_ALR = Muro_P.ALR_CU
                End If

                sumaX += Muro_P.SismoX
                sumaY += Muro_P.SismoY
                Lista_New_Y.Add(Muro_P)
            End If
        Next

        For i = 0 To Lista_New_X.Count - 2
            Proyecto.Edificio.ListaMuros_Protagonicos.Add(Lista_New_X(i))
        Next
        For i = 0 To Lista_New_Y.Count - 2
            Proyecto.Edificio.ListaMuros_Protagonicos.Add(Lista_New_Y(i))
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
        Proyecto.Edificio.Muros_Largos = Num_Largos
        Proyecto.Edificio.Muros_Intermedios = Num_Intermedios
        Proyecto.Edificio.Muros_Cortos = Num_Cortos
        Proyecto.Edificio.Muros_Confinados = Num_Confinados

        L_Grado.Visible = True

        '--------------------- ÍNDICE DE CALIFICACIÓN ESTRUCTURAL (ICE) -------------------------
        If Proyecto.Edificio.Indicador.T_Mod = False Then
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
        End If
        Dim ICE As Single = 0
        Dim Cal_Densidad As String = ""
        Dim Cal_ALR As String = ""
        P_1.Visible = True
        P_2.Visible = True
        P_3.Visible = True
        P_4.Visible = True
        P_5.Visible = True
        P_6.Visible = True
        P_0.Visible = True

        Button6.Visible = True
        Button7.Visible = True
        Button8.Visible = True
        Button9.Visible = True

        Grafico_Densidad.Dock = DockStyle.Fill
        Grafico_CargaAxial.Dock = DockStyle.Fill
        Grafico_Confinamiento.Dock = DockStyle.Fill
        Grafico_Esbeltez.Dock = DockStyle.Fill
        Grafico_Densidad.Visible = True

        '------------------------- CÁLCULO DE PESO PARA LA DENSIDAD ------------------------
        If Proyecto.Edificio.Densidad_X < 2 Then
            Cal_Densidad = "Baja"
            Proyecto.Edificio.Calificaciones.Peso_Densidad = Proyecto.Edificio.Indicador.Densidad_Max
        ElseIf 2 <= Proyecto.Edificio.Densidad_X And Proyecto.Edificio.Densidad_X <= 3 Then
            Cal_Densidad = "Media"
            Proyecto.Edificio.Calificaciones.Peso_Densidad = Proyecto.Edificio.Indicador.Densidad_Int
        ElseIf Proyecto.Edificio.Densidad_X > 3 Then
            Cal_Densidad = "Alta"
            Proyecto.Edificio.Calificaciones.Peso_Densidad = Proyecto.Edificio.Indicador.Densidad_Min
        End If
        If Proyecto.Edificio.Densidad_Y < 2 Then
            Cal_Densidad = "Baja"
            Proyecto.Edificio.Calificaciones.Peso_Densidad += Proyecto.Edificio.Indicador.Densidad_Max
        ElseIf 2 <= Proyecto.Edificio.Densidad_Y And Proyecto.Edificio.Densidad_Y <= 3 Then
            Cal_Densidad = "Media"
            Proyecto.Edificio.Calificaciones.Peso_Densidad += Proyecto.Edificio.Indicador.Densidad_Int
        ElseIf Proyecto.Edificio.Densidad_Y > 3 Then
            Cal_Densidad = "Alta"
            Proyecto.Edificio.Calificaciones.Peso_Densidad += Proyecto.Edificio.Indicador.Densidad_Min
        End If
        Proyecto.Edificio.Calificaciones.Calificacion_Densidad = "Densidad " + Cal_Densidad
        L_D.Text = Proyecto.Edificio.Calificaciones.Calificacion_Densidad
        L_D.Visible = True
        ICE += Proyecto.Edificio.Calificaciones.Peso_Densidad / 2

        '---------------------- CÁLCULO DE PESO PARA EL NUMERO DE PISOS -------------------
        If Proyecto.Edificio.Num_P < 10 Then
            Proyecto.Edificio.Calificaciones.Peso_NumPisos = Proyecto.Edificio.Indicador.Num_Pisos_Min
        ElseIf 10 <= Proyecto.Edificio.Num_P And Proyecto.Edificio.Num_P <= 15 Then
            Proyecto.Edificio.Calificaciones.Peso_NumPisos = Proyecto.Edificio.Indicador.Num_Pisos_Int
        ElseIf Proyecto.Edificio.Num_P > 15 Then
            Proyecto.Edificio.Calificaciones.Peso_NumPisos = Proyecto.Edificio.Indicador.Num_Pisos_Max
        End If
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
        ICE += Proyecto.Edificio.Calificaciones.Peso_FactorForma

        '---------------------------- CÁLCULO DE PESO PARA LA Ar -----------------------------
        Dim Porcentaje_Largos As Single = Num_Largos / Proyecto.Edificio.ListaMuros_Protagonicos.Count()
        Dim Porcentaje_Intermedios As Single = Num_Intermedios / Proyecto.Edificio.ListaMuros_Protagonicos.Count()
        Dim Porcentaje_Cortos As Single = Num_Cortos / Proyecto.Edificio.ListaMuros_Protagonicos.Count()
        If Porcentaje_Cortos >= 0.8 Then
            Proyecto.Edificio.Calificaciones.Calificacion_Ar = "Se Tienen Muros Cortos"
            Proyecto.Edificio.Calificaciones.Peso_Ar = Proyecto.Edificio.Indicador.Ar_Max
        ElseIf Porcentaje_Cortos >= 0.6 And Porcentaje_Intermedios <= 0.25 Then
            Proyecto.Edificio.Calificaciones.Calificacion_Ar = "Se Tienen Muros Cortos e Intermedios"
            Proyecto.Edificio.Calificaciones.Peso_Ar = Proyecto.Edificio.Indicador.Ar_Int
        ElseIf Porcentaje_Intermedios < 0.2 And Porcentaje_Largos < 0.2 And Porcentaje_Cortos >= 0.5 Then
            Proyecto.Edificio.Calificaciones.Calificacion_Ar = "Se Tienen Muros Cortos, Intermedios y Largos"
            Proyecto.Edificio.Calificaciones.Peso_Ar = Proyecto.Edificio.Indicador.Ar_Min
        Else
            Proyecto.Edificio.Calificaciones.Calificacion_Ar = "Se Tienen Muros Largos e Intermedios"
            Proyecto.Edificio.Calificaciones.Peso_Ar = Proyecto.Edificio.Indicador.Ar_Min
        End If
        L_Ar.Text = Proyecto.Edificio.Calificaciones.Calificacion_Ar
        L_Ar.Visible = True
        ICE += Proyecto.Edificio.Calificaciones.Peso_Ar

        '---------------------------- CÁLCULO DE PESO PARA EL ALR -----------------------------
        If Max_ALR <= 0.1 Then
            Cal_ALR = "Menor al 10%"
            Proyecto.Edificio.Calificaciones.Peso_ALR = Proyecto.Edificio.Indicador.ALR_Min
        ElseIf 0.1 < Max_ALR And Max_ALR <= 0.2 Then
            Cal_ALR = "Entre 10 % y 20%"
            Proyecto.Edificio.Calificaciones.Peso_ALR = Proyecto.Edificio.Indicador.ALR_Int
        ElseIf Max_ALR > 0.2 Then
            Cal_ALR = "Mayor al 20%"
            Proyecto.Edificio.Calificaciones.Peso_ALR = Proyecto.Edificio.Indicador.ALR_Max
        End If
        Proyecto.Edificio.Calificaciones.Calificacion_ALR = "Relación de Carga Axial " + Cal_ALR
        L_ALR.Text = Proyecto.Edificio.Calificaciones.Calificacion_ALR
        L_ALR.Visible = True
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
        ICE += Proyecto.Edificio.Calificaciones.Peso_Confinamiento

        Proyecto.Edificio.Calificaciones.ICE = ICE

        Tabla_Datos.Rows.Clear()
        Tabla_Resultados.Rows.Clear()
        Rellenar()

        'L_Grado.Text = "ICE= " + Convert.ToString(Proyecto.Edificio.Calificaciones.ICE)
        'If Proyecto.Edificio.Calificaciones.ICE <= 50 Then
        '    B_Rojo.Visible = True
        '    B_Amarillo.Visible = True
        '    B_Verde.Visible = False
        '    L_Grado.ForeColor = Color.Green
        'ElseIf Proyecto.Edificio.Calificaciones.ICE > 50 And Proyecto.Edificio.Calificaciones.ICE <= 70 Then
        '    B_Rojo.Visible = True
        '    B_Amarillo.Visible = False
        '    B_Verde.Visible = True
        '    L_Grado.ForeColor = Color.FromArgb(208, 203, 0)
        'ElseIf Proyecto.Edificio.Calificaciones.ICE > 70 Then
        '    B_Rojo.Visible = False
        '    B_Amarillo.Visible = True
        '    B_Verde.Visible = True
        '    L_Grado.ForeColor = Color.Red
        'End If


        ''----------------------- Grafico de la Densidad ---------------------
        'Grafico_Densidad.Series.Clear()
        'Dim Serie_DX As New Series
        'Grafico_Densidad.Series.Add(Serie_DX)
        'Serie_DX.ChartType = SeriesChartType.StackedColumn

        'Dim Serie_DY As New Series
        'Grafico_Densidad.Series.Add(Serie_DY)
        'Serie_DY.ChartType = SeriesChartType.StackedColumn

        'Serie_DX.LegendText = "X"
        'Serie_DY.LegendText = "Y"

        'If Proyecto.Edificio.Densidad_X < 2 Then
        '    Serie_DX.Color = Color.Red
        'ElseIf 2 <= Proyecto.Edificio.Densidad_X < 3 Then
        '    Serie_DX.Color = Color.Yellow
        'Else
        '    Serie_DX.Color = Color.Green
        'End If
        'If Proyecto.Edificio.Densidad_Y < 2 Then
        '    Serie_DY.Color = Color.Red
        'ElseIf 2 <= Proyecto.Edificio.Densidad_Y < 3 Then
        '    Serie_DY.Color = Color.Yellow
        'Else
        '    Serie_DY.Color = Color.Green
        'End If

        'Serie_DX.Points.AddXY("X", Proyecto.Edificio.Densidad_X)
        'Serie_DX.Points.AddXY("Y", 0)

        'Serie_DY.Points.AddXY("X", 0)
        'Serie_DY.Points.AddXY("Y", Proyecto.Edificio.Densidad_Y)

        ''----------------- Grafico de Cargas Axiales (ALR) ----------------
        'Dim List_B As List(Of Muro) = Proyecto.Edificio.ListaMuros_Protagonicos.FindAll(Function(P) P.Nivel_Carga = "Bajo")
        'Dim List_M As List(Of Muro) = Proyecto.Edificio.ListaMuros_Protagonicos.FindAll(Function(P) P.Nivel_Carga = "Medio")
        'Dim List_A As List(Of Muro) = Proyecto.Edificio.ListaMuros_Protagonicos.FindAll(Function(P) P.Nivel_Carga = "Alto")

        'Grafico_CargaAxial.Series.Clear()
        'Dim Serie_CargaBaja As New Series
        'Grafico_CargaAxial.Series.Add(Serie_CargaBaja)
        'Serie_CargaBaja.ChartType = SeriesChartType.StackedColumn
        'Serie_CargaBaja.Color = Color.Green

        'Dim Serie_CargaMedia As New Series
        'Grafico_CargaAxial.Series.Add(Serie_CargaMedia)
        'Serie_CargaMedia.ChartType = SeriesChartType.StackedColumn
        'Serie_CargaMedia.Color = Color.Yellow

        'Dim Serie_CargaAlta As New Series
        'Grafico_CargaAxial.Series.Add(Serie_CargaAlta)
        'Serie_CargaAlta.ChartType = SeriesChartType.StackedColumn
        'Serie_CargaAlta.Color = Color.Red

        'Serie_CargaBaja.Points.AddXY("<10%", List_B.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count * 100)
        'Serie_CargaBaja.Points.AddXY("10%-20%", 0)
        'Serie_CargaBaja.Points.AddXY(">20%", 0)

        'Serie_CargaMedia.Points.AddXY("<10%", 0)
        'Serie_CargaMedia.Points.AddXY("10%-20%", List_M.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count * 100)
        'Serie_CargaMedia.Points.AddXY(">20%", 0)

        'Serie_CargaAlta.Points.AddXY("<10%", 0)
        'Serie_CargaAlta.Points.AddXY("10%-20%", 0)
        'Serie_CargaAlta.Points.AddXY(">20%", List_A.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count * 100)

        ''------------------ Grafico del confinamiento ---------------------------------
        'Grafico_Confinamiento.Series.Clear()
        'Dim Lista_MurosConfinados As List(Of Muro) = Proyecto.Edificio.ListaMuros_Protagonicos.FindAll(Function(P) P.Confinamiento = "Si")
        'Dim Serie_MConfinados As New Series
        'Grafico_Confinamiento.Series.Add(Serie_MConfinados)
        'Serie_MConfinados.ChartType = SeriesChartType.StackedColumn
        'Serie_MConfinados.Color = Color.Green

        'Dim Serie_MNoConfinados As New Series
        'Grafico_Confinamiento.Series.Add(Serie_MNoConfinados)
        'Serie_MNoConfinados.ChartType = SeriesChartType.StackedColumn
        'Serie_MNoConfinados.Color = Color.Red

        'Serie_MConfinados.Points.AddXY("Confinados", Lista_MurosConfinados.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count * 100)
        'Serie_MConfinados.Points.AddXY("Sin Confinamiento", 0)

        'Serie_MNoConfinados.Points.AddXY("Confinados", 0)
        'Serie_MNoConfinados.Points.AddXY("Sin Confinamiento", (1 - Lista_MurosConfinados.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count) * 100)

        ''------------------------ Tipo de Muro ------------------------------
        'Grafico_Esbeltez.Series.Clear()
        'Dim Lista_MurosLargos As List(Of Muro) = Proyecto.Edificio.ListaMuros_Protagonicos.FindAll(Function(P) P.Tipo_Muro = "Largo")
        'Dim Lista_MurosIntemedios As List(Of Muro) = Proyecto.Edificio.ListaMuros_Protagonicos.FindAll(Function(P) P.Tipo_Muro = "Intermedio")
        'Dim Lista_MurosCortos As List(Of Muro) = Proyecto.Edificio.ListaMuros_Protagonicos.FindAll(Function(P) P.Tipo_Muro = "Corto")

        'Dim Serie_MLargos As New Series
        'Grafico_Esbeltez.Series.Add(Serie_MLargos)
        'Serie_MLargos.ChartType = SeriesChartType.StackedColumn
        'Serie_MLargos.Color = Color.Green

        'Dim Serie_MIntermedios As New Series
        'Grafico_Esbeltez.Series.Add(Serie_MIntermedios)
        'Serie_MIntermedios.ChartType = SeriesChartType.StackedColumn
        'Serie_MIntermedios.Color = Color.Yellow

        'Dim Serie_MCortos As New Series
        'Grafico_Esbeltez.Series.Add(Serie_MCortos)
        'Serie_MCortos.ChartType = SeriesChartType.StackedColumn
        'Serie_MCortos.Color = Color.Red

        'Serie_MLargos.Points.AddXY("Largos          (Ar <= 4)", Lista_MurosLargos.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count * 100)
        'Serie_MLargos.Points.AddXY("Intermedios     (4 < Ar <= 10)", 0)
        'Serie_MLargos.Points.AddXY("Cortos          (10 < Ar)", 0)

        'Serie_MIntermedios.Points.AddXY("Largos          (Ar <= 4)", 0)
        'Serie_MIntermedios.Points.AddXY("Intermedios    (4 < Ar <= 10)", Lista_MurosIntemedios.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count * 100)
        'Serie_MIntermedios.Points.AddXY("Cortos          (10 < Ar)", 0)

        'Serie_MCortos.Points.AddXY("Largos          (Ar <= 4)", 0)
        'Serie_MCortos.Points.AddXY("Intermedios     (4 < Ar <= 10)", 0)
        'Serie_MCortos.Points.AddXY("Cortos          (10 < Ar)", Lista_MurosCortos.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count * 100)

        Panel_Geometria.Visible = False
        Panel_Informacion.Visible = True
        Panel_Resultados.Visible = False
        Panel_Informacion.Dock = DockStyle.Fill
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
        If Form_03_ICE.WindowState = FormWindowState.Minimized Then
            Form_03_ICE.WindowState = FormWindowState.Normal
        End If
        Try
            For i = 0 To 6
                Form_03_ICE.Tabla_PesoICE.Rows.Add()
            Next

            Form_03_ICE.Tabla_PesoICE.Rows(0).Cells(0).Value = "Densidad"
            Form_03_ICE.Tabla_PesoICE.Rows(1).Cells(0).Value = "No. Pisos"
            Form_03_ICE.Tabla_PesoICE.Rows(2).Cells(0).Value = "Factor de Forma"
            Form_03_ICE.Tabla_PesoICE.Rows(3).Cells(0).Value = "Ar"
            Form_03_ICE.Tabla_PesoICE.Rows(4).Cells(0).Value = "ALR"
            Form_03_ICE.Tabla_PesoICE.Rows(5).Cells(0).Value = "Amenaza"
            Form_03_ICE.Tabla_PesoICE.Rows(6).Cells(0).Value = "Esbeltez"
            Form_03_ICE.Tabla_PesoICE.Rows(7).Cells(0).Value = "Confinamiento"

            If Proyecto.Edificio.Indicador.T_Mod = False Then
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
                Form_03_ICE.T_PFS.Text = Proyecto.Edificio.Porcentaje_FSMuros
            End If

            Form_03_ICE.Tabla_PesoICE.Rows(0).Cells(1).Value = Proyecto.Edificio.Indicador.Densidad_Max
            Form_03_ICE.Tabla_PesoICE.Rows(1).Cells(1).Value = Proyecto.Edificio.Indicador.Num_Pisos_Max
            Form_03_ICE.Tabla_PesoICE.Rows(2).Cells(1).Value = Proyecto.Edificio.Indicador.Factor_Forma_Max
            Form_03_ICE.Tabla_PesoICE.Rows(3).Cells(1).Value = Proyecto.Edificio.Indicador.Ar_Max
            Form_03_ICE.Tabla_PesoICE.Rows(4).Cells(1).Value = Proyecto.Edificio.Indicador.ALR_Max
            Form_03_ICE.Tabla_PesoICE.Rows(5).Cells(1).Value = Proyecto.Edificio.Indicador.Amenaza_Max
            Form_03_ICE.Tabla_PesoICE.Rows(6).Cells(1).Value = Proyecto.Edificio.Indicador.Esbeltez_Max
            Form_03_ICE.Tabla_PesoICE.Rows(7).Cells(1).Value = Proyecto.Edificio.Indicador.Confinamiento_Max

            Form_03_ICE.Tabla_PesoICE.Rows(0).Cells(2).Value = Proyecto.Edificio.Indicador.Densidad_Int
            Form_03_ICE.Tabla_PesoICE.Rows(1).Cells(2).Value = Proyecto.Edificio.Indicador.Num_Pisos_Int
            Form_03_ICE.Tabla_PesoICE.Rows(2).Cells(2).Value = Proyecto.Edificio.Indicador.Factor_Forma_Int
            Form_03_ICE.Tabla_PesoICE.Rows(3).Cells(2).Value = Proyecto.Edificio.Indicador.Ar_Int
            Form_03_ICE.Tabla_PesoICE.Rows(4).Cells(2).Value = Proyecto.Edificio.Indicador.ALR_Int
            Form_03_ICE.Tabla_PesoICE.Rows(5).Cells(2).Value = Proyecto.Edificio.Indicador.Amenaza_Int
            Form_03_ICE.Tabla_PesoICE.Rows(6).Cells(2).Value = Proyecto.Edificio.Indicador.Esbeltez_Int
            Form_03_ICE.Tabla_PesoICE.Rows(7).Cells(2).Value = Proyecto.Edificio.Indicador.Confinamiento_Int

            Form_03_ICE.Tabla_PesoICE.Rows(0).Cells(3).Value = Proyecto.Edificio.Indicador.Densidad_Min
            Form_03_ICE.Tabla_PesoICE.Rows(1).Cells(3).Value = Proyecto.Edificio.Indicador.Num_Pisos_Min
            Form_03_ICE.Tabla_PesoICE.Rows(2).Cells(3).Value = Proyecto.Edificio.Indicador.Factor_Forma_Min
            Form_03_ICE.Tabla_PesoICE.Rows(3).Cells(3).Value = Proyecto.Edificio.Indicador.Ar_Min
            Form_03_ICE.Tabla_PesoICE.Rows(4).Cells(3).Value = Proyecto.Edificio.Indicador.ALR_Min
            Form_03_ICE.Tabla_PesoICE.Rows(5).Cells(3).Value = Proyecto.Edificio.Indicador.Amenaza_Min
            Form_03_ICE.Tabla_PesoICE.Rows(6).Cells(3).Value = Proyecto.Edificio.Indicador.Esbeltez_Min
            Form_03_ICE.Tabla_PesoICE.Rows(7).Cells(3).Value = Proyecto.Edificio.Indicador.Confinamiento_Min

        Catch ex As Exception
        Finally
            Form_03_ICE.Show()
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
        Form_02_PlantaEstructura.T_LargoE.Text = Proyecto.Edificio.Dimension_Longitud
        Form_02_PlantaEstructura.T_AnchoE.Text = Proyecto.Edificio.Dimension_Transversal
        Form_02_PlantaEstructura.Show()
    End Sub

    Private Sub IngresarImagenDelProyectoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarImagenDelProyectoToolStripMenuItem.Click
        Form_05_AspectosGenerales.T_NameProjet.Text = Proyecto.Nombre
        Form_05_AspectosGenerales.T_Direction.Text = Proyecto.Direccion
        Form_05_AspectosGenerales.T_City.Text = Proyecto.Ciudad
        Form_05_AspectosGenerales.T_Department.Text = Proyecto.Departamento

        Form_05_AspectosGenerales.Show()
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
        Form_02_PlantaEstructura.T_AnchoE.Text = ""
        Form_02_PlantaEstructura.T_LargoE.Text = ""

        Form_01_Cargas.Tabla_Cargas.Rows.Clear()
        Tabla_Datos.Rows.Clear()
        Tabla_Resultados.Rows.Clear()
        Proyecto.Edificio.ListaMuros.Clear()
        Proyecto.Edificio.ListaMuros_Protagonicos.Clear()
        Form_05_AspectosGenerales.T_NameProjet.Text = ""
        Form_05_AspectosGenerales.T_Direction.Text = ""
        Form_05_AspectosGenerales.T_City.Text = ""
        Form_05_AspectosGenerales.T_Department.Text = ""

        Proyecto.Nombre = ""
        Proyecto.Ruta_Imagen = ""
        Proyecto.Ciudad = ""
        Proyecto.Departamento = ""
        Proyecto.Direccion = ""
        Proyecto.Edificio.Dimension_Longitud = 0
        Proyecto.Edificio.Dimension_Transversal = 0
        Proyecto.Edificio.Area = 0
        Proyecto.Edificio.AreaM_X = 0
        Proyecto.Edificio.AreaM_Y = 0
        Proyecto.Edificio.Densidad_X = 0
        Proyecto.Edificio.Densidad_Y = 0
        Proyecto.Edificio.fc = 21
        Proyecto.Edificio.Ht = 0
        Proyecto.Edificio.Num_P = 0


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

        For i = 0 To Proyecto.Edificio.ListaMuros.Count() - 1
            Tabla_Datos.Rows.Add()
        Next

        If Proyecto.Edificio.Solo_MRectangulares = False Then
            Tabla_Datos.Columns.Add("Columns7", "Longitud (Lw2)")
            Tabla_Datos.Columns.Add("Columns8", "Espesor (tw2)")
            Tabla_Datos.Columns(5).HeaderText = "Longitud (Lw2) (m)"
            Tabla_Datos.Columns(6).HeaderText = "Espesor (tw2) (m)"
            Tabla_Datos.Columns(7).HeaderText = "Sismo X (%)"
            Tabla_Datos.Columns(8).HeaderText = "Sismo Y (%)"
        End If

        For i = 0 To Proyecto.Edificio.ListaMuros.Count() - 1
            Tabla_Datos.Rows(i).Cells(0).Value = Proyecto.Edificio.ListaMuros(i).Name
            Tabla_Datos.Rows(i).Cells(1).Value = Proyecto.Edificio.ListaMuros(i).T_Muro
            Tabla_Datos.Rows(i).Cells(2).Value = Proyecto.Edificio.ListaMuros(i).Direccion
            Tabla_Datos.Rows(i).Cells(3).Value = Proyecto.Edificio.ListaMuros(i).Lw
            Tabla_Datos.Rows(i).Cells(4).Value = Proyecto.Edificio.ListaMuros(i).tw
            Tabla_Datos.Rows(i).Cells(5).Value = Math.Round(Proyecto.Edificio.ListaMuros(i).SismoX, 2)
            Tabla_Datos.Rows(i).Cells(6).Value = Math.Round(Proyecto.Edificio.ListaMuros(i).SismoY, 2)
            If Proyecto.Edificio.Solo_MRectangulares = False Then
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
            Tabla_Resultados.Rows(i).Cells(7).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).ALR_CM * 100, 2)
            Tabla_Resultados.Rows(i).Cells(8).Value = Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).ALR_CU * 100, 2)
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
        P_0.Visible = True

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
            P_7.Visible = True
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
        L_Grado.Visible = True

        Button6.Visible = True
        Button7.Visible = True
        Button8.Visible = True
        Button9.Visible = True

        Grafico_Densidad.Dock = DockStyle.Fill
        Grafico_CargaAxial.Dock = DockStyle.Fill
        Grafico_Confinamiento.Dock = DockStyle.Fill
        Grafico_Esbeltez.Dock = DockStyle.Fill
        Grafico_Densidad.Visible = True

        '----------------------- Grafico de la Densidad ---------------------
        Grafico_Densidad.Series.Clear()
        Dim Serie_DX As New Series
        Grafico_Densidad.Series.Add(Serie_DX)
        Serie_DX.ChartType = SeriesChartType.StackedColumn

        Dim Serie_DY As New Series
        Grafico_Densidad.Series.Add(Serie_DY)
        Serie_DY.ChartType = SeriesChartType.StackedColumn

        Serie_DX.LegendText = "X"
        Serie_DY.LegendText = "Y"

        If Proyecto.Edificio.Densidad_X < 2 Then
            Serie_DX.Color = Color.Red
        ElseIf 2 <= Proyecto.Edificio.Densidad_X < 3 Then
            Serie_DX.Color = Color.Yellow
        Else
            Serie_DX.Color = Color.Green
        End If
        If Proyecto.Edificio.Densidad_Y < 2 Then
            Serie_DY.Color = Color.Red
        ElseIf 2 <= Proyecto.Edificio.Densidad_Y < 3 Then
            Serie_DY.Color = Color.Yellow
        Else
            Serie_DY.Color = Color.Green
        End If

        Serie_DX.Points.AddXY("X", Proyecto.Edificio.Densidad_X)
        Serie_DX.Points.AddXY("Y", 0)

        Serie_DY.Points.AddXY("X", 0)
        Serie_DY.Points.AddXY("Y", Proyecto.Edificio.Densidad_Y)

        '----------------- Grafico de Cargas Axiales (ALR) ----------------
        Dim List_B As List(Of Muro) = Proyecto.Edificio.ListaMuros_Protagonicos.FindAll(Function(P) P.Nivel_Carga = "Bajo")
        Dim List_M As List(Of Muro) = Proyecto.Edificio.ListaMuros_Protagonicos.FindAll(Function(P) P.Nivel_Carga = "Medio")
        Dim List_A As List(Of Muro) = Proyecto.Edificio.ListaMuros_Protagonicos.FindAll(Function(P) P.Nivel_Carga = "Alto")

        Grafico_CargaAxial.Series.Clear()
        Dim Serie_CargaBaja As New Series
        Grafico_CargaAxial.Series.Add(Serie_CargaBaja)
        Serie_CargaBaja.ChartType = SeriesChartType.StackedColumn
        Serie_CargaBaja.Color = Color.Green

        Dim Serie_CargaMedia As New Series
        Grafico_CargaAxial.Series.Add(Serie_CargaMedia)
        Serie_CargaMedia.ChartType = SeriesChartType.StackedColumn
        Serie_CargaMedia.Color = Color.Yellow

        Dim Serie_CargaAlta As New Series
        Grafico_CargaAxial.Series.Add(Serie_CargaAlta)
        Serie_CargaAlta.ChartType = SeriesChartType.StackedColumn
        Serie_CargaAlta.Color = Color.Red

        Serie_CargaBaja.Points.AddXY("<10%", List_B.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count * 100)
        Serie_CargaBaja.Points.AddXY("10%-20%", 0)
        Serie_CargaBaja.Points.AddXY(">20%", 0)

        Serie_CargaMedia.Points.AddXY("<10%", 0)
        Serie_CargaMedia.Points.AddXY("10%-20%", List_M.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count * 100)
        Serie_CargaMedia.Points.AddXY(">20%", 0)

        Serie_CargaAlta.Points.AddXY("<10%", 0)
        Serie_CargaAlta.Points.AddXY("10%-20%", 0)
        Serie_CargaAlta.Points.AddXY(">20%", List_A.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count * 100)


        Grafico_CargaAxial.Series.Clear()
        Dim Serie_ALR As New Series
        Serie_ALR.ChartType = SeriesChartType.Pie
        Serie_ALR.Font = New Drawing.Font("Arial", 10)
        Grafico_CargaAxial.Series.Add(Serie_ALR)

        Dim Punto_ALR_Bajo As New DataPoint
        If List_B.Count > 0 Then
            Punto_ALR_Bajo.YValues(0) = List_B.Count
            Punto_ALR_Bajo.Label = "#PERCENT{P0}"
        Else
            Punto_ALR_Bajo.IsEmpty = True
        End If
        Punto_ALR_Bajo.LegendText = "ALR<=10%"

        Dim Punto_ALR_Medio As New DataPoint
        If List_M.Count > 0 Then
            Punto_ALR_Medio.YValues(0) = List_M.Count
            Punto_ALR_Medio.Label = "#PERCENT{P0}"
        Else
            Punto_ALR_Medio.IsEmpty = True
        End If
        Punto_ALR_Medio.LegendText = "10%<ALR<=20%"

        Dim Punto_ALR_Alto As New DataPoint
        If List_A.Count > 0 Then
            Punto_ALR_Alto.YValues(0) = List_A.Count
            Punto_ALR_Alto.Label = "#PERCENT{P0}"
        Else
            Punto_ALR_Alto.IsEmpty = True
        End If
        Punto_ALR_Alto.LegendText = "20%<ALR"

        Serie_ALR.Points.Add(Punto_ALR_Bajo)
        Serie_ALR.Points.Add(Punto_ALR_Medio)
        Serie_ALR.Points.Add(Punto_ALR_Alto)


        '------------------ Grafico del confinamiento ---------------------------------
        Grafico_Confinamiento.Series.Clear()
        Dim Lista_MurosConfinados As List(Of Muro) = Proyecto.Edificio.ListaMuros_Protagonicos.FindAll(Function(P) P.Confinamiento = "Si")
        Dim Serie_MConfinados As New Series
        Grafico_Confinamiento.Series.Add(Serie_MConfinados)
        Serie_MConfinados.ChartType = SeriesChartType.StackedColumn
        Serie_MConfinados.Color = Color.Green

        Dim Serie_MNoConfinados As New Series
        Grafico_Confinamiento.Series.Add(Serie_MNoConfinados)
        Serie_MNoConfinados.ChartType = SeriesChartType.StackedColumn
        Serie_MNoConfinados.Color = Color.Red

        Serie_MConfinados.Points.AddXY("Confinados", Lista_MurosConfinados.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count * 100)
        Serie_MConfinados.Points.AddXY("Sin Confinamiento", 0)

        Serie_MNoConfinados.Points.AddXY("Confinados", 0)
        Serie_MNoConfinados.Points.AddXY("Sin Confinamiento", (1 - Lista_MurosConfinados.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count) * 100)

        Grafico_Confinamiento.Series.Clear()
        Dim Serie_Confinamiento As New Series
        Serie_Confinamiento.ChartType = SeriesChartType.Pie
        Serie_Confinamiento.Font = New Drawing.Font("Arial", 10)
        Grafico_Confinamiento.Series.Add(Serie_Confinamiento)

        Dim Punto_Confinados As New DataPoint
        If Lista_MurosConfinados.Count > 0 Then
            Punto_Confinados.YValues(0) = Lista_MurosConfinados.Count
            Punto_Confinados.Label = "#PERCENT{P0}"
        Else
            Punto_Confinados.IsEmpty = True
        End If
        Punto_Confinados.LegendText = "Confinados"

        Dim Punto_NoConfinados As New DataPoint
        If (1 - Lista_MurosConfinados.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count) * 100 > 0 Then
            Punto_NoConfinados.YValues(0) = (Proyecto.Edificio.ListaMuros_Protagonicos.Count - Lista_MurosConfinados.Count)
            'Punto_NoConfinados.YValues(0) = (1 - Lista_MurosConfinados.Count / Proyecto.Edificio.ListaMuros_Protagonicos.Count) * 100
            Punto_NoConfinados.Label = "#PERCENT{P0}"
        Else
            Punto_NoConfinados.IsEmpty = True
        End If
        Punto_NoConfinados.LegendText = "Sin confinamiento"

        Serie_Confinamiento.Points.Add(Punto_Confinados)
        Serie_Confinamiento.Points.Add(Punto_NoConfinados)

        '------------------------ Tipo de Muro ------------------------------
        Grafico_Esbeltez.Series.Clear()
        Dim Lista_MurosLargos As List(Of Muro) = Proyecto.Edificio.ListaMuros_Protagonicos.FindAll(Function(P) P.Tipo_Muro = "Largo")
        Dim Lista_MurosIntemedios As List(Of Muro) = Proyecto.Edificio.ListaMuros_Protagonicos.FindAll(Function(P) P.Tipo_Muro = "Intermedio")
        Dim Lista_MurosCortos As List(Of Muro) = Proyecto.Edificio.ListaMuros_Protagonicos.FindAll(Function(P) P.Tipo_Muro = "Corto")

        'Grafico_Esbeltez.Series.Clear()
        'Dim Leyenda_Graf As New Legend
        'Leyenda_Graf.Alignment = StringAlignment.Center
        'Leyenda_Graf.DockedToChartArea = "ChartArea1"
        'Leyenda_Graf.Docking = Docking.Bottom
        'Leyenda_Graf.Font = New Drawing.Font("Arial", 9)
        'Leyenda_Graf.IsDockedInsideChartArea = False
        'Leyenda_Graf.Enabled = True
        'Grafico_Esbeltez.Legends.Add(Leyenda_Graf)
        Grafico_Tipo_Muro.Series("Series1").Points.Clear()

        Dim Punto_Muros_Largos As New DataPoint
        If Lista_MurosLargos.Count > 0 Then
            Punto_Muros_Largos.YValues(0) = Lista_MurosLargos.Count
            Punto_Muros_Largos.Label = "#PERCENT{P0}"
        Else
            Punto_Muros_Largos.IsEmpty = True
        End If
        Punto_Muros_Largos.LegendText = "Largos (Ar<=4)"

        Dim Punto_Muros_Intermedios As New DataPoint

        If Lista_MurosIntemedios.Count > 0 Then
            Punto_Muros_Intermedios.YValues(0) = Lista_MurosIntemedios.Count
            Punto_Muros_Intermedios.Label = "#PERCENT{P0}"
        Else
            Punto_Muros_Intermedios.IsEmpty = True
        End If
        Punto_Muros_Intermedios.LegendText = "Intermedios (4<Ar<=10)"

        Dim Punto_Muros_Cortos As New DataPoint

        If Lista_MurosCortos.Count > 0 Then
            Punto_Muros_Cortos.YValues(0) = Lista_MurosCortos.Count
            Punto_Muros_Cortos.Label = "#PERCENT{P0}"
        Else
            Punto_Muros_Cortos.IsEmpty = True
        End If
        Punto_Muros_Cortos.LegendText = "Cortos (10<Ar)"

        Grafico_Tipo_Muro.Series("Series1").Points.Add(Punto_Muros_Largos)
        Grafico_Tipo_Muro.Series("Series1").Points.Add(Punto_Muros_Intermedios)
        Grafico_Tipo_Muro.Series("Series1").Points.Add(Punto_Muros_Cortos)

    End Sub

    Private Sub NuevoProyectoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoProyectoToolStripMenuItem.Click
        Limpiar()
    End Sub

    Private Sub AcercaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaToolStripMenuItem.Click
        Form_06_Acerca.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Grafico_Densidad.Visible = True
        Grafico_CargaAxial.Visible = False
        Grafico_Confinamiento.Visible = False
        Grafico_Tipo_Muro.Visible = False

        Grafico_Densidad.Dock = DockStyle.Fill
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Grafico_Densidad.Visible = False
        Grafico_CargaAxial.Visible = True
        Grafico_Confinamiento.Visible = False
        Grafico_Tipo_Muro.Visible = False

        Grafico_CargaAxial.Dock = DockStyle.Fill
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Grafico_Densidad.Visible = False
        Grafico_CargaAxial.Visible = False
        Grafico_Confinamiento.Visible = False
        'Grafico_Esbeltez.Visible = True
        Grafico_Tipo_Muro.Visible = True

        'Grafico_Esbeltez.Dock = DockStyle.Fill
        Grafico_Tipo_Muro.Dock = DockStyle.Fill
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Grafico_Densidad.Visible = False
        Grafico_CargaAxial.Visible = False
        Grafico_Confinamiento.Visible = True
        Grafico_Tipo_Muro.Visible = False
        Grafico_Confinamiento.Dock = DockStyle.Fill
    End Sub



    '------------------------ CREAR REPORTE A PDF ------------------------
    Private Sub ExportarPDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarPDFToolStripMenuItem.Click
        Dim pdfDoc As New Document
        pdfDoc.SetMargins(40.0F, 40.0F, 70.0F, 40.0F)

        Dim SaveAs As New SaveFileDialog
        SaveAs.Filter = "Archivo|*.pdf"
        SaveAs.Title = "Guardar Archivo"
        SaveAs.ShowDialog()

        Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(SaveAs.FileName, FileMode.Create))
        Dim Events As New MypageEvents
        pdfWrite.PageEvent = Events

        pdfDoc.Open()

        '------------------------ Fuentes para el documento ---------------------------
        Dim Arial As BaseFont = BaseFont.CreateFont("c:\windows\fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
        Dim Font_Titulos As New Font(Arial, 12, FontStyle.Bold)
        Dim Font_Titulos_11 As New Font(Arial, 11, FontStyle.Bold)
        Dim Font_Titulos_10 As New Font(Arial, 10, FontStyle.Bold)
        Dim Font_Figura As New Font(Arial, 10)

        pdfDoc.Add(Chunk.NEWLINE)

        Dim Parrafo As New Paragraph
        Parrafo.Alignment = Element.ALIGN_CENTER
        Parrafo.Font = Font_Titulos
        Parrafo.Add("DIAGNÓSTICO CONCEPTUAL DE LA CONFIGURACIÓN ESTRUCTURAL")
        pdfDoc.Add(Parrafo)

        pdfDoc.Add(Chunk.NEWLINE)

        Dim TablaInformacion As New PdfPTable(2)
        'TablaInfo.TotalWidth = pdfDoc.PageSize.Width - pdfDoc.LeftMargin - pdfDoc.RightMargin
        Dim Lista As Single() = {30.0F, 70.0F}

        TablaInformacion.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
        TablaInformacion.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER

        Dim Header As New PdfPCell
        Header.Colspan = 2
        Header.HorizontalAlignment = Element.ALIGN_CENTER
        Header.Phrase = New Phrase("ASPECTOS GENERALES DEL PROYECTO", Font_Titulos)

        TablaInformacion.SetWidths(Lista)
        TablaInformacion.AddCell(Header)

        Dim Cell_Imagen As New PdfPCell
        Cell_Imagen.Colspan = 2
        Dim Imagen_Proyecto As Image = Image.GetInstance(Form_00_Principal.Proyecto.Ruta_Imagen)
        Imagen_Proyecto.ScalePercent(10.0F)
        Cell_Imagen.Image = Imagen_Proyecto
        TablaInformacion.AddCell(Cell_Imagen)

        TablaInformacion.AddCell(New Phrase("Nombre del Proyecto", Font_Titulos_11))
        TablaInformacion.AddCell(Proyecto.Nombre)

        TablaInformacion.AddCell(New Phrase("Dirección", Font_Titulos_11))
        TablaInformacion.AddCell(Proyecto.Direccion)

        TablaInformacion.AddCell(New Phrase("Ciudad/Municipio", Font_Titulos_11))
        TablaInformacion.AddCell(Proyecto.Ciudad)

        TablaInformacion.AddCell(New Phrase("Departamento", Font_Titulos_11))
        TablaInformacion.AddCell(Proyecto.Departamento)

        pdfDoc.Add(TablaInformacion)

        pdfDoc.Add(Chunk.NEWLINE)

        Dim Tabla_MurosProtagonicos As New PdfPTable(6)
        Tabla_MurosProtagonicos.SpacingAfter = 12
        Tabla_MurosProtagonicos.SpacingBefore = 2
        Tabla_MurosProtagonicos.PaddingTop = 0
        Tabla_MurosProtagonicos.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        Tabla_MurosProtagonicos.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER
        Tabla_MurosProtagonicos.HeaderRows = 1

        pdfDoc.Add(Titulo_Figura("Tabla 1.   ", "Parámetros de Muros protagónicos - 1.", "Tabla"))

        Tabla_MurosProtagonicos.AddCell(New Phrase("Nombre", Font_Titulos_10))
        Tabla_MurosProtagonicos.AddCell(New Phrase("Forma", Font_Titulos_10))
        Tabla_MurosProtagonicos.AddCell(New Phrase("Dirección", Font_Titulos_10))
        Tabla_MurosProtagonicos.AddCell(New Phrase("Sismo X (%)", Font_Titulos_10))
        Tabla_MurosProtagonicos.AddCell(New Phrase("Sismo Y (%)", Font_Titulos_10))
        Tabla_MurosProtagonicos.AddCell(New Phrase("Esbeltez", Font_Titulos_10))

        For i = 0 To Proyecto.Edificio.ListaMuros_Protagonicos.Count - 1
            Tabla_MurosProtagonicos.AddCell(New Phrase(Proyecto.Edificio.ListaMuros_Protagonicos(i).Name, Font_Figura))
            Tabla_MurosProtagonicos.AddCell(New Phrase(TipodeMuro(Proyecto.Edificio.ListaMuros_Protagonicos(i).T_Muro), Font_Figura))
            Tabla_MurosProtagonicos.AddCell(New Phrase(Proyecto.Edificio.ListaMuros_Protagonicos(i).Direccion, Font_Figura))
            Tabla_MurosProtagonicos.AddCell(New Phrase(Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).SismoX * 100, 1), Font_Figura))
            Tabla_MurosProtagonicos.AddCell(New Phrase(Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).SismoY * 100, 1), Font_Figura))
            Tabla_MurosProtagonicos.AddCell(New Phrase(Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).Esbeltez, 0), Font_Figura))
        Next
        pdfDoc.Add(Tabla_MurosProtagonicos)

        Dim Tabla_MurosProtagonicos_1 As New PdfPTable(7)
        Tabla_MurosProtagonicos_1.SpacingBefore = 2
        Tabla_MurosProtagonicos_1.SpacingAfter = 12
        Tabla_MurosProtagonicos_1.PaddingTop = 0
        Tabla_MurosProtagonicos_1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        Tabla_MurosProtagonicos_1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER
        Tabla_MurosProtagonicos_1.HeaderRows = 1

        pdfDoc.Add(Titulo_Figura("Tabla 2.   ", "Parámetros de Muros protagónicos - 2.", "Tabla"))
        Tabla_MurosProtagonicos_1.AddCell(New Phrase("Nombre", Font_Titulos_10))
        Tabla_MurosProtagonicos_1.AddCell(New Phrase("Ar X", Font_Titulos_10))
        Tabla_MurosProtagonicos_1.AddCell(New Phrase("Ar Y", Font_Titulos_10))
        Tabla_MurosProtagonicos_1.AddCell(New Phrase("Tipo", Font_Titulos_10))
        Tabla_MurosProtagonicos_1.AddCell(New Phrase("ALR (%)", Font_Titulos_10))
        Tabla_MurosProtagonicos_1.AddCell(New Phrase("Nivel de carga", Font_Titulos_10))
        Tabla_MurosProtagonicos_1.AddCell(New Phrase("Confinado", Font_Titulos_10))

        For i = 0 To Proyecto.Edificio.ListaMuros_Protagonicos.Count - 1
            Tabla_MurosProtagonicos_1.AddCell(New Phrase(Proyecto.Edificio.ListaMuros_Protagonicos(i).Name, Font_Figura))
            Tabla_MurosProtagonicos_1.AddCell(New Phrase(Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).AR_X, 1), Font_Figura))
            Tabla_MurosProtagonicos_1.AddCell(New Phrase(Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).AR_Y, 1), Font_Figura))
            Tabla_MurosProtagonicos_1.AddCell(New Phrase(Proyecto.Edificio.ListaMuros_Protagonicos(i).Tipo_Muro, Font_Figura))
            Tabla_MurosProtagonicos_1.AddCell(New Phrase(Math.Round(Proyecto.Edificio.ListaMuros_Protagonicos(i).ALR_CU, 1), Font_Figura))
            Tabla_MurosProtagonicos_1.AddCell(New Phrase(Proyecto.Edificio.ListaMuros_Protagonicos(i).Nivel_Carga, Font_Figura))
            Tabla_MurosProtagonicos_1.AddCell(New Phrase(Proyecto.Edificio.ListaMuros_Protagonicos(i).Confinamiento, Font_Figura))
        Next
        pdfDoc.Add(Tabla_MurosProtagonicos_1)

        '-------------------------- INSERTAR TABLA CON GRÁFICOS DE PARÁMETROS GLOBALES DE LA ESTRUCTURA --------------------
        Grafico_Densidad.Dock = DockStyle.Fill
        Grafico_CargaAxial.Dock = DockStyle.Fill
        Grafico_Esbeltez.Dock = DockStyle.Fill
        Grafico_Confinamiento.Dock = DockStyle.Fill

        Grafico_Densidad.BackColor = Color.White
        Grafico_CargaAxial.BackColor = Color.White
        Grafico_Esbeltez.BackColor = Color.White
        Grafico_Tipo_Muro.BackColor = Color.White
        Grafico_Confinamiento.BackColor = Color.White

        Grafico_Densidad.SaveImage(Application.StartupPath & "\Densidad.bmp", System.Drawing.Imaging.ImageFormat.Bmp)
        Grafico_CargaAxial.SaveImage(Application.StartupPath & "\ALR.bmp", System.Drawing.Imaging.ImageFormat.Bmp)
        'Grafico_Esbeltez.SaveImage(Application.StartupPath & "\Esbeltez.png", System.Drawing.Imaging.ImageFormat.Png)
        Grafico_Tipo_Muro.SaveImage(Application.StartupPath & "\Esbeltez.bmp", System.Drawing.Imaging.ImageFormat.Bmp)
        Grafico_Confinamiento.SaveImage(Application.StartupPath & "\Confinamiento.bmp", System.Drawing.Imaging.ImageFormat.Bmp)

        Dim Table As New PdfPTable(2)
        Table.DefaultCell.Border = Rectangle.NO_BORDER
        Table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER

        Table.AddCell(Insertar_Figura(Image.GetInstance(Application.StartupPath & "\Densidad.bmp")))
        Table.AddCell(Insertar_Figura(Image.GetInstance(Application.StartupPath & "\ALR.bmp")))
        Table.AddCell(Titulo_Figura("A.   ", "Densidad de muros.", "Figura"))
        Table.AddCell(Titulo_Figura("B.   ", "Relación de carga axial.", "Figura"))
        Table.AddCell("         ")
        Table.AddCell("         ")

        Table.AddCell(Insertar_Figura(Image.GetInstance(Application.StartupPath & "\Confinamiento.bmp")))
        Table.AddCell(Insertar_Figura(Image.GetInstance(Application.StartupPath & "\Esbeltez.bmp")))

        Table.AddCell(Titulo_Figura("C.   ", "Confinamiento de muros.", "Figura"))
        Table.AddCell(Titulo_Figura("D.   ", "Tipos de muros.", "Figura"))

        pdfDoc.Add(Table)
        pdfDoc.Add(Titulo_Figura("Figura 1.     ", "Parámetros globales de la estructura.", "Figura"))

        pdfDoc.Add(Chunk.NEWLINE)

        '------------------------ IMPRIMIR TABLA CON CALIFICACIÓN --------------------------
        Dim Imagen_Semaforo As Image
        If Form_00_Principal.Proyecto.Edificio.Calificaciones.ICE <= 50 Then
            Form4.Imagen_Semaforo_Verde.Image.Save(Application.StartupPath & "\Semaforo_Verde.png", System.Drawing.Imaging.ImageFormat.Png)
            Imagen_Semaforo = Image.GetInstance(Application.StartupPath & "\Semaforo_Verde.png")
            Imagen_Semaforo.Alignment = Element.ALIGN_CENTER
        ElseIf 50 < Form_00_Principal.Proyecto.Edificio.Calificaciones.ICE And Form_00_Principal.Proyecto.Edificio.Calificaciones.ICE <= 70 Then
            Form4.Imagen_Semaforo_Amarillo.Image.Save(Application.StartupPath & "\Semaforo_Amarillo.png", System.Drawing.Imaging.ImageFormat.Png)
            Imagen_Semaforo = Image.GetInstance(Application.StartupPath & "\Semaforo_Amarillo.png")
            Imagen_Semaforo.Alignment = Element.ALIGN_CENTER
        Else
            Form4.Imagen_Semaforo_Rojo.Image.Save(Application.StartupPath & "\Semaforo_Rojo.png", System.Drawing.Imaging.ImageFormat.Png)
            Imagen_Semaforo = Image.GetInstance(Application.StartupPath & "\Semaforo_Rojo.png")
            Imagen_Semaforo.Alignment = Element.ALIGN_CENTER
        End If
        Imagen_Semaforo.ScalePercent(10.0F)

        Dim Tabla_Calificaciones As New PdfPTable(3)
        Tabla_Calificaciones.SpacingBefore = 2
        Tabla_Calificaciones.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        Tabla_Calificaciones.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER
        Tabla_Calificaciones.PaddingTop = 0
        Dim Ancho_Col_Cal As Single() = {35.0F, 40.0F, 25.0F}
        Tabla_Calificaciones.SetWidths(Ancho_Col_Cal)

        pdfDoc.Add(Titulo_Figura("Tabla 3.   ", "Calificación de estructura.", "Tabla"))

        Dim Cell_Semaforo As New PdfPCell
        Cell_Semaforo.Rowspan = 8
        Cell_Semaforo.Image = Imagen_Semaforo

        Tabla_Calificaciones.AddCell(New Phrase("Parámetro", Font_Titulos_10))
        Tabla_Calificaciones.AddCell(New Phrase("Descripción", Font_Titulos_10))
        Tabla_Calificaciones.AddCell(New Phrase("Semáforo", Font_Titulos_10))

        Tabla_Calificaciones.AddCell(New Phrase("Densidad", Font_Figura))
        Tabla_Calificaciones.AddCell(New Phrase(Proyecto.Edificio.Calificaciones.Calificacion_Densidad, Font_Figura))
        Tabla_Calificaciones.AddCell(Cell_Semaforo)

        Tabla_Calificaciones.AddCell(New Phrase("Relación de aspecto (Ar)", Font_Figura))
        Tabla_Calificaciones.AddCell(New Phrase(Proyecto.Edificio.Calificaciones.Calificacion_Ar, Font_Figura))

        Tabla_Calificaciones.AddCell(New Phrase("Relación de carga axial (ALR)", Font_Figura))
        Tabla_Calificaciones.AddCell(New Phrase(Proyecto.Edificio.Calificaciones.Calificacion_ALR, Font_Figura))

        Tabla_Calificaciones.AddCell(New Phrase("Nivel de amenaza", Font_Figura))
        Tabla_Calificaciones.AddCell(New Phrase(Proyecto.Edificio.Calificaciones.Calificacion_Amenaza, Font_Figura))

        Tabla_Calificaciones.AddCell(New Phrase("Confinamiento", Font_Figura))
        Tabla_Calificaciones.AddCell(New Phrase(Proyecto.Edificio.Calificaciones.Calificacion_Confinamiento, Font_Figura))

        Tabla_Calificaciones.AddCell(New Phrase("Factor Forma", Font_Figura))
        Tabla_Calificaciones.AddCell(New Phrase(Proyecto.Edificio.Calificaciones.Calificacion_FactorForma, Font_Figura))

        Tabla_Calificaciones.AddCell(New Phrase("Esbeltez", Font_Figura))
        Tabla_Calificaciones.AddCell(New Phrase(Proyecto.Edificio.Calificaciones.Calificacion_Esbeltez, Font_Figura))

        Tabla_Calificaciones.AddCell(New Phrase("Total", Font_Titulos_10))
        Tabla_Calificaciones.AddCell(New Phrase(Proyecto.Edificio.Calificaciones.ICE, Font_Titulos_10))

        pdfDoc.Add(Tabla_Calificaciones)

        pdfDoc.Add(Chunk.NEWLINE)

        pdfDoc.Close()

        Process.Start(SaveAs.FileName)

        '------------------- Eliminar archivos de ayuda ---------------
        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Densidad.bmp")
        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\ALR.bmp")
        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Esbeltez.bmp")
        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Confinamiento.bmp")

    End Sub



    Public Class MypageEvents
        Inherits PdfPageEventHelper
        Public Overrides Sub onStartPage(ByVal Writer As PdfWriter, ByVal Documento As Document)

            Form_06_Acerca.PictureBox1.Image.Save(Application.StartupPath & "\nueva.png", System.Drawing.Imaging.ImageFormat.Png)

            Dim Imagen As Image = Image.GetInstance(Application.StartupPath & "\nueva.png")
            Imagen.ScalePercent(50.0F)
            Imagen.SetAbsolutePosition(Documento.PageSize.Width - 1.1 * Imagen.Width / 2, Documento.PageSize.Height - 1.2 * Imagen.Height / 2)
            Imagen.Alignment = Image.ALIGN_RIGHT

            Documento.Add(Imagen)

        End Sub

    End Class


    Public Function Titulo_Figura(ByVal Figura1 As String, ByVal Figura2 As String, ByVal Tipo_Titulo As String)
        Dim arial As BaseFont = BaseFont.CreateFont("c:\windows\fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
        Dim Font_Figura As New Font(arial, 10)
        Dim Font_Titulo_Figura As New Font(arial, 10, FontStyle.Bold)
        Dim Parrafo As New Paragraph
        If Tipo_Titulo = "Figura" Then
            Parrafo.Alignment = Element.ALIGN_CENTER
        ElseIf Tipo_Titulo = "Tabla" Then
            Parrafo.Alignment = Element.ALIGN_JUSTIFIED
            Parrafo.IndentationLeft = 50
        End If
        Parrafo.Font = Font_Titulo_Figura
        Parrafo.Add(Figura1)
        Parrafo.Font = Font_Figura
        Parrafo.Add(Figura2)
        Return Parrafo
    End Function


    Public Function Insertar_Figura(ByVal Imagen As Image)
        Imagen.Alignment = Element.ALIGN_CENTER
        Imagen.ScalePercent(60.0F)
        Return Imagen
    End Function


    Public Function TipodeMuro(ByVal Text As String)
        If Text = "Muro Rectangular" Then
            TipodeMuro = "Rectangular"
        ElseIf Text = "Muro en C" Then
            TipodeMuro = "En C"
        ElseIf Text = "Muro en T" Then
            TipodeMuro = "En T"
        Else
            TipodeMuro = "En L"
        End If
        Return TipodeMuro
    End Function


    Public Sub AyudaGlobo(ByVal Globo As ToolTip, ByVal Boton As PictureBox, ByVal Mensaje As String)
        Globo.RemoveAll()
        Globo.SetToolTip(Boton, Mensaje)
        Globo.InitialDelay = 100
        Globo.IsBalloon = False
    End Sub


    Private Sub P_Info_MouseEnter(sender As Object, e As EventArgs) Handles P_Info.MouseEnter
        AyudaGlobo(Tool_Info, P_Info, "(1) Corresponde a la dirección principal del Muro" + Environment.NewLine + "Esta debe coincidir con la dirección que el muro tiene en planta")
    End Sub

    Private Sub EspectroDeDiseñoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EspectroDeDiseñoToolStripMenuItem.Click
        Form_07_EspectroNSR.Show()
    End Sub

    Private Sub Boton_ALR_Click(sender As Object, e As EventArgs) Handles Boton_ALR.Click
        Panel_Geometria.Visible = True
        Panel_Informacion.Visible = False
        Panel_Resultados.Visible = False
        Panel_Geometria.Dock = DockStyle.Fill
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Panel_Geometria.Visible = False
        Panel_Informacion.Visible = True
        Panel_Resultados.Visible = False
        Panel_Informacion.Dock = DockStyle.Fill
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Panel_Geometria.Visible = False
        Panel_Informacion.Visible = False
        Panel_Resultados.Visible = True
        Panel_Resultados.Dock = DockStyle.Fill
    End Sub

    Private Sub InsertarMurosDesdeExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertarMurosDesdeExcelToolStripMenuItem.Click
        Form_08_DimMuros.Show()
    End Sub
End Class

