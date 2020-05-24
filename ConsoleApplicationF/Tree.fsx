module HelloSquare
open System
open System.IO

type 'T tree =
    Leaf of 'T
   | Node of 'T*('T tree list)

[<EntryPoint>]
let main argv =

    //деревья
    let tr =Node(1,[Node(2,[Leaf(5)]);Node(3,[Leaf(6);Leaf(7)]);Leaf(4)])
    
    let rec itr1 f = function 
             Leaf(T) -> f  T
            |Node(T,L) -> (f T; for t in L do itr1 f t done)
    let print_tree1 T = itr1 (fun x->printf "%A" x) T
    //print_tree1 tr

    let iterh f =
        let rec itr n = function 
            Leaf(T) -> f n T
           |Node(T,L) -> (f n T; for t in L do itr (n+1) t done)
        itr 0

    let spaces n =List.fold (fun s _ -> s+" ") ""[0..n]
    let print_tree T= iterh (fun h x ->printf "%s%A\n" (spaces(h*3)) x) T
    //print_tree tr

    let rec map f = function
        Leaf(T) ->Leaf(f T)
       |Node(T,L)->Node(f T,List.map(fun t->map f t)L)

    //let aaa= map (fun x->x*10) tr
    //структура папок
    let dir_tree path =
        let rec tree path ind =
            Directory.GetDirectories path |>
            Array.iter(fun dir ->printfn "%s%s" (spaces(ind*3)) dir; tree dir (ind+1))
        tree path 0
    
    let dir_tree path =
        let rec tree path ind =
            seq {
                    for dir in Directory.GetDirectories path do
                        yield  (dir,ind)
                        yield! (tree dir (ind+1))
                }
        tree path 0
    dir_tree @"D:\работа\temp"
        |>Seq.iter (fun (s,h)->printf "%s%s\n" (spaces(h*3) )s)
    
    let rec  du path =
        Directory.GetDirectories path |>  
        Array.iter(fun dir ->
            let sz= Directory.GetFiles dir |>
                Array.sumBy (fun f->(new FileInfo(f)).Length)
            printfn "%10d %s" sz dir;
            du dir)

    Console.ReadKey() |> ignore

    0 // Return an integer exit code
    