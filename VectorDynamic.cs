using System;
using System.Collections.Generic;
namespace OddsLibrary.Vector;

/// <summary>Class which holds an array of values for game design and geometry</summary>
public class VectorDynamic
{
	public float[] values;
	/// <value>dimensions of vector</value>
	public int Length => values.Length;
	public float this[int index] => values[index];
	/// <summary>uses a <see cref="float"/>[] to determine length and values</summary>
	public VectorDynamic(params float[] values)
	{
		this.values = values;
	}
	public override string ToString()
	{
		string returnString = "";
		foreach (float i in values) returnString += $"{i}, ";
		return returnString.TrimEnd().Remove(returnString.LastIndexOf(','));
	}
	/// <summary>Like <see cref="DistanceBetween(VectorDynamic)"/>, 
	/// but returns <see cref="float"/>[] with the distance</summary>
	/// <exception cref="InvalidOperationException">
	/// Length does not match the compared vector</exception>
	/// <returns><see cref="float"/>[] with the distance</returns>
	public float[] DistanceBetweenInArray(VectorDynamic vect)
	{
		List<float> foo = new();
		if (Length != vect.Length) 
			throw new InvalidOperationException
				("Length does not match the compared vector");
		for (int i = 0; i < Length; i++)
			foo.Add((float)Math.Abs(this[i] - vect[i]));
		return foo.ToArray();
	}
	/// <summary>Calcuates the length between the two points</summary>
	/// <exception cref="InvalidOperationException">Length does not match the compared vector</exception>
	/// <returns><see cref="float"/> length of vectors</returns>
	public float DistanceBetween(VectorDynamic vect)
	{
		float bar = 0f;
		float[] foo = DistanceBetweenInArray(vect);
		foreach (float i in foo)
			bar += i * i;
		return (float)Math.Sqrt(bar);
	}
}
