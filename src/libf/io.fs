module std.io

open System
open System.IO


type TextReader = Reader of System.IO.TextReader

type TextWriter = Writer of System.IO.TextWriter

type Error = int

type Result<'t> = std.result<'t, Error>


let stdin () : Result<TextReader> = 
    (fun () -> Reader Console.In) |> toResult
    
let stdout () : Result<TextWriter> =
    (fun () -> Writer Console.Out) |> toResult 

let readln (TextReader.Reader stm) =
    stm.ReadLine()

let writeln (TextWriter.Writer stm ) (m : string) : unit =
    stm.WriteLine(m)

let openRead (f : string) : Result<TextReader> =
    (fun () -> Reader (System.IO.File.OpenText(f))) |> toResult

let openWrite (f : string) : Result<TextWriter> =
    (fun () -> Writer (System.IO.File.CreateText(f))) |> toResult
