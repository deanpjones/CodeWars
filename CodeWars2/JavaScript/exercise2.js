//Summy
//Jan.30, 2018

//Write a function that takes a string which has integers inside it separated by spaces, and your task is to convert each integer in the string into an integer and return their sum.

//Example
//summy("1 2 3")  ==> 6

var s = "1 2 3";
var s2 = "666";     //test for ONE NUMBER

//FUNCTION
function summy(stringOfInts) {
    var sum = (a, b) => +a + +b;
    return Number.parseInt(stringOfInts.split(" ").reduce(sum));
}

//??? FAILS ON ONE NUMBER ONLY (returns string)
//function summy(stringOfInts) {
//    var sum = (a, b) => +a + +b;
//    return stringOfInts.split(" ").reduce(sum);
//}

//var c = "1 2 3";
//var sum = 0;
//var temp = c;
//var char;

////c.replace(" ",  "")
//temp = temp.replace(/ /g, "");                          //regex (removes all spaces, globally)

//if (Number.isInteger(Number.parseInt(temp))) {          //test for integer (return true)

//    for (var i = 0; i < temp.length; i++) {
//        char = temp.slice(0, 1);                        //gets first digit (returns "1")
//        sum += Number.isInteger(Number.parseInt(char)); //add digit to sum
//        temp = temp.replace(i + 1, "");                 //removes first digit (returns "23")
//    }
//}


Number.parseInt(c);          //convert String to Number

c.replace(1, "");           //removes first CHAR of string

c = c.slice(0, 1);              //gets first digit (returns "1")
sum = Number.isInteger(Number.parseInt(c))
c = c.replace(1, "")        //removes first digit (returns "23")

