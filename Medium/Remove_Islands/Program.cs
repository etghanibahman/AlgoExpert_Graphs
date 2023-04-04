using System;
using System.ComponentModel.Design;
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
                                          new int[] { 1, 1, 0, 0, 1, 0},
                                          new int[] { 1, 0, 1, 1, 0, 0},
                                          new int[] { 1, 0, 0, 0, 0, 1}};


            Console.WriteLine("The input matrix is:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(",", matrix[i]));
            }

            var result = RemoveIslands(matrix);

            Console.WriteLine("\nThe output matrix is:");
            for (int i = 0; i < result.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(",", result[i]));
            }
        }

        public static int[][] RemoveIslands(int[][] matrix)
        {
            Console.WriteLine($"rows : {matrix.Length} | cols: {matrix[0].Length}");
            var notIslands = new bool[matrix.Length,matrix[0].Length];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool rowIsBorder = row == 0 || row == matrix.Length - 1;
                    bool colIsBorder = col == 0 || col == matrix[row].Length - 1;
                    bool isBorder = rowIsBorder || colIsBorder;
                    if (!isBorder)
                    {
                        continue;
                    }
                    if (matrix[row][col] != 1)
                    {
                        continue;
                    }
                    DFS(matrix,row,col,notIslands);
                }
            }

            Console.WriteLine("\notIslands is:");
            for (int i = 0; i < notIslands.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(",", GetRow(notIslands, i)));
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    if (matrix[row][col] == 1 && notIslands[row,col] == false)
                    {
                        matrix[row][col] = 0;
                    }
                }
            }

            return matrix;
        }
        //Depth-first search to find 1's which cannot be an island
        public static void DFS(int[][] matrix, int row, int col, bool[,] notIslands)
        {
            if (matrix[row][col] == 0 || notIslands[row,col] == true)
            {
                return;
            }
            notIslands[row, col] = true;

            //Search up
            if (row > 0)
            {
                DFS(matrix, row -1, col, notIslands);
            }
            //Search down
            if (row < matrix.Length -1)
            {
                DFS(matrix, row + 1, col, notIslands);
            }
            //Search left
            if (col > 0)
            {
                DFS(matrix, row, col-1, notIslands);
            }
            //Search right
            if (col < matrix[0].Length -1)
            {
                DFS(matrix, row , col + 1, notIslands);
            }
        }

        public static bool[] GetRow(bool[,] mat, int rowNumber)
  => Enumerable.Range(0, mat.GetLength(1))
          .Select(i => mat[rowNumber, i])
          .ToArray();
    }
}
