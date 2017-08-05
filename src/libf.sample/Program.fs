
open std
open std.result


[<EntryPoint>]
let main argv = 

    let content = io.stdin()
                  |> and_then io.read_line
                  |> expect "read fail"
    printfn "%s" content

    0 // return an integer exit code
