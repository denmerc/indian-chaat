namespace Service
open System.Collections.Generic
open Dto
open System.Linq
open ServiceStack
open System
open ServiceStack.Configuration
open ServiceStack
open Helper.ChaatHelper







type ServerEventsServices() =
    inherit Service()

    member __.Post(request : InputMessage) =
        chaatAgent.Post request
        {Data = storage.ToArray()} |> box
