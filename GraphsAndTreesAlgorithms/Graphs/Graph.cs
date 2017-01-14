using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAndTreesAlgorithms.Graphs
{
    public class Graph
    {
        public List<Node> Nodes { get; }

        public Graph()
        {
            Nodes = new List<Node>();
        }

        public void AddNode(string name)
        {
            if (Nodes.Exists(n => n.Name == name))
                throw new ArgumentException("This node has been already added");

            Nodes.Add(new Node(name));
        }

        public void AddNode(Node node)
        {
            if (Nodes.Exists(n => n.Name == node.Name))
                throw new ArgumentException("This node has been already added");

            Nodes.Add(node);
        }

        public void AddConnection(string from, string to, double distance, bool twoWay)
        {
            if (!Nodes.Exists(n => n.Name == from))
                throw new ArgumentException("From node does not exist");

            if (!Nodes.Exists(n => n.Name == to))
                throw new ArgumentException("To node does not exist");

            Nodes.First(n => n.Name == from).AddConnection(Nodes.First(n => n.Name == to), distance, twoWay);
        }
    }
}
