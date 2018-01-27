using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars2.Exercises
{
    public static class exercise6
    {
        //---------------------------------
        //exercise 6 
        //This is an easy twist to the example kata(provided by Codewars when learning how to create your own kata).
        //Add the value "codewars" to the array websites/Websites 1,000 times
        public static string[] Websites;

        //method to push to...
        public static string[] WebsitesToCodeWars()
        {
            Websites = new string[1000];
            for (int i = 0; i < Websites.Length; i++)
            {
                Websites[i] = "codewars";
            }
            return Websites;
        }
        //test method 
        public static void testWebsites()
        {
            WebsitesToCodeWars();

            for (int i = 0; i < Websites.Length; i++)
            {
                Console.WriteLine(Websites[i]);     //test each element
            }
            Console.WriteLine("Websites length: {0}", Websites.Length);
        }
        //---------------------------------
    }
}
