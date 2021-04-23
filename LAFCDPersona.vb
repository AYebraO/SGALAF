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

    'Funcion para insertar una nueva Persona , recibe los elementos a insertar desde Inicio.xaml.vb
    Public Function InsertarPersona(Persona As EntidadPersona) As Boolean

        Dim ds As New DataSet
        cn = Conexion.Conectar()

        da = New SqlDataAdapter("sp_CrearPersonas " + Persona.Insert, cn)
        da.Fill(ds)
        'Return ds

        Return True

        ds.Dispose()
        da.Dispose()
        cn.Dispose()

    End Function

End Class
