Public Class EntidadCaso
    Dim IdCaso As Int32
    Dim Numero As String
    Dim Propietario As String
    Dim Expediente As String
    Dim FechaCrear As DateTime
    Dim UsuarioCrear As String
    Dim FechaMod As DateTime
    Dim UsuarioMod As String
    Public Function Insert() As String
        Dim Cadena As String

        Cadena = "'" + Numero + "', '" + Propietario + "', '" + Expediente + "', '" + FechaCrear.ToString("yyyy-MM-dd") + "', '" + UsuarioCrear + "', '" + FechaMod.ToString("yyyy-MM-dd") + "', '" + UsuarioMod + "'"



        Return Cadena


    End Function

    Public Function Update() As String
        Dim Cadena As String

        Cadena = IdCaso.ToString + ", '" + Numero + "', '" + Propietario + "', '" + Expediente + "', '" + FechaMod.ToString("yyyy-MM-dd") + "', '" + UsuarioMod + "'"



        Return Cadena


    End Function

    Public Sub New(idCaso As Integer, numero As String, propietario As String, expediente As String, fechaCrear As Date, usuarioCrear As String, fechaMod As Date, usuarioMod As String)
        Me.IdCaso1 = idCaso
        Me.Numero1 = numero
        Me.Propietario1 = propietario
        Me.Expediente1 = expediente
        Me.FechaCrear1 = fechaCrear
        Me.UsuarioCrear1 = usuarioCrear
        Me.FechaMod1 = fechaMod
        Me.UsuarioMod1 = usuarioMod
    End Sub

    Public Property IdCaso1 As Integer
        Get
            Return IdCaso
        End Get
        Set(value As Integer)
            IdCaso = value
        End Set
    End Property

    Public Property Numero1 As String
        Get
            Return Numero
        End Get
        Set(value As String)
            Numero = value
        End Set
    End Property

    Public Property Propietario1 As String
        Get
            Return Propietario
        End Get
        Set(value As String)
            Propietario = value
        End Set
    End Property

    Public Property Expediente1 As String
        Get
            Return Expediente
        End Get
        Set(value As String)
            Expediente = value
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
        Dim caso = TryCast(obj, EntidadCaso)
        Return caso IsNot Nothing AndAlso
               IdCaso1 = caso.IdCaso1 AndAlso
               Numero1 = caso.Numero1 AndAlso
               Propietario1 = caso.Propietario1 AndAlso
               Expediente1 = caso.Expediente1 AndAlso
               FechaCrear1 = caso.FechaCrear1 AndAlso
               UsuarioCrear1 = caso.UsuarioCrear1 AndAlso
               FechaMod1 = caso.FechaMod1 AndAlso
               UsuarioMod1 = caso.UsuarioMod1
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return HashCode.Combine(IdCaso1, Numero1, Propietario1, Expediente1, FechaCrear1, UsuarioCrear1, FechaMod1, UsuarioMod1)
    End Function
End Class
