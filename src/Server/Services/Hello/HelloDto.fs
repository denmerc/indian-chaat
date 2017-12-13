namespace Dto
open ServiceStack

[<CLIMutable>]
type HelloResponse = {
    Result : string
}

[<CLIMutableAttribute>]
[<Route("/hello")>]
[<Route("/hello/{Name}")>]
type Hello = {
    Name : string
}
with interface IReturn<HelloResponse>