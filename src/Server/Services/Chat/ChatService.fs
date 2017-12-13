namespace Service
open System.Collections.Generic
open Dto
open System.Linq
open ServiceStack
open System
open ServiceStack.Configuration
open ServiceStack

[<AllowNullLiteralAttribute>]
type IChatHistory =
    abstract member GetNextMessageId : string -> int64
    abstract member Log : string * ChatMessage  -> unit
    abstract member GetRecentChatHistory : string * Nullable<int64> * Nullable<int> -> List<ChatMessage>
    abstract member Flush : unit -> unit

type MemoryChatHistory() =
    let mutable MessagesMap = Dictionary<string, List<ChatMessage>>()
    member val DefaultLimit = 100 with get,set
    member val ServerEvents :IServerEvents = null with get,set
    interface IChatHistory with
        member this.GetNextMessageId _ =
            this.ServerEvents.GetNextSequence("chatMsg")
        member __.Log(channel, msg) =
            let mutable msgs = new List<ChatMessage>()
            if MessagesMap.TryGetValue(channel,&msgs) then
                msgs <- new List<ChatMessage>()
                MessagesMap.[channel] <- msgs
            else
                msgs.Add msg
        member this.GetRecentChatHistory (channel:string, afterId:Nullable<int64>, take:Nullable<int>) =
            let mutable msgs = new List<ChatMessage>()
            let aId = if afterId.HasValue then afterId.Value else 0L
            let t = if take.HasValue then take.Value else this.DefaultLimit
            if MessagesMap.TryGetValue(channel,&msgs) then new List<ChatMessage>()
            else
            let ret = msgs
                        .Where(fun x -> x.Id > aId)
                        .Reverse()
                        .Take(t)
                        .Reverse()
            ret.ToList()
        member __.Flush() =
            printfn "flushing things out"
            MessagesMap <- Dictionary<string, List<ChatMessage>>()

type ServerEventsServices() =
    inherit Service()

    member val ServerEvents : IServerEvents = null with get,set
    member val ChatHistory : IChatHistory = null with get,set
    member val AppSettings : IAppSettings = null with get,set

    member this.Any(request : ClearChatHistory) =
        printfn "In flush event"
        this.ChatHistory.Flush()
        HttpResult.Redirect("/")
