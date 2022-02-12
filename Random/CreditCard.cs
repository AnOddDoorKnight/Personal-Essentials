namespace OddsLibrary.Random;
using System.Collections.Generic;
using System;
public class Card
{
	public bool isCredit;
	public uint[] Numbers { get 
		{ 
			string[] vars = credit.Split('-'); 
			List<uint> returnVars = new();
			foreach (string i in vars) 
				returnVars.Add(uint.Parse(i)); 
			return returnVars.ToArray(); 
		} }
	public string credit;
	public DateTime expirationDate;
	public ushort securityNumber;
	public Card()
	{
		credit = "";
		Random Random = new();
		for (int ii = 0; ii < 4; ii++)
		{
			credit += "-";
			for (int i = 0; i < 4; i++) credit += Random.Next(0, 10);
		}
		expirationDate = DateTime.Today;
		expirationDate.AddYears(Random.Next(-5, 7));
		isCredit = Random.Next(0, 2) == 0;
		securityNumber = (ushort)Random.Next(100, 1000);
	}
	public override string ToString() => $"{(isCredit ? "Credit" : "Debit")} Card: {credit} {securityNumber}\nExpiration Date: {expirationDate}\n";
}