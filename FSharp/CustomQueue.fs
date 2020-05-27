module CustomQueue
    type 'a queue='a list *'a list
    let empty=[],[]
    let tail (L,R)=
        match L with
            [x]->(List.rev R,[])
            |h::t->(t,R)
    let head (h::_,_)=h
    let put x (L,R) =
        match L with
        [x]->([x],R)
        |_->(L,x::R)
