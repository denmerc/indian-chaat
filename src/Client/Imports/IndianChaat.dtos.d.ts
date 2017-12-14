export interface IReturn<T> {
    createResponse(): T;
}
export interface IReturnVoid {
    createResponse(): void;
}
export declare class Message {
    data: string;
    color: string;
}
export declare class HelloResponse {
    result: string;
}
export declare class OutPutMessages {
    data: Message[];
}
export declare class Hello implements IReturn<HelloResponse> {
    name: string;
    createResponse(): HelloResponse;
    getTypeName(): string;
}
export declare class InputMessage implements IReturn<OutPutMessages> {
    userId: number;
    created: string;
    message: Message;
    createResponse(): OutPutMessages;
    getTypeName(): string;
}
