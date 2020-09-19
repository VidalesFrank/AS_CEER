<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
        Me.Tabla_PesoICE = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_PFS = New System.Windows.Forms.TextBox()
        Me.Tool_Ayuda = New System.Windows.Forms.ToolTip(Me.components)
        Me.P_Info = New System.Windows.Forms.PictureBox()
        CType(Me.Tabla_PesoICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.P_Info, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tabla_PesoICE
        '
        Me.Tabla_PesoICE.AllowUserToResizeRows = False
        Me.Tabla_PesoICE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Tabla_PesoICE.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Tabla_PesoICE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Tabla_PesoICE.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Tabla_PesoICE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Tabla_PesoICE.ColumnHeadersHeight = 30
        Me.Tabla_PesoICE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Tabla_PesoICE.DefaultCellStyle = DataGridViewCellStyle2
        Me.Tabla_PesoICE.Location = New System.Drawing.Point(33, 30)
        Me.Tabla_PesoICE.Name = "Tabla_PesoICE"
        Me.Tabla_PesoICE.RowHeadersVisible = False
        Me.Tabla_PesoICE.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.Tabla_PesoICE.RowTemplate.Height = 25
        Me.Tabla_PesoICE.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Tabla_PesoICE.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Tabla_PesoICE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Tabla_PesoICE.Size = New System.Drawing.Size(736, 229)
        Me.Tabla_PesoICE.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Indicador"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Peso Máximo (%)"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Peso Intermedio (%)"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Peso Mínimo (%)"
        Me.Column4.Name = "Column4"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Button2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2.Location = New System.Drawing.Point(340, 326)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(110, 30)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "OK"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 276)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 33)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Porcentaje de Fuerza Sismica de Muros Protagonicos (%)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'T_PFS
        '
        Me.T_PFS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_PFS.Location = New System.Drawing.Point(237, 281)
        Me.T_PFS.Name = "T_PFS"
        Me.T_PFS.Size = New System.Drawing.Size(70, 22)
        Me.T_PFS.TabIndex = 14
        Me.T_PFS.Text = "65"
        Me.T_PFS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'P_Info
        '
        Me.P_Info.Image = CType(resources.GetObject("P_Info.Image"), System.Drawing.Image)
        Me.P_Info.Location = New System.Drawing.Point(312, 283)
        Me.P_Info.Name = "P_Info"
        Me.P_Info.Size = New System.Drawing.Size(18, 18)
        Me.P_Info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.P_Info.TabIndex = 15
        Me.P_Info.TabStop = False
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 373)
        Me.Controls.Add(Me.P_Info)
        Me.Controls.Add(Me.T_PFS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Tabla_PesoICE)
        Me.Name = "Form5"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Índice de Calificación Estructural, ICE"
        CType(Me.Tabla_PesoICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.P_Info, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Tabla_PesoICE As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents T_PFS As TextBox
    Friend WithEvents Tool_Ayuda As ToolTip
    Friend WithEvents P_Info As PictureBox
End Class
