﻿Imports System.Data.OleDb
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Tabla_Cargas.Columns.Clear()
        Dim Open As New OpenFileDialog
        'Open.Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*"
        'Open.Title = "Abrir Archivo"
        'Open.ShowDialog()

        With Open
            .Title = "Seleccionar archivos"
            .Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Traer(.FileName, Tabla_Cargas)
            End If
        End With


    End Sub

    Sub Traer(ByRef path As String, ByVal Datagrid As DataGridView)
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim Ds As New DataSet
            Dim Da As New OleDbDataAdapter
            Dim Dt As New DataTable
            Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & (path & ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;';"))
            Dim cnConex As New OleDbConnection(stConexion)
            cnConex.Open()
            Dim Cmd As New OleDbCommand("Select * From [Hoja1$]")
            Cmd.Connection = cnConex
            Da.SelectCommand = Cmd
            Da.Fill(Ds)
            Dt = Ds.Tables(0)
            Datagrid.Columns.Clear()
            Datagrid.DataSource = Dt
            cnConex.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i = 0 To Tabla_Cargas.Rows.Count - 2
            Form_00_Principal.T_Name.Text = Tabla_Cargas.Rows(i).Cells(0).Value
            Form_00_Principal.Direccion.Text = Tabla_Cargas.Rows(i).Cells(4).Value
            Form_00_Principal.T_Lw.Text = Tabla_Cargas.Rows(i).Cells(1).Value
            Form_00_Principal.T_tw.Text = Tabla_Cargas.Rows(i).Cells(2).Value
            Form_00_Principal.T_Cantidad.Text = Tabla_Cargas.Rows(i).Cells(3).Value
            Form_00_Principal.Button1.PerformClick()
        Next



    End Sub
End Class