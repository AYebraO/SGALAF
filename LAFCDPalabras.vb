Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class LAFCDPalabras
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim Conexion As New LAFConexion
    Public Function ListarPalabras(ByVal Archivo As Int32) As DataSet

        Dim ds As New DataSet
        cn = Conexion.Conectar()

        da = New SqlDataAdapter("sp_ListarPalabras " + Archivo.ToString, cn)
        da.Fill(ds, "Palabra")
        Return ds

        ds.Dispose()
        da.Dispose()
        cn.Dispose()

    End Function

    'Funcion para insertar una nueva Persona , recibe los elementos a insertar desde Inicio.xaml.vb
    Public Function InsertarPalabra(Palabra As EntidadPalabra) As Boolean

        Dim ds As New DataSet
        cn = Conexion.Conectar()

        da = New SqlDataAdapter("sp_CrearPalabras " + Palabra.Insert, cn)
        da.Fill(ds)
        'Return ds

        Return True

        ds.Dispose()
        da.Dispose()
        cn.Dispose()

    End Function

End Class

