Public Class EntidadPalabra
    Dim IdPalabra As Int32
    Dim IdArchivo As Int32
    Dim Texto As String
    Dim Formante1 As Decimal
    Dim Formante2 As Decimal
    Dim Formante3 As Decimal
    Dim Formante4 As Decimal
    Dim Tono As Decimal
    Dim Intensidad As Decimal
    Dim Pulsos As Decimal
    Dim FechaCrear As DateTime
    Dim UsuarioCrear As String
    Dim FechaMod As DateTime
    Dim UsuarioMod As String

    Public Sub New(idPalabra As Integer, idArchivo As Integer, texto As String, formante1 As Decimal, formante2 As Decimal, formante3 As Decimal, formante4 As Decimal, tono As Decimal, intensidad As Decimal, pulsos As Decimal, fechaCrear As Date, usuarioCrear As String, fechaMod As Date, usuarioMod As String)
        Me.IdPalabra1 = idPalabra
        Me.IdArchivo1 = idArchivo
        Me.Texto1 = texto
        Me.Formante11 = formante1
        Me.Formante21 = formante2
        Me.Formante31 = formante3
        Me.Formante41 = formante4
        Me.Tono1 = tono
        Me.Intensidad1 = intensidad
        Me.Pulsos1 = pulsos
        Me.FechaCrear1 = fechaCrear
        Me.UsuarioCrear1 = usuarioCrear
        Me.FechaMod1 = fechaMod
        Me.UsuarioMod1 = usuarioMod
    End Sub

    Public Property IdPalabra1 As Integer
        Get
            Return IdPalabra
        End Get
        Set(value As Integer)
            IdPalabra = value
        End Set
    End Property

    Public Property IdArchivo1 As Integer
        Get
            Return IdArchivo
        End Get
        Set(value As Integer)
            IdArchivo = value
        End Set
    End Property

    Public Property Texto1 As String
        Get
            Return Texto
        End Get
        Set(value As String)
            Texto = value
        End Set
    End Property

    Public Property Formante11 As Decimal
        Get
            Return Formante1
        End Get
        Set(value As Decimal)
            Formante1 = value
        End Set
    End Property

    Public Property Formante21 As Decimal
        Get
            Return Formante2
        End Get
        Set(value As Decimal)
            Formante2 = value
        End Set
    End Property

    Public Property Formante31 As Decimal
        Get
            Return Formante3
        End Get
        Set(value As Decimal)
            Formante3 = value
        End Set
    End Property

    Public Property Formante41 As Decimal
        Get
            Return Formante4
        End Get
        Set(value As Decimal)
            Formante4 = value
        End Set
    End Property

    Public Property Tono1 As Decimal
        Get
            Return Tono
        End Get
        Set(value As Decimal)
            Tono = value
        End Set
    End Property

    Public Property Intensidad1 As Decimal
        Get
            Return Intensidad
        End Get
        Set(value As Decimal)
            Intensidad = value
        End Set
    End Property

    Public Property Pulsos1 As Decimal
        Get
            Return Pulsos
        End Get
        Set(value As Decimal)
            Pulsos = value
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

    Public Function Insert() As String
        Dim Cadena As String

        Cadena = IdArchivo1.ToString + ",'" + Texto1.ToString + "', " + Formante11.ToString + ", " + Formante21.ToString +
            ", " + Formante31.ToString + ", " + Formante41.ToString + ", " + Tono1.ToString + ", " + Intensidad1.ToString + ", " + Pulsos1.ToString +
            ", '" + UsuarioCrear1 + "', '" + FechaCrear1.ToString("yyyy-MM-dd") + "', '" + UsuarioMod1 + "', '" + FechaMod1.ToString("yyyy-MM-dd") + "'"

        Return Cadena


    End Function
End Class
