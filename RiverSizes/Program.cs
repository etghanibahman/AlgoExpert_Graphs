using System;
using System.Collections.Generic;

namespace RiverSizes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]{ {1, 0, 0, 1, 0},
                                        {1, 0, 1, 0, 0},
                                        {0, 0, 1, 0, 1},
                                        {1, 0, 1, 0, 1},
                                        {1, 0, 1, 1, 0}};

            Console.WriteLine("River sizes are : ");
            var riverSizes = RiverSizes(matrix);

            foreach (var size in riverSizes)
            {
                Console.WriteLine(size);
            }
        }

        public static List<int> RiverSizes(int[,] matrix)
        {

            return new List<int>() { 1 , 5};
        }
    }
}
