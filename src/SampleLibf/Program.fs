// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open std

[<EntryPoint>]
let main argv = 

    //let r = Result.Ok 42
    let r = (fun () -> 42) |> toResult
            |> and_then (fun x -> x + 10)
            |> ok "failure"

    printfn "%A" r


    0 // return an integer exit code
