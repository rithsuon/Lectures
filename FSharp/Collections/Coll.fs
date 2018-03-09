// A sequence is an immutable, iterable collection of values with no concern for how the values
// are represented in the sequence. 

// There are many helpers to define sequences. The simplest is the seq keyword.

let mySeq = seq {yield 1; yield 2; yield 3}

// This sequence contains 3 values, and can be iterated over using a for loop.
let printSequence (s : int seq) =
    for i in s do
        printfn "%d" i
// Fun fact: the type annotation isn't necessary...

printSequence mySeq

// A shortcut lets us define sequences over ranges.
let longSeq = seq {1 .. 1000}
printSequence longSeq

// A sequence is not a real collection type. It cannot be added to or removed from. 
// The shortcuts we've seen involve some hacks at implementation time.
// The real purpose of seq is as a base type for other collections, including arrays
// and linked lists.



// A list is an immutable collection of homogenous data stored as a persistent linked list.
let list1 = [1; 2; 3] // square brackets and semicolons
let list2 = 4 :: list1 // :: is "cons" ; create a new list by placing a new 
                         // head on an existing list

let list3 = list1 @ list2 // @ is "concat": concatenate/append two lists

// Lists are sequences, so we can pass them to a function taking a seq.
printSequence list1

// Lists have "properties" accessed with "." syntax, like in Java/C#. 

printfn "list1.Head: %d\n" list1.Head // Head is "first"
printfn "list1.Tail:" 
printSequence list1.Tail


// Jump over to "Generics.fs" first


// Lists are a "generic type", in that many operations on lists are agnostic regarding
// the type of data contained in the list. We can write methods that operate on lists of any 
// type using generics.
let second (coll : 'a list) =
    coll.Tail.Head

// second is of type ('a list) -> 'a
// Given a list of some type, returns an element of the same type.
printfn "\nsecond list1: %d" (second list1)

// Writing type annotations for lists is tedious. We typically DON'T use .Head or .Tail for this reason.
// Instead, the List class has functions named "head" and "tail" that can be applied to a list object.

let third coll =
    List.head (List.tail (List.tail coll))
// coll is inferred to be of type "'a list", because List.tail takes a param of type "'a list". NICE.

// So get ".Head" and ".Tail" out of your brain. That's imperative-style thinking. Think functionally!!

// All the parens in third are making me dizzy. I thought we were done with Lisp!
// Enter the |> operator, F#'s "pipe forward" operator. |> is an infix operator that takes a value and a 
// function. The value is passed to the function as the last parameter.
let third2 coll =
    coll |> List.tail |> List.tail |> List.head

// |> can be broken over many lines for better readability
let second2 coll =
    coll
    |> List.tail
    |> List.head
// BEAUTIFUL.

// We can use |> all the time!!
second2 list1 |> printfn "second2 list: %d"



// See if a list starts with the given element.
let startsWith h coll =
    coll
    |> List.head
    |> (=) h      // all operators are also functions; but we have to put them in parens to force this.


printfn "startsWith list1 5: %O" (startsWith 1 list1)

// You know what's coming next.... recursive functions on lists!
