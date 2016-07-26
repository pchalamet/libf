module io
open std

type TextReader

type TextWriter

val stdin : Unit -> Result<TextReader>

val stdout : Unit -> Result<TextWriter>

val openRead : string -> Result<TextReader>

val openWrite : string -> Result<TextWriter>

val readln : TextReader -> string

val writeln : TextWriter -> string -> unit
