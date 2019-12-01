open System.IO

let LoadData =
    File.ReadAllLines "input.txt"

let GetIntValues input =
    [for inputValue in input -> inputValue |> int]

let CalculateFuel input =
    [for inputValue in input -> inputValue/3 - 2]

let ReduceResult input =
    List.sum input

[<EntryPoint>]
let main argv =
    LoadData
        |>GetIntValues
        |>CalculateFuel
        |>ReduceResult
        |>printf "%i"
    0