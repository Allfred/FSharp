module HelloSquare

open System
open System.Numerics
  
[<EntryPoint>]
let main argv =
    
    let mandelf (c:Complex) (z:Complex) = z*z + c
    let rec rpt n f x = 
        if n = 0 then x
        else f(rpt (n-1) f x)
    let isMandel c =Complex.Abs(rpt 20 (mandelf c) (Complex.Zero)) < 1.0
    
    let scale (x:float,y:float) (u,v) n= float(n-u)/float(v-u)*(y-x)+x

    for i=1 to 60 do
        for j=1 to 60 do
            let lscale = scale (-1.2, 1.2) (1,60) in
            let t = Complex((lscale j), (lscale i)) in
            Console.Write(if isMandel t then "*" else " ")
        Console.WriteLine("")

    
    
    Console.ReadKey() |> ignore
    0 // Return an integer exit code
