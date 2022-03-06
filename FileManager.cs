using System.IO;
using System;
namespace OddsLibrary.IO;
/// <summary>
/// Holds the path of the <see cref="File"/>/<see cref="Directory"/> 
/// for creation and easy manipulation
/// </summary>
public class FileManager
{
	public readonly bool isFile;
	public readonly string filePath;
	public readonly string[] directories;
	/// <summary>Assigns the <see cref="File"/>/<see cref="Directory"/> 
	/// for modification</summary>
	/// <param name="filePath">The file path.</param>
	public FileManager(string filePath)
	{
		this.filePath = filePath;
		directories = RemoveLingeringSlashes(filePath).Split(@"\");
		isFile = File.Exists(filePath);
	}
	/// <summary>
	/// Returns a <see cref="File.ReadAllLines(string)"/>, but creates an empty 
	/// file if it doesn't exist</summary>
	/// <returns><see cref="string"/>[] of the file's contents</returns>
	public string[] ReadFile()
	{
		if (File.Exists(filePath)) return File.ReadAllLines(filePath);
		BuildFile();
		File.Create(filePath);
		return Array.Empty<string>();
	}
	/// <summary>
	/// Builds a path for the <see cref="File"/>/<see cref="Directory"/>
	/// </summary>
	public void BuildPath()
	{
		string forEachLine = "";
		for (int i = 0; i < directories.Length; i++)
		{
			if (!Directory.Exists(forEachLine + directories[i]))
				Directory.CreateDirectory(forEachLine + directories[i]);
			forEachLine += directories[i] + @"\";
		}
	}
	/// <summary>
	/// Builds only files, and builds the directory for it if it doesn't exist.
	/// </summary>
	/// <exception cref="ArgumentException">This is for files only!</exception>
	public void BuildFile()
	{
		if (!isFile) throw new ArgumentException("This is for files only!");
		if (File.Exists(filePath)) return;
		string directoryForFile = "";
		for (int i = 0; i < directories.Length - 1; i++)
			directoryForFile += $@"{directories[i]}\";
		if (!Directory.Exists(directoryForFile)) BuildPath();
		File.Create($@"{directoryForFile}\{directories[^1]}");
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