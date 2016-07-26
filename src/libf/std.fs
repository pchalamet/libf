module std

type Result<'t> =
    | Ok of 't
    | Err of System.Exception

let toResult f =
    try
        Result.Ok (f())
    with exn -> Result.Err exn

let ok (m : string) (r : Result<'t>) : 't =
    match r with
    | Result.Ok t -> t
    | Result.Err exn -> raise (System.Exception(m, exn))

let and_then f r =
    match r with
    | Ok t -> try
                Result.Ok (f t)
              with exn -> Result.Err exn
    | x -> x


let unwrap_or_else f r =
    match r with
    | Ok t -> f t
    | x -> x

let unwrap_or nt r =
    match r with
    | Ok t -> t
    | _ -> nt

