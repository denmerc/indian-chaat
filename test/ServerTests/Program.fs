// Learn more about F# at http://fsharp.org

open System
open Expecto


[<EntryPoint>]
let main args =
    printfn "Hello World from F#!"
    runTestsInAssembly {defaultConfig with ``parallel`` = false} args
