module std

type IoResult<'t> =
    | Ok of 't
    | Err of System.Exception

let toResult f =
    try
        f() |> IoResult.Ok
    with
        exn -> exn |> IoResult.Err

let ok (m : string) (r : IoResult<'t>) : 't =
    match r with
    | IoResult.Ok t -> t
    | IoResult.Err exn -> raise (System.Exception(m, exn))

let and_then f r =
    match r with
    | Ok t -> (fun () -> f t) |> toResult
    | Err e -> e |> IoResult.Err

let unwrap_or_else f r =
    match r with
    | Ok t -> f t
    | Err e -> e |> IoResult.Err

let unwrap_or nt r =
    match r with
    | Ok t -> t
    | _ -> nt
