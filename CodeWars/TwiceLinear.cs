using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CodeWars
{
    class TwiceLinear
    {
        //--------------------------------------------------
        //Consider a sequence u where u is defined as follows:

        //The number u(0) = 1 is the first one in u.
        //For each x in u, then y = 2 * x + 1 and z = 3 * x + 1 must be in u too.
        //There are no other numbers in u.
        //Ex: u = [1, 3, 4, 7, 9, 10, 13, 15, 19, 21, 22, 27, ...]

        //1 gives 3 and 4, then 3 gives 7 and 10, 4 gives 9 and 13, then 7 gives 15 and 22 and so on...

        //#Task: Given parameter n the function dbl_linear (or dblLinear...) returns the element u(n) of the ordered (with <) sequence u.

        //#Example: dbl_linear(10) should return 22
        //--------------------------------------------------

        public static int DblLinear(int n)
        {
            int temp1, temp2;                       //temp values for formulas
            int count = 0;                          //keep track of element
            int element = 1;                        //element to add index                
            int[] list = new int[2 * n + 1];        //create list (to make sure all lesser values are accounted for)
            list[0] = 1;                            //start off list for one          

            for (int i = 0; i < n; i++)
            {
                temp1 = (2 * list[count] + 1);          //formula 1
                list[element] = temp1;                  //add to array         
                //sort list (after each pass)
                list = list.OrderBy(x => x == 0).ThenBy(x => x).ToArray();  
                element++;                              //increment for next position

                temp2 = (3 * list[count] + 1);          //formula 2
                list[element] = temp2;                  //add to array
                //sort list (after each pass)
                list = list.OrderBy(x => x == 0).ThenBy(x => x).ToArray();  
                element++;                              //increment for next position

                count++;                                //increment for input
            }

            //u = [1, 3, 4, 7, 9, 10, 13, 15, 19, 21, 22, 27, 
            //remove duplicates at end 
            list = list.Distinct().ToArray();
            return list[n];                             //return nth value
        }
        public static int GetSum(int x, int y)
        {
            return x + y;
        }

        //COMBINATIONS (POW)(Vivian Assignment)
        //Carmen can babysit for three(3) days, she can only work up to (5hrs/day max)
        //How many different combinations can she work in the three days to earn $9.00 she needs?
        public static List<String> GetCombination()
        {
            //can only work (up to 5 hrs) per day (each list is a day)
            int[] day1 = { 0, 1, 2, 3, 4, 5 };
            int[] day2 = { 0, 1, 2, 3, 4, 5 };
            int[] day3 = { 0, 1, 2, 3, 4, 5 };

            List<string> s = new List<string>();

            for (int i = 0; i < day1.Length; i++)
            {
                for (int j = 0; j < day2.Length; j++)
                {
                    for (int k = 0; k < day3.Length; k++)
                    {
                        if(i + j + k == 9)     //condition (filter to TOTAL $9.00)
                        {
                            s.Add(day1[i] + ", " + day2[j] + ", " + day3[k]);
                        }                     
                    }
                }
            }

            return s;
        }

        public static void TestEnumCombination()
        {
            var triplets = from I in Enumerable.Range(0, 3)
                   from J in Enumerable.Range(0, 3)
                   from K in Enumerable.Range(0, 3)
                   select new { I, J, K };
            foreach (var t in triplets)
            {
                Console.WriteLine("{0}, {1}, {2}", t.I, t.J, t.K);
            }
        }
    }
}
