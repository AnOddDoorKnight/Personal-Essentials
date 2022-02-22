using OddsLibrary.Vector;
using System;
using System.Collections.Generic;
namespace OddsLibrary.Algebra;

// Rename namespace and class to Algebra
public static class Algebra
{
	/// <summary> Limits the value between the max and min</summary>
	/// <param name="input">The input.</param>
	/// <param name="min">The minimum.</param>
	/// <param name="max">The maximum.</param>
	public static double LimitValue(double input, double min, double max) => input < min ? min : input > max ? max : input;
	public static bool HealthManager(ref double value, in double maxHealth, in double deathPoint = 0)
	{
		if (value <= deathPoint)
		{
			value = deathPoint;
			return false;
		}
		else if (value > maxHealth) value = maxHealth;
		return true;
	}
	/// <summary> Gets a random item in an array</summary>
	public static T GetRandom<T>(T[] TValues) => TValues[new System.Random().Next(TValues.Length)];
	/// <summary>Gets a random item in the list</summary>>
	public static T GetRandom<T>(List<T> TValues) => GetRandom(TValues.ToArray());
	/// <summary>Gets a random item in the dictionary</summary>
	public static TValues GetRandom<TKeys, TValues>(Dictionary<TKeys, TValues> TDictValues) where TKeys : notnull
	{ 
		List<TValues> T2List = new();
		foreach (TValues value in TDictValues.Values)
			T2List.Add(value);
		return GetRandom(T2List.ToArray()); 
	}
}
public struct Polynomial
{
	public double this[int index] => data[index];
	private double[] data;
	public readonly PolynomialType type;
	public Polynomial(params double[] data)
	{
		this.data = data;
		type = data.Length < 1 ? throw new ArgumentNullException(data.ToString()) : 
			data.Length >= (int)PolynomialType.Over ? PolynomialType.Over : 
			(PolynomialType)data.Length;
	}
	public override string ToString()
	{
		string output = string.Empty;
		for (int i = data.Length; i > 0; i--)
			output += $"{data[i]}^{(i != 1 ? i.ToString() : "")} {(data[i] < 0 ? "-" : "+")} ";
		return output;
	}
}
public enum PolynomialType : byte
{
	Monomial,
	Binomial,
	Trinomial,
	Quadnomial,
	Over,
}
public struct Trinomial
{
	public double xCubic, xSquared, x;
	public Trinomial(float xCubic, float xSquared, float x)
	{
		this.xCubic = xCubic;
		this.xSquared = xSquared;
		this.x = x;
	}
	public double[] ToArray => new double[] {xCubic, xSquared, x};
	public Vertex ToVertex() => 
		new (xCubic, xSquared / (2 * xCubic), x - Math.Pow(xSquared, 2) / (4 * xCubic));
	//public Vertex Solve() => new(1, xSquared / 2, x - Math.Pow(xSquared / 2, 2));
	public override string ToString() => 
		$"{(xCubic == 1 ? "" : xCubic)}x^2 {(xSquared >= 0 ? "+" : "-")}" + 
		$" {(xSquared == 1 ? "" : xSquared)}x {(x >= 0 ? "+" : "-")} {x}";
}
public struct Vertex
{
	public double multiplier, sqrtValue, remainder;
	public Vertex(double multiplier, double sqrtValue, double remiander)
	{
		this.multiplier = multiplier;
		this.sqrtValue = sqrtValue;
		this.remainder = remiander;
	}
	public VectorDynamic OriginPoint => new(new float[] { (float)-sqrtValue, (float)remainder });
	#warning Not Implemented!
	public Trinomial ToTrinomial() => throw new NotImplementedException();
	public override string ToString() => 
		$"{(multiplier == 1 ? "" : multiplier)}(x {(sqrtValue >= 0 ? "+" : "-")} " + 
		$"{Math.Abs(sqrtValue)})^2 {(remainder >= 0 ? "+" : "-")} {Math.Abs(remainder)}";
}