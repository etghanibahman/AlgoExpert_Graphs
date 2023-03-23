using System;

namespace YoungestCommonAncestor
{
    class Program
    {  
        static void Main(string[] args)
        {
            AncestralTree nodeA = new AncestralTree('A');
            AncestralTree nodeB = new AncestralTree('B');
            AncestralTree nodeC = new AncestralTree('C');
            AncestralTree nodeD = new AncestralTree('D');
            AncestralTree nodeE = new AncestralTree('E');
            AncestralTree nodeF = new AncestralTree('F');
            AncestralTree nodeG = new AncestralTree('G');
            AncestralTree nodeH = new AncestralTree('H');
            AncestralTree nodeI = new AncestralTree('I');

            nodeB.ancestor = nodeA;
            nodeC.ancestor = nodeA;
            nodeD.ancestor = nodeB;
            nodeE.ancestor = nodeB;
            nodeF.ancestor = nodeC;
            nodeG.ancestor = nodeC;
            nodeH.ancestor = nodeD;
            nodeI.ancestor = nodeD;

            var youngestCommonAncestor = GetYoungestCommonAncestor(nodeA,nodeE,nodeI);
            //var youngestCommonAncestor = GetYoungestCommonAncestor(nodeA, nodeI, nodeE);

            Console.WriteLine($"Youngest Common Ancestor: {youngestCommonAncestor.name}");
        }

        public static AncestralTree GetYoungestCommonAncestor(AncestralTree topAncestor,AncestralTree descendantOne,
                                                                AncestralTree descendantTwo)
        {
            int depthOne = GetDepth(descendantOne, topAncestor);
            int depthTwo = GetDepth(descendantTwo, topAncestor);

            var diff = Math.Abs(depthOne - depthTwo);

            AncestralTree node1 = depthOne > depthTwo ? descendantOne : descendantTwo;
            AncestralTree node2 = depthOne > depthTwo ? descendantTwo : descendantOne;

            while (diff>0)
            {
                node1 = node1.ancestor;
                diff -= 1;
            }

            while (node1 != node2)
            {
                node1 = node1.ancestor;
                node2 = node2.ancestor;
            }

            return node1;
        }

        private static int GetDepth(AncestralTree tree, AncestralTree topAncestor) {
            int depth = 0;
            AncestralTree node = tree;
            while (node != topAncestor)
            {
                node = node.ancestor;
                depth += 1;
            }
            return depth;
        }

        public class AncestralTree
        {
            public char name;
            public AncestralTree ancestor;

            public AncestralTree(char name)
            {
                this.name = name;
                this.ancestor = null;
            }

            // This method is for testing only.
            public void AddAsAncestor(AncestralTree[] descendants)
            {
                foreach (AncestralTree descendant in descendants)
                {
                    descendant.ancestor = this;
                }
            }
        }

    }
}
