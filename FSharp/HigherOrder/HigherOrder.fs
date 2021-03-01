open System

// A "higher order function" is one that uses another function as one of its parameters.
// What's the use? Like all functions, it's about abstracting patterns to make code more robust and reusable.

// Find the first even integer in a list.
let rec findFirstEven coll =
    match coll with 
    | []                    -> failwith "can't find an integer from an empty list"
    | h :: _ when h % 2 = 0 -> h
    | _ :: t                -> findFirstEven t


[1; 3; 5; 6; 7; 8]
|> findFirstEven
|> printfn "first even: %d"


// How about... findFirstOdd?
let rec findFirstOdd coll =
    match coll with 
    | []                    -> failwith "can't find an integer from an empty list"
    | h :: _ when h % 2 = 1 -> h
    | _ :: t                -> findFirstOdd t


// How about... findFirstVowel?
let rec findFirstVowel coll =
    match coll with 
    | []                    -> failwith "can't find a character from an empty list"
    | h :: _ when h = 'a' || h = 'e' || h = 'i' || h = 'o' || h = 'u' -> h
    | _ :: t                -> findFirstVowel t


// What can we abstract about these functions?
// They each iterate through a list of SOME TYPE; test the values of that type under a CONDITION; 
// and return a value of that type.
// A CONDITION is really just a FUNCTION that returns boolean (a "predicate").
let rec findFirst pred coll =
    match coll with
    | []                 -> failwith "can't find the first in an empty list"
    | h :: _ when pred h -> h
    | _ :: t             -> findFirst pred t

// What is the type of findFirst?
// Your first higher-order function!


["Neal"; "Anthony"; "Mehrdad"; "Claus"; "Jaclyn"]
|> findFirst (fun s -> String.length s > 5)
|> printfn "First long name: %s"

// Now, ANY time we have a list of values and want to know the first value that satisfies some condition...
// we can use findFirst!
// (Really we would use List.find, which is this function built into F#)
[("Victor", 3.3); ("Ada", 3.8); ("Barry", 2.9)]
|> List.find (fun (n, gpa) -> gpa >= 3.5) // (n, gpa) means the param is a tuple with 2 values
|> printfn "First dean's list student: %O"



// Now we study 3 very important and famous higher-order functions; the foundation of functional programming.

// 1. Filter: given a predicate and a list of values, return a new list of only those values 
// that pass the predicate.
["Neal"; "Anthony"; "Mehrdad"; "Claus"; "Jaclyn"]
|> List.filter (fun s -> String.length s > 5)
|> printfn "All long names: %O"

// What type is List.filter?

// Can we write it?
let rec filter pred coll =
    match coll with 
    | []                 -> []
    | h :: t when pred h -> h :: filter pred t
    | _ :: t             -> filter pred t

["Neal"; "Anthony"; "Mehrdad"; "Claus"; "Jaclyn"]
|> filter (fun s -> String.length s > 5)
|> printfn "My long names: %O"

// Can we write it with TAIL recursion? 
let filterTail pred coll =
    let rec filterTailImpl pred coll acc = // acc = the result of filtering the items before this point.
        match coll with
        | []                 -> acc
        // problem: how to combine h with acc?
        | h :: t when pred h -> filterTailImpl pred t (h :: acc) // uh oh... look at the result of this...
        | _ :: t             -> filterTailImpl pred t acc

    filterTailImpl pred coll []

["Neal"; "Anthony"; "Mehrdad"; "Claus"; "Jaclyn"]
|> filterTail (fun s -> String.length s > 5)
|> printfn "All long names???: %O"