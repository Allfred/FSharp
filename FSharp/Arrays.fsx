module HelloSquare
open System

let sum (a : int[])=
     let rec sumrec i s=
         if i < a.Length then sumrec (i+1) (s+a.[i])
         else s
     sumrec 0 0
//изменение элементов массива
let intarray n=
    let a=Array.create n 0
    Array.iteri (fun i _->a.[i]<-(i-1)) a
    a
(intarray 5)
[<EntryPoint>]
let main argv =
    //массивы 
    [|1;2;3;4;5|]
    let a=[|1..5|]
  //можно изымать диапазон значений и такж присванивание
    ([1..4].[2..3])
    a.[2..3]<-[|-1;-3|]
    //ResizeArray для массивов с неизвестной длиной
    //многомерные массивы
    //jagged arrays
    let pascal n =
        let rec pas L n=
            let A::t = L in 
            if n = 0 then L
            else pas (( (1::[for i in 1..(List.length A-1)->A.[i-1]+A.[i]])@[1])::L) (n-1)
        pas [[1;1]] n
    //pascal 3
    
    let fold_cols f i (A: 't[,])=
        let n=Array2D.length2 A
        let res =Array.create n i
        Array2D.iteri (fun i j x-> res.[j]<- f res.[j] x) A
        res
    let my2DArray = array2D [ [ 1; 2]; [3; 4] ]
    fold_cols (fun x y->x+y) 3 my2DArray
    
    Console.ReadKey() |> ignore

    0 // Return an integer exit code
    