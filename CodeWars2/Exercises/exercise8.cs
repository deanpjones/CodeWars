using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars2.Exercises
{
    public static class exercise8
    {
        //exercise 8
        //If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        //Finish the solution so that it returns the sum of all the multiples of 3 or 5 below the number passed in.
        //Note: If the number is a multiple of both 3 and 5, only count it once.
        //--------
        //other answers 
        //  return Enumerable.Range(0, n).Where(e => e % 3 == 0 || e % 5 == 0).Sum();
        public static int Solution(int value)
        {
            int result;

            //declare lists
            List<int> list3 = new List<int>();
            List<int> list5 = new List<int>();
            List<int> listFinal = new List<int>();

            //push lists
            list3 = GetListFromMultiple(3, value);
            list5 = GetListFromMultiple(5, value);

            //join lists
            listFinal = list3.Union(list5).ToList();

            //sum from list
            result = listFinal.Sum();

            return result;

        }

        //temp function
        public static List<int> GetListFromMultiple(int multiple, int value)
        {
            int temp = multiple;
            List<int> list = new List<int>();

            while (temp < value)
            {
                list.Add(temp);             //add to list
                temp += multiple;           //increment by 3
            }

            return list;
        }

        //test 
        public static void TestSolution()
        {
            int temp = 10;
            int result = Solution(temp);

            Console.WriteLine("Input is 10, result should be 23 (3+5+6+9), result: {0}", result);
        }
    }
}
