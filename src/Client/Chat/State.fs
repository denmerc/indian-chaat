module Chat.State

open Elmish
open Types
open Fable.Core
open Fable.Import
open IndianChaat
open SSClient
open System
open System.Collections.Generic
open JsInterop



let [<Import("*","@servicestack\client")>] SSClient: SSClient.IExports = jsNative

let baseUrl = "http://localhost:5000"

let subscribe =
        let socketSubscription dispatch = 
            let eventSourceOptions = createEmpty<IEventSourceOptions>
            eventSourceOptions.handlers <- createObj [
                // "onConnect" ==> fun (sub : ServerEventConnect) -> printfn "onConnect: %A" sub.displayName
                // "onJoin" ==> fun (msg: ServerEventJoin) -> printfn "onJoin: %A" msg.displayName
                // "onLeave" ==> fun (msg: ServerEventLeave) -> printfn "onLeave: %A" msg.displayName
                // "onUpdate" ==> fun (msg : ServerEventUpdate) -> printfn "onUpdate %A" msg.displayName
                "onMessage" ==> fun (msg: ServerEventMessage) -> printfn "onMessage %A" msg.json
                "chat" ==> fun (msg : OutPutMessages) ->
                                msg |> (SSESuccessMessages >> dispatch)
            ] |> Some |> Some

            let channels = [|"home"; ""|]
            SSClient.ServerEventsClient.Create(baseUrl
            , new List<string>(channels)
            , eventSourceOptions
            ).start() |> ignore
        Cmd.ofSub socketSubscription



let client = SSClient.JsonServiceClient.Create(baseUrl)



let init () : Model * Cmd<Msg> =

  {LocalStr = ""; ServerMessages = [||]; SpanCls = Blue}, Cmd.none

let update msg model =
  match msg with
  | ChangeStr s ->
    {model with LocalStr = s}, Cmd.none
  | ChangeColor s ->
    {model with SpanCls = s}, Cmd.none
  | PreparePost ->
    let inputMessage = dtos.InputMessage.Create()
    let message = dtos.Message.Create()
    message.color <- model.SpanCls.ToString()
    message.data <- model.LocalStr
    inputMessage.created <- DateTime.Now.ToString()
    inputMessage.userId <- 0.
    inputMessage.message <- message
    let postCmd = Cmd.ofMsg (PostMessage inputMessage)
    model,postCmd
  | PostMessage pm ->
    let msgPost (msg : InputMessage) =
      client.post (msg :> IReturn<OutPutMessages>)
    let helloCmd (msg: InputMessage) =
      Cmd.ofPromise msgPost msg SuccessMessages Failed
    let msgCmd = helloCmd pm
    model, msgCmd
  | SuccessMessages o ->
    {model with ServerMessages = o.data.ToArray(); LocalStr = ""}, Cmd.none
  | SSESuccessMessages o ->
    {model with ServerMessages = o.data.ToArray()}, Cmd.none
  | Failed exn ->
    model, Cmd.none
