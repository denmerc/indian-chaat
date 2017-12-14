namespace Dto

open ServiceStack
open System


[<CLIMutableAttribute>]
type Message = {
    Data : string
    Color : string
}


[<CLIMutableAttribute>]
type OutPutMessages = {
    Data : Message []
}

[<CLIMutableAttribute>]
[<Route("/Chat")>]
type InputMessage = {
    UserId : int
    Created : DateTime
    Message : Message
} with interface IReturn<OutPutMessages>
