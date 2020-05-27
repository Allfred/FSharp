module HelloSquare
open System
open System.IO
type Drawer = float*float ->unit
type Point = {x:float; y:float}
type Shape= interface
    abstract Draw:unit->unit
    abstract Area:float
    end
//создание классов с помощью делегирования
let circle draw c r =
       {new Shape with
                member this.Area: float = Math.PI*r*r/2.0
                member this.Draw(): unit = for phi in 0.0..0.1..(2.0*Math.PI) do
                                           draw (c.x+r*Math.Cos(phi),c.y+r*Math.Sin(phi)) 
       }
(*let ConsoleCircle cent rad =
    circle(fun x y->Console.Write("*")) cent rad*)



//создание иерархии классов
type Point1 (cx,cy)=
    let mutable x=cx;
    let mutable y=cy;
    new() = new Point1(0.0,0.0)
    abstract MoveTo :Point1->unit
    default p.MoveTo(dest)=p.Coords<-dest.Coords
    member p.Coords
        with get()=(x,y) and set(v) =let (x1,y1)= v in x<-x1;y<-y1
    interface Shape with 
        override this.Draw()= printf "Point %A" this.Coords
        override this.Area =0.0
    static member Zero=new Point1()
type Circle1 (cx,cy,cr)=
    class
        inherit Point1(cx,cy)
        let mutable r=cr
        new ()=new Circle1(0.0,0.0,0.0)
        member this.Radius with get()=r and set(v)=r<-v
        interface Shape with 
            override this.Draw()= printf "Circle %A r=%f" this.Coords r
            override this.Area =Math.PI*r*r/2.0
    end
let plist =[new Point1();new Circle1():>Point1;new Circle1(1.0,2.0,3.0):>Point1;]

[<EntryPoint>]
let main argv =


    plist|>List.iter(fun p ->(p:>Shape).Draw())
    plist|>List.iter(fun p ->p.MoveTo(Point1.Zero))
    plist|>List.map(fun x ->(x.Coords,(x:>Shape).Area))
    //:> upcasting :?>downcasting
    let area (p:Object)=
        match p with
        | :? Shape as s ->s.Area
        | _ -> failwith "Not a shape"

    let area (p:Object)=
        if(p:? Shape) then (p:?>Shape).Area
        else failwith "Not a shape"

    Console.ReadKey() |> ignore

    0 // Return an integer exit code
    