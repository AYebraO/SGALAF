Imports System.Data.SqlClient
Imports System.Data

Public Class LAFCDCasos
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim Conexion As New LAFConexion

    Public Function ListarCasos() As DataSet

        Dim ds As New DataSet
        cn = Conexion.Conectar()

        da = New SqlDataAdapter("sp_ListarCasos", cn)
        da.Fill(ds, "Casos")
        Return ds

        ds.Dispose()
        da.Dispose()
        cn.Dispose()

    End Function

    'Funcion para insertar un nuevo Caso, recibe los elementos a insertar desde Inicio.xaml.vb
    Public Function InsertarCaso(Caso As EntidadCaso) As Boolean

        Dim ds As New DataSet
        cn = Conexion.Conectar()

        da = New SqlDataAdapter("sp_CrearCasos " + Caso.Insert, cn)
        da.Fill(ds)
        'Return ds

        Return True

        ds.Dispose()
        da.Dispose()
        cn.Dispose()

    End Function

    Public Function ActualizarCaso(Caso As EntidadCaso) As Boolean

        Dim ds As New DataSet
        cn = Conexion.Conectar()

        da = New SqlDataAdapter("sp_ActualizarCasos " + Caso.Update, cn)
        da.Fill(ds)
        'Return ds

        Return True

        ds.Dispose()
        da.Dispose()
        cn.Dispose()

    End Function

End Class
