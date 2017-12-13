// ts2fable 0.6.0-build.165
module rec Fable.Import.SSClient
open System
open Fable.Core
open Fable.Import.JS
open Fable.PowerPack.Fetch
open Browser

let [<Import("*","src")>] toCamelCase: (string -> string) = jsNative
let [<Import("*","src")>] sanitize: (obj option -> obj option) = jsNative
let [<Import("*","src")>] nameOf: (obj option -> obj option) = jsNative
let [<Import("*","src")>] css: (U2<string, NodeListOf<Element>> -> string -> string -> unit) = jsNative
let [<Import("*","src")>] splitOnFirst: (string -> string -> ResizeArray<string>) = jsNative
let [<Import("*","src")>] splitOnLast: (string -> string -> ResizeArray<string>) = jsNative
let [<Import("*","src")>] humanize: (obj option -> obj option) = jsNative
let [<Import("*","src")>] queryString: (string -> obj option) = jsNative
let [<Import("*","src")>] combinePaths: (ResizeArray<string> -> string) = jsNative
let [<Import("*","src")>] createPath: (string -> obj option -> string) = jsNative
let [<Import("*","src")>] createUrl: (string -> obj option -> string) = jsNative
let [<Import("*","src")>] appendQueryString: (string -> obj option -> string) = jsNative
let [<Import("*","src")>] bytesToBase64: (Uint8Array -> string) = jsNative
let [<Import("*","src")>] stripQuotes: (string -> string) = jsNative
let [<Import("*","src")>] tryDecode: (string -> string) = jsNative
let [<Import("*","src")>] parseCookie: (string -> Cookie) = jsNative
let [<Import("*","src")>] normalizeKey: (string -> string) = jsNative
let [<Import("*","src")>] normalize: (obj option -> bool -> obj option) = jsNative
let [<Import("*","src")>] getField: (obj option -> string -> obj option) = jsNative
let [<Import("*","src")>] parseResponseStatus: (string -> obj option -> obj option) = jsNative
let [<Import("*","src")>] toDate: (string -> DateTime) = jsNative
let [<Import("*","src")>] toDateFmt: (string -> string) = jsNative
let [<Import("*","src")>] padInt: (float -> U2<string, float>) = jsNative
let [<Import("*","src")>] dateFmt: (DateTime -> string) = jsNative
let [<Import("*","src")>] dateFmtHM: (DateTime -> string) = jsNative
let [<Import("*","src")>] timeFmt12: (DateTime -> string) = jsNative

type [<AllowNullLiteral>] IExports =
    abstract ResponseStatus: ResponseStatusStatic
    abstract ResponseError: ResponseErrorStatic
    abstract ErrorResponse: ErrorResponseStatic
    abstract NewInstanceResolver: NewInstanceResolverStatic
    abstract SingletonInstanceResolver: SingletonInstanceResolverStatic
    abstract IEventSource: IEventSourceStaticStatic
    abstract ServerEventsClient: ServerEventsClientStatic
    abstract ServerEventReceiver: ServerEventReceiverStatic
    abstract UpdateEventSubscriber: UpdateEventSubscriberStatic
    abstract UpdateEventSubscriberResponse: UpdateEventSubscriberResponseStatic
    abstract GetEventSubscribers: GetEventSubscribersStatic
    abstract ServerEventUser: ServerEventUserStatic
    abstract HttpMethods: HttpMethodsStatic
    abstract GetAccessTokenResponse: GetAccessTokenResponseStatic
    abstract JsonServiceClient: JsonServiceClientStatic

type [<AllowNullLiteral>] IReturnVoid =
    abstract createResponse: unit -> obj option

type [<AllowNullLiteral>] IReturn<'T> =
    abstract createResponse: unit -> 'T

type [<AllowNullLiteral>] ResponseStatus =
    abstract errorCode: string with get, set
    abstract message: string with get, set
    abstract stackTrace: string with get, set
    abstract errors: ResizeArray<ResponseError> with get, set
    abstract meta: obj with get, set

type [<AllowNullLiteral>] ResponseStatusStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> ResponseStatus

type [<AllowNullLiteral>] ResponseError =
    abstract errorCode: string with get, set
    abstract fieldName: string with get, set
    abstract message: string with get, set
    abstract meta: obj with get, set

type [<AllowNullLiteral>] ResponseErrorStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> ResponseError

type [<AllowNullLiteral>] ErrorResponse =
    abstract ``type``: ErrorResponseType with get, set
    abstract responseStatus: ResponseStatus with get, set

type [<AllowNullLiteral>] ErrorResponseStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> ErrorResponse

