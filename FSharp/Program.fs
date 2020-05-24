module HelloSquare
open System
open System.IO

type 'a SeqCell=
    Nil
   |Cons of 'a * 'a Stream 
   and 'a Stream = Lazy<'a SeqCell>

[<EntryPoint>]
let main argv =
    //Продолжения
    let rec rev1 L=
        match L with
            []->[]
           |h::t-> rev1 t @ [h]
    
    let rec rv l f =
        match l with
            []-> f []
           |h::t ->rv t (f>>(fun x ->h::x))
    let rev l = rv l (fun x->x)
    let a=rev [1;2]
    
    let rev2 L=
        let rec rv l f =
            match l with
                []->(f[])
               |h::t ->rv t (f>>(fun x ->h::x))
        rv L (fun x->x)



    Console.ReadKey() |> ignore

    0 // Return an integer exit code
    