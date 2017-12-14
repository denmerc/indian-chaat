module Home.Types
open Fable.Import.IndianChaat
open Fable.Core

let [<Import("*","./../Imports/IndianChaat.dtos")>] dtos: IExports = jsNative

let hello = dtos.Hello.Create()

type Model = {
  Current : string
  Server : string
}

type Msg =
  | ChangeStr of string
  | Req of Hello
  | Res of HelloResponse
  | Failed of exn
