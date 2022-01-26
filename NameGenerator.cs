using System;
using System.IO;
namespace OddsLibrary;
public static class Names
{
	// "Undefined Von Nullerson"
	public static string Get() => Algebra.Algebra.GetRandom(sampleNames);
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
		try { return Algebra.Algebra.GetRandom(File.ReadAllLines(path)); }
		catch (FileNotFoundException) { return "Invalid Path"; }
		throw new NotImplementedException("What the fuck, this should be unreachable");
	}
	public static string GetFantasyDefault(double chance = 0.7d)
	{
		chance = Algebra.Algebra.LimitValue(chance, 0, 1);
		string[] vs;
		if (new Random().NextDouble() > chance) // Exotic
			vs = new string[]
			{
				"Name",
				"404: Name Not Found",
				"Bootyslayer",
				"BitchChooseAName",
				"Bonny",
				"Thermonuclear Attack Poop",
				"Femboy Rathalos",
				"Anal Surge",
				"Maxie",
				"Pussy Pounder",
				"Dickward",
				"Gay"
			};
		else //Normal
			vs = new string[]
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
				"Johnson"
			};
		return Algebra.Algebra.GetRandom(vs);
	}
}