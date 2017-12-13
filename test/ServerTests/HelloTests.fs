module ServerTests.Tests

open Expecto
open Expecto.Flip
open ServiceStack
open ServiceStack.Testing
open Service
open Dto
open IntegrationTests




[<Tests>]
let HelloServcieUnitTests =
  testList "Hello Service Unit List" [
    use appHost = (new BasicAppHost()).Init()
    appHost.Container.AddTransient<HelloService>() |> ignore
    use helloService = appHost.Container.Resolve<HelloService>()
    yield testCase "Hello Test" <| fun _ ->
      Expect.isTrue "Something is true" true
    yield testCase "Hello World" <| fun _ ->
      let expected : HelloResponse= { Result = "Hello, World !"}
      let actual = helloService.Any {Hello.Name = "World"}
      Expect.equal "Hello World" expected actual
  ]

[<Tests>]
let HelloServiceIntegrationTests =
  testList "Hello Service Integration Service" [
    (new IntegrationAppHost()).Init().Start(baseUrl) |> ignore
    use client = new JsonServiceClient(baseUrl)
    yield testCase "Hello Test" <| fun _ ->
      Expect.isTrue "Something is true" true
    yield testCase "Hello World"  <| fun _ ->
      let expected = { Result = "Hello, World !"}
      let actual = client.Get<HelloResponse>({Hello.Name = "World"})
      Expect.equal "Hello World" expected actual
  ]