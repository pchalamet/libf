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



let stdin () = 
    (fun () -> { TextReader.Stream = Console.In }) |> toResult
    
let stdout () =
    (fun () -> { TextWriter.Stream = Console.Out }) |> toResult 

let readln (s : TextReader) : Result<string> =
    s.Stream.ReadLine |> toResult

let writeln (s : TextWriter) (m : string) : Result<TextWriter> =
    (fun () -> s.Stream.WriteLine m; s) |> toResult
