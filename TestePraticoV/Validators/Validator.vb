Imports System.Text.RegularExpressions

Public Class Validator
    Public Shared Function ValidarCPF(cpf As String) As Boolean
        Dim regex As New Regex("^\d{3}\.\d{3}\.\d{3}-\d{2}$")
        Return regex.IsMatch(cpf)
    End Function

    Public Shared Function ValidarRG(rg As String) As Boolean
        Dim regex As New Regex("^\d{1,2}\.\d{3}\.\d{3}-\d{1}$")
        Return regex.IsMatch(rg)
    End Function

    Public Shared Function ValidarEmail(email As String) As Boolean
        Dim regex As New Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
        Return regex.IsMatch(email)
    End Function

    Public Shared Function ValidarCep(cep As String) As Boolean
        Dim regex As New Regex("^\d{5}-\d{3}$")
        Return regex.IsMatch(cep)
    End Function
End Class
