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

        /// <summary>
        /// Time = O(wh) , Space = O(wh)
        /// </summary>
        public static List<int> RiverSizes(int[,] matrix)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            bool[,] visitedMatrix = new bool[height, width];
            Stack<int[]> coordOfSameRiver = new Stack<int[]>();
            List<int> ret = new List<int>();

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (visitedMatrix[row,col])
                        continue;
                    if (matrix[row,col] == 1)
                    {
                        visitedMatrix[row, col] = true;
                        coordOfSameRiver.Push(new int[2] { row,col});
                        ret.Add(ComputeSizeOfCurrentRiver(matrix,coordOfSameRiver,visitedMatrix));
                    }
                }
            }

            return ret;
        }

        public static int ComputeSizeOfCurrentRiver(int[,] matrix, Stack<int[]> coordOfSameRiver, bool[,] visitedMatrix) { 
            int size = 0;
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            while (coordOfSameRiver.Count > 0)
            {
                var current = coordOfSameRiver.Pop();
                int row = current[0];
                int col = current[1];
                size++;

                if (row -1 >= 0 && !visitedMatrix[row - 1,col] && matrix[row - 1, col] == 1)
                {
                    visitedMatrix[row - 1, col] = true;
                    coordOfSameRiver.Push(new int[2] { row - 1, col});
                }

                if (col + 1 < width && !visitedMatrix[row, col + 1] && matrix[row, col + 1] == 1)
                {
                    visitedMatrix[row, col + 1] = true;
                    coordOfSameRiver.Push(new int[2] { row , col + 1 });
                }

                if (row + 1 < height && !visitedMatrix[row + 1, col] && matrix[row + 1, col] == 1)
                {
                    visitedMatrix[row + 1, col] = true;
                    coordOfSameRiver.Push(new int[2] { row + 1, col });
                }

                if (col - 1 > 0 && !visitedMatrix[row, col - 1] && matrix[row, col - 1] == 1)
                {
                    visitedMatrix[row, col - 1] = true;
                    coordOfSameRiver.Push(new int[2] { row, col - 1 });
                }
            }

            return size;
        }
    }
}
