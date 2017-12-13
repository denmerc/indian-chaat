namespace Server


open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Funq
open ServiceStack
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Logging
open Service
open ServiceStack.Configuration




type AppHost() =
    inherit AppHostBase("ServiceStack + .NET Core Self Host",typeof<HelloService>.Assembly)

    override __.Configure (container: Container) =
            __.Plugins.Add(new TemplatePagesFeature())
            __.Plugins.Add(ServerEventsFeature())
            __.Plugins.Add(CorsFeature(
                                allowOriginWhitelist = [|"http://localhost";"http://127.0.0.1:8080";"http://localhost:8080";"http://localhost:8081";"http://null.jsbin.com"|],
                                allowCredentials = true,
                                allowedHeaders = "Content-Type, Allow, Authorization"
            ))
            container.Register<IChatHistory>(fun _ -> MemoryChatHistory() :> IChatHistory) |> ignore
            ignore()


type Startup (configuration: IConfiguration) =

    member __.ConfigureServices (_:IServiceCollection) =
        ignore

    member __.Configure(app:IApplicationBuilder, env:IHostingEnvironment, loggerFactory : ILoggerFactory) =
        loggerFactory.AddConsole() |> ignore
        if env.IsDevelopment() then app.UseDeveloperExceptionPage() |> ignore
        let apphost = new AppHost()
        apphost.AppSettings <- NetCoreAppSettings(configuration)
        app.UseServiceStack(apphost) |> ignore
        app.Run(fun context ->
                        context.Response.Redirect("/metadata") |> ignore
                        Task.FromResult(0) :> Task
                ) |> ignore