module Counter.State

open Elmish
open Types
open Fable.Core
open Fable.Import
open IndianChaat
open SSClient
open System



let [<Import("*","@servicestack\client")>] SSClient: SSClient.IExports = jsNative

let client = SSClient.JsonServiceClient.Create("http://localhost:5000")

let init () : Model * Cmd<Msg> =
  {LocalStr = "local"; ServerMessages = [||]; SpanCls = Blue}, Cmd.none

let update msg model =
  match msg with
  | ChangeStr s ->
    printfn "Local string is getting changed"
    let updatedModel = {model with LocalStr = s}
    let inputMessage = dtos.InputMessage.Create()
    let message = dtos.Message.Create()
    message.color <- updatedModel.SpanCls.ToString()
    message.data <- updatedModel.LocalStr
    inputMessage.created <- DateTime.Now.ToString()
    inputMessage.userId <- 0.
    inputMessage.message <- message
    let postCmd = Cmd.ofMsg (PostMessage inputMessage)
    updatedModel, postCmd
  | ChangeColor s ->
    printfn "Color is changing"
    let updatedModel = {model with SpanCls = s}
    updatedModel, Cmd.none
  | PostMessage pm ->
    let msgPost (msg : InputMessage) =
      client.post (msg :> IReturn<OutPutMessages>)
    let helloCmd (msg: InputMessage) =
      Cmd.ofPromise msgPost msg SuccessMessages Failed
    let msgCmd = helloCmd pm
    model, msgCmd
  | SuccessMessages o ->
    {model with ServerMessages = o.data.ToArray()}, Cmd.none
  | Failed exn ->
    model, Cmd.none
