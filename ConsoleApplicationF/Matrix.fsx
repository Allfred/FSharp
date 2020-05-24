module HelloSquare
open System
open Microsoft.FSharp.Math


[<EntryPoint>]
let main argv =

    //специализированные типы для матриц и векторов
    //Matrix<_> Vector<_> RowVector<_>
    let v =vector [1.;2.;3.;]
    let rv=rowvec [1.;2.;3.]
    let m : Matrix<float> =matrix [[1.;2.;3.];[4.;5.;6.];[7.;8.;9.]]
    let rvv=rv*v
    let vrv=v*rv
    let mv=m*v
    let rvm=rv*m
    //разряженные матрицы
    let sparse =Matrix.initSparse 100 100 [for i in 0..99->(i,i,1.0)]


    Console.ReadKey() |> ignore

    0 // Return an integer exit code
    