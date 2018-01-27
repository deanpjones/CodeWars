using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using djOutput = LibraryDJ.Extensions.OutputExtension;        //add custom library

namespace CodeWars2.Exercises
{
    public static class exercise7
    {
        //exercise 7 
        //Write an algorithm that takes an array and moves all of the zeros to the end, preserving the order of the other elements.
        //Kata.MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}) => 
        //    new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0}
        // ------------
        //other solutions 
        //public static int[] MoveZeroes(int[] arr) => arr.OrderBy(o => o == 0).ToArray();
        public static int[] MoveZeroes(int[] arr)
        {
            //get all zeros
            var list1 = arr.ToList().FindAll(x => x == 0);
            //get all other numbers (not zeros)
            var list2 = arr.ToList().FindAll(x => x != 0);
            //put the zeros on the end
            list2.AddRange(list1);
            //convert back to array
            int[] result = list2.ToArray();

            return result;
        }
   
        //test...
        public static void TestMoveZeroes()
        {
            //list to test...
            int[] arr1 = new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 };
            //convert list...
            int[] result = MoveZeroes(arr1);

            //display
            Console.Write("Argument int[]: ");
            djOutput.PrintToConsole(arr1.ToList());
            
            Console.Write("Result: ");
            djOutput.PrintToConsole(result.ToList());
        }
    }
}
