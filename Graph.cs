using System;

namespace DijktraAlgorithm;

public class Graph
{
    private readonly Dictionary<string, List<(string destination, int weight)>> _adjacencyList;

    public Graph()
    {
        _adjacencyList = new Dictionary<string, List<(string, int)>>();
    }

    public void AddVertex(string vertex)
    {
        if (!_adjacencyList.ContainsKey(vertex))
        {
            _adjacencyList[vertex] = new List<(string, int)>();
        }
    }

    public void AddEdge(string from, string to, int weight, bool IsBidirectional = true)
    {
        AddVertex(from);
        _adjacencyList[from].Add((to, weight));

        if (IsBidirectional)
        {
            AddVertex(to);
            _adjacencyList[to].Add((from, weight));
        }

        // Add both directions to make it undirected

    }

    public IEnumerable<string> Vertices => _adjacencyList.Keys;

    public List<(string destination, int weight)> Neighbors(string vertex)
    {
        return _adjacencyList.ContainsKey(vertex)
            ? _adjacencyList[vertex]
            : new List<(string, int)>();
    }

    public void Print()
    {
        foreach (var vertex in _adjacencyList)
        {
            Console.Write($"{vertex.Key} -> ");
            foreach (var edge in vertex.Value)
            {
                Console.Write($"[{edge.destination}, {edge.weight}] ");
            }
            Console.WriteLine();
        }
    }
}
