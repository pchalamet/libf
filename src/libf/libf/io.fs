module io

open System
open System.IO
open std


type TextReader = 
    {
        Stream : IO.TextReader
    }

type TextWriter =
    {
        Stream : IO.TextWriter    
    }


let toResult f =
    try
        Result.Ok (f())
    with exn -> Result.Err exn


let ok (r : Result<'t>) : 't option =
    match r with
    | Result.Ok t -> Some t
    | Result.Err _ -> None

let expect (r : Result<'t>) (m : string) : 't =
    match r with
    | Result.Ok t -> t
    | Result.Err exn -> raise (System.Exception(m, exn))

let stdin () = 
    (fun () -> { TextReader.Stream = Console.In }) |> toResult
    
let stdout () =
    (fun () -> { TextWriter.Stream = Console.Out }) |> toResult 

let readln (s : TextReader) : Result<string> =
    (fun () -> s.Stream.ReadLine()) |> toResult

let writeln (s : TextWriter) (m : string) : Result<TextWriter> =
    (fun () -> s.Stream.WriteLine m; s) |> toResult

