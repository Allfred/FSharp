module HelloSquare
open System
open System.IO
open CustomQueue
//расширение функциональности
type System.Int32 with
    member x.isOdd =x%2=1
    member x.isEven =x%2=1


[<EntryPoint>]
let main argv =

    (12).isEven
    let q=CustomQueue.empty
    let q1=CustomQueue.put 5 (CustomQueue.put 10 q)
    CustomQueue.head 

    
    Console.ReadKey() |> ignore

    0 // Return an integer exit code
    