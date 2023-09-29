using System.Collections.Generic;

namespace Grafos.Clases
{
    public class SoftwareProject
    {
        private Dictionary<string, List<string>> GraphDependencies = new Dictionary<string, List<string>>();

        public void AddDependence(string OriginModule, string moduleDestination)
        {
            if (!GraphDependencies.ContainsKey(OriginModule))
            {
                GraphDependencies[OriginModule] = new List<string>();
            }
            GraphDependencies[OriginModule].Add(moduleDestination);
        }

        public bool DependencyCycles()
        {
            HashSet<string> nodesVisited = new HashSet<string>();
            HashSet<string> nodesInProcess = new HashSet<string>();
            foreach (var module in GraphDependencies.Keys)
            {
                if (DetectCycle(module, nodesVisited, nodesInProcess))
                    return true;
            }
            return false;
        }

        private bool DetectCycle(string module, HashSet<string> nodesVisited, HashSet<string> nodesInProcess)
        {
            nodesVisited.Add(module);
            nodesInProcess.Add(module);
            if (GraphDependencies.ContainsKey(module))
            {
                foreach (var dependence in GraphDependencies[module])
                {
                    if (!nodesVisited.Contains(dependence))
                    {
                        if (DetectCycle(dependence, nodesVisited, nodesInProcess))
                            return true;
                    }
                    else if (nodesInProcess.Contains(dependence))
                    {
                        return true;
                    }
                }
            }
            nodesInProcess.Remove(module);
            return false;
        }
    }
}