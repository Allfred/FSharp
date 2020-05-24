module MatchingQuadr
type SolveResult = 
    None
   |Linear of float
   |Quadratic of float*float
    

let main1 argv =
    let solveD a b c = 
        let D = b*b - 4.*a*c
        if a = 0.0 then 
            if b = 0.0 then None
            else Linear(-c/b)
        else 
            if D < 0. then None 
            else Quadratic((-b + sqrt(D))/ 2.0 * a,(-b - sqrt(D))/ 2.0 * a)
    let result = solveD 1.0 2.0 -3.0 in
    match result with
      None -> printf "Нет решений" 
     |Linear(x) -> printf "Линейное уравнение, корень %f" x
     |Quadratic(x1,x2) -> printf "Квадратное уравнениеб корни %f %f" x1 x2
    let text_result x = match x with
        None -> "Нет решений" 
       |Quadratic(x1,x2) when x1=x2 -> "Линейное уравнение, корень"+x1.ToString()
       |Quadratic(x1,x2) -> "Квадратное уравнениеб корни  "+x1.ToString()+x2.ToString()

    match result with
        None -> printf "Нет решений" 
       |Quadratic(x1,x2) when x1=x2 -> printf "Линейное уравнение, корень %f" x1
       |Quadratic(x1,x2) -> printf "Квадратное уравнениеб корни %f %f" x1 x2
    
    let text_result x = function
        None -> "Нет решений" 
       |Quadratic(x1,x2) when x1=x2 -> "Линейное уравнение, корень"+x1.ToString()
       |Quadratic(x1,x2) -> "Квадратное уравнениеб корни  "+x1.ToString()+x2.ToString()
    
    text_result result
    