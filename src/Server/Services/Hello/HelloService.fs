namespace Service
open ServiceStack
open Dto


type HelloService() =
    inherit Service()

    member __.Any (request : Hello) =
        { Result = sprintf "Hello, %s !" request.Name}