module std.result

type Result<'t, 'e> =
    | Ok of 't
    | Err of 'e


let is_ok (r : Result<'t, 'e>) =
    match r with
    | Result.Ok _ -> true
    | Result.Err _ -> false
    
let is_err (r : Result<'t, 'e>)  = r |> is_ok |> not

let ok (r : Result<'t, 'e>) =
    match r with
    | Result.Ok x -> x |> Some
    | _ -> None

let err (r : Result<'t, 'e>) =
    match r with
    | Err x -> x |> Some
    | _ -> None

let map f (r : Result<'t, 'e>) =
    match r with
    | Ok x -> x |> f |> Ok
    | Err x -> x |> Err

let map_err o (r : Result<'t, 'e>) =
    match r with
    | Err x -> x |> o |> Err
    | Ok x -> x |> Ok

let ``and`` (res : Result<'t2, 'e>) (s : Result<'t1, 'e>) =
    match s with
    | Ok _ -> res
    | Err x -> x |> Err 

let and_then f (r : Result<'t, 'e>) =
    match r with
    | Ok x -> x |> f
    | Err x -> x |> Err

let ``or`` (res : Result<'t, 'e2>) (s : Result<'t, 'e1>) =
    match s with
    | Err _ -> res
    | Ok x -> x |> Ok

let or_else o (r : Result<'t, 'e>) =
    match r with
    | Err x -> x |> o
    | Ok x -> x |> Ok

let unwrap_or optb (r : Result<'t, 'e>) =
    match r with
    | Ok r -> r
    | _ -> optb

let unwrap_or_else f (r : Result<'t, 'e>) =
    match r with
    | Ok x -> x
    | Err x -> x |> f

let unwrap (r : Result<'t, 'e>) =
    match r with
    | Ok x -> x
    | Err x -> x |> failwithf "%A"

let expect msg (r : Result<'t, 'e>) =
    match r with
    | Ok x -> x
    | Err _ -> msg |> failwith

let unwrap_err (r : Result<'t, 'e>) =
    match r with
    | Err x -> x
    | Ok x -> x |> failwithf "%A"

let expect_err msg (r : Result<'t, 'e>) =
    match r with
    | Err x -> x
    | Ok _ -> msg |> failwith

let unwrap_or_default (r : Result<'t, 'e>) =
    match r with
    | Ok x -> x
    | _ -> Unchecked.defaultof<'t>
