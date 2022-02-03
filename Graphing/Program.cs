using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.InteropServices;

namespace OddsLibrary.Graphing;
static class Master
{
	static BarGraph graph = new() {HeightLength = 12};
	static Master()
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			Console.WindowWidth += 50;
			Console.WindowHeight += 10;
		}
	}
	static void Main()
	{
		Dictionary<string, int> counted = new() { ["posters"] = 5, ["boards"] = 5, ["papers"] = 17, ["curtains"] = 4, ["tables"] = 8, ["childrenChairs"] = 16 };
		foreach (int i in counted.Values) graph.Add(i);
		Console.WriteLine(graph);
	}
	static string SetRandom()
	{
		Random Random = new();
		graph.HeightLength = 15;
		int ii = Random.Next(2, 15);
		graph.Data = new();
		for (int i = 0; i != ii; i++) graph.Add(Random.Next(2, 32));
		return graph.ToString();
	}
}