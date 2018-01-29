using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars2.Exercises
{
    //FACTORIAL (HOW MANY ZERO'S ON THE END...)
    //  4 KYU (pretty high level of difficulty)
    //  the trick here (the ZERO's all come from 10's which are FACTORS OF (2 and 5 only)
    //      so I ONLY NEED TO FIGURE... the NUMBERS that have PAIRS OF (2 * 5)(or below)

    //  pattern, need to only follow the (MULITPLES OF 5)(for BASE-10)(test on WOLFRAM ALPHA)
    //      once it gets to (25!) (5x5) (there are TWO ZEROS added here, just like 125(5x5x5) THREE ZEROS
    //      5, 5, 5, 5, (5^2), 5, 5, 5, 5, (5^2), 5, 5, 5, 5, (5^2), 5, 5, 5, 5, (5^2), 5, 5, 5, 5, (5^3),...

    //  WOLFRAM ALPHA 
    //  1,000,000!  = 249,998 TRAILING ZEROS
    //  999,999!    = 249,992 TRAILING ZEROS

    //  999,990!    = 249,991
    //  999989!     = 249,990 
    //----------------------
    //The problem
    //How many zeroes are at the end of the factorial of 10? 10! = 3628800, i.e.there are 2 zeroes. 16! in hexadecimal would be 0x130777758000, which has 3 zeroes.

    //Scalability
    //Unfortunately, machine integer numbers has not enough precision for larger values.Floating point numbers drop the tail we need.We can fall back to arbitrary-precision ones - built-ins or from a library, but calculating the full product isn't an efficient way to find just the tail of a factorial. Calculating 100'000! in compiled language takes around 10 seconds. 1'000'000! would be around 10 minutes, even using efficient Karatsuba algorithm

    //Your task
    //is to write a function, which will find the number of zeroes at the end of(number) factorial in arbitrary radix = base for larger numbers.

    //base is an integer from 2 to 256
    //number is an integer from 1 to 1'000'000

    class _exercise10
    {
    }
}
