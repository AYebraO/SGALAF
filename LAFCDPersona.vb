Imports System.Data.SqlClient
Imports System.Data

Public Class LAFCDPersona
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim Conexion As New LAFConexion
    Public Function ListarPersonas(ByVal Caso As Int32) As DataSet

        Dim ds As New DataSet
        cn = Conexion.Conectar()

        da = New SqlDataAdapter("sp_ListarPersonas " + Caso.ToString, cn)
        da.Fill(ds, "Persona")
        Return ds

        ds.Dispose()
        da.Dispose()
        cn.Dispose()

    End Function

    'Funcion para insertar un nuevo Caso, recibe los elementos a insertar desde Inicio.xaml.vb
    Public Function InsertarCaso(Caso As DataSet)
        Dim ds As New DataSet
        cn = Conexion.Conectar()

        da = New SqlDataAdapter("sp_ListarCasos", cn)
        da.Fill(ds, "Caso")
        Return ds

        ds.Dispose()
        da.Dispose()
        cn.Dispose()

    End Function
End Class
