open System.IO

let LoadData =
    File.ReadAllLines "input.txt" |> Array.map int

let rec CalculateFuelForModule input =
    let check x =
        if x <= 0 then 0
        else x + CalculateFuelForModule x
    input/3 - 2 |> check

let CalculateFuelForAllModules input =
    input |> Array.map CalculateFuelForModule

let ReduceResult input =
    Array.sum input

[<EntryPoint>]
let main argv =
    LoadData
        |>CalculateFuelForAllModules
        |>ReduceResult
        |>printf "%i"
    0