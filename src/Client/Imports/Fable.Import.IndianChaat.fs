// ts2fable 0.6.0-build.165
module rec Fable.Import.IndianChaat
open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.SSClient


type [<AllowNullLiteral>] IExports =
    abstract HelloResponse: HelloResponseStatic
    abstract HttpResult: HttpResultStatic
    abstract Hello: HelloStatic
    abstract ClearChatHistory: ClearChatHistoryStatic

// type [<AllowNullLiteral>] IReturn<'T> =
//     abstract createResponse: unit -> 'T

// type [<AllowNullLiteral>] IReturnVoid =
//     abstract createResponse: unit -> unit

type [<RequireQualifiedAccess>] CacheControl =
    | None = 0
    | Public = 1
    | Private = 2
    | MustRevalidate = 4
    | NoCache = 8
    | NoStore = 16
    | NoTransform = 32
    | ProxyRevalidate = 64

type [<AllowNullLiteral>] IContentTypeWriter =
    interface end

type [<RequireQualifiedAccess>] RequestAttributes =
    | None = 0
    | Localhost = 1
    | LocalSubnet = 2
    | External = 4
    | Secure = 8
    | InSecure = 16
    | AnySecurityMode = 24
    | HttpHead = 32
    | HttpGet = 64
    | HttpPost = 128
    | HttpPut = 256
    | HttpDelete = 512
    | HttpPatch = 1024
    | HttpOptions = 2048
    | HttpOther = 4096
    | AnyHttpMethod = 8160
    | OneWay = 8192
    | Reply = 16384
    | AnyCallStyle = 24576
    | Soap11 = 32768
    | Soap12 = 65536
    | Xml = 131072
    | Json = 262144
    | Jsv = 524288
    | ProtoBuf = 1048576
    | Csv = 2097152
    | Html = 4194304
    | Wire = 8388608
    | MsgPack = 16777216
    | FormatOther = 33554432
    | AnyFormat = 67076096
    | Http = 67108864
    | MessageQueue = 134217728
    | Tcp = 268435456
    | EndpointOther = 536870912
    | AnyEndpoint = 1006632960
    | InProcess = 1073741824
    | InternalNetworkAccess = 1073741827
    | AnyNetworkAccessType = 1073741831
    | Any = 1140850687

type [<AllowNullLiteral>] IRequestPreferences =
    abstract acceptsGzip: bool option with get, set
    abstract acceptsDeflate: bool option with get, set

type [<AllowNullLiteral>] IRequest =
    abstract originalRequest: Object option with get, set
    abstract response: IResponse option with get, set
    abstract operationName: string option with get, set
    abstract verb: string option with get, set
    abstract requestAttributes: RequestAttributes option with get, set
    abstract requestPreferences: IRequestPreferences option with get, set
    abstract dto: Object option with get, set
    abstract contentType: string option with get, set
    abstract isLocal: bool option with get, set
    abstract userAgent: string option with get, set
    abstract cookies: obj option with get, set
    abstract responseContentType: string option with get, set
    abstract hasExplicitResponseContentType: bool option with get, set
    abstract items: obj option with get, set
    abstract headers: obj option option with get, set
    abstract queryString: obj option option with get, set
    abstract formData: obj option option with get, set
    abstract useBufferedStream: bool option with get, set
    abstract rawUrl: string option with get, set
    abstract absoluteUri: string option with get, set
    abstract userHostAddress: string option with get, set
    abstract remoteIp: string option with get, set
    abstract authorization: string option with get, set
    abstract isSecureConnection: bool option with get, set
    abstract acceptTypes: ResizeArray<string> option with get, set
    abstract pathInfo: string option with get, set
    abstract originalPathInfo: string option with get, set
    abstract contentLength: float option with get, set
    abstract files: ResizeArray<IHttpFile> option with get, set
    abstract urlReferrer: obj option option with get, set

type [<AllowNullLiteral>] IResponse =
    abstract originalResponse: Object option with get, set
    abstract request: IRequest option with get, set
    abstract statusCode: float option with get, set
    abstract statusDescription: string option with get, set
    abstract contentType: string option with get, set
    abstract dto: Object option with get, set
    abstract useBufferedStream: bool option with get, set
    abstract isClosed: bool option with get, set
    abstract keepAlive: bool option with get, set
    abstract items: obj option with get, set

type [<AllowNullLiteral>] IHttpFile =
    abstract name: string option with get, set
    abstract fileName: string option with get, set
    abstract contentLength: float option with get, set
    abstract contentType: string option with get, set

type [<AllowNullLiteral>] HelloResponse =
    abstract result: string with get, set

type [<AllowNullLiteral>] HelloResponseStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> HelloResponse

type [<AllowNullLiteral>] HttpResult =
    abstract responseText: string with get, set
    abstract fileInfo: obj option with get, set
    abstract contentType: string with get, set
    abstract headers: obj with get, set
    abstract cookies: ResizeArray<obj option> with get, set
    abstract eTag: string with get, set
    abstract age: string with get, set
    abstract maxAge: string with get, set
    abstract expires: string with get, set
    abstract lastModified: string with get, set
    abstract cacheControl: CacheControl with get, set
    abstract resultScope: obj option with get, set
    abstract allowsPartialResponse: bool with get, set
    abstract options: obj with get, set
    abstract status: float with get, set
    abstract statusCode: obj option with get, set
    abstract statusDescription: string with get, set
    abstract response: Object with get, set
    abstract responseFilter: IContentTypeWriter with get, set
    abstract requestContext: IRequest with get, set
    abstract view: string with get, set
    abstract template: string with get, set
    abstract paddingLength: float with get, set
    abstract isPartialRequest: bool with get, set

type [<AllowNullLiteral>] HttpResultStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> HttpResult

type [<AllowNullLiteral>] Hello =
    inherit IReturn<HelloResponse>
    abstract name: string with get, set
    abstract createResponse: unit -> HelloResponse
    abstract getTypeName: unit -> string

type [<AllowNullLiteral>] HelloStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Hello

type [<AllowNullLiteral>] ClearChatHistory =
    inherit IReturnVoid
    abstract createResponse: unit -> unit
    abstract getTypeName: unit -> string

type [<AllowNullLiteral>] ClearChatHistoryStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> ClearChatHistory
