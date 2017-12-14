"use strict";
/* Options:
Date: 2017-12-14 12:32:47
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
var Message = /** @class */ (function () {
    function Message() {
    }
    return Message;
}());
exports.Message = Message;
var HelloResponse = /** @class */ (function () {
    function HelloResponse() {
    }
    return HelloResponse;
}());
exports.HelloResponse = HelloResponse;
var OutPutMessages = /** @class */ (function () {
    function OutPutMessages() {
    }
    return OutPutMessages;
}());
exports.OutPutMessages = OutPutMessages;
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
// @Route("/Chat")
var InputMessage = /** @class */ (function () {
    function InputMessage() {
    }
    InputMessage.prototype.createResponse = function () { return new OutPutMessages(); };
    InputMessage.prototype.getTypeName = function () { return "InputMessage"; };
    return InputMessage;
}());
exports.InputMessage = InputMessage;
