Public Class Cliente
    Private _id As Integer
    Private _nome As String
    Private _email As String
    Private _cpf As String
    Private _rg As String
    Private _contatos As List(Of Contato)
    Private _enderecos As List(Of Endereco)

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Nome As String
        Get
            Return _nome
        End Get
        Set(value As String)
            _nome = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property CPF As String
        Get
            Return _cpf
        End Get
        Set(value As String)
            _cpf = value
        End Set
    End Property

    Public Property RG As String
        Get
            Return _rg
        End Get
        Set(value As String)
            _rg = value
        End Set
    End Property

    Public Property Contatos As List(Of Contato)
        Get
            Return _contatos
        End Get
        Set(value As List(Of Contato))
            _contatos = value
        End Set
    End Property

    Public Property Enderecos As List(Of Endereco)
        Get
            Return _enderecos
        End Get
        Set(value As List(Of Endereco))
            _enderecos = value
        End Set
    End Property
End Class
