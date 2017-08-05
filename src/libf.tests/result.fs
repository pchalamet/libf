module std.result.tests

open FsUnit
open NUnit.Framework
open std.result

[<Test>]
let is_ok () =
    42 |> Result<int, string>.Ok |> is_ok |> should equal true
    "toto" |> Result<int, string>.Err |> is_ok |> should equal false

[<Test>]
let is_err () =
    42 |> Result<int, string>.Ok |> is_err |> should equal false
    "toto" |> Result<int, string>.Err |> is_err |> should equal true

[<Test>]
let ok () =
    42 |> Result<int, string>.Ok |> ok |> should equal (Some 42)
    "toto" |> Result<int, string>.Err |> ok |> should equal None

[<Test>]
let err () =
    42 |> Result<int, string>.Ok |> err |> should equal None
    "toto" |> Result<int, string>.Err |> err |> should equal (Some "toto")

[<Test>]
let map () =
    let multBy y x = x * y
    42 |> Result<int, string>.Ok |> map (multBy 10) |> should equal (420 |> Result<int, string>.Ok)
    "toto" |> Result<int, string>.Err |> map (multBy 10) |> should equal ("toto" |> Result<int, string>.Err)

[<Test>]
let map_err () =
    let append y x = x + y
    42 |> Result<int, string>.Ok |> map_err (append "++") |> should equal (42 |> Result<int, string>.Ok)
    "toto" |> Result<int, string>.Err |> map_err (append "++") |> should equal ("toto++" |> Result<int, string>.Err)

[<Test>]
let ``and`` () = 
    let o1 = 42 |> Result<int, string>.Ok
    let o2 = 666 |> Result<int, string>.Ok
    let e = "toto" |> Result<int, string>.Err
    o1 |> ``and`` o2 |> should equal o2
    e |> ``and`` o2 |> should equal e

[<Test>]
let and_then () =
    let multBy y x = x * y |> Result<int, string>.Ok
    let o1 = 42 |> Result<int, string>.Ok
    let o2 = 420 |> Result<int, string>.Ok
    let e = "toto" |> Result<int, string>.Err
    o1 |> and_then (multBy 10) |> should equal o2
    e |> and_then (multBy 10) |> should equal e

[<Test>]
let ``or`` () = 
    let o1 = 42 |> Result<int, string>.Ok
    let o2 = 666 |> Result<int, string>.Ok
    let e = "toto" |> Result<int, string>.Err
    o1 |> ``or`` o2 |> should equal o1
    e |> ``or`` o2 |> should equal o2

[<Test>]
let or_else () =
    let append y x = x + y |> Result<int, string>.Err
    let o = 42 |> Result<int, string>.Ok
    let e1 = "toto" |> Result<int, string>.Err
    let e2 = "toto++" |> Result<int, string>.Err
    o |> or_else (append "++") |> should equal o
    e1 |> or_else (append "++") |> should equal e2

[<Test>]
let unwrap_or () = 
    let o = 42 |> Result<int, string>.Ok
    let e = "toto" |> Result<int, string>.Err
    o |> unwrap_or 666 |> should equal 42
    e |> unwrap_or 666 |> should equal 666

[<Test>]
let unwrap_or_else () =
    let convert e = 666 
    let o = 42 |> Result<int, string>.Ok
    let e = "toto" |> Result<int, string>.Err
    o |> unwrap_or_else convert |> should equal 42
    e |> unwrap_or_else convert |> should equal 666

[<Test>]
let unwrap () =
    let o = 42 |> Result<int, string>.Ok
    let e = "toto" |> Result<int, string>.Err
    o |> unwrap |> should equal 42
    (fun () -> e |> unwrap |> ignore) |> should (throwWithMessage "\"toto\"") typeof<System.Exception>

[<Test>]
let expect () =
    let o = 42 |> Result<int, string>.Ok
    let e = "toto" |> Result<int, string>.Err
    o |> expect "titi" |> should equal 42
    (fun () -> e |> expect "titi" |> ignore) |> should (throwWithMessage "titi") typeof<System.Exception>

[<Test>]
let unwrap_err () =
    let o = 42 |> Result<int, string>.Ok
    let e = "toto" |> Result<int, string>.Err
    (fun () -> o |> unwrap_err |> ignore) |> should (throwWithMessage "42") typeof<System.Exception>
    e |> unwrap_err |> should equal "toto"

[<Test>]
let expect_err () =
    let o = 42 |> Result<int, string>.Ok
    let e = "toto" |> Result<int, string>.Err
    (fun () -> o |> expect_err "titi" |> ignore) |> should (throwWithMessage "titi") typeof<System.Exception>
    e |> expect_err "titi" |> should equal "toto"

[<Test>]
let unwrap_or_default () =
    let o = 42 |> Result<int, string>.Ok
    let e = "toto" |> Result<int, string>.Err
    o |> unwrap_or_default |> should equal 42
    e |> unwrap_or_default |> should equal 0
       