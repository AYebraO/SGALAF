Imports System.Data.SqlClient



Public Class LAFConexion


    Public Function Conectar() As SqlConnection
        'Dim csb As New SqlConnectionStringBuilder
        'csb.DataSource = ("Initial Catalog=dbLAF;", "Data Source=192.168.234.8;Integrated Security=SSPI;")

        'Dim conexion As New SqlConnection(csb.ConnectionString)
        Dim conexion As New SqlConnection("Database=dbLAF;Server=192.168.234.8;User Id=sa; Password=123; Trusted_Connection=False; MultipleActiveResultSets=true ")


        Return conexion

    End Function


End Class
