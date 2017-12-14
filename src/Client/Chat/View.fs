module Chat.View

open Fable.Core
open JsInterop
open Fable.Helpers.React
open Props
open Types
open Fulma.Elements.Form
open Fulma.Common
open Fulma.Elements




let root model dispatch =
  div [] [
    Content.content [] [
      ul [] [
        for m in model.ServerMessages do
          yield
            li[][
              span [ClassName m.color][str m.data]
            ]
      ]
    ]

    br []
    br []
    p [ClassName (model.SpanCls.ToString())] [str (sprintf "local message %s" model.LocalStr)]


    Control.control_div [] [
      Radio.radio [CustomClass "red"] [
        Radio.input [
          Radio.Input.name "color"
          Radio.Input.props [
              Checked (model.SpanCls = Red)
              OnChange (fun _ -> Red |> ChangeColor |> dispatch)
              ]
          ]
        str "Red"
      ]
      Radio.radio [CustomClass "green"] [
        Radio.input [
          Radio.Input.name "color"
          Radio.Input.props [
              Checked (model.SpanCls = Green)
              OnChange (fun _ -> Green |> ChangeColor |> dispatch)
              ]
          ]
        str "Green"
      ]
      Radio.radio [CustomClass "yellow"] [
        Radio.input [
          Radio.Input.name "color"
          Radio.Input.props [
              Checked (model.SpanCls = Yellow)
              OnChange (fun _ -> Yellow |> ChangeColor |> dispatch)
              ]
          ]
        str "Yellow"
      ]
      Radio.radio [CustomClass "blue"] [
        Radio.input [
            Radio.Input.name "color"
            Radio.Input.props [
              Checked (model.SpanCls = Blue)
              OnChange (fun _ -> Blue |> ChangeColor |> dispatch)
              ]
          ]
        str "Blue"
      ]
    ]

    Control.control_div [] [
      Input.input [
        Input.typeIsText
        Input.placeholder "AddSomething"
        Input.value model.LocalStr
        Input.props [
          OnChange (fun ev -> !!ev.target?value |> ChangeStr |> dispatch)
          ]
      ]
    ]
    Button.button_btn [
      Button.onClick (fun _ -> PreparePost |> dispatch)
    ] [str "Post"]
  ]
