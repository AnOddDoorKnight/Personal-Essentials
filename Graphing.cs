using System;
using System.Collections.Generic;
using System.Linq;
namespace OddsLibrary.Graphing;
public class Graph
{
	// Fields
	public List<GraphLine> Data = new();
	private uint _heightL;
	// Properties
	public uint HeightLength { get => _heightL; set { _heightL = value; Update(); } }
	public double[] AmountPerLengthPoint { get; private set; } = Array.Empty<double>();
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
	protected void Sort()
	{
		double[] values = new double[Data.Count];
		for (int i = 0; i < values.Length; i++) values[i] = Data[i].Value;
		Array.Sort(values);
		for (int i = 0; i < values.Length; i++) Data[i] = new GraphLine(values[i], null);
	}
	// Returning Data Values
	public override string ToString()
	{
		string output = "";
		foreach (GraphLine i in Data) output += $"{i}\n";
		return output;
	}
	public virtual string BaseString() => base.ToString()!;
	public string AsBarGraph()
	{
		if (Data.Count < 2) return BaseString();
		string output = "", lineReadonly = "{0}) ", line;
		byte outLength = (byte)(Math.Truncate(AmountPerLengthPoint[^1]).ToString().Length + lineReadonly.Replace("{0}", "").Length);
		for (uint i = HeightLength; i > 0; i--)
		{
			//Use Amount Per Length Point
			line = lineReadonly.Replace("{0}", Math.Truncate(AmountPerLengthPoint[i]).ToString());
			while (line.Length < outLength)
				line += " ";
			for (int ii = 0; ii < Data.Count; ii++)
				line += $".{(Data[ii].Length >= i ? "#" : ".")}";
			output += $"{line}\n";
		}
		line = lineReadonly.Replace("{0}", Math.Round(AmountPerLengthPoint[0]).ToString()); 
		while (line.Length < outLength)
			line += " ";
		output += line;
		for (uint i = (uint)Data.Count; i > 0; i--)
			output += " T";
		return output;
	}
}
public struct GraphLine
{
	public double Value;
	public uint? Length;
	public string? name;
	public GraphLine(double value, uint? length, string? name = null)
	{
		Value = value;
		Length = length;
		this.name = name;
	}
	public override string ToString() => $"Value: {Value}, Length: {(Length == null ? "Null" : Length)}";
}