type [<StringEnum>] [<RequireQualifiedAccess>] ErrorResponseType =
    | [<CompiledName "RefreshTokenException">] RefreshTokenException

type [<AllowNullLiteral>] IResolver =
    abstract tryResolve: Function: obj option -> obj option

type [<AllowNullLiteral>] NewInstanceResolver =
    inherit IResolver
    abstract tryResolve: ctor: ObjectConstructor -> obj option

type [<AllowNullLiteral>] NewInstanceResolverStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> NewInstanceResolver

type [<AllowNullLiteral>] SingletonInstanceResolver =
    inherit IResolver
    abstract tryResolve: ctor: ObjectConstructor -> obj option

type [<AllowNullLiteral>] SingletonInstanceResolverStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> SingletonInstanceResolver

type [<AllowNullLiteral>] ServerEventMessage =
    abstract ``type``: U6<string, string, string, string, string, string> with get, set
    abstract eventId: float with get, set
    abstract channel: string with get, set
    abstract data: string with get, set
    abstract selector: string with get, set
    abstract json: string with get, set
    abstract op: string with get, set
    abstract target: string with get, set
    abstract cssSelector: string with get, set
    abstract body: obj option with get, set
    abstract meta: obj with get, set

type [<AllowNullLiteral>] ServerEventCommand =
    inherit ServerEventMessage
    abstract userId: string with get, set
    abstract displayName: string with get, set
    abstract channels: string with get, set
    abstract profileUrl: string with get, set

type [<AllowNullLiteral>] ServerEventConnect =
    inherit ServerEventCommand
    abstract id: string with get, set
    abstract unRegisterUrl: string with get, set
    abstract heartbeatUrl: string with get, set
    abstract updateSubscriberUrl: string with get, set
    abstract heartbeatIntervalMs: float with get, set
    abstract idleTimeoutMs: float with get, set

type [<AllowNullLiteral>] ServerEventHeartbeat =
    inherit ServerEventCommand

type [<AllowNullLiteral>] ServerEventJoin =
    inherit ServerEventCommand

type [<AllowNullLiteral>] ServerEventLeave =
    inherit ServerEventCommand

type [<AllowNullLiteral>] ServerEventUpdate =
    inherit ServerEventCommand

type [<AllowNullLiteral>] IReconnectServerEventsOptions =
    abstract url: string option with get, set
    abstract onerror: (ResizeArray<obj option> -> unit) option with get, set
    abstract onmessage: (ResizeArray<obj option> -> unit) option with get, set
    abstract error: Error option with get, set

type [<RequireQualifiedAccess>] ReadyState =
    | CONNECTING = 0
    | OPEN = 1
    | CLOSED = 2

type [<AllowNullLiteral>] IEventSourceStatic =
    inherit EventTarget
    abstract url: string with get, set
    abstract withCredentials: bool with get, set
    abstract CONNECTING: ReadyState with get, set
    abstract OPEN: ReadyState with get, set
    abstract CLOSED: ReadyState with get, set
    abstract readyState: ReadyState with get, set
    abstract onopen: Function with get, set
    abstract onmessage: (IOnMessageEvent -> unit) with get, set
    abstract onerror: Function with get, set
    abstract close: (unit -> unit) with get, set

type [<AllowNullLiteral>] IEventSourceStaticStatic =
    [<Emit "new $0($1...)">] abstract Create: url: string * ?eventSourceInitDict: IEventSourceInit -> IEventSourceStatic

type [<AllowNullLiteral>] IEventSourceInit =
    abstract withCredentials: bool option with get, set

type [<AllowNullLiteral>] IOnMessageEvent =
    abstract data: string with get, set

type [<AllowNullLiteral>] IEventSourceOptions =
    abstract channels: string option with get, set
    abstract handlers: obj option option with get, set
    abstract receivers: obj option option with get, set
    abstract onException: Function option with get, set
    abstract onReconnect: Function option with get, set
    abstract onTick: Function option with get, set
    abstract resolver: IResolver option with get, set
    abstract validate: (ServerEventMessage -> bool) option with get, set
    abstract heartbeatUrl: string option with get, set
    abstract unRegisterUrl: string option with get, set
    abstract updateSubscriberUrl: string option with get, set
    abstract heartbeatIntervalMs: float option with get, set
    abstract heartbeat: float option with get, set
    abstract resolveStreamUrl: (string -> string) option with get, set

