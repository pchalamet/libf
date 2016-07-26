module io
open std

type TextReader

type TextWriter

val stdin : Unit -> Result<TextReader>

val stdout : Unit -> Result<TextWriter>

val readln : TextReader -> Result<string>

val writeln : TextWriter -> string -> Result<TextWriter>
