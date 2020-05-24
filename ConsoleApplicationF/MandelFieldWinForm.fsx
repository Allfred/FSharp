module HelloSquare
open System
open System.Numerics
open System.Drawing
open System.Windows.Forms

  
[<EntryPoint>]
let main argv =
    
    let mandelf (c:Complex) (z:Complex) = z*z + c
    let rec rpt n f x = 
        if n = 0 then x
        else f(rpt (n-1) f x)
    let isMandel c =Complex.Abs(rpt 20 (mandelf c) (Complex.Zero)) < 1.0
    
    let scale (x:float,y:float) (u,v) n= float(n-u)/float(v-u)*(y-x)+x
    (*
    for i=1 to 60 do
        for j=1 to 60 do
            let lscale = scale (-1.2, 1.2) (1,60) in
            let t = Complex((lscale j), (lscale i)) in
            Console.Write(if isMandel t then "*" else " ")
        Console.WriteLine("")
     *)

    let form =
        let image= new Bitmap(400,400)
        let lscale =scale (-1.2,1.2) (0, image.Height-1)
        for i=0 to (image.Height-1) do
            for j=0 to (image.Width-1) do
                let t = Complex(lscale i,lscale j)
                image.SetPixel(i,j,if isMandel t then Color.Black else Color.White)
        
        let temp =new Form()
        temp.Paint.Add(fun e->e.Graphics.DrawImage(image,0,0))
        temp.Show()
        System.Windows.Forms.Application.Run(temp)
    0 // Return an integer exit code
