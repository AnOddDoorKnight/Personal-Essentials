using System.IO;
using System;
namespace OddsLibrary.IO;
public class FileManager
{
	public readonly bool isFile;
	public readonly string filePath;
	public readonly string[] directories;
	public FileManager(string filePath, bool isFile = false)
	{
		this.isFile = isFile;
		this.filePath = filePath;
		directories = RemoveLingeringSlashes(filePath).Split(@"\");
	}
	public bool ReadFile(bool buildFileIfDoesntExist)
	{
		if (!isFile) throw new ArgumentException("This is for files only!");
		if (File.Exists(fileLocation)) return true;
		else if (!buildFileIfDoesntExist) return false;
		BuildFile();
		File.Create($@"{directory}\{fileFolderNames[^1]}");
		return true;
	}
	public Task BuildPath()
	{
		string forEachLine = "";
		for (int i = 0; i < directories.Length; i++)
		{
			if (!Directory.Exists(forEachLine + directories[i]))
				Directory.CreateDirectory(forEachLine + directories[i]);
			forEachLine += directories[i] + @"\";
		}
		return Task.CompletedTask;
	}
	public Task BuildFile()
	{
		if (!isFile) throw new ArgumentException("This is for files only!");
		if (File.Exists(filePath)) return Task.CompletedTask;
		string directoryForFile = "";
		for (int i = 0; i < fileFolderNames.Length - 1; i++)
			directory += $@"{fileFolderNames[i]}\";
		if (!Directory.Exists(directoryForFile)) BuildPath();
		File.Create($@"{directory}\{fileFolderNames[^1]}");
		return Task.CompletedTask;
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