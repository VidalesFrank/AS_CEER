Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class Form9
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pdfDoc As New Document

        Dim SaveAs As New SaveFileDialog
        SaveAs.Filter = "Archivo|*.pdf"
        SaveAs.Title = "Guardar Archivo"
        SaveAs.ShowDialog()

        Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(SaveAs.FileName, FileMode.Create))

        pdfDoc.Open()

        Form8.PictureBox1.Image.Save(Application.StartupPath & "\nueva.png", System.Drawing.Imaging.ImageFormat.Png)

        Dim Imagen As Image = Image.GetInstance(Application.StartupPath & "\nueva.png")
        Imagen.ScalePercent(50.0F)
        Imagen.Alignment = Image.ALIGN_RIGHT
        pdfDoc.Add(Imagen)

        pdfDoc.Add(New Paragraph(""))

        Dim arial As BaseFont = BaseFont.CreateFont("c:\windows\fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
        Dim Font_Titulo As New Font(arial, 12, FontStyle.Bold)
        Dim Font_Titulo_11 As New Font(arial, 11, FontStyle.Bold)
        Dim Font_Tabla As New Font(arial, 12)
        Dim Font_Figura As New Font(arial, 10)
        Dim Font_Titulo_Figura As New Font(arial, 10, FontStyle.Bold)

        pdfDoc.Add(Chunk.NEWLINE)

        Dim Parrafo As New Paragraph
        Parrafo.Alignment = Element.ALIGN_CENTER
        Parrafo.Font = Font_Titulo
        Parrafo.Add("RESULTADOS DE DIAGNÓSTICO DE DESEMPEÑO SÍSMICO")
        pdfDoc.Add(Parrafo)

        pdfDoc.Add(Chunk.NEWLINE)

        Dim TablaInfo As New PdfPTable(2)
        Dim Lista As Single() = {30.0F, 70.0F}

        TablaInfo.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
        TablaInfo.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER

        Dim Header As New PdfPCell
        Header.Colspan = 2
        Header.HorizontalAlignment = Element.ALIGN_CENTER
        Header.Phrase = New Phrase("ASPECTOS GENERALES DEL PROYECTO", Font_Titulo)

        TablaInfo.SetWidths(Lista)
        TablaInfo.AddCell(Header)

        Dim Cell_Imagen As New PdfPCell
        Cell_Imagen.Colspan = 2
        Dim Imagen_Proyecto As Image = Image.GetInstance(Form1.Proyecto.Ruta_Imagen)
        Imagen_Proyecto.Alignment = Element.ALIGN_CENTER
        Imagen_Proyecto.ScalePercent(10.0F)
        Cell_Imagen.HorizontalAlignment = Element.ALIGN_CENTER
        Cell_Imagen.VerticalAlignment = Element.ALIGN_CENTER
        Cell_Imagen.Image = Imagen_Proyecto
        TablaInfo.AddCell(Cell_Imagen)

        Dim Cell_1_1 As New PdfPCell
        Cell_1_1.Phrase = New Phrase("Nombre del Proyecto", Font_Titulo_11)
        TablaInfo.AddCell(Cell_1_1)
        TablaInfo.AddCell(Form1.Proyecto.Nombre)

        Dim Cell_2_1 As New PdfPCell
        Cell_2_1.Phrase = New Phrase("Dirección", Font_Titulo_11)
        TablaInfo.AddCell(Cell_2_1)
        TablaInfo.AddCell(Form1.Proyecto.Direccion)

        Dim Cell_3_1 As New PdfPCell
        Cell_3_1.Phrase = New Phrase("Ciudad/Municipio", Font_Titulo_11)
        TablaInfo.AddCell(Cell_3_1)
        TablaInfo.AddCell(Form1.Proyecto.Ciudad)

        Dim Cell_4_1 As New PdfPCell
        Cell_4_1.Phrase = New Phrase("Departamento", Font_Titulo_11)
        TablaInfo.AddCell(Cell_4_1)
        TablaInfo.AddCell(Form1.Proyecto.Departamento)

        pdfDoc.Add(TablaInfo)

        pdfDoc.Add(Chunk.NEWLINE)

        '-------------------------- INSERTAR TABLA CON GRÁFICOS DE PARÁMETROS GLOBALES DE LA ESTRUCTURA --------------------
        Form1.Grafico_Densidad.Dock = DockStyle.Fill
        Form1.Grafico_CargaAxial.Dock = DockStyle.Fill
        Form1.Grafico_Esbeltez.Dock = DockStyle.Fill
        Form1.Grafico_Confinamiento.Dock = DockStyle.Fill

        Form1.Grafico_Densidad.SaveImage(Application.StartupPath & "\Densidad.png", System.Drawing.Imaging.ImageFormat.Png)
        Form1.Grafico_CargaAxial.SaveImage(Application.StartupPath & "\ALR.png", System.Drawing.Imaging.ImageFormat.Png)
        Form1.Grafico_Esbeltez.SaveImage(Application.StartupPath & "\Esbeltez.png", System.Drawing.Imaging.ImageFormat.Png)
        Form1.Grafico_Confinamiento.SaveImage(Application.StartupPath & "\Confinamiento.png", System.Drawing.Imaging.ImageFormat.Png)

        Dim Imagen_Den As Image = Image.GetInstance(Application.StartupPath & "\Densidad.png")
        Dim Imagen_ALR As Image = Image.GetInstance(Application.StartupPath & "\ALR.png")
        Dim Imagen_Esb As Image = Image.GetInstance(Application.StartupPath & "\Esbeltez.png")
        Dim Imagen_Conf As Image = Image.GetInstance(Application.StartupPath & "\Confinamiento.png")

        Imagen_Den.ScalePercent(60.0F)
        Imagen_ALR.ScalePercent(60.0F)
        Imagen_Esb.ScalePercent(60.0F)
        Imagen_Conf.ScalePercent(60.0F)

        Imagen_Den.Alignment = Element.ALIGN_CENTER
        Imagen_ALR.Alignment = Element.ALIGN_CENTER
        Imagen_Conf.Alignment = Element.ALIGN_CENTER
        Imagen_Esb.Alignment = Element.ALIGN_CENTER

        Dim Table As New PdfPTable(2)
        Table.DefaultCell.Border = Rectangle.NO_BORDER
        Table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        Table.AddCell(Imagen_Den)
        Table.AddCell(Imagen_ALR)

        Dim Cell_T As New PdfPCell
        Cell_T.HorizontalAlignment = Element.ALIGN_CENTER
        Cell_T.Border = Rectangle.NO_BORDER

        Dim Ensayo0 As New Paragraph
        Table.AddCell(Titulo_Figura(Ensayo0, "A.   ", "Densidad de muros."))
        Dim Ensayo1 As New Paragraph
        Table.AddCell(Titulo_Figura(Ensayo1, "B.   ", "Relación de carga axial."))
        Table.AddCell("         ")
        Table.AddCell("         ")

        Table.AddCell(Imagen_Conf)
        Table.AddCell(Imagen_Esb)
        Dim Ensayo3 As New Paragraph
        Table.AddCell(Titulo_Figura(Ensayo3, "C.   ", "Confinamiento de muros."))
        Dim Ensayo4 As New Paragraph
        Table.AddCell(Titulo_Figura(Ensayo4, "D.   ", "Tipos de muros."))
        Table.AddCell("         ")
        Table.AddCell("         ")

        Dim Ensayo5 As New Paragraph
        Dim Cell5 As New PdfPCell
        Cell5.Colspan = 2
        Cell5.Border = Rectangle.NO_BORDER
        Cell5.HorizontalAlignment = Element.ALIGN_CENTER
        Cell5.VerticalAlignment = Element.ALIGN_CENTER
        Cell5.Phrase = Titulo_Figura(Ensayo5, "Figura 1.     ", "Parámetros globales de la estructura.")
        Table.AddCell(Cell5)

        pdfDoc.Add(Table)

        Dim Imagen_Semaforo As Image
        If Form1.Proyecto.Edificio.Calificaciones.ICE <= 50 Then
            Form4.Imagen_Semaforo_Verde.Image.Save(Application.StartupPath & "\Semaforo_Verde.png", System.Drawing.Imaging.ImageFormat.Png)
            Imagen_Semaforo = Image.GetInstance(Application.StartupPath & "\Semaforo_Verde.png")
            Imagen_Semaforo.Alignment = Element.ALIGN_CENTER
        ElseIf 50 < Form1.Proyecto.Edificio.Calificaciones.ICE And Form1.Proyecto.Edificio.Calificaciones.ICE <= 70 Then
            Form4.Imagen_Semaforo_Amarillo.Image.Save(Application.StartupPath & "\Semaforo_Amarillo.png", System.Drawing.Imaging.ImageFormat.Png)
            Imagen_Semaforo = Image.GetInstance(Application.StartupPath & "\Semaforo_Amarillo.png")
            Imagen_Semaforo.Alignment = Element.ALIGN_CENTER
        Else
            Form4.Imagen_Semaforo_Rojo.Image.Save(Application.StartupPath & "\Semaforo_Rojo.png", System.Drawing.Imaging.ImageFormat.Png)
            Imagen_Semaforo = Image.GetInstance(Application.StartupPath & "\Semaforo_Rojo.png")
            Imagen_Semaforo.Alignment = Element.ALIGN_CENTER
        End If
        Imagen_Semaforo.ScalePercent(20.0F)

        pdfDoc.Add(Imagen_Semaforo)

        Dim Titulo_Semaforo As New Paragraph
        Titulo_Semaforo.Alignment = Element.ALIGN_CENTER
        pdfDoc.Add(Titulo_Figura(Titulo_Semaforo, "Figura 2.    ", "Semáforo"))

        pdfDoc.Close()

        Process.Start(SaveAs.FileName)

        '------------------- Eliminar archivos de ayuda ---------------
        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Densidad.png")
        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\ALR.png")
        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Esbeltez.png")
        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Confinamiento.png")

    End Sub

    Public Function Titulo_Figura(ByVal Parrafo As Paragraph, ByVal Figura1 As String, ByVal Figura2 As String)
        Dim arial As BaseFont = BaseFont.CreateFont("c:\windows\fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
        Dim Font_Figura As New Font(arial, 10)
        Dim Font_Titulo_Figura As New Font(arial, 10, FontStyle.Bold)
        Parrafo.Alignment = Element.ALIGN_CENTER
        Parrafo.Font = Font_Titulo_Figura
        Parrafo.Add(Figura1)
        Parrafo.Font = Font_Figura
        Parrafo.Add(Figura2)
        Return Parrafo
    End Function


End Class