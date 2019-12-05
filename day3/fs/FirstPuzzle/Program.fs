open System.IO
open System.Collections.Generic
let LoadData =
  File.ReadAllLines "input.txt"
  |> Array.map (fun l -> l.Split ',' |> Array.map (fun i -> (i.[0], (i.[1..] |> int))))


let MakePoint previous command : int * int =
  match command with
  | 'U' | 'u' -> (fst previous, snd previous + 1)
  | 'R' | 'r' -> (fst previous + 1, snd previous)
  | 'D' | 'd' -> (fst previous, snd previous - 1)
  | 'L' | 'l' -> (fst previous - 1, snd previous)
  | _ -> failwith "wrong argument"

let TransformPoints (command: char, times: int) (previous : List<int*int>)=
  for _ in 1..times do
    previous.Add (MakePoint (previous.Item (previous.Count - 1)) command)

let FoldHelper (acc: List<int*int>) (elem : char * int)=
  TransformPoints elem acc
  acc

let GetPoints arr=
  let res = new List<int*int>()
  res.Add (0, 0)
  arr
    |> Array.fold FoldHelper res
    |> Set.ofSeq

[<EntryPoint>]
let main argv =
  let data = LoadData
  Set.intersect (GetPoints data.[0]) (GetPoints data.[1])
    |> Set.filter (fun (x,y) -> x <> 0 || y <> 0  )
    |> Set.map (fun (x, y) -> (abs x) + (abs y)) 
    |> Set.minElement
    |> printfn "%i"
    
  0 // return an integer exit code
