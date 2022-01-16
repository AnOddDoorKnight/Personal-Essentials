using System;
namespace OddsLibrary.Vector;

public struct Vector3
{
	public Vector3(float X, float Y, float Z)
	{
		base.X = X;
		base.Y = Y;
		this.Z = Z;
	}
	public float Z { get; set; }
	public override string ToString() => $"{X}, {Y}, {Z}";
	public override float[] ToArray() => new float[] { X, Y, Z };
	#warning Not Implemented!
	public float[] DistanceBetweenInArray(Vector2 vect3)
		=> throw new NotImplementedException();
	public float DistanceBetween(Vector3 vect3)
		=> throw new NotImplementedException(); 
}
public struct Vector2
{
	public Vector2(float X, float Y)
	{
		this.Y = Y;
	}
	public float Y { get; set; }
	public override string ToString() => $"{X}, {Y}";
	public float[] ToArray() => new float[] { X, Y };
	public float[] DistanceBetweenInArray(Vector2 vect2) 
		=> new float[] { Math.Abs(X - vect2.X), Math.Abs(Y - vect2.Y) };
	// This could be better worked on
	public float DistanceBetween(Vector2 vect2)
	{
		float[] foo = DistanceBetweenInArray(vect2);
		return Math.Sqrt((foo[0] * foo[0]) + (foo[1] * foo[1]));
	}
	/*
	public float DistanceBetween(Vector2 vect2)
	{
		float a1 = (float)Math.Pow(Math.Abs(X) + Math.Abs(vect2.X), 2);
		float a2 = (float)Math.Pow(Math.Abs(Y) + Math.Abs(vect2.Y), 2);
		return (float)Math.Sqrt(a1 + a2);
	}
	*/
}
public struct Vector1
{
	public Vector1(float X) => this.X = X;
	public float X { get; set; }
	public override string ToString() => X.ToString();
	public float DistanceBetween(Vector1 vect1) 
		=> Math.Abs(X - vect1.X);
}
// This needs code review...
public static class Vector
{
	static public double Vector3Distance(Vector3 point1, Vector3 point2)
	{
		return Math.Sqrt(DistanceLength(point1.X, point2.X) + DistanceLength(point1.Y, point2.Y) + DistanceLength(point1.Z, point2.Z));
	}
	static double DistanceLength(float point1, float point2)
	{
		return Math.Pow(Math.Abs(point1) + Math.Abs(point2), 2);
	}
}
