
open std
open std.result


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

    let content = text.stdin()
                  |> and_then text.readln
                  |> expect "read fail"
    printfn "%s" content

    0 // return an integer exit code
