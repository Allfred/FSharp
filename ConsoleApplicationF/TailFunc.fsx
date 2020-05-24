module HelloSquare
open System
   
   let rev L=
        let rec rev_tail s= function
            []->s
           |h::t ->rev_tail (h::s) t in rev_tail [] L
   (*
   type 'a queue =' a list
   let tail = List.tail
   let head = List.head
   let rec put x L = L @ [x]
  *)
   type 'a queue1 ='a list * ' a list
   let tail (L,R)= 
        match L with
        [x]->(rev R,[])
       |h::t -> (t,R)
    
   let head (h::_,_)=h

   let put x (L,R)=
        match L with
         []->([x],R)
        |_->(L,x::R)

[<EntryPoint>]
let main argv =
    //хвостовая рекурсия
    let rec len a = function 
        []->a
       |_::t->len (a+1) t

    let rec rev = function
        []->[]
       | h::t-> (rev t)@[h]
     
    let rev L=
        let rec rev_tail s= function
            []->s
           |h::t ->rev_tail (h::s) t in rev_tail [] L
    //let a=rev [1;2;3]
   


  

    Console.ReadKey() |> ignore
    0 // Return an integer exit code
