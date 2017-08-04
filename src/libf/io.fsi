module std.io

type TextReader

type TextWriter

type Error

type Result<'t>

val stdin : Unit -> Result<TextReader>

val stdout : Unit -> Result<TextWriter>

val openRead : string -> Result<TextReader>

val openWrite : string -> Result<TextWriter>

val readln : TextReader -> string

val writeln : TextWriter -> string -> unit
