using System;
using System.IO;
using OddsLibrary.Algebra;
namespace OddsLibrary;
public static class Names
{
    public static readonly string 
    public static string Get() => Algebra.GetRandom(sampleNames);
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
    public static string Get(string path)
    {
        try { return Algebra.GetRandom(File.ReadAllLines(path)); }
        catch (FileNotFoundException) { return "Invalid Path"; }
        throw new NotImplementedException("What the fuck, this should be unreachable");
    }
    public static string GetFantasyDefault()
    {
        
    }
}