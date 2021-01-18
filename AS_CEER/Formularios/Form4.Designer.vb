<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.Imagen_Semaforo_Rojo = New System.Windows.Forms.PictureBox()
        Me.Imagen_Semaforo_Amarillo = New System.Windows.Forms.PictureBox()
        Me.Imagen_Semaforo_Verde = New System.Windows.Forms.PictureBox()
        CType(Me.Imagen_Semaforo_Rojo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Imagen_Semaforo_Amarillo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Imagen_Semaforo_Verde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Imagen_Semaforo_Rojo
        '
        Me.Imagen_Semaforo_Rojo.Image = CType(resources.GetObject("Imagen_Semaforo_Rojo.Image"), System.Drawing.Image)
        Me.Imagen_Semaforo_Rojo.Location = New System.Drawing.Point(12, 36)
        Me.Imagen_Semaforo_Rojo.Name = "Imagen_Semaforo_Rojo"
        Me.Imagen_Semaforo_Rojo.Size = New System.Drawing.Size(278, 348)
        Me.Imagen_Semaforo_Rojo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Imagen_Semaforo_Rojo.TabIndex = 0
        Me.Imagen_Semaforo_Rojo.TabStop = False
        '
        'Imagen_Semaforo_Amarillo
        '
        Me.Imagen_Semaforo_Amarillo.Image = CType(resources.GetObject("Imagen_Semaforo_Amarillo.Image"), System.Drawing.Image)
        Me.Imagen_Semaforo_Amarillo.Location = New System.Drawing.Point(324, 36)
        Me.Imagen_Semaforo_Amarillo.Name = "Imagen_Semaforo_Amarillo"
        Me.Imagen_Semaforo_Amarillo.Size = New System.Drawing.Size(282, 348)
        Me.Imagen_Semaforo_Amarillo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Imagen_Semaforo_Amarillo.TabIndex = 1
        Me.Imagen_Semaforo_Amarillo.TabStop = False
        '
        'Imagen_Semaforo_Verde
        '
        Me.Imagen_Semaforo_Verde.Image = CType(resources.GetObject("Imagen_Semaforo_Verde.Image"), System.Drawing.Image)
        Me.Imagen_Semaforo_Verde.Location = New System.Drawing.Point(638, 23)
        Me.Imagen_Semaforo_Verde.Name = "Imagen_Semaforo_Verde"
        Me.Imagen_Semaforo_Verde.Size = New System.Drawing.Size(277, 377)
        Me.Imagen_Semaforo_Verde.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Imagen_Semaforo_Verde.TabIndex = 2
        Me.Imagen_Semaforo_Verde.TabStop = False
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1082, 412)
        Me.Controls.Add(Me.Imagen_Semaforo_Verde)
        Me.Controls.Add(Me.Imagen_Semaforo_Amarillo)
        Me.Controls.Add(Me.Imagen_Semaforo_Rojo)
        Me.Name = "Form4"
        Me.Text = "Form4"
        CType(Me.Imagen_Semaforo_Rojo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Imagen_Semaforo_Amarillo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Imagen_Semaforo_Verde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Imagen_Semaforo_Rojo As PictureBox
    Friend WithEvents Imagen_Semaforo_Amarillo As PictureBox
    Friend WithEvents Imagen_Semaforo_Verde As PictureBox
End Class
