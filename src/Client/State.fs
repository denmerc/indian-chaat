module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import.Browser
open Global
open Types

let pageParser: Parser<Page->Page,Page> =
  oneOf [
    map About (s "about")
    map Chat (s "chat")
    map Home (s "home")
  ]

let urlUpdate (result: Option<Page>) model =
  match result with
  | None ->
    console.error("Error parsing url")
    model,Navigation.modifyUrl (toHash model.currentPage)
  | Some page ->
      { model with currentPage = page }, []

let init result =
  let (chat, chatCmd) = Chat.State.init()
  let (home, homeCmd) = Home.State.init()
  let (model, cmd) =
    urlUpdate result
      { currentPage = Home
        chat = chat
        home = home }
  model, Cmd.batch [ cmd
                     Cmd.map ChatMsg chatCmd
                     Cmd.map HomeMsg homeCmd ]

let update msg model =
  match msg with
  | ChatMsg msg ->
      let (counter, counterCmd) = Chat.State.update msg model.chat
      { model with chat = counter }, Cmd.map ChatMsg counterCmd
  | HomeMsg msg ->
      let (home, homeCmd) = Home.State.update msg model.home
      { model with home = home }, Cmd.map HomeMsg homeCmd
