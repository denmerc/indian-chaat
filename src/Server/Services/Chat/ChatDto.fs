namespace Dto
open ServiceStack
open System.Collections.Generic
open System

type ChatMessage() =
    member val Id:int64 = 0L with get,set
    member val Channel = "" with get,set
    member val FromUserId = "" with get,set
    member val FromName= "" with get,set
    member val DisplayName= "" with get,set
    member val Message= "" with get,set
    member val UserAuthId= "" with get,set
    member val Private = "" with get,set

type GetChatHistoryResponse() =
        member val  Results = new List<ChatMessage>() with get,set
        member val  ResponseStatus : ResponseStatus = null with get,set

[<Route("/channels/{Channel}/chat")>]
type PostChatToChannel() =
    member val From = "" with get,set
    member val ToUserId = "" with get,set
    member val Channel = "" with get,set
    member val Message = "" with get,set
    member val Selector = "" with get,set
    with interface IReturn<ChatMessage>


[<Route("/channels/{Channel}/raw")>]
type PostRawToChannel() =
    member val From = "" with get,set
    member val ToUserId = "" with get,set
    member val Channel = "" with get,set
    member val Message = "" with get,set
    member val Selector = "" with get,set
    with interface IReturnVoid

[<Route("/chathistory")>]
type GetChatHistory() = // : IReturn<GetChatHistoryResponse>
    member val Channels: string[] = [||] with get,set
    member val AfterId : Nullable<int64> = Nullable<Int64>() with get,set
    member val Take : Nullable<int> = Nullable<int>() with get,set
    with interface IReturn<GetChatHistoryResponse>

[<Route("/reset")>]
type ClearChatHistory = class end with interface IReturnVoid

[<Route("/reset-serverevents")>]
type ResetServerEvents = class end with interface IReturnVoid
