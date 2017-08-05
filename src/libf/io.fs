module std.io

type File = System.IO.Stream

type Error =
    | NotFound
    | PermissionDenied
    | AlreadyExists 
    | UnexpectedEof

type Result<'t> = std.result.Result<'t, Error>

type TextReader = System.IO.TextReader

type TextWriter = System.IO.TextWriter

let stdin () : Result<TextReader> = 
    System.Console.In |> Result<TextReader>.Ok
    
let stdout () : Result<TextWriter>  = 
    System.Console.Out |> Result<TextWriter>.Ok


let read_line (tr : TextReader) : Result<string> =
    tr.ReadLine() |> Result<string>.Ok
