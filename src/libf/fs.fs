module std.fs
open std.io


let open_read (path : string) =
    path |> System.IO.File.OpenRead :> System.IO.Stream
         |> Result<File>.Ok

let open_write (path : string) =
    path |> System.IO.File.OpenWrite :> System.IO.Stream 
         |> Result<File>.Ok

let close (f : File) =
    f.Close()