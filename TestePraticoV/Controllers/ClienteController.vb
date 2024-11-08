Imports System.Net
Imports System.Web.Http

Public Class ClienteController
    Inherits ApiController

    Private ReadOnly _clienteService As ClienteService

    Public Sub New(clienteService As ClienteService)
        _clienteService = clienteService
    End Sub

    ' GET api/cliente/listar
    <HttpGet>
    <Route("api/cliente/listar")>
    Public Function Listar(Optional nome As String = "", Optional email As String = "", Optional cpf As String = "") As IEnumerable(Of Cliente)
        Return _clienteService.Listar(nome, email, cpf)
    End Function

    ' POST api/cliente/criar
    <HttpPost>
    <Route("api/cliente/criar")>
    Public Function Criar(cliente As Cliente) As IHttpActionResult
        _clienteService.Criar(cliente)

        Return StatusCode(HttpStatusCode.Created)
    End Function

    ' PUT api/cliente/atualizar/5
    <HttpPut>
    <Route("api/cliente/atualizar/{id}")>
    Public Function Atualizar(id As Integer, cliente As Cliente) As IHttpActionResult
        If cliente Is Nothing Then
            Return NotFound()
        End If

        cliente.Id = id
        _clienteService.Atualizar(cliente)
        Return Ok(cliente)
    End Function


    ' DELETE api/cliente/remover/5
    <HttpDelete>
    <Route("api/cliente/remover/{id}")>
    Public Function Remover(id As Integer) As IHttpActionResult
        Dim clienteExiste As Boolean = _clienteService.Existe(id)
        If Not clienteExiste Then
            Return NotFound()
        End If

        _clienteService.Remover(id)

        Return StatusCode(HttpStatusCode.NoContent)
    End Function
End Class
