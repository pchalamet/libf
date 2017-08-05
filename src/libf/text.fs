module text

type TextReader = System.IO.TextReader

type TextWriter = System.IO.TextWriter

type Result<'t> = std.result.Result<'t, std.io.Error>

let stdin () : Result<TextReader> = 
    System.Console.In |> Result<TextReader>.Ok
    
let stdout () : Result<TextWriter>  = 
    System.Console.Out |> Result<TextWriter>.Ok

let readln (tr : TextReader) : Result<string> =
    tr.ReadLine() |> Result<string>.Ok

