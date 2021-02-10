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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint1 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(1.0R, 10.0R)
        Dim DataPoint2 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(2.0R, 20.0R)
        Dim DataPoint3 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(3.0R, 30.0R)
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint4 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(1.0R, 10.0R)
        Dim DataPoint5 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(2.0R, 20.0R)
        Dim DataPoint6 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(3.0R, 30.0R)
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint7 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(1.0R, 10.0R)
        Dim DataPoint8 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(2.0R, 20.0R)
        Dim DataPoint9 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(3.0R, 30.0R)
        Me.Imagen_Semaforo_Rojo = New System.Windows.Forms.PictureBox()
        Me.Imagen_Semaforo_Amarillo = New System.Windows.Forms.PictureBox()
        Me.Imagen_Semaforo_Verde = New System.Windows.Forms.PictureBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.Imagen_Semaforo_Rojo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Imagen_Semaforo_Amarillo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Imagen_Semaforo_Verde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Imagen_Semaforo_Rojo
        '
        Me.Imagen_Semaforo_Rojo.Image = CType(resources.GetObject("Imagen_Semaforo_Rojo.Image"), System.Drawing.Image)
        Me.Imagen_Semaforo_Rojo.Location = New System.Drawing.Point(806, 36)
        Me.Imagen_Semaforo_Rojo.Name = "Imagen_Semaforo_Rojo"
        Me.Imagen_Semaforo_Rojo.Size = New System.Drawing.Size(278, 348)
        Me.Imagen_Semaforo_Rojo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Imagen_Semaforo_Rojo.TabIndex = 0
        Me.Imagen_Semaforo_Rojo.TabStop = False
        '
        'Imagen_Semaforo_Amarillo
        '
        Me.Imagen_Semaforo_Amarillo.Image = CType(resources.GetObject("Imagen_Semaforo_Amarillo.Image"), System.Drawing.Image)
        Me.Imagen_Semaforo_Amarillo.Location = New System.Drawing.Point(1085, 419)
        Me.Imagen_Semaforo_Amarillo.Name = "Imagen_Semaforo_Amarillo"
        Me.Imagen_Semaforo_Amarillo.Size = New System.Drawing.Size(282, 348)
        Me.Imagen_Semaforo_Amarillo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Imagen_Semaforo_Amarillo.TabIndex = 1
        Me.Imagen_Semaforo_Amarillo.TabStop = False
        '
        'Imagen_Semaforo_Verde
        '
        Me.Imagen_Semaforo_Verde.Image = CType(resources.GetObject("Imagen_Semaforo_Verde.Image"), System.Drawing.Image)
        Me.Imagen_Semaforo_Verde.Location = New System.Drawing.Point(1090, 36)
        Me.Imagen_Semaforo_Verde.Name = "Imagen_Semaforo_Verde"
        Me.Imagen_Semaforo_Verde.Size = New System.Drawing.Size(277, 377)
        Me.Imagen_Semaforo_Verde.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Imagen_Semaforo_Verde.TabIndex = 2
        Me.Imagen_Semaforo_Verde.TabStop = False
        '
        'Chart1
        '
        ChartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(12, 24)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn
        Series1.IsValueShownAsLabel = True
        Series1.Legend = "Legend1"
        Series1.Name = "Largos"
        Series1.Points.Add(DataPoint1)
        Series1.Points.Add(DataPoint2)
        Series1.Points.Add(DataPoint3)
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn
        Series2.IsValueShownAsLabel = True
        Series2.IsXValueIndexed = True
        Series2.Legend = "Legend1"
        Series2.Name = "Intermedios"
        Series2.Points.Add(DataPoint4)
        Series2.Points.Add(DataPoint5)
        Series2.Points.Add(DataPoint6)
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn
        Series3.IsValueShownAsLabel = True
        Series3.IsXValueIndexed = True
        Series3.Legend = "Legend1"
        Series3.Name = "Cortos"
        Series3.Points.Add(DataPoint7)
        Series3.Points.Add(DataPoint8)
        Series3.Points.Add(DataPoint9)
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Size = New System.Drawing.Size(788, 547)
        Me.Chart1.TabIndex = 3
        Me.Chart1.Text = "Chart1"
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1379, 823)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.Imagen_Semaforo_Verde)
        Me.Controls.Add(Me.Imagen_Semaforo_Amarillo)
        Me.Controls.Add(Me.Imagen_Semaforo_Rojo)
        Me.Name = "Form4"
        Me.Text = "Form4"
        CType(Me.Imagen_Semaforo_Rojo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Imagen_Semaforo_Amarillo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Imagen_Semaforo_Verde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Imagen_Semaforo_Rojo As PictureBox
    Friend WithEvents Imagen_Semaforo_Amarillo As PictureBox
    Friend WithEvents Imagen_Semaforo_Verde As PictureBox
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
End Class
