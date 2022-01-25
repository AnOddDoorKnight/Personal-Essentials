using OddsLibrary.Vector;
using System;
using System.Collections.Generic;
namespace OddsLibrary.Algebra;

// Rename namespace and class to Algebra
public static class Algebra
{
	public static double LimitValue(double input, double min, double max)
	{
		if (input < min) return min;
		else if (input > max) return max;
		else return input;
	}
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
	public static T GetRandomInArray<T>(T[] TValues) => TValues[new Random().Next(TValues.Length)];
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
public enum Nomial
{
	Constant, //ie 6 , Mono
	Linear, //ie 2x + 6, Bi
	Quadratic, //ie 2x^2 + 3x + 6, Tri
	Cubic,
	Quartic,
}