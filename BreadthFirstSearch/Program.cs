using System;
using System.Collections.Generic;

namespace BreadthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
			#region Creating Graph

			Node aNode = new Node("A");
			Node bNode = new Node("B");
			Node cNode = new Node("C");
			Node dNode = new Node("D");
			Node eNode = new Node("E");
			Node fNode = new Node("F");
			Node gNode = new Node("G");
			Node hNode = new Node("H");
			Node iNode = new Node("I");
			Node jNode = new Node("J");
			Node kNode = new Node("K");

			List<Node> aChildren = new List<Node>() { bNode, cNode, dNode };
			List<Node> bChildren = new List<Node>() { eNode, fNode };
			List<Node> dChildren = new List<Node>() { gNode, hNode };
			List<Node> fChildren = new List<Node>() { iNode, jNode };
			List<Node> gChildren = new List<Node>() { kNode };

			aNode.children = aChildren;
			bNode.children = bChildren;
			cNode.children = null;
			dNode.children = dChildren;
			fNode.children = fChildren;
			gNode.children = gChildren;

			#endregion

			Console.WriteLine($"The output is :  { String.Join(',', aNode.BreadthFirstSearch(new List<string>()))}");
		}

		public class Node
		{
			public string name;
			public List<Node> children = new List<Node>();

			public Node(string name)
			{
				this.name = name;
			}


			/// <summary>
			/// Time = O(V + E)  => Number of vertices(pl of vertex) + Edges
			/// Space = O(V) => Number of vertices(pl of vertex)
			/// </summary>
			public List<string> BreadthFirstSearch(List<string> array)
			{
				
				Queue<Node> graphNodes = new Queue<Node>();
				graphNodes.Enqueue(this);
                while (graphNodes.Count > 0)
                {
					var currentNode = graphNodes.Dequeue();
					array.Add(currentNode.name);
					if (currentNode.children == null)
						continue;
                    foreach (var item in currentNode.children)
                    {
						graphNodes.Enqueue(item);
                    }
				}
				return array;
			}

			public Node AddChild(string name)
			{
				Node child = new Node(name);
				children.Add(child);
				return this;
			}
		}
	}
}
