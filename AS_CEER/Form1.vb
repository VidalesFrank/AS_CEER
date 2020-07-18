Public Class Form1

    Public Class Muros
        Public Name As String
        Public T_Muro As String
        Public Direccion As String
        Public Lw As Single
        Public tw As Single
        Public Lw2 As Single
        Public tw2 As Single
        Public Porcentaje_Vb As Single
        Public Porcentaje_Vb_Y As Single
        Public AreaX As Single
        Public AreaY As Single
        Public AreaE As Single
        Public Dx As Single
        Public Dy As Single
        Public Op_Tipo As Integer
        Public SismoX As Single
        Public SismoY As Single
        Public Esbeltez As Single
        Public AR_X As Single
        Public AR_Y As Single
        Public Hn As Single
        Public Ht As Single
        Public Op_Cargas As String
        Public Op_Area As String
        Public CM As Single
        Public CD As Single
        Public ALR_CM As Single
        Public ALR_CU As Single
        Public Tipo_Muro As String
        Public Nivel_Carga As String
        Public N_Fila As Integer

    End Class
    Public ListaMuros As New List(Of Muros)

    Private Sub Tipo_Muro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tipo_Muro.SelectedIndexChanged
        Try
            AddHandler Forma_Muro.Paint, AddressOf Me.PictureBox_Paint
            Forma_Muro.Refresh()
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
        Dim err As Integer = 0
        For i = 0 To ListaMuros.Count - 1
            If T_Name.Text = ListaMuros(i).Name Then
                Dim style = MsgBoxStyle.Exclamation
                MsgBox("Muro existente", style, "Elemento Duplicado")
                err = 1
            End If
        Next
        If err = 0 Then
            Tabla_Datos.Refresh()
            Tabla_Datos.Rows.Add()
            Dim Muro As New Muros
            Muro.Name = Convert.ToString(T_Name.Text)
            Muro.T_Muro = Convert.ToString(Tipo_Muro.Text)

            If Muro.T_Muro <> "Muro Rectangular" Then
                Muro.Op_Tipo = 1
            Else
                Muro.Op_Tipo = 0
            End If

            Dim Col_Lw2 As Integer = 5
            Dim Col_tw2 As Integer = 6
            Dim Col_Sx As Integer = 5
            Dim Col_Sy As Integer = 6

            If Muro.Op_Tipo = 1 Then
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

            If ListaMuros.Count > 1 Then
                For k = 0 To ListaMuros.Count - 1
                    If ListaMuros(k).Op_Tipo = 1 Then
                        Col_Sx = 7
                        Col_Sy = 8
                        Exit For
                    End If
                Next
            End If

            Muro.Lw = Convert.ToSingle(T_Lw.Text)
            Muro.tw = Convert.ToSingle(T_tw.Text)
            Muro.Direccion = Convert.ToString(Direccion.Text)

            If Muro.Op_Tipo = 1 Then
                Muro.Lw2 = Convert.ToSingle(T_Lw2.Text)
                Muro.tw2 = Convert.ToSingle(T_tw2.Text)
            Else
                Muro.Lw2 = 0
                Muro.tw2 = 0
            End If

            Muro.Porcentaje_Vb = Muro.Lw ^ 2 * Muro.tw
            Dim ContX As Single = 0
            Dim ContY As Single = 0

            ListaMuros.Add(Muro)

            For i = 0 To ListaMuros.Count - 1
                ContX = 0
                ContY = 0
                For j = 0 To ListaMuros.Count - 1
                    If ListaMuros(j).T_Muro = "Muro Rectangular" Then
                        If ListaMuros(j).Direccion = "X" Then
                            ContX += ListaMuros(j).Porcentaje_Vb
                            ContY += 0
                        Else
                            ContX += 0
                            ContY += ListaMuros(j).Porcentaje_Vb
                        End If
                    ElseIf ListaMuros(j).T_Muro = "Muro en T" Or ListaMuros(j).T_Muro = "Muro en L" Then
                        If ListaMuros(j).Direccion = "X" Then
                            ContX += ListaMuros(j).Lw ^ 2 * ListaMuros(j).tw
                            ContY += ListaMuros(j).Lw2 ^ 2 * ListaMuros(j).tw2
                        Else
                            ContX += ListaMuros(j).Lw2 ^ 2 * ListaMuros(j).tw2
                            ContY += ListaMuros(j).Lw ^ 2 * ListaMuros(j).tw
                        End If
                    ElseIf ListaMuros(j).T_Muro = "Muro en C" Then
                        If ListaMuros(j).Direccion = "X" Then
                            ContX += 2 * ListaMuros(j).Lw ^ 2 * ListaMuros(j).tw
                            ContY += ListaMuros(j).Lw2 ^ 2 * ListaMuros(j).tw2
                        Else
                            ContX += ListaMuros(j).Lw2 ^ 2 * ListaMuros(j).tw2
                            ContY += 2 * ListaMuros(j).Lw ^ 2 * ListaMuros(j).tw
                        End If
                    End If
                Next
                If ListaMuros(i).T_Muro = "Muro Rectangular" Then
                    If ListaMuros(i).Direccion = "X" Then
                        ListaMuros(i).SismoX = ListaMuros(i).Porcentaje_Vb / ContX
                        ListaMuros(i).SismoY = 0
                        ListaMuros(i).AreaX = ListaMuros(i).Lw * ListaMuros(i).tw
                        ListaMuros(i).AreaY = 0
                    Else
                        ListaMuros(i).SismoX = 0
                        ListaMuros(i).SismoY = ListaMuros(i).Porcentaje_Vb / ContY
                        ListaMuros(i).AreaY = ListaMuros(i).Lw * ListaMuros(i).tw
                        ListaMuros(i).AreaX = 0
                    End If
                ElseIf ListaMuros(i).T_Muro = "Muro en T" Or ListaMuros(i).T_Muro = "Muro en L" Then
                    If ListaMuros(i).Direccion = "X" Then
                        ListaMuros(i).SismoX = ListaMuros(i).Lw ^ 2 * ListaMuros(i).tw / ContX
                        ListaMuros(i).SismoY = ListaMuros(i).Lw2 ^ 2 * ListaMuros(i).tw2 / ContY
                        ListaMuros(i).AreaX = ListaMuros(i).Lw * ListaMuros(i).tw
                        ListaMuros(i).AreaY = ListaMuros(i).Lw2 * ListaMuros(i).tw2
                    Else
                        ListaMuros(i).SismoX = ListaMuros(i).Lw2 ^ 2 * ListaMuros(i).tw2 / ContX
                        ListaMuros(i).SismoY = ListaMuros(i).Lw ^ 2 * ListaMuros(i).tw / ContY
                        ListaMuros(i).AreaY = ListaMuros(i).Lw * ListaMuros(i).tw
                        ListaMuros(i).AreaX = ListaMuros(i).Lw2 * ListaMuros(i).tw2
                    End If
                ElseIf ListaMuros(i).T_Muro = "Muro en C" Then
                    If ListaMuros(i).Direccion = "X" Then
                        ListaMuros(i).SismoX = 2 * ListaMuros(i).Lw ^ 2 * ListaMuros(i).tw / ContX
                        ListaMuros(i).SismoY = ListaMuros(i).Lw2 ^ 2 * ListaMuros(i).tw2 / ContY
                        ListaMuros(i).AreaX = 2 * ListaMuros(i).Lw * ListaMuros(i).tw
                        ListaMuros(i).AreaY = ListaMuros(i).Lw2 * ListaMuros(i).tw2
                    Else
                        ListaMuros(i).SismoX = ListaMuros(i).Lw2 ^ 2 * ListaMuros(i).tw2 / ContX
                        ListaMuros(i).SismoY = 2 * ListaMuros(i).Lw ^ 2 * ListaMuros(i).tw / ContY
                        ListaMuros(i).AreaY = 2 * ListaMuros(i).Lw * ListaMuros(i).tw
                        ListaMuros(i).AreaX = ListaMuros(i).Lw2 * ListaMuros(i).tw2
                    End If
                End If

                Tabla_Datos.Rows(i).Cells(0).Value = ListaMuros(i).Name
                Tabla_Datos.Rows(i).Cells(1).Value = ListaMuros(i).T_Muro
                Tabla_Datos.Rows(i).Cells(2).Value = ListaMuros(i).Direccion
                Tabla_Datos.Rows(i).Cells(3).Value = ListaMuros(i).Lw
                Tabla_Datos.Rows(i).Cells(4).Value = ListaMuros(i).tw
                Tabla_Datos.Rows(i).Cells(Col_Sx).Value = Math.Round(ListaMuros(i).SismoX, 2)
                Tabla_Datos.Rows(i).Cells(Col_Sy).Value = Math.Round(ListaMuros(i).SismoY, 2)

                If Col_Sx = 7 Then
                    If ListaMuros(i).T_Muro <> "Muro Rectangular" Then
                        Tabla_Datos.Rows(i).Cells(5).Value = ListaMuros(i).Lw2
                        Tabla_Datos.Rows(i).Cells(6).Value = ListaMuros(i).tw2
                    Else
                        Tabla_Datos.Rows(i).Cells(5).Value = ""
                        Tabla_Datos.Rows(i).Cells(6).Value = ""
                    End If
                End If

                Dim Op3 As Integer
                For j = 0 To ListaMuros.Count - 1
                    If ListaMuros(j).T_Muro = "Muro en T" Or ListaMuros(j).T_Muro = "Muro en L" Or ListaMuros(j).T_Muro = "Muro en C" Then
                        Op3 = 1
                        Exit For
                    End If
                Next

                If Op3 = 1 Then
                    Tabla_Datos.Columns(5).HeaderText = "Longitud (Lw2)"
                    Tabla_Datos.Columns(6).HeaderText = "Espesor (tw2)"
                    Tabla_Datos.Columns(7).HeaderText = "Sismo X"
                    Tabla_Datos.Columns(8).HeaderText = "Sismo Y"
                End If

            Next
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Try
            T_Area.Visible = True
            Label16.Visible = True
            Label17.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Try
            T_Area.Visible = False
            Label16.Visible = False
            Label17.Visible = False
        Catch ex As Exception
        Finally
            Form3.Show()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            For i = 0 To ListaMuros.Count - 1
                Form2.Tabla_Cargas.Rows.Add()
            Next
            For i = 0 To ListaMuros.Count - 1
                Form2.Tabla_Cargas.Rows(i).Cells(0).Value = ListaMuros(i).Name
                If ListaMuros(0).Op_Cargas = "Ya" Then
                    Form2.Tabla_Cargas.Rows(i).Cells(1).Value = ListaMuros(i).CM
                    Form2.Tabla_Cargas.Rows(i).Cells(2).Value = ListaMuros(i).CD
                End If
            Next
        Catch ex As Exception
        Finally
            Form2.Show()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For i = 0 To ListaMuros.Count - 1
            Tabla_Resultados.Rows.Add()
        Next
        For i = 0 To ListaMuros.Count - 1
            ListaMuros(i).Hn = Convert.ToSingle(T_Hn.Text)
            ListaMuros(i).Ht = Convert.ToSingle(T_NP.Text) * ListaMuros(i).Hn
            ListaMuros(i).Esbeltez = ListaMuros(i).Hn / ListaMuros(i).tw
            If ListaMuros(i).Direccion = "X" Then
                ListaMuros(i).AR_X = ListaMuros(i).Ht / ListaMuros(i).Lw
                If ListaMuros(i).T_Muro = "Muro Rectangular" Then
                    ListaMuros(i).AR_Y = 0
                Else
                    ListaMuros(i).AR_Y = ListaMuros(i).Ht / ListaMuros(i).Lw2
                End If
            Else
                ListaMuros(i).AR_Y = ListaMuros(i).Ht / ListaMuros(i).Lw
                If ListaMuros(i).T_Muro = "Muro Rectangular" Then
                    ListaMuros(i).AR_X = 0
                Else
                    ListaMuros(i).AR_X = ListaMuros(i).Ht / ListaMuros(i).Lw2
                End If
            End If

            If ListaMuros(i).AR_X <= 3 Then
                ListaMuros(i).Tipo_Muro = "Largo"
            ElseIf 3 < ListaMuros(i).AR_X And ListaMuros(i).AR_X <= 9 Then
                ListaMuros(i).Tipo_Muro = "Intermedio"
            ElseIf ListaMuros(i).AR_X > 9 Then
                ListaMuros(i).Tipo_Muro = "Corto"
            End If

            Tabla_Resultados.Rows(i).Cells(0).Value = ListaMuros(i).Name
            Tabla_Resultados.Rows(i).Cells(1).Value = Math.Round(ListaMuros(i).SismoX, 2)
            Tabla_Resultados.Rows(i).Cells(2).Value = Math.Round(ListaMuros(i).SismoY, 2)
            Tabla_Resultados.Rows(i).Cells(3).Value = Math.Round(ListaMuros(i).Esbeltez, 2)
            Tabla_Resultados.Rows(i).Cells(4).Value = Math.Round(ListaMuros(i).AR_X, 1)
            Tabla_Resultados.Rows(i).Cells(5).Value = Math.Round(ListaMuros(i).AR_Y, 1)
            Tabla_Resultados.Rows(i).Cells(6).Value = ListaMuros(i).Tipo_Muro
        Next

        Dim fc As Single = Convert.ToSingle(T_fc.Text)
        If ListaMuros(0).Op_Cargas = "Ya" Then
            For i = 0 To ListaMuros.Count - 1
                ListaMuros(i).ALR_CM = ListaMuros(i).CM / (fc * 1000 * (ListaMuros(i).Lw * ListaMuros(i).tw + ListaMuros(i).Lw2 * ListaMuros(i).tw2))
                ListaMuros(i).ALR_CU = ListaMuros(i).CD / (fc * 1000 * (ListaMuros(i).Lw * ListaMuros(i).tw + ListaMuros(i).Lw2 * ListaMuros(i).tw2))
                If ListaMuros(i).ALR_CU <= 0.1 Then
                    ListaMuros(i).Nivel_Carga = "Bajo"
                ElseIf 0.1 < ListaMuros(i).ALR_CU And ListaMuros(i).ALR_CU <= 0.2 Then
                    ListaMuros(i).Nivel_Carga = "Medio"
                ElseIf ListaMuros(i).ALR_CU > 0.2 Then
                    ListaMuros(i).Nivel_Carga = "Alto"
                End If
                Tabla_Resultados.Rows(i).Cells(7).Value = Math.Round(ListaMuros(i).ALR_CM, 2)
                Tabla_Resultados.Rows(i).Cells(8).Value = Math.Round(ListaMuros(i).ALR_CU, 2)
                Tabla_Resultados.Rows(i).Cells(9).Value = ListaMuros(i).Nivel_Carga
            Next
        End If

        Dim AreaT_X As Single = 0
        Dim AreaT_Y As Single = 0
        For i = 0 To ListaMuros.Count - 1
            AreaT_X += ListaMuros(i).AreaX
            AreaT_Y += ListaMuros(i).AreaY
        Next
        If ListaMuros(0).Op_Area = "Ya" Then
            Tabla_Resultados.Rows(0).Cells(10).Value = Math.Round(AreaT_X / ListaMuros(0).AreaE * 100, 2)
            Tabla_Resultados.Rows(0).Cells(11).Value = Math.Round(AreaT_Y / ListaMuros(0).AreaE * 100, 2)
        End If
        If RadioButton2.Checked = True Then
            Tabla_Resultados.Rows(0).Cells(10).Value = Math.Round(AreaT_X / Convert.ToSingle(T_Area.Text) * 100, 2)
            Tabla_Resultados.Rows(0).Cells(11).Value = Math.Round(AreaT_Y / Convert.ToSingle(T_Area.Text) * 100, 2)
        End If

        Tabla_Resultados.Sort(Tabla_Resultados.Columns(1), System.Windows.Forms.SortOrder.Ascending)

    End Sub
End Class
