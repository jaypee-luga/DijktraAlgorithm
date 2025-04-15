using System;

namespace DijktraAlgorithm;

public static class Dijkstra
{
    public static (int distance, List<string> path) ShortestPath(Graph graph, string start, string end)
    {
        var distances = new Dictionary<string, int>();
        var previous = new Dictionary<string, string>();
        var pq = new SortedSet<(int, string)>();
        var visited = new HashSet<string>();

        foreach (var v in graph.Vertices)
        {
            distances[v] = int.MaxValue;
            previous[v] = null;
        }

        distances[start] = 0;
        pq.Add((0, start));

        while (pq.Any())
        {
            var (dist, current) = pq.Min;
            pq.Remove(pq.Min);

            if (visited.Contains(current)) continue;
            visited.Add(current);

            foreach (var (neighbor, weight) in graph.Neighbors(current))
            {
                int newDist = dist + weight;
                if (newDist < distances[neighbor])
                {
                    //pq.Remove((distances[neighbor], neighbor));
                    distances[neighbor] = newDist;
                    previous[neighbor] = current;
                    pq.Add((newDist, neighbor));
                }
            }
        }

        var path = new List<string>();
        var temp = end;
        while (temp != null)
        {
            path.Insert(0, temp);
            temp = previous[temp];
        }

        return (distances[end], path);
    }
}
