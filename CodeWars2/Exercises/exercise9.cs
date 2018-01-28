using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars2.Exercises
{
    //exercise 9
    //Calculate the area of a regular n sides polygon inside a circle of radius r

    //Write the following function:

    //  public static double AreaOfPolygonInsideCircle(double circleRadius, int numberOfSides)
    //  It should calculate the area of a regular polygon of numberOfSides or number_of_sides sides inside a circle of radius circleRadius or circle_radius which passes through all the vertices of the polygon (such circle is called circumscribed circle or circumcircle).The answer should be rounded to 3 decimal places.

    //    Input :: Output Examples
    //AreaOfPolygonInsideCircle(3, 3)   // returns 11.691
    //AreaOfPolygonInsideCircle(5.8, 7) // returns 92.053
    //AreaOfPolygonInsideCircle(4, 5)   // returns 38.042
    //
    //others answers 
    //  return Math.Round(n*Math.Pow(r, 2)*Math.Sin(2*Math.PI/n)/2, 3);

    public static class exercise9
    {
        //AREA OF A (REGULAR) POLYGON
        public static double AreaOfPolygonInsideCircle(double circleRadius, int numberOfSides)
        {
            //REGULAR POLYGON (same side lengths)
            //FORMULA (area = (r^2 * n * sin(360/n)) / 2)
            //r = radius (circumscribed polygon)
            //n = number of polygon sides

            double result;
            //calc
            result = (Math.Pow(circleRadius, 2) * numberOfSides * Math.Sin(ToRadians(360) / numberOfSides)) / 2;
            //rounding
            result = Math.Round(result, 3);

            return result;
        }

        //test
        public static void TestAreaOfPolygonInsideCircle()
        {
            Console.WriteLine("Radius is 1 for all shapes");
            Console.WriteLine("A hexagon area is: {0}", AreaOfPolygonInsideCircle(1, 6));
            Console.WriteLine("A pentagon area is: {0}", AreaOfPolygonInsideCircle(1, 5));
            Console.WriteLine("A square area is: {0}", AreaOfPolygonInsideCircle(1, 4));
        }

        //METHOD (DEGREES TO RADIANS)
        public static double ToRadians(this double degrees)
        {
            return degrees * (Math.PI / 180);
        }
        
    }
}
