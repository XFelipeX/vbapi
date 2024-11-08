Public Class Contato
    Private _id As Integer
    Private _tipo As String
    Private _ddd As Integer
    Private _telefone As Decimal

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Tipo As String
        Get
            Return _tipo
        End Get
        Set(value As String)
            _tipo = value
        End Set
    End Property

    Public Property DDD As Integer
        Get
            Return _ddd
        End Get
        Set(value As Integer)
            _ddd = value
        End Set
    End Property

    Public Property Telefone As Decimal
        Get
            Return _telefone
        End Get
        Set(value As Decimal)
            _telefone = value
        End Set
    End Property
End Class
