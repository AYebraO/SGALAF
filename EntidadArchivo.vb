Public Class EntidadArchivo
    Dim IdArchivo As Int32
    Dim IdPersona As Int32
    Dim Nombre As String
    Dim Duracion As String
    Dim Archivo As Byte()
    Dim FechaCrear As DateTime
    Dim UsuarioCrear As String
    Dim FechaMod As DateTime
    Dim UsuarioMod As String

    Public Sub New(idArchivo As Integer, idPersona As Integer, nombre As String, duracion As String, archivo As Byte(), fechaCrear As Date, usuarioCrear As String, fechaMod As Date, usuarioMod As String)
        Me.IdArchivo1 = idArchivo
        Me.IdPersona1 = idPersona
        Me.Nombre1 = nombre
        Me.Duracion1 = duracion
        Me.Archivo1 = archivo
        Me.FechaCrear1 = fechaCrear
        Me.UsuarioCrear1 = usuarioCrear
        Me.FechaMod1 = fechaMod
        Me.UsuarioMod1 = usuarioMod
    End Sub

    Public Function Insert() As String
        Dim Cadena As String

        Cadena = IdPersona + ",'" + Nombre + "', " + Duracion + ", '" + "', '" + FechaCrear.ToString("yyyy-MM-dd") + "', '" + UsuarioCrear + "', '" + FechaMod.ToString("yyyy-MM-dd") + "', '" + UsuarioMod + "'"



        Return Cadena


    End Function

    Public Property IdArchivo1 As Integer
        Get
            Return IdArchivo
        End Get
        Set(value As Integer)
            IdArchivo = value
        End Set
    End Property

    Public Property IdPersona1 As Integer
        Get
            Return IdPersona
        End Get
        Set(value As Integer)
            IdPersona = value
        End Set
    End Property

    Public Property Nombre1 As String
        Get
            Return Nombre
        End Get
        Set(value As String)
            Nombre = value
        End Set
    End Property

    Public Property Duracion1 As String
        Get
            Return Duracion
        End Get
        Set(value As String)
            Duracion = value
        End Set
    End Property

    Public Property Archivo1 As Byte()
        Get
            Return Archivo
        End Get
        Set(value As Byte())
            Archivo = value
        End Set
    End Property

    Public Property FechaCrear1 As Date
        Get
            Return FechaCrear
        End Get
        Set(value As Date)
            FechaCrear = value
        End Set
    End Property

    Public Property UsuarioCrear1 As String
        Get
            Return UsuarioCrear
        End Get
        Set(value As String)
            UsuarioCrear = value
        End Set
    End Property

    Public Property FechaMod1 As Date
        Get
            Return FechaMod
        End Get
        Set(value As Date)
            FechaMod = value
        End Set
    End Property

    Public Property UsuarioMod1 As String
        Get
            Return UsuarioMod
        End Get
        Set(value As String)
            UsuarioMod = value
        End Set
    End Property

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim archivo = TryCast(obj, EntidadArchivo)
        Return archivo IsNot Nothing AndAlso
               IdArchivo = archivo.IdArchivo AndAlso
               IdPersona = archivo.IdPersona AndAlso
               Nombre = archivo.Nombre AndAlso
               Duracion = archivo.Duracion AndAlso
               FechaCrear = archivo.FechaCrear AndAlso
               UsuarioCrear = archivo.UsuarioCrear AndAlso
               FechaMod = archivo.FechaMod AndAlso
               UsuarioMod = archivo.UsuarioMod
    End Function

    Public Overrides Function GetHashCode() As Integer
        Dim hash = New HashCode()
        hash.Add(IdArchivo)
        hash.Add(IdPersona)
        hash.Add(Nombre)
        hash.Add(Duracion)
        hash.Add(Archivo)
        hash.Add(FechaCrear)
        hash.Add(UsuarioCrear)
        hash.Add(FechaMod)
        hash.Add(UsuarioMod)
        Return hash.ToHashCode()
    End Function
End Class
