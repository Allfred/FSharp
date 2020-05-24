module HelloSquare
open System

type 't btree=
    Node of 't*'t btree *'t btree
   |Nil

type Operation = Add|Sub|Mul|Div
type ExprNode = Op of Operation | Value of int
type ExprTree = ExprNode btree

//вид проще
type Expr =
    Add of Expr * Expr
   |Sub of Expr * Expr
   |Mul of Expr * Expr
   |Div of Expr * Expr
   |Value of int

[<EntryPoint>]
let main argv =
    //Деревья выражений и абстрактные синтактические деревья(AST)
    //1*2+3
    //let ex=Node(Op(Add),Node(Op(Mul),Node(Value(1),Nil,Nil),Node(Value(2),Nil,Nil)),Node(Value(3),Nil,Nil))
    let ex1=Add(Value(3),Mul(Value(1),Value(2)))
    let rec compute = function
        Value(n)->n
       |Add(e1,e2)-> compute e1 + compute e2
       |Sub(e1,e2)-> compute e1 - compute e2
       |Mul(e1,e2)-> compute e1 * compute e2
       |Div(e1,e2)-> compute e1 / compute e2
    
    Console.ReadKey() |> ignore

    0 // Return an integer exit code
    