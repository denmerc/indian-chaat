module IntegrationTests

open ServiceStack
open Service
open Funq

let baseUrl = "http://localhost:5000/"


type IntegrationAppHost() =
    inherit AppSelfHostBase("ServiceStack + .NET Core Self Host",typeof<HelloService>.Assembly)

    override __.Configure (_: Container) =
            // __.Plugins.Add(new TemplatePagesFeature())
            ignore()
