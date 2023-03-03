using System;

namespace CycleInGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] edges = { new int[] { 1, 3 }, new int[] { 2, 3, 4 }, new int[] { 0 }, 
                                new int[] { }, new int[] { 2, 5 }, new int[] { } };

            

            Console.WriteLine($"Is there a cycle in the graph? {CycleInGraph(edges)}");
        }

        public static bool CycleInGraph(int[][] edges)
        {
            // Write your code here.
            return false;
        }
    }
}
