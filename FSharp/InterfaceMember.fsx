module HelloSquare
open System
open System.IO
type Shape ={Draw: unit -> unit; Area: unit ->float}
//методы
type Point = {x:float; y:float}
    with 
        member P.Draw = printfn "Point @(%f,%f)" P.x P.y
        static member Zero = {x=0.0;y=0.0}
        static member Distance (P1,P2)=
            let sqr x= x*x
            Math.Sqrt(sqr(P1.x-P2.x)+sqr(P1.y-P2.y))
        member P1.Distance(P2) =Point.Distance(P1,P2)
        static member (+) (P1: Point,P2: Point)=
            {x=P1.x+P2.x; y=P1.y+P2.y}
        override P.ToString()=sprintf "Point @(%f,%f)" P.x P.y
//интерфейсы можно без слова interface и убрать end
type Shape1= interface
    abstract Draw:unit->unit
    abstract Area:float
    end
let circle1 c r =
       {new Shape1 with
                member this.Area: float = Math.PI*r*r/2.0
                member this.Draw(): unit =printf "Circle @(%f,%f), r=%f" c.x c.y r 
       }
let squaer1 c x=
    {
    new Shape1 with
         member this.Area: float = 
             x*x
         member this.Draw(): unit = 
             printf "Square @(%f,%f), r=%f" c.x c.y x
    }
[<EntryPoint>]
let main argv =
    //Моделирование объектной  ориентированности через записи и замыкания    
    let circle c r =
            let cent,rad= c,r
            { Draw=fun()->printf "Circle @(%f,%f), r=%f" cent.x cent.y rad
              Area = fun()->Math.PI*rad*rad/2.0 }
            
    let square c x =
            let cent,len= c,x
            { Draw=fun()->printf "Square @(%f,%f), r=%f" cent.x cent.y len
              Area = fun()->len*len }
    let shapes = [circle { x=1.0; y=2.0} 10.0; square { x=10.0; y=5.0} 3.0]
    shapes|>List.iter (fun shape->shape.Draw())
    let a=shapes|>List.map (fun shape->shape.Area())
    //методы
    
    
    Console.ReadKey() |> ignore

    0 // Return an integer exit code
    