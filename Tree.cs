namespace OddsLibrary;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// <para>A point of a whole tree, helpful for interviews.
/// Can hold infinite amount of branches.</para>
/// <para>You should probably not add
/// <see cref="TreePiece{T}"/> to T</para>
/// </summary>
/// <typeparam name="T">Specified Value, not nullable</typeparam>
public class TreePiece<T> where T : notnull
{
	public List<TreePiece<T>> leadsTo;
	public T SpecifiedItem;
	/// <summary>
	/// Initializes a new instance of the <see cref="TreePiece{T}"/> class.
	/// </summary>
	/// <param name="SpecifiedItem">Input of <see cref="T"/></param>
	/// <param name="treePieces">Additional <see cref="TreePiece{T}"/>s</param>
	public TreePiece(T SpecifiedItem, params TreePiece<T>[]? treePieces)
	{
		leadsTo = treePieces == null ? new List<TreePiece<T>>() : treePieces.ToList();
		this.SpecifiedItem = SpecifiedItem;
	}
	/// <summary>A Fowarded Method of <see cref="leadsTo.Add()"/></summary>
	public void Add(TreePiece<T> item) => leadsTo.Add(item);
	protected virtual string ToString(int index)
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