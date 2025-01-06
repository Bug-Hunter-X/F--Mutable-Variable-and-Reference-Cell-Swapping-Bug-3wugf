//This solution uses a helper function to swap the values properly

let swap x y = 
    let temp = !x
    x := !y
    y := temp

let swapReferences x y =
    let temp = !x
    x := !y
    y := temp

let mutable x = ref 10
let mutable y = ref 20

//Testing the swapReferences function
printf "Before swap: %d %d\n" (!x) (!y)
swapReferences x y
printf "After swap: %d %d\n" (!x) (!y)

swapReferences x y
printf "After another swap: %d %d\n" (!x) (!y)

//This will now correctly swap the references between consecutive calls.
