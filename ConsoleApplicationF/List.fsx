module HelloSquare
open System
open System.Numerics

  
[<EntryPoint>]
let main argv =
    let rec len l = 
        match l with
            []-> 0
           |h::t ->1+len t
    
    let rec len1 =function
            []-> 0
           |_::t ->1+len t
    len1 [1;2;3] 

    //Map
    let rec map f = function
        []->[]
       |h::t->(f h)::(map f t)
    map (fun x->x*2) [1;2;3]
    let a= [1;2;3]|>List.mapi (fun i x->(i+1).ToString()+". "+ x.ToString())
    //функция перевода 10 систему счиления
    let conv_to_dec b l =
        List.rev l |>
        List.mapi (fun i x -> x*int(float(b)**float(i))) |>
        List.sum
    conv_to_dec 2 [1;0;0;0]

    List.map2 (fun u v -> u + v) [1;2;3] [-1;-2;-3]
    List.map2 (+) [1;2;3] [-1;-2;-3]

    let conv_to_dec1 b l=
        [for i =(List.length l)-1 downto 0 do yield int(float(b)**float(i))]|>
        List.map2 (*) l|>
        List.sum
    conv_to_dec 2 [1;0;0;0]

    ["https://yandex.ru/";"https://yandex2.ru/";"https://yandex3.ru/"]|>
    List.map (fun url-> ["https "+(url+"/about.html");"https "+(url+"/contact.html")])|>
    List.concat

    ["https://yandex.ru/";"https://yandex2.ru/";"https://yandex3.ru/"]|>
    List.collect (fun url-> ["https "+(url+"/about.html");"https "+(url+"/contact.html")])
    
    //FILTER
    [1..10]|> List.filter (fun x-> x%2=0)
    //реализация филтер
    let rec filter f= function
        []->[]
       |h::t when (f h)->h::(filter f t)
       | _::t ->filter f t
    ["https://yandex.ru/";"https://bing.ru/"]|>
    List.filter (fun s->s.IndexOf("bing")>0)

    let rec primes =function
        []->[]
       |h::tan-> h::primes(filter (fun x-> x%h > 0) tan)

    //быстрая сортировка
    let rec qsort = function
        []->[]
       |h::t->
       qsort(List.filter ((>)h) t) @ h @
       qsort(List.filter ((<=)h) t)
    
    let rec qsort1 = function
        []->[]
       |h::t -> 
       qsort1([for x in t do if x < h then yield x]) @ h @
       qsort1([for x in t do if x >= h then yield x])
    //with partition
    let rec qsort2 = function
        []->[]
       |h::t ->
            let (a,b)=List.partition((>)h) t
            qsort2(a) @[h]@ qsort2(b)
    
    //Choose
    let choose1 f = List.choose(fun x->Some(f x))
    choose1 (fun x->x*2) [1;2]

    Console.ReadKey() |> ignore
    0 
