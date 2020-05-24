module HelloSquare

open System
open Microsoft.FSharp.Core

let main argv =
    let rec for_loop f a b=
        if a >= b then f  a
        else
            f  a
            for_loop f (a+1) b
    
    for_loop (fun x -> printf "%d" x) 1 10
    
    for x = 1 to 10 do printf "%d" x
    for x in 1..10 do printf "%d" x

    let rec rpt n f x = 
        if n = 0 then x
        else f(rpt (n-1) f x)
            



    Console.ReadKey() |> ignore
    0 // Return an integer exit code
