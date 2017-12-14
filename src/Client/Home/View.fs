module Home.View

open Fable.Core
open JsInterop
open Fable.Helpers.React
open Props
open Types

let root model dispatch =
  div
    [ ]
    [ p
        [ ClassName "control" ]
        [ input
            [ ClassName "input"
              Type "text"
              Placeholder "Type your name"
              DefaultValue model.Current
              AutoFocus true
              OnChange (fun ev -> !!ev.target?value |> ChangeStr |> dispatch ) ] ]
      button[OnClick (fun _ -> (hello.name <- model.Current; hello) |> Req |> dispatch)][str "Server Hello"]
      br [ ]
      span
        [ ]
        [ str (sprintf "Hello ji %s" model.Current) ]
      br []
      span [] [
        str (sprintf "Server says: %s" model.Server)
      ]
    ]


