Imports System.Web.Http
Imports System.Net
Imports System.Net.Http

Public Class ClienteService
    Private ReadOnly _clienteRepository As ClienteRepository

    Public Sub New(clienteRepository As ClienteRepository)
        _clienteRepository = clienteRepository
    End Sub

    Public Function Listar(Optional nome As String = "", Optional email As String = "", Optional cpf As String = "") As List(Of Cliente)
        Return _clienteRepository.ObterTodos(nome, email, cpf)
    End Function

    Public Sub Criar(cliente As Cliente)
        Try
            If Not Validator.ValidarCPF(cliente.CPF) Then
                Throw New ArgumentException("CPF inválido")
            End If
            If Not Validator.ValidarRG(cliente.RG) Then
                Throw New ArgumentException("RG inválido")
            End If
            If Not Validator.ValidarEmail(cliente.Email) Then
                Throw New ArgumentException("E-mail inválido")
            End If

            For Each endereco In cliente.Enderecos
                If Not Validator.ValidarCep(endereco.CEP) Then
                    Throw New ArgumentException("CEP inválido")
                End If
            Next


            _clienteRepository.Adicionar(cliente)

        Catch ex As ArgumentException
            Dim response As New HttpResponseMessage(HttpStatusCode.BadRequest)
            response.Content = New StringContent($"Erro de validação: {ex.Message}")
            Throw New HttpResponseException(response)

        Catch ex As Exception
            Dim response As New HttpResponseMessage(HttpStatusCode.InternalServerError)
            response.Content = New StringContent($"Erro interno: {ex.Message}")
            Throw New HttpResponseException(response)
        End Try
    End Sub

    Public Sub Atualizar(cliente As Cliente)
        If Not Validator.ValidarCPF(cliente.CPF) Then Throw New ArgumentException("CPF inválido")
        If Not Validator.ValidarRG(cliente.RG) Then Throw New ArgumentException("RG inválido")
        If Not Validator.ValidarEmail(cliente.Email) Then Throw New ArgumentException("E-mail inválido")
        For Each endereco In cliente.Enderecos
            If Not Validator.ValidarCep(endereco.CEP) Then
                Throw New ArgumentException("CEP inválido")
            End If
        Next

        _clienteRepository.Atualizar(cliente)
    End Sub

    Public Sub Remover(id As Integer)
        _clienteRepository.Remover(id)
    End Sub

    Public Function Existe(id As Integer) As Boolean
        Return _clienteRepository.ObterPorId(id) IsNot Nothing
    End Function

End Class
