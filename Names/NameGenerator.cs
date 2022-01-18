using System;
using System.IO;
namespace OddsLibrary.Name;
public class GenerateName
{
    #warning Be sure to include fantasy!
    private delName DelegateName = Primary;
    public string Generate() 
    {
        try { return DelegateName(); }
        catch (DirectoryNotFoundException e) 
            { DelegateName = Safe; Console.WriteLine(e + "\nUsing safe name from now on."); }
        return Safe();
    }
    private virtual string Primary()
    {
        string[] names = File.ReadAllLines(filePath);
	    return names[new Random().Next(names.Length - 1)];
    }
    private virtual string Safe() => "Unnamed";

    private delegate string delName();
}