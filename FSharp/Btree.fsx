module HelloSquare
open System

type 't btree=
    Node of 't*'t btree *'t btree
   |Nil
[<EntryPoint>]
let main argv =
    let spaces n =List.fold (fun s _ -> s+" ") ""[0..n]
    let btr=Node(1,Node(2,Nil,Nil),Node(2,Nil,Nil))
    //двоичные деревья
    //обход двочного дерева
    let prefix root left right=(root();left();right())
    let infix root left right=(left();root();right())
    let postfix root left right=(left();right();root())

    let iterh trav f t =
        let rec tr t h =
            match t with
             Node (x,L,R) -> trav
                                (fun x->(f x h))//обход корня
                                (fun ()-> tr L (h+1))//обход левого поддерева
                                (fun ()-> tr R (h+1));//обход правого поддерева
             |Nil _->()
        tr t 0
    //let print_tree T=iterh infix (fun x h ->printf "%s%A\n" (spaces h)x) T
    //print_tree btr
    //fold
    let fold_infix f init t =
        let rec tr t x =
            match t with
                Node (z,L,R) ->tr L (f z (tr R x))
               |Nil -> x
        tr t init
    let tree_to_list T = fold_infix(fun x t -> x::t) [] T 
    let b=tree_to_list btr
    Console.ReadKey() |> ignore

    0 // Return an integer exit code
    