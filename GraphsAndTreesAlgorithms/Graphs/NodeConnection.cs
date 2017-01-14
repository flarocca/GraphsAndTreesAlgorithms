using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAndTreesAlgorithms.Graphs
{
    public class NodeConnection
    {
        public Node Target { get; }
        public double Distance { get; }

        public NodeConnection(Node target, double distance)
        {
            if (target == null)
                throw new ArgumentException("Target cannot be null");

            if (distance < 0)
                throw new ArgumentException("Distance cannot be negative");

            Target = target;
            Distance = distance;
        }     
    }
}
