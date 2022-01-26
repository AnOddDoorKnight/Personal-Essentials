using System;
using System.Collections.Generic;
namespace OddsLibrary.Vector;

public class VectorDynamic
{
	public float[] values;
	public int Length => values.Length;
	public float this[int index] => values[index];
	public VectorDynamic(float[] values)
	{
		this.values = values;
	}
	public override string ToString()
	{
		string returnString = "";
		foreach (float i in values) returnString += $"{i}, ";
		return returnString.TrimEnd().Remove(returnString.LastIndexOf(','));
	}
	public float[] DistanceBetweenInArray(VectorDynamic vect)
	{
		List<float> foo = new();
		if (Length != vect.Length) throw new InvalidOperationException("Length does not match the compared vector");
		for (int i = 0; i < Length; i++)
			foo.Add((float)Math.Abs(this[i] - vect[i]));
		return foo.ToArray();
	}
	public float DistanceBetween(VectorDynamic vect)
	{
		float bar = 0f;
		float[] foo = DistanceBetweenInArray(vect);
		foreach (float i in foo)
			bar += i * i;
		return (float)Math.Sqrt(bar);
	}
}
