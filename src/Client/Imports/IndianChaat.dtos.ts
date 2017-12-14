/* Options:
Date: 2017-12-14 16:03:37
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


export interface IReturn<T>
{
    createResponse() : T;
}

export interface IReturnVoid
{
    createResponse() : void;
}

export class Message
{
    data: string;
    color: string;
}

export class HelloResponse
{
    result: string;
}

export class OutPutMessages
{
    data: Message[];
}

// @Route("/hello")
// @Route("/hello/{Name}")
export class Hello implements IReturn<HelloResponse>
{
    name: string;
    createResponse() { return new HelloResponse(); }
    getTypeName() { return "Hello"; }
}

// @Route("/Chat")
export class InputMessage implements IReturn<OutPutMessages>
{
    userId: number;
    created: string;
    message: Message;
    createResponse() { return new OutPutMessages(); }
    getTypeName() { return "InputMessage"; }
}
