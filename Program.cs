using DijktraAlgorithm;

var graph = SampleData.LoadSampleMap();

Console.WriteLine("GPS Shortest Path Calculator");
while (true)
{
    Console.WriteLine("\nCommands: show, path [from] [to], exit");
    Console.Write("> ");
    var input = Console.ReadLine()?.Split(' ');

    if (input == null || input.Length == 0) continue;

    if (input[0] == "exit") break;
    if (input[0] == "show")
    {
        graph.Print();
    }
    else if (input[0] == "path" && input.Length == 3)
    {
        // var (distance, path) = Dijkstra.ShortestPath(graph, input[1], input[2]);
        var (distance, path) = Dijkstra_unassisted.FindShortestPath(graph, input[1], input[2]);
        Console.WriteLine($"Shortest path: {string.Join(" -> ", path)} (Total Distance: {distance})");
    }
    else
    {
        Console.WriteLine("Invalid command.");
    }
}
