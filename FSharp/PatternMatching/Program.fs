// Another syntax for writing functions using "pattern matching"

let equalsOne x =
    if x = 1 then
        true
    else 
        false

10 |> equalsOne |> printfn "%O" // prints false
// This syntax is unwieldy. When we have a pattern of "if this thing matches this pattern, then do this",
// we can use a special syntax.

let equalsTwo x =
    match x with
    | 2 -> true
    | _ -> false // _ means "match anything"

2 |> equalsTwo |> printfn "%O" // prints true


// Works with strings too
let getPrice food =
    match food with
    | "banana" -> 0.79
    | "watermelon" -> 3.49
    | "tofu" -> 1.09
    | _ -> nan



// We can do lots of complicated functions using pattern matching instead of nested if-elifs.
let rec factorial n = 
    match n with
    | 0 -> 1
    | x -> x  * factorial (n - 1)

let rec fibonacci n =
    match n with 
    | 0 -> 0
    | 1 -> 1
    | x -> fibonacci (n - 1) + fibonacci (n - 2)


// We can also match on lists
let isEmpty coll =
    match coll with
    | [] -> true
    | _  -> false

[1; 2; 3] |> isEmpty |> printfn "%O" // prints false

let rec last coll =
    match coll with
    | [x] -> x
    | h :: t -> last t

[1; 2; 3] |> last |> printfn "%d" // prints 3


let rec skip n coll =
    match n with
    | 0 -> coll
    | _ -> skip (n - 1) (List.tail coll)

[1; 2; 3; 4] |> skip 2 |> printfn "%A" // CURRYING: prints [3; 4]



// If a function's final parameter is what is matched, we can eliminate some syntax with "function"
let getPrice2 = function
    | "banana" -> 0.79
    | "watermelon" -> 3.49
    | "tofu" -> 1.09
    | _ -> nan

// This shortcut syntax actually compiles to this:
let rec getPrice3 =
    (fun x ->
        match x with 
        | "banana" -> 0.79
        | "watermelon" -> 3.49
        | "tofu" -> 1.09
        | _ -> nan)

// Demonstrate that all three work:
"watermelon" |> getPrice |> printfn "%f"
"watermelon" |> getPrice2 |> printfn "%f"
"watermelon" |> getPrice3 |> printfn "%f"