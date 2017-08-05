module std.io

type File = System.IO.Stream

type Error =
    | NotFound
    | PermissionDenied
    | AlreadyExists 
    | UnexpectedEof

type Result<'t> = std.result.Result<'t, Error>

