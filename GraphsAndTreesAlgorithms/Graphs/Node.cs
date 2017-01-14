using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAndTreesAlgorithms.Graphs
{
    public class Node
    {
        public List<NodeConnection> Connections { get; }
        public string Name { get; }
        public double DistanceFromStart { get; set; }

        public Node(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or withe spaces");

            Name = name;
            Connections = new List<NodeConnection>();
        }

        public void AddConnection(Node target, double distance, bool twoWay)
        {
            if (target == null)
                throw new ArgumentException("Target node cannot be null.");

            if (distance < 0)
                throw new ArgumentException("Distance cannot be negative.");

            if(Connections.Exists(c => c.Target.Name == target.Name))
                throw new ArgumentException("This connection has been already added.");

            Connections.Add(new NodeConnection(target, distance));
            if (twoWay)
                target.AddConnection(this, distance, false);
        }
    }
}
