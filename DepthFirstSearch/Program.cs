using System;
using System.Collections.Generic;

namespace DepthFirstSearch
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

			Console.WriteLine($"The output is :  { String.Join(',', aNode.DepthFirstSearch(new List<string>()))}");
		}

		// Do not edit the class below except for the DepthFirstSearch method.
		// Feel free to add new properties and methods to the class.
		public class Node
		{
			public string name;
			public List<Node> children = new List<Node>();

			public Node(string name)
			{
				this.name = name;
			}

			public List<string> DepthFirstSearch(List<string> array)
			{
				// Write your code here.
				Stack<Node> nodesStack = new Stack<Node>();
				nodesStack.Push(this);

                while (nodesStack.Count > 0)
                {
					var curNode = nodesStack.Pop();
					array.Add(curNode.name);
					if (curNode.children == null)
						continue;
                    for (int i = curNode.children.Count - 1; i >= 0; i--)
                    {
						nodesStack.Push(curNode.children[i]);
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
