using System;
using System.Collections.Generic;
using System.Linq;
namespace OddsLibrary.Graphing;
public abstract class Graph
{
	public List<GraphLine> Data = new();
	private uint _heightL;
	public uint HeightLength { get => _heightL; set { _heightL = value; Update(); } }
	// Constructors
	public Graph(double[]? values = null, uint height = 10) 
	{ 
		_heightL = height; 
		if (values != null) foreach (int i in values) Data.Add(new GraphLine(i, null));
		Update();
	}
	// Methods
	public void Add(int value)
	{
		Data.Add(new GraphLine(value, null));
		Update();
	}
	public virtual GraphLine this[int index] => Data[index];
	public void Update()
	{
		if (Data.Count == 0) return;
		Sort();
		UpdateLengths();
	}
	protected void UpdateLengths()
	{
		if (Data.Count < 2) return;
		double largest = Data[^1].Value,
			smallest = Data[0].Value,
			height = largest - smallest;
		Data[0] = new GraphLine(smallest, 0);
		Data[^1] = new GraphLine(largest, HeightLength);
		List<double> accountedValues = new();
		foreach (GraphLine i in Data) accountedValues.Add(i.Value - smallest);
		double percentagePerPoint = 1d / height;
		// It starts at smallest instead of zero, hence height
		for (int i = 1; i < Data.Count - 1; i++)
			#warning TODO: ALlow Round or Truncate determined by the user
			Data[i] = new GraphLine(Data[i].Value, (uint)Math.Round((accountedValues[i] / (double)height) * HeightLength));
		// Allowing GetPerLengthPoint to Work
		AmountPerLengthPoint = new double[HeightLength + 2];
		AmountPerLengthPoint[0] = smallest;
		for (int i = 1; i < AmountPerLengthPoint.Length; i++)
			AmountPerLengthPoint[i] = (height / HeightLength) * i + smallest;
	}
	public double[] AmountPerLengthPoint { get; private set; } = Array.Empty<double>();
	protected void Sort()
	{
		double[] values = new double[Data.Count];
		for (int i = 0; i < values.Length; i++) values[i] = Data[i].Value;
		Array.Sort(values);
		for (int i = 0; i < values.Length; i++) Data[i] = new GraphLine(values[i], null);
	}
	public override string ToString()
	{
		string output = "Using Default String...\n";
		foreach (GraphLine i in Data) output += $"{i}\n";
		return output;
	}
	public virtual string BaseString() => base.ToString()!;
	public static dynamic Convert<T>(Graph graph) where T : Graph
	{
		Type type = typeof(T), barGraph = graph.GetType();
		string ofTypeString = barGraph.ToString();
		List<double> vars = new();
		foreach (GraphLine i in graph.Data) vars.Add(i.Value);
		switch (ofTypeString)
		{
			case "BarGraph": return new BarGraph(vars.ToArray(), graph.HeightLength);
			case "PointGraph": return new PointGraph(vars.ToArray(), graph.HeightLength);
			default: throw new NotImplementedException();
		}
	}
}