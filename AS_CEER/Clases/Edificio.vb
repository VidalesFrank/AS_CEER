﻿<Serializable>
Public Class Edificio
    Public Vb_X As Single
    Public Vb_Y As Single
    Public Num_P As Integer
    Public Hn As Single
    Public Ht As Single
    Public Area As Single
    Public Op_fc As String
    Public fc As Single
    Public AreaM_X As Single
    Public AreaM_Y As Single
    Public Densidad_X As Single
    Public Densidad_Y As Single
    Public Dimension_Longitud As Single
    Public Dimension_Transversal As Single
    Public Amenaza As String

    Public Muros_Largos As Integer
    Public Muros_Intermedios As Integer
    Public Muros_Cortos As Integer

    Public Muros_Confinados As Integer

    Public Op_Cargas As Boolean = False
    Public Porcentaje_FSMuros As Single = Convert.ToSingle(Form5.T_PFS.Text)

    Public Calificaciones As New Calificacion
    Public Indicador As New Indicadores

    Public ListaMuros As New List(Of Muro)
    Public ListaMuros_Protagonicos As New List(Of Muro)

    <Serializable>
    Public Class Calificacion
        Public Peso_Densidad As Single
        Public Peso_NumPisos As Single
        Public Peso_FactorForma As Single
        Public Peso_Ar As Single
        Public Peso_ALR As Single
        Public Peso_Amenaza As Single
        Public Peso_Esbeltez As Single
        Public Peso_Confinamiento As Single
        Public ICE As Single

        Public Calificacion_Densidad As String
        Public Calificacion_NumPisos As String
        Public Calificacion_FactorForma As String
        Public Calificacion_Ar As String
        Public Calificacion_ALR As String
        Public Calificacion_Amenaza As String
        Public Calificacion_Esbeltez As String
        Public Calificacion_Confinamiento As String
    End Class

    <Serializable>
    Public Class Indicadores

        Public T_Mod As Boolean = False

        Public Densidad_Max As Integer = 5
        Public Densidad_Int As Integer = 10
        Public Densidad_Min As Integer = 5
        Public Num_Pisos_Max As Integer = 5
        Public Num_Pisos_Int As Integer = 2
        Public Num_Pisos_Min As Integer = 0
        Public Ar_Max As Integer = 20
        Public Ar_Int As Integer = 10
        Public Ar_Min As Integer = 0
        Public ALR_Max As Integer = 20
        Public ALR_Int As Integer = 10
        Public ALR_Min As Integer = 5
        Public Esbeltez_Max As Integer = 15
        Public Esbeltez_Int As Integer = 10
        Public Esbeltez_Min As Integer = 0
        Public Factor_Forma_Max As Integer = 5
        Public Factor_Forma_Int As Integer = 2
        Public Factor_Forma_Min As Integer = 0
        Public Amenaza_Max As Integer = 10
        Public Amenaza_Int As Integer = 5
        Public Amenaza_Min As Integer = 0
        Public Confinamiento_Max As Integer = 10
        Public Confinamiento_Int As Integer = 5
        Public Confinamiento_Min As Integer = 0
    End Class
End Class



