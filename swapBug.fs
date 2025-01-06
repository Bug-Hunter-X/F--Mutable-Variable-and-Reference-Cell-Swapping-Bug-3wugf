let mutable x = 10
let mutable y = 20

let swap x y = 
    let temp = x
    x <- y
    y <- temp

swap x y
printf "%d %d" x y // This will print 20 10 as expected

// However, if we do:
let mutable x = 10
let mutable y = ref 20 // y is now a reference cell

let swap x y = 
    let temp = x
    x <- !y // Dereference y to get its value
    y := temp // Assign temp to the value inside the reference cell

swap x y
printf "%d %d" x (!y) //This will print 20 10. This is not entirely unexpected

//Now, consider the following:
let mutable x = 10
let mutable y = ref 20
let mutable z = ref 30

let swap x y z = 
    let temp = x
    x <- !y
    y := !z
    z := temp

swap x y z
printf "%d %d %d" x (!y) (!z) //This will print 20 30 10. So far so good

//Let's try something else
let mutable x = ref 10
let mutable y = ref 20

let swap x y = 
    let temp = !x
    x := !y
    y := temp

swap x y
printf "%d %d" (!x) (!y) //This will print 20 10. Nothing wrong here

//However, if you call this swap method multiple times:
let mutable x = ref 10
let mutable y = ref 20

let swap x y = 
    let temp = !x
    x := !y
    y := temp

swap x y
printf "%d %d" (!x) (!y) //This will print 20 10
swap x y
printf "%d %d" (!x) (!y) //This will also print 20 10

//This happens because the swap function is only swapping the values of references, not the references themselves. Therefore, consecutive calls don't modify the references.
//This is a bit subtle and can be easily missed if you are not careful