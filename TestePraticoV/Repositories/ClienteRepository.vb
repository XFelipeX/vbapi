Imports Newtonsoft.Json
Imports System.IO

Public Class ClienteRepository
    Dim filePath As String = HttpContext.Current.Server.MapPath("~/App_Data/clientes.json")

    Private Sub VerificarCriarArquivo()
        If Not File.Exists(filePath) Then
            Using fs As FileStream = File.Create(filePath)
                Dim defaultData As String = "[]"
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(defaultData)
                fs.Write(bytes, 0, bytes.Length)
            End Using
        End If
    End Sub

    Public Function ObterTodos(Optional nome As String = "", Optional email As String = "", Optional cpf As String = "") As List(Of Cliente)
        VerificarCriarArquivo()

        Dim clientes As List(Of Cliente) = JsonConvert.DeserializeObject(Of List(Of Cliente))(File.ReadAllText(FilePath))

        If Not String.IsNullOrEmpty(nome) Then
            clientes = clientes.Where(Function(c) c.Nome.Contains(nome)).ToList()
        End If
        If Not String.IsNullOrEmpty(email) Then
            clientes = clientes.Where(Function(c) c.Email.Contains(email)).ToList()
        End If
        If Not String.IsNullOrEmpty(cpf) Then
            clientes = clientes.Where(Function(c) c.CPF.Contains(cpf)).ToList()
        End If

        Return clientes
    End Function

    Public Function ObterPorId(id As Integer) As Cliente
        VerificarCriarArquivo()

        Dim clientes As List(Of Cliente) = JsonConvert.DeserializeObject(Of List(Of Cliente))(File.ReadAllText(filePath))
        Return clientes.FirstOrDefault(Function(c) c.Id = id)
    End Function

    Public Sub Adicionar(cliente As Cliente)
        VerificarCriarArquivo()

        Dim clientes As List(Of Cliente) = JsonConvert.DeserializeObject(Of List(Of Cliente))(File.ReadAllText(filePath))
        If clientes.Any() Then
            cliente.Id = clientes.Max(Function(c) c.Id) + 1
        Else
            cliente.Id = 1
        End If

        clientes.Add(cliente)
        File.WriteAllText(FilePath, JsonConvert.SerializeObject(clientes))
    End Sub

    Public Sub Atualizar(cliente As Cliente)
        VerificarCriarArquivo()
        Dim clientes As List(Of Cliente) = JsonConvert.DeserializeObject(Of List(Of Cliente))(File.ReadAllText(filePath))
        Dim existingCliente = clientes.FirstOrDefault(Function(c) c.Id = cliente.Id)

        If existingCliente IsNot Nothing Then
            existingCliente.Nome = cliente.Nome
            existingCliente.Email = cliente.Email
            existingCliente.CPF = cliente.CPF
            existingCliente.RG = cliente.RG
            existingCliente.Contatos = cliente.Contatos
            existingCliente.Enderecos = cliente.Enderecos
            File.WriteAllText(filePath, JsonConvert.SerializeObject(clientes))
        End If
    End Sub

    Public Sub Remover(id As Integer)
        VerificarCriarArquivo()
        Dim clientes As List(Of Cliente) = JsonConvert.DeserializeObject(Of List(Of Cliente))(File.ReadAllText(filePath))
        Dim cliente = clientes.FirstOrDefault(Function(c) c.Id = id)

        If cliente IsNot Nothing Then
            clientes.Remove(cliente)
            File.WriteAllText(filePath, JsonConvert.SerializeObject(clientes))
        End If
    End Sub
End Class
