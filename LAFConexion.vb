Imports System.Data.SqlClient



Public Class LAFConexion


    Public Function Conectar() As SqlConnection
        'Dim csb As New SqlConnectionStringBuilder
        'csb.DataSource = ("Initial Catalog=dbLAF;", "Data Source=192.168.234.8;Integrated Security=SSPI;")

        'Dim conexion As New SqlConnection(csb.ConnectionString)
        Dim conexion As New SqlConnection("Initial Catalog=dbLAF;" &
                                   "Data Source=192.168.234.8;Integrated Security=SSPI; ")


        Return conexion

    End Function


End Class
