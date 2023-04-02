using System;
using System.Linq;

namespace Remove_Islands
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[][] {new int[] { 1, 0, 0, 0, 0, 0},
                                          new int[] { 0, 1, 0, 1, 1, 1},
                                          new int[] { 0, 0, 1, 0, 1, 0},
                                          new int[]{ 1, 1, 0, 0, 1, 0},
                                          new int[]{ 1, 0, 1, 1, 0, 0},
                                          new int[]{ 1, 0, 0, 0, 0, 1}};


            Console.WriteLine("The input matrix is:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(",", matrix[i]));
            }

            var result = RemoveIslands(matrix);

            //Console.WriteLine("\nThe output matrix is:");
            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    Console.WriteLine(string.Join(",", matrix[i]));
            //}

            //Console.WriteLine("Hello World!");
        }

        public static int[][] RemoveIslands(int[][] matrix)
        {
            // Write your code here.
            return new int[][] { };
        }

        //public static int[] GetRow(int[][] mat, int rowNumber)
        //{ 
            
        //}
    }
}
