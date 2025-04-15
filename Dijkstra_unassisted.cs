using System;

namespace DijktraAlgorithm;

public static class Dijkstra_unassisted
{
    public static (int distance, List<string> path) FindShortestPath(Graph source, string origin, string target)
    {
        var distances = new Dictionary<string, int>();
        var previous = new Dictionary<string, string>();
        var priorityQueue = new PriorityQueue<string, int>();
        var visited = new HashSet<string>();

        foreach (var v in source.Vertices)
            distances[v] = int.MaxValue;

        distances[origin] = 0;
        priorityQueue.Enqueue(origin, 0);

        while (priorityQueue.Count > 0)
        {
            if (priorityQueue.TryDequeue(out string? activeNode, out int distance))
            {
                if (!visited.Add(activeNode)) continue;

                foreach (var (node, weight) in source.Neighbors(activeNode))
                {
                    var newDistance = weight + distance;
                    if (newDistance < distances[node])
                    {
                        distances[node] = newDistance;
                        previous[node] = activeNode;
                        priorityQueue.Enqueue(node, newDistance);
                    }
                }
            }
        }



        return (distances[target], new List<string>());
    }

}
