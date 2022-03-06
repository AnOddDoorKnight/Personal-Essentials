namespace OddsLibrary;
using System.Collections.Generic;
using System.Linq;
public class TreePiece<T> where T : notnull
{
	public List<TreePiece<T>> leadsTo;
	public T SpecifiedItem;
	public TreePiece(T SpecifiedItem, params TreePiece<T>[]? treePieces)
	{
		leadsTo = treePieces == null ? new List<TreePiece<T>>() : treePieces.ToList();
		this.SpecifiedItem = SpecifiedItem;
	}
	public void Add(TreePiece<T> item) => leadsTo.Add(item);
	public virtual string ToString(int index)
	{
		string output = SpecifiedItem.ToString() ?? string.Empty;
		foreach (TreePiece<T> i in leadsTo)
		{
			output += $"\n{new string(' ', index * 3)}{i.ToString(index + 1)}";
		}
		return output;
	}
	public override string ToString()
	{
		string output = $"{SpecifiedItem}\n";
		foreach (TreePiece<T> i in leadsTo)
		{
			output += $"   {i.ToString(2)}\n";
		}
		return output;
	}
}