type [<AllowNullLiteral>] ServerEventsClient =
    abstract channels: ResizeArray<string> with get, set
    abstract options: IEventSourceOptions with get, set
    abstract eventSource: IEventSourceStatic with get, set
    abstract UnknownChannel: string with get, set
    abstract eventStreamUri: string with get, set
    abstract updateSubscriberUrl: string with get, set
    abstract connectionInfo: ServerEventConnect with get, set
    abstract serviceClient: JsonServiceClient with get, set
    abstract stopped: bool with get, set
    abstract resolver: IResolver with get, set
    abstract listeners: obj with get, set
    abstract EventSource: IEventSourceStatic with get, set
    abstract withCredentials: bool with get, set
    abstract onMessage: (IOnMessageEvent -> unit) with get, set
    abstract onError: (obj option -> unit) with get, set
    abstract getEventSourceOptions: unit -> obj
    abstract reconnectServerEvents: ?opt: IReconnectServerEventsOptions -> IEventSourceStatic
    abstract start: unit -> ServerEventsClient
    abstract stop: unit -> Promise<unit>
    abstract invokeReceiver: r: obj option * cmd: string * el: Element * request: ServerEventMessage * name: string -> unit
    abstract hasConnected: unit -> bool
    abstract registerHandler: name: string * fn: Function -> ServerEventsClient
    abstract setResolver: resolver: IResolver -> ServerEventsClient
    abstract registerReceiver: receiver: obj option -> ServerEventsClient
    abstract registerNamedReceiver: name: string * receiver: obj option -> ServerEventsClient
    abstract unregisterReceiver: ?name: string -> ServerEventsClient
    abstract updateChannels: channels: ResizeArray<string> -> unit
    abstract update: subscribe: U2<string, ResizeArray<string>> * unsubscribe: U2<string, ResizeArray<string>> -> unit
    abstract addListener: eventName: string * handler: (ServerEventMessage -> unit) -> ServerEventsClient
    abstract removeListener: eventName: string * handler: (ServerEventMessage -> unit) -> ServerEventsClient
    abstract raiseEvent: eventName: string * msg: ServerEventMessage -> unit
    abstract getConnectionInfo: unit -> ServerEventConnect
    abstract getSubscriptionId: unit -> string
    abstract updateSubscriber: request: UpdateEventSubscriber -> Promise<unit>
    abstract subscribeToChannels: [<ParamArray>] channels: ResizeArray<string> -> Promise<unit>
    abstract unsubscribeFromChannels: [<ParamArray>] channels: ResizeArray<string> -> Promise<unit>
    abstract getChannelSubscribers: unit -> Promise<ResizeArray<ServerEventUser>>
    abstract toServerEventUser: map: ServerEventsClientToServerEventUserMap -> ServerEventUser

type [<AllowNullLiteral>] ServerEventsClientToServerEventUserMap =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: id: string -> string with get, set

type [<AllowNullLiteral>] ServerEventsClientStatic =
    [<Emit "new $0($1...)">] abstract Create: baseUrl: string * channels: ResizeArray<string> * ?options: IEventSourceOptions * ?eventSource: IEventSourceStatic -> ServerEventsClient

type [<AllowNullLiteral>] IReceiver =
    abstract noSuchMethod: selector: string * message: obj option -> obj option

type [<AllowNullLiteral>] ServerEventReceiver =
    inherit IReceiver
    abstract client: ServerEventsClient with get, set
    abstract request: ServerEventMessage with get, set
    abstract noSuchMethod: selector: string * message: obj option -> unit

type [<AllowNullLiteral>] ServerEventReceiverStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> ServerEventReceiver

type [<AllowNullLiteral>] UpdateEventSubscriber =
    inherit IReturn<UpdateEventSubscriberResponse>
    abstract id: string with get, set
    abstract subscribeChannels: ResizeArray<string> with get, set
    abstract unsubscribeChannels: ResizeArray<string> with get, set
    abstract createResponse: unit -> UpdateEventSubscriberResponse
    abstract getTypeName: unit -> string

type [<AllowNullLiteral>] UpdateEventSubscriberStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> UpdateEventSubscriber

type [<AllowNullLiteral>] UpdateEventSubscriberResponse =
    abstract responseStatus: ResponseStatus with get, set

type [<AllowNullLiteral>] UpdateEventSubscriberResponseStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> UpdateEventSubscriberResponse

type [<AllowNullLiteral>] GetEventSubscribers =
    inherit IReturn<ResizeArray<obj option>>
    abstract channels: ResizeArray<string> with get, set
    abstract createResponse: unit -> ResizeArray<obj option>
    abstract getTypeName: unit -> string

type [<AllowNullLiteral>] GetEventSubscribersStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> GetEventSubscribers

type [<AllowNullLiteral>] ServerEventUser =
    abstract userId: string with get, set
    abstract displayName: string with get, set
    abstract profileUrl: string with get, set
    abstract channels: ResizeArray<string> with get, set
    abstract meta: obj with get, set

