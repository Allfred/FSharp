module HelloSquare
open System
open System.Collections.Generic

[<EntryPoint>]
let main argv =
    //Set
    let s1 =set [1;2;3;4]
    let s2 =set [2;3;10;23]
    
    s1-s2 //(Set.intersect s1 s2)
    s1+s2 //(Set.union s1 s2)
    let letters (s:string)=
        s.ToCharArray()
        |> Array.fold (fun acc x->  acc+ set[x]) Set.empty 
    
    //Map
    let letters1 (s:string) =
         s.ToCharArray()
        |> Array.fold(fun mp x-> 
                                if Map.containsKey x mp
                                then Map.add x (mp.[x]+1) mp 
                                else Map.add x 1 mp)
                                Map.empty
    //хештаблицы
    let letters2 (s:string) =
        let ht = new HashMultiMap<char,int>(HashIdentity.Structural)
        s.ToCharArray()
        |> Array.iter (fun x->  if ht.ContainsKey x
                                then ht.[x]<- ht.[x]+1   
                                else ht.[x]<-1)
        ht
    //можно юзать .net струуктры словари
    let letters2 (s:string) =
        let ht = new Dictionary<char,int>()
        s.ToCharArray()
        |> Array.iter (fun x->  if ht.ContainsKey x
                                then ht.[x]<- ht.[x]+1   
                                else ht.[x]<-1)
        ht
    Console.ReadKey() |> ignore

    0 // Return an integer exit code
    