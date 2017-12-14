namespace Service
open System.Collections.Generic
open Dto
open System.Linq
open ServiceStack
open System
open ServiceStack.Configuration
open ServiceStack





type ServerEventsServices() =
    inherit Service()

    member __.Post(request : InputMessage) =
        //do something
        {Data = [|request.Message|]} |> box
