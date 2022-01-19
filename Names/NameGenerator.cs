using System;
using System.IO;
namespace OddsLibrary.Name;
public static class GenerateName
{
#warning Be sure to include fantasy!
	private static delName DelegateName = Primary;
	public static string Generate()
	{
		return DelegateName();
		return Safe();
	}
	private static string Primary() => sampleNames[new Random().Next(sampleNames.Length - 1)];
	private static string Safe() => "Unnamed";
	private delegate string delName();
	private static readonly string[] sampleNames =
	{
		"Tom",
		"Bob",
		"Bobby",
		"Johnny",
		"Macoe",
		"Wolfie",
		"Samthony",
		"Anthosam",
		"Jagger",
		"Jabadamazo",
		"Venesuela",
		"Johnson",
		"Bonny",
		"Maxie",
	};
}