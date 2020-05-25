module HelloSquare
open System
open System.IO
type Point = {x:float; y:float}
type Circle = {x:float; y:float; z:float}
[<EntryPoint>]
let main argv =
    //Элементы императивного программирования на f#
    let sum_list l =
        let acc =ref 0
        for x in l do
            acc:=!acc + x
        !acc
    //цикл с предусловием
    let readLines()=
        let a = new ResizeArray<string>()
        let mutable s=" "
        while s<>"." do
                s<-Console.ReadLine()
                a.Add(s)
        List.ofSeq a
    //условный оператор
    let print_sign x =
            if x>0 then printfn "Positive"
            elif x=0 then printfn "Zero"
            else printfn "Negative"
    //Null-значения
    let getenv s =match System.Environment.GetEnvironmentVariable s with
                    null->None
                   | x->Some(x)
    //обработка исключительных ситуаций
    
    //exception CannotReadFile of String
    let ReadFile f =
           try
                use fi =File.OpenText(f)
                fi.ReadToEnd()
                with
                    | :? FileNotFoundException ->eprintf "File not found"; None.ToString()
                    | :? NotSupportedException
                    | :? ArgumentException ->eprintf "Illegal path"; None.ToString()
                    | _->eprintf "Unknow error"; None.ToString()  
           //finally
           //fi.Close()
    //Записи
    
    let p1 ={x=10.0; y=10.0}
    let p2 = {new Point with x=10.0 and y=0.0}
    
    let distance a b =
        let sqr x=x*x
        Math.Sqrt(sqr(a.x-b.x)+sqr(a.y-b.y))
    //сопоставление
    let quadrant p =
        match p with
            {x=0.0; y=0.0} ->0
           |{x=u; y=v} when u>=0.0 && v>=0.0 ->1
           |{x=u; y=v} when u>=0.0 && v<0.0 ->2
           |{x=u; y=v} when u<0.0 && v<0.0 ->3
           |{x=u; y=v} when u<0.0 && v>=0.0 ->4
    
          
        
    Console.ReadKey() |> ignore

    0 // Return an integer exit code
    