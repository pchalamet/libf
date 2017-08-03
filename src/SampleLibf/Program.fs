// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open std


let getValue (x : int) =
    failwithf "toto"

let printValue f =
    try
        let r = f()
        printfn "%A" r
    with    
        exn -> printfn "%A" exn

[<EntryPoint>]
let main argv = 

    let content = io.openRead "c:/src/tree.dgml" 
                  |> and_then io.readln
                  |> ok "read fail"
    printfn "%s" content

    //let r = Result.Ok 42
    let r = (fun () -> 42) |> toResult
            |> and_then (fun x -> x + 10)
            |> ok "failure"
    printfn "%A" r


    0 // return an integer exit code
