module Counter.Types
open Fable.Core
open Fable.Import.IndianChaat

let [<Import("*","./../Imports/IndianChaat.dtos")>] dtos: IExports = jsNative



type [<StringEnum>]SpanCls = Red | Blue | Green | Yellow

type Model =  {
  LocalStr : string
  ServerMessages : Message []
  SpanCls : SpanCls
}

type Msg =
  | ChangeStr of string
  | ChangeColor of SpanCls
  | PostMessage of InputMessage
  | SuccessMessages of OutPutMessages
  | Failed of exn
