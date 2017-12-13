"use strict";
/* Options:
Date: 2017-12-13 19:45:45
Version: 5.00
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://localhost:5000

//GlobalNamespace:
//MakePropertiesOptional: True
//AddServiceStackTypes: True
//AddResponseStatus: False
//AddImplicitVersion:
//AddDescriptionAsComments: True
//IncludeTypes:
//ExcludeTypes:
//DefaultImports:
*/
exports.__esModule = true;
// @Flags()
var CacheControl;
(function (CacheControl) {
    CacheControl[CacheControl["None"] = 0] = "None";
    CacheControl[CacheControl["Public"] = 1] = "Public";
    CacheControl[CacheControl["Private"] = 2] = "Private";
    CacheControl[CacheControl["MustRevalidate"] = 4] = "MustRevalidate";
    CacheControl[CacheControl["NoCache"] = 8] = "NoCache";
    CacheControl[CacheControl["NoStore"] = 16] = "NoStore";
    CacheControl[CacheControl["NoTransform"] = 32] = "NoTransform";
    CacheControl[CacheControl["ProxyRevalidate"] = 64] = "ProxyRevalidate";
})(CacheControl = exports.CacheControl || (exports.CacheControl = {}));
// @Flags()
var RequestAttributes;
(function (RequestAttributes) {
    RequestAttributes[RequestAttributes["None"] = 0] = "None";
    RequestAttributes[RequestAttributes["Localhost"] = 1] = "Localhost";
    RequestAttributes[RequestAttributes["LocalSubnet"] = 2] = "LocalSubnet";
    RequestAttributes[RequestAttributes["External"] = 4] = "External";
    RequestAttributes[RequestAttributes["Secure"] = 8] = "Secure";
    RequestAttributes[RequestAttributes["InSecure"] = 16] = "InSecure";
    RequestAttributes[RequestAttributes["AnySecurityMode"] = 24] = "AnySecurityMode";
    RequestAttributes[RequestAttributes["HttpHead"] = 32] = "HttpHead";
    RequestAttributes[RequestAttributes["HttpGet"] = 64] = "HttpGet";
    RequestAttributes[RequestAttributes["HttpPost"] = 128] = "HttpPost";
    RequestAttributes[RequestAttributes["HttpPut"] = 256] = "HttpPut";
    RequestAttributes[RequestAttributes["HttpDelete"] = 512] = "HttpDelete";
    RequestAttributes[RequestAttributes["HttpPatch"] = 1024] = "HttpPatch";
    RequestAttributes[RequestAttributes["HttpOptions"] = 2048] = "HttpOptions";
    RequestAttributes[RequestAttributes["HttpOther"] = 4096] = "HttpOther";
    RequestAttributes[RequestAttributes["AnyHttpMethod"] = 8160] = "AnyHttpMethod";
    RequestAttributes[RequestAttributes["OneWay"] = 8192] = "OneWay";
    RequestAttributes[RequestAttributes["Reply"] = 16384] = "Reply";
    RequestAttributes[RequestAttributes["AnyCallStyle"] = 24576] = "AnyCallStyle";
    RequestAttributes[RequestAttributes["Soap11"] = 32768] = "Soap11";
    RequestAttributes[RequestAttributes["Soap12"] = 65536] = "Soap12";
    RequestAttributes[RequestAttributes["Xml"] = 131072] = "Xml";
    RequestAttributes[RequestAttributes["Json"] = 262144] = "Json";
    RequestAttributes[RequestAttributes["Jsv"] = 524288] = "Jsv";
    RequestAttributes[RequestAttributes["ProtoBuf"] = 1048576] = "ProtoBuf";
    RequestAttributes[RequestAttributes["Csv"] = 2097152] = "Csv";
    RequestAttributes[RequestAttributes["Html"] = 4194304] = "Html";
    RequestAttributes[RequestAttributes["Wire"] = 8388608] = "Wire";
    RequestAttributes[RequestAttributes["MsgPack"] = 16777216] = "MsgPack";
    RequestAttributes[RequestAttributes["FormatOther"] = 33554432] = "FormatOther";
    RequestAttributes[RequestAttributes["AnyFormat"] = 67076096] = "AnyFormat";
    RequestAttributes[RequestAttributes["Http"] = 67108864] = "Http";
    RequestAttributes[RequestAttributes["MessageQueue"] = 134217728] = "MessageQueue";
    RequestAttributes[RequestAttributes["Tcp"] = 268435456] = "Tcp";
    RequestAttributes[RequestAttributes["EndpointOther"] = 536870912] = "EndpointOther";
    RequestAttributes[RequestAttributes["AnyEndpoint"] = 1006632960] = "AnyEndpoint";
    RequestAttributes[RequestAttributes["InProcess"] = 1073741824] = "InProcess";
    RequestAttributes[RequestAttributes["InternalNetworkAccess"] = 1073741827] = "InternalNetworkAccess";
    RequestAttributes[RequestAttributes["AnyNetworkAccessType"] = 1073741831] = "AnyNetworkAccessType";
    RequestAttributes[RequestAttributes["Any"] = 1140850687] = "Any";
})(RequestAttributes = exports.RequestAttributes || (exports.RequestAttributes = {}));
var HelloResponse = /** @class */ (function () {
    function HelloResponse() {
    }
    return HelloResponse;
}());
exports.HelloResponse = HelloResponse;
var HttpResult = /** @class */ (function () {
    function HttpResult() {
    }
    return HttpResult;
}());
exports.HttpResult = HttpResult;
// @Route("/hello")
// @Route("/hello/{Name}")
var Hello = /** @class */ (function () {
    function Hello() {
    }
    Hello.prototype.createResponse = function () { return new HelloResponse(); };
    Hello.prototype.getTypeName = function () { return "Hello"; };
    return Hello;
}());
exports.Hello = Hello;
// @Route("/reset")
var ClearChatHistory = /** @class */ (function () {
    function ClearChatHistory() {
    }
    ClearChatHistory.prototype.createResponse = function () { };
    ClearChatHistory.prototype.getTypeName = function () { return "ClearChatHistory"; };
    return ClearChatHistory;
}());
exports.ClearChatHistory = ClearChatHistory;
