module std

type Result<'t> =
    | Ok of 't
    | Err of System.Exception
