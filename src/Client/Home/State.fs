module Home.State

open Elmish
open Types
open Fable.Import
open Fable.Core
open IndianChaat
open SSClient

let [<Import("*","@servicestack\client")>] SSClient: SSClient.IExports = jsNative

let client = SSClient.JsonServiceClient.Create("http://localhost:5000")

let init () : Model * Cmd<Msg> =
  {Current = ""; Server = ""}, Cmd.none


let update msg model : Model * Cmd<Msg> =
  match msg with
  | ChangeStr str ->
      {model with Current = str}, Cmd.none
  | Req r ->
    let helloGet (h : Hello) =
      client.get (U2.Case1 (h  :> IReturn<HelloResponse>))
    let helloCmd (h : Hello) =
      Cmd.ofPromise helloGet h Res Failed
    let hCmd = helloCmd r
    model, hCmd
  | Res r ->
    {model with Server = r.result}, Cmd.none
  | Failed exn ->
    model, Cmd.none
