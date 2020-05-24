module HelloSquare
open System

  
[<EntryPoint>]
let main argv =
    //свертка fold
    let sum k L = List.fold (fun s x-> s+x) k L
    sum 1 [1;2]    
    
    let sum =List.fold (+) 0
    let product =List.fold (*) 1


    let minmax L=
        let a0= List.head L in
            List.fold (fun (mi,ma) x->
                ((if mi > x then x else mi),
                (if ma < x then x else ma)))
                (a0,a0) L
    let min L =fst (minmax L)
    let max L =snd (minmax L)
    
    //правая или обратная свертка //порядок обхода всего то
    let minmax L =
        let a0= List.head L in
        List.foldBack(fun x (mi,ma)-> 
            ((if mi > x then x else mi),
            (if ma < x then x else ma)))
            L (a0,a0)
    //set a min with reduce
    let min : int list -> int =List.reduce (fun a b ->Math.Min(a,b))
    
    let minimum a b = if a>b then b else a
    let min L = List.reduce minimum L 
    
    //function Iter
    Console.ReadKey() |> ignore
    0 // Return an integer exit code
