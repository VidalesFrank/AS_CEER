Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Public Class Form_01_Cargas
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Form_00_Principal.Proyecto.Edificio.Op_Cargas = True
            For i = 0 To Tabla_Cargas.Rows.Count - 2
                Dim f As Integer = i
                Form_00_Principal.Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Tabla_Cargas.Rows(f).Cells(0).Value.ToString).CM = Tabla_Cargas.Rows(i).Cells(1).Value
                Form_00_Principal.Proyecto.Edificio.ListaMuros.Find(Function(p) p.Name = Tabla_Cargas.Rows(f).Cells(0).Value.ToString).CD = Tabla_Cargas.Rows(i).Cells(2).Value
                'Form_00_Principal.Proyecto.Edificio.ListaMuros(i).CM = Convert.ToSingle(Tabla_Cargas.Rows(i).Cells(1).Value)
                'Form_00_Principal.Proyecto.Edificio.ListaMuros(i).CD = Convert.ToSingle(Tabla_Cargas.Rows(i).Cells(2).Value)
            Next
        Catch ex As Exception
        Finally
            Me.Close()
        End Try
    End Sub

    Private Sub Form_01_Cargas_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Button1.Left = (GroupBox1.Width - Button1.Width) / 2
    End Sub
    Dim Lista_Archivo As New List(Of String)
    Private Sub EnviarAExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarAExcelToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim Archivo As String = "Cargas en Muros"
        Dim connection As String = "Provider=sqloledb;Data Source==miServidor;Initial Catalog=bdd_Web;User Id=web;Password="
        Dim conexion As New OleDbConnection(connection)

        Try
            Dim C_Borde As Color = Color.FromArgb(200, 200, 200)
            Dim C_Fondo As Color = Color.FromArgb(220, 220, 220)
            Dim appXL As New Microsoft.Office.Interop.Excel.Application
            Dim wbXL As Excel.Workbook
            Dim shXL As Excel.Worksheet
            wbXL = appXL.Workbooks.Add()

            shXL = wbXL.Sheets.Add()
            shXL.Name = "Cargas en Muros"
            shXL.Range("A1:E10000").Font.Name = "Arial"
            shXL.Range("A1:E10000").Font.Size = 11
            shXL.Range("A1:E10000").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter
            shXL.Range("A1:E1").Font.Bold = True
            shXL.Range("A1:E1").Interior.Color = C_Fondo
            shXL.Range("A:C").ColumnWidth = 15

            For i = 0 To 2
                shXL.Cells(1, i + 1) = Tabla_Cargas.Columns(i).HeaderText
                For j = 0 To Form_00_Principal.Proyecto.Edificio.ListaMuros.Count - 1
                    shXL.Cells(j + 2, i + 1) = Tabla_Cargas.Rows(j).Cells(i).Value
                Next
            Next

            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Title = "Guardar documento Excel"
            saveFileDialog1.Filter = "Excel File|*.xlsx"
            saveFileDialog1.FileName = Convert.ToString(Archivo)
            'saveFileDialog1.ShowDialog()
            'wbXL.SaveAs(saveFileDialog1.FileName)
            wbXL.SaveAs(Application.StartupPath & "\" & Archivo & ".xlsx")
            appXL.Workbooks.Close()
            appXL.Quit()
            'System.Diagnostics.Process.Start(saveFileDialog1.FileName)
            System.Diagnostics.Process.Start(Application.StartupPath & "\" & Archivo & ".xlsx")
            Lista_Archivo.Add(Application.StartupPath & "\" & Archivo & ".xlsx")
        Catch ex As Exception
            MessageBox.Show("Error al exportar los datos a excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
            Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub TraerDeExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TraerDeExcelToolStripMenuItem.Click
        Importar_Datos_de_Excel(Lista_Archivo(Lista_Archivo.Count - 1), Tabla_Cargas)
    End Sub

    Public Function Importar_Datos_de_Excel(ByRef path As String, ByVal Datagrid As DataGridView)
        Try

            Dim appXL As New Microsoft.Office.Interop.Excel.Application
            Dim Libro = appXL.Workbooks.Open(path)
            Dim P = Libro.Worksheets("Cargas en Muros")




            'Me.Cursor = Cursors.WaitCursor
            'Dim Ds As New DataSet
            'Dim Da As New OleDbDataAdapter
            'Dim Dt As New DataTable
            'Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & (path & ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=0;';"))
            'Dim cnConex As New OleDbConnection(stConexion)
            'cnConex.Open()
            'Dim Cmd As New OleDbCommand("Select * From [Cargas en Muros$]")
            'Cmd.Connection = cnConex
            'Da.SelectCommand = Cmd
            'Da.Fill(Ds)
            'Dt = Ds.Tables(0)
            'Datagrid.Columns.Clear()
            'Datagrid.DataSource = Dt
            'cnConex.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
        Return True
    End Function
End Class