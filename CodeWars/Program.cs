using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            //exercise 5 
            Console.WriteLine("Exercise 5, 0 = '00:00:00': " + GetReadableTime(0));
            Console.WriteLine("Exercise 5, 5 = '00:00:05': " + GetReadableTime(5));
            Console.WriteLine("Exercise 5, 60 = '00:01:00': " + GetReadableTime(60));
            Console.WriteLine("Exercise 5, 86399 = '23:59:59': " + GetReadableTime(86399));
            Console.WriteLine("Exercise 5, 359999 = '99:59:59': " + GetReadableTime(359999));
            //Assert.AreEqual(TimeFormat.GetReadableTime(0), "00:00:00");
            //Assert.AreEqual(TimeFormat.GetReadableTime(5), "00:00:05");
            //Assert.AreEqual(TimeFormat.GetReadableTime(60), "00:01:00");
            //Assert.AreEqual(TimeFormat.GetReadableTime(86399), "23:59:59");
            //Assert.AreEqual(TimeFormat.GetReadableTime(359999), "99:59:59");

            //exercise 1
            int[] numbers = { 5, 8, 7, 9, 2, 3, -1 };
            var x = sumTwoSmallestNumbers(numbers);
            Console.WriteLine("sumTwoSmallestNumbers: " + x);

            //exercise 2
            var x2 = SongDecoder("WUBWEWUBAREWUBWUBWUBWUBWUBWUBWUBWUBTHEWUBCHAMPIONSWUBMYWUBFRIENDWUB");
            Console.WriteLine("SongDecoder: " + x2);

            //exercise 3
            var x3 = Persistence(39);       //3
            var x4 = Persistence(999);      //4
            var x5 = Persistence(4);        //0
            var x6 = Persistence(25);       //2
            Console.WriteLine("Persistence: " + x3);
            Console.WriteLine("Persistence: " + x4);
            Console.WriteLine("Persistence: " + x5);
            Console.WriteLine("Persistence: " + x6);

            //combinations...
            var list = TwiceLinear.GetCombination();
            Console.WriteLine("Combinations: ");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Combinations (count): " + list.Count);

            //test enumeration 
            Console.WriteLine("test enumeration: ");
            TwiceLinear.TestEnumCombination();

            //exercise 4 
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 10; i < 100; i++)
            {
                var d1 = TwiceLinear.DblLinear(i);
                Console.WriteLine("DblLinear({0}): {1}", i, d1);
            }
            sw.Stop();
            double time = sw.ElapsedMilliseconds;
            Console.WriteLine("total time: " + time);
            //var d1 = TwiceLinear.DblLinear(10);
            //var d2 = TwiceLinear.DblLinear(20);
            //var d3 = TwiceLinear.DblLinear(30);
            //var d4 = TwiceLinear.DblLinear(50);
            //Console.WriteLine("DblLinear(10): " + d1);
            //Console.WriteLine("DblLinear(20): " + d2);
            //Console.WriteLine("DblLinear(30): " + d3);
            //Console.WriteLine("DblLinear(50): " + d4);

            List<int> list2 = new List<int>();
            list2.Add(1);
            list2.Add(2);
            list2.Add(2);
            list2.Add(4);
            Console.WriteLine("list2[3]: " + list2[3]);

            Console.Read();
        }

        //CODE WARS (EXERCISE 1)
        //Sum of two lowest positive integers
        public static int sumTwoSmallestNumbers(int[] numbers)
        {
            //Using LINQ to sort array
            numbers = numbers.OrderBy(x => x).ToArray();
            //Simply add up first two elements
            return numbers[0] + numbers[1];

            //*** the optimized code (by others) ***
            //return numbers.OrderBy(i => i).Take(2).Sum();
        }

        //CODE WARS (EXERCISE 2)
        //string decoder (remove "WUB" and whitespace)
        public static string SongDecoder(string input)
        {
            //this will fix 95% of the string
            string s = input.Replace("WUB", " ").Trim();
            for (int i = 0; i < 100; i++)
            {
                //this will ensure all DOUBLE (or more) spaces convert back to a single space
                s = s.Replace("  ", " ");   //use this to repeat any crazy amount of spaces
            }
            return s;

            //other code...
            //return Regex.Replace(input, "(WUB)+", " " ).Trim();
        }

        //CODE WARS (EXERCISE 3)
        //multiplicative persistence (multiplies all digits, and repeats until one digit)
        public static int Persistence(long n)
        {
            int mult;                                       //multiplied value (for each loop)
            int tempInt = (int)n;                           //value (from input)
            int count = 0;                                  //track count

            if(tempInt.ToString().Length > 1)               //use this only for single digit(otherwise count will trip early)
            {
                do
                {
                    mult = 1;                               //need to reset value here
                    while (tempInt != 0)
                    {
                        mult = mult * (tempInt % 10);       //get last digit
                        tempInt = tempInt / 10;             //chop off digit
                    }
                    count++;                                //keep the count
                    tempInt = mult;                         //reset the tempInt (with new value)

                } while (mult > 9);                         //need do while to stop at (single digit)
            }

            return count;
            //return mult;
        }
        //by others 
        //public static int Persistence(long n)
        //{
        //    int count = 0;
        //    while (n > 9)
        //    {
        //        count++;
        //        n = n.ToString().Select(digit => int.Parse(digit.ToString())).Aggregate((x, y) => x * y);
        //    }
        //    return count;
        //}

        //EXERCISE 5
        //Write a function, which takes a non-negative integer (seconds) as input and returns the time in a human-readable format (HH:MM:SS)
        //  HH = hours, padded to 2 digits, range: 00 - 99
        //  MM = minutes, padded to 2 digits, range: 00 - 59
        //  SS = seconds, padded to 2 digits, range: 00 - 59
        //
        //Was thinking about adding some error handling for (negative, or greater than 360,000, but decided not to here)
        public static string GetReadableTime(int seconds)
        {
            int hh, mm, ss;                     //define hours, minutes, and seconds
            int hh_remainder;                   //temporary value
            string result = "undefined";        //return string

            //-------------------
            //calc
            hh = seconds / 3600;                //get hours
            hh_remainder = seconds % 3600;      //get remaining seconds

            mm = hh_remainder / 60;             //get minutes

            ss = hh_remainder % 60;             //get remaining seconds
            //-------------------

            result = String.Format("{0:00}:{1:00}:{2:00}", hh, mm, ss);

            return result;
        }
        //others...
        //return string.Format("{0:d2}:{1:d2}:{2:d2}", seconds / 3600, seconds / 60 % 60, seconds % 60);
        //
        //var t = TimeSpan.FromSeconds(seconds);
        //return string.Format("{0:00}:{1:00}:{2:00}", (int) t.TotalHours, t.Minutes, t.Seconds);
    }

}

