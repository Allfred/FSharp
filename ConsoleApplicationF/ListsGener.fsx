module HelloSquare
open System

  
[<EntryPoint>]
let main argv =
    //генераторы списков
    [1;2;3]
    [1..10]
    
    [1.0..0.1..2.]//with step 0.1
    [10..-1..1]//with step -1
    [for x in 0..8 -> float(x)**2.0]//только в явном виде можно записывать
    List.init 9 (fun x->2.0**float(x))
    [1..9]|> List.map (fun x->2.0*float(x))

    Console.ReadKey() |> ignore
    0 // Return an integer exit code
