module io
open std

type TextReader

type TextWriter

val stdin : Unit -> IoResult<TextReader>

val stdout : Unit -> IoResult<TextWriter>

val openRead : string -> IoResult<TextReader>

val openWrite : string -> IoResult<TextWriter>

val readln : TextReader -> string

val writeln : TextWriter -> string -> unit
