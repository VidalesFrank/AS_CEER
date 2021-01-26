<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_05_AspectosGenerales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_05_AspectosGenerales))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Op_1984 = New System.Windows.Forms.RadioButton()
        Me.Op_1998 = New System.Windows.Forms.RadioButton()
        Me.Op_2010 = New System.Windows.Forms.RadioButton()
        Me.Op_2020 = New System.Windows.Forms.RadioButton()
        Me.T_NameProjet = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_Direction = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.T_City = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_Department = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("SansSerif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(398, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ASPECTOS GENERALES DEL PROYECTO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Romantic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Romantic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(34, 333)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(156, 18)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Año de Construcción"
        '
        'Op_1984
        '
        Me.Op_1984.AutoSize = True
        Me.Op_1984.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Op_1984.Location = New System.Drawing.Point(37, 354)
        Me.Op_1984.Name = "Op_1984"
        Me.Op_1984.Size = New System.Drawing.Size(79, 21)
        Me.Op_1984.TabIndex = 6
        Me.Op_1984.TabStop = True
        Me.Op_1984.Text = "  < 1984"
        Me.Op_1984.UseVisualStyleBackColor = True
        '
        'Op_1998
        '
        Me.Op_1998.AutoSize = True
        Me.Op_1998.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Op_1998.Location = New System.Drawing.Point(123, 354)
        Me.Op_1998.Name = "Op_1998"
        Me.Op_1998.Size = New System.Drawing.Size(107, 21)
        Me.Op_1998.TabIndex = 7
        Me.Op_1998.TabStop = True
        Me.Op_1998.Text = " 1984 - 1998"
        Me.Op_1998.UseVisualStyleBackColor = True
        '
        'Op_2010
        '
        Me.Op_2010.AutoSize = True
        Me.Op_2010.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Op_2010.Location = New System.Drawing.Point(237, 354)
        Me.Op_2010.Name = "Op_2010"
        Me.Op_2010.Size = New System.Drawing.Size(107, 21)
        Me.Op_2010.TabIndex = 8
        Me.Op_2010.TabStop = True
        Me.Op_2010.Text = " 1998 - 2010"
        Me.Op_2010.UseVisualStyleBackColor = True
        '
        'Op_2020
        '
        Me.Op_2020.AutoSize = True
        Me.Op_2020.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Op_2020.Location = New System.Drawing.Point(351, 354)
        Me.Op_2020.Name = "Op_2020"
        Me.Op_2020.Size = New System.Drawing.Size(75, 21)
        Me.Op_2020.TabIndex = 9
        Me.Op_2020.TabStop = True
        Me.Op_2020.Text = " > 2010"
        Me.Op_2020.UseVisualStyleBackColor = True
        '
        'T_NameProjet
        '
        Me.T_NameProjet.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_NameProjet.Location = New System.Drawing.Point(34, 43)
        Me.T_NameProjet.Multiline = True
        Me.T_NameProjet.Name = "T_NameProjet"
        Me.T_NameProjet.Size = New System.Drawing.Size(386, 28)
        Me.T_NameProjet.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("SansSerif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(176, 449)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 30)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("SansSerif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(34, 285)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(171, 28)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Insertar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Romantic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(34, 266)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 18)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Imagen del Proyecto"
        '
        'T_Direction
        '
        Me.T_Direction.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_Direction.Location = New System.Drawing.Point(34, 104)
        Me.T_Direction.Multiline = True
        Me.T_Direction.Name = "T_Direction"
        Me.T_Direction.Size = New System.Drawing.Size(386, 28)
        Me.T_Direction.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Romantic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(34, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 18)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Dirección"
        '
        'T_City
        '
        Me.T_City.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_City.Location = New System.Drawing.Point(34, 163)
        Me.T_City.Multiline = True
        Me.T_City.Name = "T_City"
        Me.T_City.Size = New System.Drawing.Size(386, 28)
        Me.T_City.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Romantic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 18)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Ciudad/Municipio"
        '
        'T_Department
        '
        Me.T_Department.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_Department.Location = New System.Drawing.Point(34, 224)
        Me.T_Department.Multiline = True
        Me.T_Department.Name = "T_Department"
        Me.T_Department.Size = New System.Drawing.Size(386, 28)
        Me.T_Department.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Romantic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(34, 205)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 18)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Departamento"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.T_Department)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Op_1984)
        Me.GroupBox1.Controls.Add(Me.T_City)
        Me.GroupBox1.Controls.Add(Me.Op_1998)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Op_2010)
        Me.GroupBox1.Controls.Add(Me.T_Direction)
        Me.GroupBox1.Controls.Add(Me.Op_2020)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.T_NameProjet)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(459, 391)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'Form_05_AspectosGenerales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 497)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_05_AspectosGenerales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aspectos Generales"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Protected Friend WithEvents Op_1984 As RadioButton
    Protected Friend WithEvents Op_1998 As RadioButton
    Protected Friend WithEvents Op_2010 As RadioButton
    Protected Friend WithEvents Op_2020 As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label6 As Label
    Public WithEvents T_NameProjet As TextBox
    Public WithEvents T_Direction As TextBox
    Friend WithEvents Label9 As Label
    Public WithEvents T_City As TextBox
    Friend WithEvents Label3 As Label
    Public WithEvents T_Department As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