type [<AllowNullLiteral>] ServerEventUserStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> ServerEventUser

type [<AllowNullLiteral>] HttpMethods =
    abstract Get: string with get, set
    abstract Post: string with get, set
    abstract Put: string with get, set
    abstract Delete: string with get, set
    abstract Patch: string with get, set
    abstract Head: string with get, set
    abstract Options: string with get, set
    abstract hasRequestBody: (string -> bool) with get, set

type [<AllowNullLiteral>] HttpMethodsStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> HttpMethods

type [<AllowNullLiteral>] IRequestFilterOptions =
    abstract url: string with get, set

type [<AllowNullLiteral>] Cookie =
    abstract name: string with get, set
    abstract value: string with get, set
    abstract path: string with get, set
    abstract domain: string option with get, set
    abstract expires: DateTime option with get, set
    abstract httpOnly: bool option with get, set
    abstract secure: bool option with get, set
    abstract sameSite: string option with get, set

type [<AllowNullLiteral>] GetAccessTokenResponse =
    abstract accessToken: string with get, set
    abstract responseStatus: ResponseStatus with get, set

type [<AllowNullLiteral>] GetAccessTokenResponseStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> GetAccessTokenResponse

type [<AllowNullLiteral>] ISendRequest =
    abstract ``method``: string with get, set
    abstract request: obj option option with get, set
    abstract body: obj option option option with get, set
    abstract args: obj option option with get, set
    abstract url: string option with get, set
    abstract returns: obj option with get, set

type [<AllowNullLiteral>] JsonServiceClient =
    abstract baseUrl: string with get, set
    abstract replyBaseUrl: string with get, set
    abstract oneWayBaseUrl: string with get, set
    abstract mode: RequestMode with get, set
    abstract credentials: RequestCredentials with get, set
    abstract headers: Headers with get, set
    abstract userName: string with get, set
    abstract password: string with get, set
    abstract bearerToken: string with get, set
    abstract refreshToken: string with get, set
    abstract refreshTokenUri: string with get, set
    abstract requestFilter: (Request -> IRequestFilterOptions -> unit) with get, set
    abstract responseFilter: (Response -> unit) with get, set
    abstract exceptionFilter: (Response -> obj option -> unit) with get, set
    abstract onAuthenticationRequired: (unit -> Promise<obj option>) with get, set
    abstract manageCookies: bool with get, set
    abstract cookies: obj with get, set
    abstract toBase64: (string -> string) with get, set
    abstract setCredentials: userName: string * password: string -> unit
    abstract setBearerToken: token: string -> unit
    abstract get: request: U2<IReturn<'T>, string> * ?args: obj option -> Promise<'T>
    abstract delete: request: U2<IReturn<'T>, string> * ?args: obj option -> Promise<'T>
    abstract post: request: IReturn<'T> * ?args: obj option -> Promise<'T>
    abstract postToUrl: url: string * request: IReturn<'T> * ?args: obj option -> Promise<'T>
    abstract postBody: request: IReturn<'T> * body: U2<string, obj option> * ?args: obj option -> Promise<'T>
    abstract put: request: IReturn<'T> * ?args: obj option -> Promise<'T>
    abstract putToUrl: url: string * request: IReturn<'T> * ?args: obj option -> Promise<'T>
    abstract putBody: request: IReturn<'T> * body: U2<string, obj option> * ?args: obj option -> Promise<'T>
    abstract patch: request: IReturn<'T> * ?args: obj option -> Promise<'T>
    abstract patchToUrl: url: string * request: IReturn<'T> * ?args: obj option -> Promise<'T>
    abstract patchBody: request: IReturn<'T> * body: U2<string, obj option> * ?args: obj option -> Promise<'T>
    abstract createUrlFromDto: ``method``: string * request: IReturn<'T> -> string
    abstract toAbsoluteUrl: relativeOrAbsoluteUrl: string -> string
    // abstract createRequest: {method, request, url, args, body}: obj -> unit
    abstract createResponse: res: obj * request: obj -> unit
    abstract handleError: holdRes: obj * res: obj * ?``type``: obj -> unit
    abstract send: ``method``: string * request: obj option option * ?args: obj option * ?url: string -> Promise<'T>
    abstract sendBody: ``method``: obj * request: obj * body: obj * ?args: obj -> unit
    abstract sendRequest: info: ISendRequest -> Promise<'T>
    abstract raiseError: res: Response * error: obj option -> obj option

type [<AllowNullLiteral>] JsonServiceClientStatic =
    [<Emit "new $0($1...)">] abstract Create: baseUrl: string -> JsonServiceClient
