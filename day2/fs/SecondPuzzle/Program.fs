open System.IO

let LoadData = File.ReadAllText "input.txt" |> fun i -> i.Split ',' |> Array.map int

let SafeReplaceAt state index value=
  state |> Array.indexed |> Array.map (fun (x,y) -> if x = index then value else y)

let rec StateMachine pc (state: int[])  =
  let opCode = state.[pc]
  let input = fun (s: int[])-> (s.[s.[pc+1]], s.[s.[pc+2]])
  let output = fun (s: int[]) -> s.[pc+3]
  let newPc = (pc + 4)
  match opCode with
  | 1 -> input state |> fun (x, y) -> x + y |> SafeReplaceAt state (output state)|> StateMachine newPc
  | 2 -> input state |> fun (x,y) -> x * y |> SafeReplaceAt state (output state)|> StateMachine newPc
  | 99 -> state
  | _ -> failwith "Value out of range"

[<EntryPoint>]
let main argv =
  LoadData |> fun state ->
    for i in 0..100 do
      for j in 0..100 do
        SafeReplaceAt state 1 i
        |> fun s -> SafeReplaceAt s 2 j
        |> StateMachine 0
        |> fun a -> if a.[0] = 19690720 then printfn "%i" (100 * i + j)
  0 // return an integer exit code
