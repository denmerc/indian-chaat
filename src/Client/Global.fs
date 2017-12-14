module Global

type Page =
  | Home
  | Chat
  | About

let toHash page =
  match page with
  | About -> "#about"
  | Chat -> "#chat"
  | Home -> "#home"
