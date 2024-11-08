Imports System.Web.Http
Imports Unity
Imports Unity.Lifetime
Imports Unity.WebApi

Public Module UnityConfig
    Private container As IUnityContainer

    Public Sub RegisterComponents()
        container = New UnityContainer()

        container.RegisterType(Of ClienteService)()
        container.RegisterType(Of ClienteRepository)()

        GlobalConfiguration.Configuration.DependencyResolver = New UnityDependencyResolver(container)
    End Sub
End Module
