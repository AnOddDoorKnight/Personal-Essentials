using System;
namespace OddsLibrary.Graphing;
public sealed class BarGraph : Graph
{
	public BarGraph(double[]? values = null, uint height = 10) : base(values, height) { }
	public override string ToString()
	{
		if (Data.Count < 2) return base.ToString();
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
		line = lineReadonly.Replace("{0}", Math.Round(AmountPerLengthPoint[0]).ToString()); //
			while (line.Length < outLength)
				line += " ";
		output += line;
		for (uint i = (uint)Data.Count; i > 0; i--)
			output += " T";
		return output;
	}
	public override string BaseString() => base.ToString();
}