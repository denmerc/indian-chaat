namespace Helper


type Agent<'a> = MailboxProcessor<'a>



module ChaatHelper =
    open Dto
    open System.Collections.Generic
    open System
    open System.Threading

    type Utility() =
        static let rand = Random()

        static member RandomSleep() =
            let ms = rand.Next(1,1000)
            Thread.Sleep ms


    let storage = new List<Message>()

    let blastAgent = Agent<List<Message>>.Start(fun inbox ->
        let rec messageLoop() = async {
            let! msg = inbox.Receive()
            Utility.RandomSleep()
            let sse = ServiceStack.ServiceStackHost.Instance.Container.TryResolve<ServiceStack.IServerEvents>()
            let blastObject = {Data = (msg.ToArray())}
            sse.NotifyChannel("home","cmd.chat", blastObject)
            return! messageLoop()
        }
        messageLoop()
    )

    let chaatAgent = Agent<InputMessage>.Start(fun inbox ->
        let rec messageLoop() = async {
            let! msg = inbox.Receive()
            Utility.RandomSleep()
            storage.Add(msg.Message)
            blastAgent.Post storage
            return! messageLoop()
        }
        messageLoop()
    )


