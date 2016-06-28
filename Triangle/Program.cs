using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program { 
    public class Triangle
    {

        public enum TriangleType { ISOSCELES, SCALENE, EQUILATERAL, INVALID }

        public int[] Sides { get; set; }

        public  TriangleType DetectType()
        {
            if (Sides.Length != 3)
            {
                throw new InvalidTriangleException();
            }

            int[] s = new int[Sides.Length];

            TriangleType result = TriangleType.INVALID;

            try
            {
                for (int i = 0; i < Sides.Length; i++)
                    s[i] = Sides[i];

                if (s[0] > s[1])
                    swap(s, 0, 1);

                if (s[0] > s[2])
                    swap(s, 0, 2);

                if (s[1] > s[2])
                    swap(s, 1, 2);

                if (s[0] <= 0 || s[2] - s[0] >= s[1])
                {
                    throw new InvalidTriangleException();
                }

                if (s[0] == s[2])
                {
                    result = TriangleType.EQUILATERAL;
                }
                else if (s[0] == s[1] || s[1] == s[2])
                {
                    result = TriangleType.ISOSCELES;
                }
                else
                {
                    result = TriangleType.SCALENE;
                }
            }
            catch (Exception e)
            {
                result = TriangleType.INVALID;
                throw e; //re throw
            }

            return result;
        }

         void swap(int[] s, int i, int j)
        {
            int tmp = s[i];
            s[i] = s[j];
            s[j] = tmp;
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Enter the sides of the triangle:");
            char whitespace = ' ';
            int[] sides = Console.ReadLine().Split(whitespace).Select(s => Convert.ToInt32(s)).ToArray();
            Triangle triangleDetector = new Triangle();
            triangleDetector.Sides = sides;
            TriangleType type = triangleDetector.DetectType();
            Console.WriteLine("The triangle type is " + type);
            Console.ReadLine();
        }
    }

}