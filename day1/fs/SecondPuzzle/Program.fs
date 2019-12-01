open System.IO

let LoadData =
    [for value in File.ReadAllLines "input.txt" -> value |> int]

let rec CalculateFuelForModule input =
    let check x =
        if x <= 0 then 0
        else x + CalculateFuelForModule x
    input/3 - 2 |> check

let CalculateFuelForAllModules input =
    [for inputValue in input -> inputValue |> CalculateFuelForModule]

let ReduceResult input =
    List.sum input

[<EntryPoint>]
let main argv =
    LoadData
        |>CalculateFuelForAllModules
        |>ReduceResult
        |>printf "%i"
    0