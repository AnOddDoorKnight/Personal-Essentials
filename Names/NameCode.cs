using System;
using System.IO;
namespace OddsLibrary.Name
{
	public static partial class Generate
	{
		public static string Name() => DelegateName();




		private delegate string DelName();
		// This should allow the person to get a name, using delegates save some efficiency instead of using if statements
		private static DelName DelegateName = PrimaryName; 

		private const string filePath = @"C:\Users\gooey\OneDrive\Work\Coding Work\The Odder Server Projects\ClassLibrary1\Names\SampleNames.txt";
		private static string PrimaryName()
		{
			try
			{
				string[] names = File.ReadAllLines(filePath);
				return names[new Random().Next(names.Length - 1)];
			}
			catch (DirectoryNotFoundException) { DelegateName = SafeName; }
			return SafeName();
		}
		private static string SafeName() => "Unnamed";
	}
}
namespace OddsLibrary.Name.Fantasy
{
	/// <summary>
	/// Name(CreatureType) = Get a name for creature listed in enum.
	/// GetNormalChanceForPlayer = Get a chance between 0 and 1 as a percentage to get chance.
	/// </summary>
	public static partial class Generate
	{
		private const string fantasyFilePath = @"C:\Users\gooey\OneDrive\Work\Coding Work\The Odder Server Projects\ClassLibrary1\Names\FantasyNames.txt";
		private delegate string FantasyNameDel(CreatureType creature);
		private static FantasyNameDel DelegateName = FantasyPrimaryName;
		public static string FantasyName(CreatureType creature) => DelegateName(creature);
		private static string FantasyPrimaryName(CreatureType creature)
		{
			try
			{
				string[] nameData = File.ReadAllLines(fantasyFilePath);
				switch (creature)
				{
					case CreatureType.Player: return PlayerName(nameData)?.Replace(@"\t", "") ?? FantasySafeName(creature);
					case CreatureType.Slime: return SlimeName(nameData)?.Replace(@"\t", "") ?? "Slimy";
				}
			}
			catch (DirectoryNotFoundException) { DelegateName = FantasySafeName; }
			return FantasySafeName(creature);
		}
		private static double chanceValue = 0.7d;
		public static double GetNormalChanceForPlayer { get => chanceValue; set => chanceValue = Algebra.Algebra.LimitValue(value, 0, 1); }
		private static string? PlayerName(in string[] nameData)
		{
			const string
				startNormalPlayer = "<NormalPlayer>",
				endNormalPlayer = "</NormalPlayer>",
				startExoticPlayer = "<ExoticPlayer>",
				endExoticPlayer = "</ExoticPlayer>";
			//This will find the regular names and exotic names
			bool isExotic = new Random().NextDouble() > GetNormalChanceForPlayer; // Exotic if true
			int startIndex, endIndex;
			for (int i = 0; i < nameData.Length; i++)
			if (nameData[i] == (isExotic ? startExoticPlayer : startNormalPlayer))
			{
				startIndex = i;
				for (int b = startIndex; b < nameData.Length; b++)
				if (nameData[b] == (isExotic ? endExoticPlayer : endNormalPlayer))
				{
					endIndex = b;
					string[] playerData = new string[endIndex - startIndex];
					return playerData[new Random().Next(playerData.Length - 1)];
				}
			}
			return null;
		}
		private static string? SlimeName(in string[] nameData)
		{
			const string
				startSlime = "<Slime>",
				endSlime = "</Slime";
			int startIndex, endIndex;
			for (int i = 0; i < nameData.Length; i++)
			if (nameData[i] == startSlime)
			{
				startIndex = i;
				for (int b = startIndex; b < nameData.Length; i++)
				if (nameData[b] == endSlime)
				{
					endIndex = b;
					string[] slimeData = new string[endIndex - startIndex];
					return slimeData[new Random().Next(slimeData.Length - 1)];
				}
			}
			return null;
		}
		private static string FantasySafeName(CreatureType creature) => "Undefined Von Nullerson";
	}
	public enum CreatureType
	{
		Player,
		Slime
	}
}