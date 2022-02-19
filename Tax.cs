namespace OddsLibrary.Taxes;
using System;
public class TaxBase
{
	public float? maxTax;
	private float _taxingPercent;
	public float TaxingPercent { get => _taxingPercent; set => _taxingPercent = value > 1 ? 1 : value < 0 ? 0 : value; }
	public TaxBase() { }
	public TaxBase(float? maxTax, float taxingPercent) : this()
	{
		this.maxTax = maxTax;
		_taxingPercent = taxingPercent;
	}
	public float CalculateTaxPoint(float input, out float? leftOver)
	{
		input *= (1 - TaxingPercent);
		if (input > maxTax)
		{
			leftOver = input - maxTax;
			return maxTax ?? throw new NotImplementedException();
		}
		leftOver = null;
		return input;
	}
	public static float ApplyTaxes(float input, params TaxBase[] taxPoints)
	{
		float output = 0;
		float? leftOver = 0;
		for (int i = 0; i < taxPoints.Length && leftOver != null; i++)
		{
			float ass = taxPoints[i].CalculateTaxPoint(input, out leftOver);
			output += ass;
			input = leftOver ?? 0;
		}
		return output;
	}
}
public class Tax : TaxBase
{
	public float Value;
	public Tax(float Value, float? maxTax, float taxingPercent) : base(maxTax, taxingPercent)
	{
		this.Value = Value;
	}
	public float CalculateTaxPoint(out float? leftOver) => CalculateTaxPoint(Value, out leftOver);
}