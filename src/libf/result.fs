module std.result

type Result<'t, 'e> =
    | Ok of 't
    | Err of 'e


let is_ok = function
            | Result.Ok _ -> true
            | Result.Err _ -> false
    
let is_err (r : Result<'t, 'e>)  = r |> is_ok |> not

let ok = function
         | Result.Ok x -> x |> Some
         | _ -> None

let err = function
          | Err x -> x |> Some
          | _ -> None

let map f = function
            | Ok x -> x |> f |> Ok
            | Err x -> x |> Err

let map_err o = function
                | Err x -> x |> o |> Err
                | Ok x -> x |> Ok

let ``and`` (res : Result<'t2, 'e>) = function
                                      | Ok _ -> res
                                      | Err x -> x |> Err 

let and_then f = function
                 | Ok x -> x |> f
                 | Err x -> x |> Err

let ``or`` (res : Result<'t, 'e2>) = function
                                     | Err _ -> res
                                     | Ok x -> x |> Ok

let or_else o = function
                | Err x -> x |> o
                | Ok x -> x |> Ok

let unwrap_or optb = function
                     | Ok r -> r
                     | _ -> optb

let unwrap_or_else f = function
                       | Ok x -> x
                       | Err x -> x |> f

let unwrap = function
             | Ok x -> x
             | Err x -> x |> failwithf "%A"

let expect msg = function
                 | Ok x -> x
                 | Err _ -> msg |> failwith

let unwrap_err = function
                 | Err x -> x
                 | Ok x -> x |> failwithf "%A"

let expect_err msg = function
                     | Err x -> x
                     | Ok _ -> msg |> failwith

let unwrap_or_default = function
                        | Ok x -> x
                        | _ -> Unchecked.defaultof<'t>
