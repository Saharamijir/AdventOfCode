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
  LoadData |> StateMachine 0 |> fun a -> printfn"%A" a.[0]
  0 // return an integer exit code
