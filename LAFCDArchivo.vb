Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class LAFCDArchivo


    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim Conexion As New LAFConexion

    Public Function ObtenerArchivo(ByVal archivo As Int32) As DataSet

        Dim ds As New DataSet
        cn = Conexion.Conectar()

        da = New SqlDataAdapter("SELECT Archivo from archivo" + archivo, cn)
        da.Fill(ds, "Archivo")
        Return ds

        ds.Dispose()
        da.Dispose()
        cn.Dispose()


        ds.Dispose()
        da.Dispose()
        cn.Dispose()

    End Function

    Public Function ListarArchivos(ByVal Persona As Int32) As DataSet

        Dim ds As New DataSet
        cn = Conexion.Conectar()

        da = New SqlDataAdapter("sp_ListarArchivos " + Persona.ToString, cn)
        da.Fill(ds, "Archivo")
        Return ds

        ds.Dispose()
        da.Dispose()
        cn.Dispose()

    End Function

    'Funcion para insertar una nueva Persona , recibe los elementos a insertar desde Inicio.xaml.vb
    Public Function InsertarArchivo(Archivo As EntidadArchivo) As Boolean

        Dim ds As New DataSet
        cn = Conexion.Conectar()
        'Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Using con As New SqlConnection(cn.ConnectionString)
            Dim query As String = "INSERT INTO Archivo(IdPersona, nombre, duracion, archivo, usuariocreacion, fechacreacion, usuariomodificacion, fechamodificacion) VALUES (@Idpersona, @nomarchivo, @duracion, @archivo, @usrcreacion, @fechacrear, @usrmod, @fechamod)"

            Using cmd As New SqlCommand(query)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@Idpersona", Archivo.IdPersona1)
                cmd.Parameters.AddWithValue("@nomarchivo", Archivo.Nombre1)
                cmd.Parameters.AddWithValue("@duracion", Archivo.Duracion1)
                cmd.Parameters.AddWithValue("@archivo", Archivo.Archivo1)
                cmd.Parameters.AddWithValue("@usrcreacion", Archivo.UsuarioCrear1)
                cmd.Parameters.AddWithValue("@fechacrear", Archivo.FechaCrear1)
                cmd.Parameters.AddWithValue("@usrmod", Archivo.UsuarioMod1)
                cmd.Parameters.AddWithValue("@fechamod", Archivo.FechaMod1)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using





        Return True

        ds.Dispose()
        da.Dispose()
        cn.Dispose()

    End Function

End Class