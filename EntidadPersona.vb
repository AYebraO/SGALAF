Public Class EntidadPersona
    Dim idPersona As Int32
    Dim IdCaso As Int32
    Dim Nombre As String
    Dim Genero As String
    Dim Edad As Integer
    Dim Acento As String
    Dim Ritmo As String
    Dim Pausas As String
    Dim Tono As String
    Dim Muletillas As String
    Dim TipoLenguaje As String
    Dim Entorno As String
    Dim FechaCrear As DateTime
    Dim UsuarioCrear As String
    Dim FechaMod As DateTime
    Dim UsuarioMod As String
    Public Function Insert() As String
        Dim Cadena As String

        Cadena = IdCaso.ToString + ",'" + Nombre + "', '" + Genero + "', " + Edad.ToString +
            ", '" + Acento + "', '" + Ritmo + "', '" + Pausas + "', '" + Tono + "', '" + Muletillas +
            "', '" + TipoLenguaje + "', '" + Entorno + "', '" + UsuarioCrear +
            "', '" + FechaCrear.ToString("yyyy-MM-dd") + "', '" + UsuarioMod + "', '" + FechaMod.ToString("yyyy-MM-dd") + "'"



        Return Cadena


    End Function


    Public Sub New(idPersona As Integer, idCaso As Integer, nombre As String, genero As String, edad As Integer, acento As String, ritmo As String, pausas As String, tono As String, muletillas As String, tipoLenguaje As String, entorno As String, fechaCrear As Date, usuarioCrear As String, fechaMod As Date, usuarioMod As String)
        Me.IdPersona1 = idPersona
        Me.IdCaso1 = idCaso
        Me.Nombre1 = nombre
        Me.Genero1 = genero
        Me.Edad1 = edad
        Me.Acento1 = acento
        Me.Ritmo1 = ritmo
        Me.Pausas1 = pausas
        Me.Tono1 = tono
        Me.Muletillas1 = muletillas
        Me.TipoLenguaje1 = tipoLenguaje
        Me.Entorno1 = entorno
        Me.FechaCrear1 = fechaCrear
        Me.UsuarioCrear1 = usuarioCrear
        Me.FechaMod1 = fechaMod
        Me.UsuarioMod1 = usuarioMod
    End Sub

    Public Property IdPersona1 As Integer
        Get
            Return idPersona
        End Get
        Set(value As Integer)
            idPersona = value
        End Set
    End Property

    Public Property IdCaso1 As Integer
        Get
            Return IdCaso
        End Get
        Set(value As Integer)
            IdCaso = value
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

    Public Property Genero1 As String
        Get
            Return Genero
        End Get
        Set(value As String)
            Genero = value
        End Set
    End Property

    Public Property Edad1 As Integer
        Get
            Return Edad
        End Get
        Set(value As Integer)
            Edad = value
        End Set
    End Property

    Public Property Acento1 As String
        Get
            Return Acento
        End Get
        Set(value As String)
            Acento = value
        End Set
    End Property

    Public Property Ritmo1 As String
        Get
            Return Ritmo
        End Get
        Set(value As String)
            Ritmo = value
        End Set
    End Property

    Public Property Pausas1 As String
        Get
            Return Pausas
        End Get
        Set(value As String)
            Pausas = value
        End Set
    End Property

    Public Property Tono1 As String
        Get
            Return Tono
        End Get
        Set(value As String)
            Tono = value
        End Set
    End Property

    Public Property Muletillas1 As String
        Get
            Return Muletillas
        End Get
        Set(value As String)
            Muletillas = value
        End Set
    End Property

    Public Property TipoLenguaje1 As String
        Get
            Return TipoLenguaje
        End Get
        Set(value As String)
            TipoLenguaje = value
        End Set
    End Property

    Public Property Entorno1 As String
        Get
            Return Entorno
        End Get
        Set(value As String)
            Entorno = value
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
End Class
