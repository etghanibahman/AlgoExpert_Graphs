using System;
using System.Collections.Generic;

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


        /// <summary>
        /// Time O(v+e) , Space O(v)
        /// </summary>
        #region Iterative DFS
        public static bool CycleInGraph(int[][] edges)
        {
            for (int i = 0; i < edges.Length; i++)
            {
                if (traverseNode(edges, i)) { return true; }
            }
            return false;
        }
        public static bool traverseNode(int[][] edges, int idx)
        {
            Stack<int> nodesToVisit = new Stack<int>();
            HashSet<int> seen = new HashSet<int>();
            nodesToVisit.Push(idx);
            while (nodesToVisit.Count > 0)
            {
                int current = nodesToVisit.Pop();
                if (Array.Exists(edges[current], e => e == idx))
                {
                    return true;
                }
                seen.Add(current);
                foreach (int v in edges[current])
                {
                    if (!seen.Contains(v))
                    {
                        nodesToVisit.Push(v);
                    }
                }
            }
            return false;
        }
        #endregion

        #region Recursive 
        //public static bool CycleInGraph(int[][] edges)
        //{
        //    var visitedNodes = new HashSet<int>();
        //    var processed = new HashSet<int>();
        //    var isCycle = false;
        //    for (int i = 0; i < edges.Length; i++)
        //    {
        //        if (!processed.Contains(i))
        //        {
        //            isCycle |= CycleInGraph(edges,i,visitedNodes,processed );
        //        }
        //    }
        //    return isCycle;
        //}
        //public static bool CycleInGraph(int[][] edges, int vertex, HashSet<int> visitedNodes, HashSet<int> processed) {
        //    if (visitedNodes.Contains(vertex))
        //    {
        //        return true;
        //    }
        //    visitedNodes.Add(vertex);
        //    var isCycle = false;
        //    for (int i = 0; i < edges[vertex].Length; i++)
        //    {
        //        isCycle |= CycleInGraph(edges, edges[vertex][i],visitedNodes,processed);
        //    }
        //    visitedNodes.Remove(vertex);
        //    processed.Add(vertex);
        //    return isCycle;
        //}
        #endregion
    }
}
