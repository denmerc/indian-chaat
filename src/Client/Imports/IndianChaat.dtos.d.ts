export interface IReturn<T> {
    createResponse(): T;
}
export interface IReturnVoid {
    createResponse(): void;
}
export declare enum CacheControl {
    None = 0,
    Public = 1,
    Private = 2,
    MustRevalidate = 4,
    NoCache = 8,
    NoStore = 16,
    NoTransform = 32,
    ProxyRevalidate = 64,
}
export interface IContentTypeWriter {
}
export declare enum RequestAttributes {
    None = 0,
    Localhost = 1,
    LocalSubnet = 2,
    External = 4,
    Secure = 8,
    InSecure = 16,
    AnySecurityMode = 24,
    HttpHead = 32,
    HttpGet = 64,
    HttpPost = 128,
    HttpPut = 256,
    HttpDelete = 512,
    HttpPatch = 1024,
    HttpOptions = 2048,
    HttpOther = 4096,
    AnyHttpMethod = 8160,
    OneWay = 8192,
    Reply = 16384,
    AnyCallStyle = 24576,
    Soap11 = 32768,
    Soap12 = 65536,
    Xml = 131072,
    Json = 262144,
    Jsv = 524288,
    ProtoBuf = 1048576,
    Csv = 2097152,
    Html = 4194304,
    Wire = 8388608,
    MsgPack = 16777216,
    FormatOther = 33554432,
    AnyFormat = 67076096,
    Http = 67108864,
    MessageQueue = 134217728,
    Tcp = 268435456,
    EndpointOther = 536870912,
    AnyEndpoint = 1006632960,
    InProcess = 1073741824,
    InternalNetworkAccess = 1073741827,
    AnyNetworkAccessType = 1073741831,
    Any = 1140850687,
}
export interface IRequestPreferences {
    acceptsGzip?: boolean;
    acceptsDeflate?: boolean;
}
export interface IRequest {
    originalRequest?: Object;
    response?: IResponse;
    operationName?: string;
    verb?: string;
    requestAttributes?: RequestAttributes;
    requestPreferences?: IRequestPreferences;
    dto?: Object;
    contentType?: string;
    isLocal?: boolean;
    userAgent?: string;
    cookies?: {
        [index: string]: any;
    };
    responseContentType?: string;
    hasExplicitResponseContentType?: boolean;
    items?: {
        [index: string]: Object;
    };
    headers?: any;
    queryString?: any;
    formData?: any;
    useBufferedStream?: boolean;
    rawUrl?: string;
    absoluteUri?: string;
    userHostAddress?: string;
    remoteIp?: string;
    authorization?: string;
    isSecureConnection?: boolean;
    acceptTypes?: string[];
    pathInfo?: string;
    originalPathInfo?: string;
    contentLength?: number;
    files?: IHttpFile[];
    urlReferrer?: any;
}
export interface IResponse {
    originalResponse?: Object;
    request?: IRequest;
    statusCode?: number;
    statusDescription?: string;
    contentType?: string;
    dto?: Object;
    useBufferedStream?: boolean;
    isClosed?: boolean;
    keepAlive?: boolean;
    items?: {
        [index: string]: Object;
    };
}
export interface IHttpFile {
    name?: string;
    fileName?: string;
    contentLength?: number;
    contentType?: string;
}
export declare class HelloResponse {
    result: string;
}
export declare class HttpResult {
    responseText: string;
    fileInfo: any;
    contentType: string;
    headers: {
        [index: string]: string;
    };
    cookies: any[];
    eTag: string;
    age: string;
    maxAge: string;
    expires: string;
    lastModified: string;
    cacheControl: CacheControl;
    resultScope: any;
    allowsPartialResponse: boolean;
    options: {
        [index: string]: string;
    };
    status: number;
    statusCode: any;
    statusDescription: string;
    response: Object;
    responseFilter: IContentTypeWriter;
    requestContext: IRequest;
    view: string;
    template: string;
    paddingLength: number;
    isPartialRequest: boolean;
}
export declare class Hello implements IReturn<HelloResponse> {
    name: string;
    createResponse(): HelloResponse;
    getTypeName(): string;
}
export declare class ClearChatHistory implements IReturnVoid {
    createResponse(): void;
    getTypeName(): string;
}
