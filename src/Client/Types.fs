module App.Types

open Global

type Msg =
  | ChatMsg of Chat.Types.Msg
  | HomeMsg of Home.Types.Msg

type Model = {
    currentPage: Page
    chat: Chat.Types.Model
    home: Home.Types.Model
  }
