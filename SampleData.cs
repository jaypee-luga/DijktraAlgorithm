using System;

namespace DijktraAlgorithm;

public static class SampleData
{
    public static Graph LoadSampleMap()
    {
        var g = new Graph();
        //sample case study data
        g.AddEdge("A", "B", 4);
        g.AddEdge("A", "C", 6);
        g.AddEdge("B", "F", 2);
        g.AddEdge("C", "D", 8);
        g.AddEdge("D", "E", 4);
        g.AddEdge("D", "G", 1);
        g.AddEdge("E", "B", 2, false);
        g.AddEdge("E", "F", 3);
        g.AddEdge("E", "I", 8);
        g.AddEdge("F", "G", 4);
        g.AddEdge("F", "H", 6);
        g.AddEdge("G", "H", 5);
        g.AddEdge("G", "I", 5);
        return g;
    }
}