//BETA 
//JAN.28, 2018
//Prime factorisation in index notation

//You need to create a function ( primeFactorisation() )which takes a non- empty array, of non- negative integers as its argument and returns a 2- dimensional array containing the prime factorisation array of each of it's arguments' elements.

//Three examples of correct prime factorisation arrays of 10, 17 and 60:

//10 -> [1, 0, 1] //since 10 = 2^1 x 3^0 x 5^1

//17 -> [0, 0, 0, 0, 0, 0, 1] //since 17 = 2^0 x 3^0 x 5^0 x 7^0 x 11^0 x 13^0 17^1

//60 -> [2, 1, 1] //since 60 = 2^2 x 3^1 x 5^1

//If an element of the given array does not have a prime factorisation, it should be ignored and not included in the returned array.The returned array's elements should be in order, starting with the prime factorisation representing the largest number and finish with the smallest.

//primeFactorisation([10, 2]);

//returns-- > [[1, 0, 1], [1]]

//primeFactorisation([2, 10]);

//Also returns (since 10> 2)-- > [[1, 0, 1], [1]]

//------------
//SAMPLE TESTS... (ordered LARGE to SMALL)
//Test.assertSimilar(primeFactorisation([10]), [[1, 0, 1]], "[10] should return: [[1, 0, 1]]")
//Test.assertSimilar(primeFactorisation([10, 2]), [[1, 0, 1], [1]], "[10 , 2] should return: [[1, 0, 1], [1]]")
//Test.assertSimilar(primeFactorisation([12, 3, 6]), [[2, 1], [1, 1], [0, 1]], " should return: [[2, 1], [1, 1], [0, 1]]")
//Test.assertSimilar(primeFactorisation([102, 35, 600, 1000]), [[3, 0, 3], [3, 1, 2], [1, 1, 0, 0, 0, 0, 1], [0, 0, 1, 1]], "[102, 35, 600, 1000] should return: [[3, 0, 3], [3, 1, 2], [1, 1, 0, 0, 0, 0, 1], [0, 0, 1, 1]]")
//Test.assertSimilar(primeFactorisation([12, 34, 66, 88]), [[3, 0, 0, 0, 1], [1, 1, 0, 0, 1], [1, 0, 0, 0, 0, 0, 1], [2, 1]], "[12, 34, 66, 88] should return: [[3, 0, 0, 0, 1], [1, 1, 0, 0, 1], [1, 0, 0, 0, 0, 0, 1], [2, 1]]")
//Test.assertSimilar(primeFactorisation([1]), [], "[1] should return: []")
//Test.assertSimilar(primeFactorisation([9, 8, 96, 0]), [[5, 1], [0, 2], [3]], "[9,8,96,0] should return: [[5, 1], [0, 2], [3]]")


//prime list (up to 1000)(use for reference)
var primes = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97,
    101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199,
    211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293,
    307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397,
    401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499,
    503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599,
    601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691,
    701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797,
    809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887,
    907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997
];

//***************************************************************************
//***************************************************************************
//MAIN FUNCTION 
function primeFactorisation(arr) {
    var _arr = arr;
    _arr = RemoveZeroAndOneFromArray(_arr);       //remove any zeros in array
    
    _arr = arr.sort((a, b) => { return b - a });        //sort descending
    var finalArray = [];

    for (var i = 0; i < _arr.length; i++) {
        var factors = GetPrimeFactors2(_arr[i]);
        var indexOfFactors = GetIndexOfPrimeFactors(factors)
        indexOfFactors = RemoveTrailingZerosInArray(indexOfFactors);
        finalArray.push(indexOfFactors);
    }

    //using RemoveZeroAndOneFromArray
    //[1] should return: [] - Expected: '[]', instead got: '[[]]'
    //if (typeof finalArray[0][0] == 'undefined') {
    //    finalArray.pop();
    //}

    return finalArray;
}
//***************************************************************************
//***************************************************************************

//remove zero(0) and one(1) from array (var arr = [9, 8, 96, 0])(var arr = [1])
function RemoveZeroAndOneFromArray(arr) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] < 2) {               //if (arr[i] == 0) {
            arr.splice(i, 1);
        }
    }
    return arr;
}

//---------------------------------
//get index of prime factors 
function GetIndexOfPrimeFactors(arrayPrimeFactors) {
    //var arr = [2, 2, 3];    //12 (2,2,3) --> [2,1]
    var primeFactorsIndexes = [];

    for (var i = 0; i < primes.length; i++) {
        primeFactorsIndexes[i] = CountInArray(primes[i], arrayPrimeFactors);
    } 
    return primeFactorsIndexes;
}

//remove (trailing zeros) in array 
function RemoveTrailingZerosInArray(arr) {
    while (arr[arr.length - 1] === 0) {     // While the last element is a 0,
        arr.pop();                          // Remove that last element
    }
    return arr;
}

//count the number of times (n) is in the (array)
function CountInArray(n, array) {
    var count = 0;
    for (var i = 0; i < array.length; ++i) {
        if (array[i] == n)
            count++;
    }
    return count;
}
//---------------------------------
//---------------------------------
//test all primes for divisibility (return array of primes)
//only returns (one instance of prime factor)
function GetPrimeFactors(n) {
    var primeFactors = [];

    for (var i = 0; i < primes.length; i++) {
        if (IsDivisible(n, primes[i])) {
            primeFactors.push(primes[i]);
        }
    }

    return primeFactors;
}

//test all primes for divisibility (return array of primes)
//returns (all instances of prime factors)
function GetPrimeFactors2(n) {
    var primeFactors = [];
    var temp = n;
    var remainder = 0;

    for (var i = 0; i < primes.length; i++) {
        if (IsDivisible(n, primes[i])) {
            while (remainder == 0) {
                temp = temp / primes[i];
                remainder = temp % primes[i];
                primeFactors.push(primes[i]);
            }
            remainder = 0;
        }
    }

    return primeFactors;
}

//test if divisible (by prime)
function IsDivisible(n, prime) {
    return n % prime == 0;
}
//---------------------------------

//test to count factors
function Count(n, prime) {
    var count = 0;
    var temp = n;

    //repeat
    while (temp % prime == 0) {
        temp = temp / prime;
        count++;
    }

    return count;
}


