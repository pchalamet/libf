module io
open std

type TextReader

type TextWriter

val ok : Result<'t> -> 't option

val expect : Result<'t> -> string -> 't

val stdin : Unit -> Result<TextReader>

val stdout : Unit -> Result<TextWriter>

val readln : TextReader -> Result<string>

val writeln : TextWriter -> string -> Result<TextWriter>
