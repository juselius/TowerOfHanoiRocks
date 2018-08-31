module FsHanoi.Hanoi

open System

type TowerOfHanoi = {
    numDisks : int
    }

let rec moveTowerUnsafe n from ``to`` other =
    if n.numDisks > 0 then
        let n' = { n with numDisks = n.numDisks - 1 }
        moveTowerUnsafe n' from other ``to``
        printfn "Move disk %d from %d -> %d" n.numDisks from ``to`` 
        moveTowerUnsafe n'  other from ``to``
    else
        ()

let rec moveTower' n f t o r =
    if n > 0 then
        let n' = n - 1
        let x = moveTower' n' f o t r 
        let r' = (n, f, t) :: x
        moveTower' n' o f t r'
    else
        r

let moveTower n =
    moveTower' n 1 2 3 [] |> List.rev 

let fizzbuzz n =
    [1..n] |> List.map (
        function
        | n when n % 15 = 0 -> "Fizzbuzz(" + string n + ")"
        | n when n % 5 = 0 -> "buzz(" + string n + ")"
        | n when n % 3 = 0 -> "fizz(" + string n + ")"
        | n -> string n
    )

module Program =
    let main () =
        let th = { numDisks = 3 }
        printfn "%A" <| moveTowerUnsafe th 1 2 3
        moveTower 3 |> List.iter (fun (n, f, t) -> 
            printfn "Move disk %d from %d -> %d" n f t)
        fizzbuzz 30 |> List.iter (printfn "%s")

