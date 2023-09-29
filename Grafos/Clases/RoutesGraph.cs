using System.Collections.Generic;

namespace Grafos.Clases
{
    public class RoutesGraph
    {
        private Dictionary<string, Dictionary<string, int>> graph = new Dictionary<string, Dictionary<string, int>>();

        public void AddRoutes(string origin, string destiny, int distance)
        {
            if (!graph.ContainsKey(origin))
            {
                graph[origin] = new Dictionary<string, int>();
            }
            graph[origin][destiny] = distance;

            if (!graph.ContainsKey(destiny))
            {
                graph[destiny] = new Dictionary<string, int>();
            }
            graph[destiny][origin] = distance;
        }

        public int CalculateShortestRoute(string origin, string destini)
        {
            Dictionary<string, int> distance = new Dictionary<string, int>();
            foreach (var node in graph.Keys)
            {
                distance[node] = int.MaxValue;
            }
            distance[origin] = 0;
            HashSet<string> VisitedNodes = new HashSet<string>();
            while (VisitedNodes.Count < graph.Count)
            {
                string CurrentNode = GetNodeWithShorterDistance(distance, VisitedNodes);
                VisitedNodes.Add(CurrentNode);
                foreach (var neighbor in graph[CurrentNode])
                {
                    if (!VisitedNodes.Contains(neighbor.Key))
                    {
                        int distanciaHastaVecino = distance[CurrentNode] + neighbor.Value;
                        if (distanciaHastaVecino < distance[neighbor.Key])
                        {
                            distance[neighbor.Key] = distanciaHastaVecino;
                        }
                    }
                }
            }
            return distance[destini];
        }

        private string GetNodeWithShorterDistance(Dictionary<string, int> distances, HashSet<string> VisitedNodes)
        {
            int MinDistance = int.MaxValue;
            string NodeWithMinDistance = null;
            foreach (var node in graph.Keys)
            {
                if (!VisitedNodes.Contains(node) && distances[node] < MinDistance)
                {
                    MinDistance = distances[node];
                    NodeWithMinDistance = node;
                }
            }
            return NodeWithMinDistance;
        }
    }
}