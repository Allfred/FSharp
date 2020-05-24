module HelloSquare
open System
open System.IO
open Microsoft.FSharp.Collections
    //изменяемое значение , новый синтаксис
type cell={mutable content :int}
let new_counter n=
    let x={content = n}
    fun()->(x.content<-x.content+1;x.content)
let new_counter1 n=
    let x=ref n in
    fun ()->
        (x:=!x+1;!x)

let rec take n gen=
    if n=0 then []
    else gen()::take(n-1) gen

let new_generator fgen init =
    let x= ref init
    (fun ()-> x:=fgen !x; !x)
      

let new_counter11 n = new_generator (fun x-> x+1) n

[<EntryPoint>]
let main argv =
    
    //замыкание функция филт представляет с собой замыкание
    let divisible n = List.filter (fun x->x%n=0)
    let filt =divisible 3 in [1..100]|>filt
    //динамическое связывание mutable
    let mutable x=4;
    let adder y=x+y;
    adder 1//5
    x<-3
    adder 1//4
    //let a =(new_counter11 3)()
    //Ленивые последовательности
    let fibs = Seq.unfold
                    (fun (u,v)->Some(u,(u+v,u)))
                    (1,1)
    Seq.take 10(Seq.filter (fun x->x%3=0) fibs) |>Seq.toList
    let squares =Seq.initInfinite(fun n-> n*n)
    let squares =Seq.init 10 (fun n-> n*n)
    //let aa=Seq.take 3 squares |> Seq.toList  
    let readLines fn =
        seq { use inp =File.OpenText fn in
                while not(inp.EndOfStream) do 
                yield (inp.ReadLine())
            }
    //let table = readLines "1.txt" |> Seq.map(fun s-> s.Split([|','|]))
    //let sum_age =table |> Seq.fold(fun x l ->x+Int32.Parse(l.[2])) 0
    //let aaa=seq{for i in 1..10 ->(i,i*i)}|> Seq.toList
    seq{for x in fibs do if x%3=0 then yield x} |>Seq.take 10
    
    //частотный словарь
    readLines @"" |>Seq.collect (fun s->s.Split([|',';':';' ';'!';'.';|]))
    let FreqDict S=
        Seq.fold (fun (ht:Map<_,int>) v ->
            if Map.containsKey v ht then Map.add v ((Map.find v ht)+1) ht
            else Map.add v 1 ht)
            (Map.empty) S
    (*
    readLines @"" |>Seq.collect (fun s->s.Split([|',';':';' ';'!';'.';|]))
    |>FreqDict
    |>Map.toList
    |>List.sortWith(fun (k1,v1) (k2,v2)-> -compare v1 v2)
    |>List.filter(fun (k,v)->k.Length>3)
    |>Seq.take 10
    *)
    //вычисление числа пи методом Монте-карло
    let rand max n =
        seq{let r =new System.Random(n)
            while true do yield r.NextDouble()*max
            }
    let MonteCarlo hit R N =
        let hits = (float)(
            Seq.zip (rand R 134) (rand R 313)
            |>Seq.take N 
            |>Seq.filter hit 
            |>Seq.length) 
        hits/(float)N

    let pi = 4.0*MonteCarlo (fun (x,y) -> x*x+y*y<=1.0) 1.0 10000

    Console.ReadKey() |> ignore

    0 // Return an integer exit code
    