namespace OddsLibrary.Graphing;
public struct GraphLine
{
	public double Value;
	public uint? Length;
	public string? name;
	public GraphLine(double value, uint? length, string? name = null)
	{
		Value = value;
		Length = length;
		this.name = name;
	}
	public override string ToString() => $"Value: {Value}, Length: {(Length == null ? "Null" : Length)}";
}