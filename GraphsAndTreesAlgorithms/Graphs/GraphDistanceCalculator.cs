using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAndTreesAlgorithms.Graphs
{
    public class GraphDistanceCalculator
    {
        public IDictionary<string, double> CalculateDistances(Graph graph, string startingNode)
        {
            if (!graph.Nodes.Any(n => n.Name == startingNode))
                throw new ArgumentException("Starting node must be in graph.");

            InitializeGraph(graph, startingNode);
            ProcessGraph(graph, startingNode);
            return ExtractDistances(graph);
        }

        private void InitializeGraph(Graph graph, string startingNode)
        {
            foreach (var node in graph.Nodes)
                node.DistanceFromStart = double.PositiveInfinity;

            graph.Nodes.Find(n => n.Name == startingNode).DistanceFromStart = 0;
        }

        private void ProcessGraph(Graph graph, string startingNode)
        {
            var finished = false;
            var queue = graph.Nodes.ToList();

            while (!finished)
            {
                var nextNode = queue.OrderBy(n => n.DistanceFromStart).FirstOrDefault(n => n.DistanceFromStart != double.PositiveInfinity);
                if (nextNode != null)
                {
                    ProcessNode(nextNode, queue);
                    queue.Remove(nextNode);
                }
                else
                {
                    finished = true;
                }
            }
        }

        private void ProcessNode(Node node, List<Node> queue)
        {
            var connections = node.Connections.Where(c => queue.Contains(c.Target));
            foreach (var conn in connections)
            {
                var distance = node.DistanceFromStart + conn.Distance;
                if (distance < conn.Target.DistanceFromStart)
                    conn.Target.DistanceFromStart = distance;
            }
        }

        private IDictionary<string, double> ExtractDistances(Graph graph)
        {
            return graph.Nodes.ToDictionary(n => n.Name, n => n.DistanceFromStart);
        }
    }
}
