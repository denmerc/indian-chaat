// ts2fable 0.6.0-build.165
module rec Fable.Import.IndianChaat
open System
open Fable.Core
open Fable.Import.JS
open SSClient


type [<AllowNullLiteral>] IExports =
    abstract Message: MessageStatic
    abstract HelloResponse: HelloResponseStatic
    abstract OutPutMessages: OutPutMessagesStatic
    abstract Hello: HelloStatic
    abstract InputMessage: InputMessageStatic

// type [<AllowNullLiteral>] IReturn<'T> =
//     abstract createResponse: unit -> 'T

// type [<AllowNullLiteral>] IReturnVoid =
//     abstract createResponse: unit -> unit

type [<AllowNullLiteral>] Message =
    abstract data: string with get, set
    abstract color: string with get, set

type [<AllowNullLiteral>] MessageStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Message

type [<AllowNullLiteral>] HelloResponse =
    abstract result: string with get, set

type [<AllowNullLiteral>] HelloResponseStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> HelloResponse

type [<AllowNullLiteral>] OutPutMessages =
    abstract data: ResizeArray<Message> with get, set

type [<AllowNullLiteral>] OutPutMessagesStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> OutPutMessages

type [<AllowNullLiteral>] Hello =
    inherit IReturn<HelloResponse>
    abstract name: string with get, set
    abstract createResponse: unit -> HelloResponse
    abstract getTypeName: unit -> string

type [<AllowNullLiteral>] HelloStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Hello

type [<AllowNullLiteral>] InputMessage =
    inherit IReturn<OutPutMessages>
    abstract userId: float with get, set
    abstract created: string with get, set
    abstract message: Message with get, set
    abstract createResponse: unit -> OutPutMessages
    abstract getTypeName: unit -> string

type [<AllowNullLiteral>] InputMessageStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> InputMessage
