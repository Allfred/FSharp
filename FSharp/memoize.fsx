module HelloSquare
open System
open System.IO

type 'a SeqCell=
    Nil
   |Cons of 'a * 'a Stream 
   and 'a Stream = Lazy<'a SeqCell>

[<EntryPoint>]
let main argv =
    //ленивые и энергичные вычисления
    (*
    let Solve =
        let a = lazy(Read "a=")
        let b = lazy(Read "b=")
        let c = lazy(Read "c=")
        let d = lazy(b.Force()*b.Force()-4.*a.Force()*c.Force())
        Print((-b.Force()+sqrt(d.Force()))/2./a.Force(),(-b.Force()-sqrt(d.Force()))/2./a.Force()) 
     *)


    let simple1 = lazy(Cons(1,lazy(Cons(2,lazy(Nil)))))
    let simple2 = lazy(Cons(3,lazy(Cons(4,lazy(Nil)))))
    let rec concat (s: 'a Stream) (t: 'a Stream) =
        match s.Force() with
            Nil->t
          |Cons(x,y)->lazy(Cons(x,(concat y t)))
    
    let lsqr (x:Lazy<int>)=lazy(x.Force()*x.Force())
    //let a=(lsqr(lazy(5)).Force())
    let rec fib n =
        if n<2 then 1 
        else fib (n-1)+fib (n-2)
    let memoize (f:'a->'b)=
        let t=new System.Collections.Generic.Dictionary<'a,'b>()
        fun n->
            if t.ContainsKey(n) then t.[n]
            else let res= f n
                 t.Add(n,res)
                 res
    let rec fibFast = memoize (fun n -> if n < 2 then 1 else fibFast(n-1)+fibFast(n-2))
    Console.ReadKey() |> ignore

    0 // Return an integer exit code
    