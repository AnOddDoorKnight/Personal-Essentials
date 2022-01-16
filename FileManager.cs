using System.IO;
using System;
namespace OddsLibrary.IO;
public static class FileManager
{
	public static void DirectoryBuilder(string fileSpecification) //c:\Documents\My Games\ASimpleGame\Saves\
	{
		string[] directories = RemoveLingeringSlashes(fileSpecification).Split(@"\");
		string forEachLine = "";
		for (int i = 0; i < directories.Length; i++)
		{
			if (!Directory.Exists(forEachLine + directories[i]))
			{
				Directory.CreateDirectory(forEachLine + directories[i]);
			}
			forEachLine += directories[i] + @"\";
		}
	}
	public static void BuildForFile(string fileLocation)
	{
		string[] fileFolderNames = RemoveLingeringSlashes(fileLocation).Split(@"\");
		if (File.Exists(fileLocation)) return;
		// Gets the folders before the file itself
		string directory = "";
		for (int i = 0; i < fileFolderNames.Length - 1; i++)
			directory += $@"{fileFolderNames[i]}\"; 
		directory = RemoveLingeringSlashes(directory);
		// Directory exists, but not file
		if (Directory.Exists(directory))
		{ 
			File.Create($@"{directory}\{fileFolderNames[^1]}"); 
			return; 
		}
		// Neither Exists
		DirectoryBuilder(directory);
		File.Create($@"{directory}\{fileFolderNames[^1]}");
	}
	// This needs debugging, might not work
	public static void GetFile(string fileLocation)
    {
		string[] fileFolderNames = RemoveLingeringSlashes(fileLocation).Split(@"\");
		if (File.Exists(fileLocation)) //File Save 
		{
			Console.WriteLine("File Retrieved!");
		}
		else
        {
			//Input going to directory
			string directory = "";
			for (int i = 0; i < fileFolderNames.Length - 1; i++)
				directory += $@"{fileFolderNames[i]}\"; 
			directory = RemoveLingeringSlashes(directory);
			if (Directory.Exists(directory))
            {
				Console.WriteLine("Save File does not exist, building..");
				File.Create($@"{directory}\{fileFolderNames[^1]}"); //Directory Exists
				Console.WriteLine("Built!");
			}
			else //Neither exists
			{
				Console.WriteLine("Directory does not exist, building..");
				DirectoryBuilder(directory);
				File.Create($@"{directory}\{fileFolderNames[^1]}");
				Console.WriteLine("Built!");
			}
		}
        
    }
	internal static string RemoveLingeringSlashes(string input)
	{
		if (input.EndsWith(@"\"))
		{
			int fileLength = input.Length;
			input = input.Remove(fileLength);
		}
		return input;
	}
}