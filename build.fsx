open System.Runtime.InteropServices
(**
FAKE build script the rule them all
*)

#r @"packages/build/FAKE/tools/FakeLib.dll"
#r @"packages/build/Newtonsoft.Json/lib/net45/Newtonsoft.Json.dll"
open Fake
open System.IO
open Newtonsoft.Json.Linq
open System
open Fake.ReleaseNotesHelper

let serverPath = "./src/Server/" |> FullName
let serverTestsPath = "./test/ServerTests/" |> FullName

let dockerUser = getBuildParam "DockerUser"
let dockerPassword = getBuildParam "DockerPassword"
let dockerLoginServer = getBuildParam "DockerLoginServer"
let dockerImageName = getBuildParam "DockerImageName"

let deployDir = "./deploy"

let dotnetcliVersion : string =
    try
        let content = File.ReadAllText "global.json"
        let json = Newtonsoft.Json.Linq.JObject.Parse content
        let sdk = json.Item("sdk") :?> JObject
        let version = sdk.Property("version").Value.ToString()
        version
    with
    | exn -> failwithf "Could not parse global.json: %s" exn.Message

let mutable dotnetExePath = "dotnet"



let run' timeout cmd args dir =
    if execProcess (fun info ->
        info.FileName <- cmd
        if not (String.IsNullOrWhiteSpace dir) then
            info.WorkingDirectory <- dir
        info.Arguments <- args
    ) timeout |> not then
        failwithf "Error while running '%s' with args: %s" cmd args

let run = run' System.TimeSpan.MaxValue

let runDotnet workingDir args =
    let result =
        ExecProcess (fun info ->
            info.FileName <- dotnetExePath
            info.WorkingDirectory <- workingDir
            info.Arguments <- args) TimeSpan.MaxValue
    if result <> 0 then failwithf "dotnet %s failed" args

let platformTool tool winTool =
    let tool = if isUnix then tool else winTool
    tool
    |> ProcessHelper.tryFindFileOnPath
    |> function Some t -> t | _ -> failwithf "%s not found" tool

let nodeTool = platformTool "node" "node.exe"
let npmTool = platformTool "npm" "npm.cmd"
let yarnTool = platformTool "yarn" "yarn.cmd"

do if not isWindows then
    // We have to set the FrameworkPathOverride so that dotnet sdk invocations know
    // where to look for full-framework base class libraries
    let mono = platformTool "mono" "mono"
    let frameworkPath = IO.Path.GetDirectoryName(mono) </> ".." </> "lib" </> "mono" </> "4.5"
    setEnvironVar "FrameworkPathOverride" frameworkPath

let releaseNotes = File.ReadAllLines "RELEASE_NOTES.md"
let releaseNotesData =
    releaseNotes
    |> parseAllReleaseNotes

let release = List.head releaseNotesData

let packageVersion = SemVerHelper.parse release.NugetVersion

//-------------------------
//Clean build results
Target "Clean" (fun _ ->
    !!"src/**/bin"
    ++ "test/**/bin"
    |> CleanDirs

    !! "src/**/obj/*.nuspec"
    ++ "test/**/obj/*.nuspec"
    |> DeleteFiles

    CleanDirs ["bin"; "temp"; "docs/output"; deployDir]
)

Target "InstallDotNetCore" (fun _ ->
    dotnetExePath <- DotNetCli.InstallDotNetSDK dotnetcliVersion
)

//-----------------------------
// Build App and Test Project
Target "BuildServer" (fun _ ->
    runDotnet serverPath "build"
)

Target "BuildServerTests" (fun _ ->
    runDotnet serverTestsPath "build"
)

//-----------------------------
// Run tests
Target "RunServerTests" (fun _ ->
    runDotnet serverTestsPath "run"
)

//-------------------------
Target "PublishApp" (fun _ ->
    let result =
        ExecProcess (fun info ->
            info.FileName <- dotnetExePath
            info.WorkingDirectory <- serverPath
            info.Arguments <- "publish -c Release -o \"" + FullName deployDir + "\"") TimeSpan.MaxValue
    if result <> 0 then failwith "Publish failed"
)

//-------------------------
// Run web app

let ipAddress = "localhost"
let port = 5000


Target "Run" (fun _ ->
    runDotnet serverTestsPath "restore"

    let unitTestsWatch = async {
        let result =
            ExecProcess (fun info ->
                info.FileName <- dotnetExePath
                info.WorkingDirectory <- serverTestsPath
                info.Arguments <- sprintf "watch msbuild /t:TestAndRun /p:DotNetHost=%s" dotnetExePath) TimeSpan.MaxValue

        if result <> 0 then failwith "Website shut down." }

    let openBrowser = async {
        System.Threading.Thread.Sleep(5000)
        Diagnostics.Process.Start("http://"+ ipAddress + sprintf ":%d" port) |> ignore }

    Async.Parallel [| unitTestsWatch; openBrowser |]
    |> Async.RunSynchronously
    |> ignore
)

Target "Build" DoNothing
Target "All" DoNothing

"Clean"
==> "InstallDotNetCore"
==> "BuildServer"
==> "BuildServerTests"
==> "RunServerTests"
==> "PublishApp"
==> "All"


"InstallDotNetCore"
==> "Run"

"BuildServer"
  ==> "Build"

RunTargetOrDefault "All"