module io

open System
open System.IO
open std


type TextReader = Reader of System.IO.TextReader

type TextWriter = Writer of System.IO.TextWriter



let stdin () : IoResult<TextReader> = 
    (fun () -> Reader Console.In) |> toResult
    
let stdout () : IoResult<TextWriter> =
    (fun () -> Writer Console.Out) |> toResult 

let readln (TextReader.Reader stm) =
    stm.ReadLine()

let writeln (TextWriter.Writer stm ) (m : string) : unit =
    stm.WriteLine(m)

let openRead (f : string) : IoResult<TextReader> =
    (fun () -> Reader (System.IO.File.OpenText(f))) |> toResult

let openWrite (f : string) : IoResult<TextWriter> =
    (fun () -> Writer (System.IO.File.CreateText(f))) |> toResult
