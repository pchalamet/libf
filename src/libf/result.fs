module std.result

type Result<'t, 'e> =
    | Ok of 't
    | Err of 'e

let toResult f =
    try
        f() |> Result.Ok
    with
        exn -> exn |> Result.Err

let ok (m : string) (r : Result<'t, 'e>) : 't =
    match r with
    | Result.Ok t -> t
    | Result.Err exn -> raise (System.Exception(m, exn))

let and_then f r =
    match r with
    | Ok t -> (fun () -> f t) |> toResult
    | Err e -> e |> Result.Err

let unwrap_or_else f r =
    match r with
    | Ok t -> f t
    | Err e -> e |> Result.Err

let unwrap_or nt r =
    match r with
    | Ok t -> t
    | _ -> nt
