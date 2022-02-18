namespace OddsLibrary.Taxes;
class Taxes
{
	public float GetTotalCash(float input, TaxPoint[] taxPoints)
	{

	}
	public struct TaxPackage
	{
		public float Value,
			maxTax;
		private float _taxingPercent;
		public float TaxingPercent { get => _taxingPercent; set => _taxingPercent = value > 1 ? 1 : value < 0 ? 0 : value; }
		public TaxPackage(float Value, float maxTax, float taxingPercent)
		{
			this.Value = Value;
			this.maxTax = maxTax;
			_taxingPercent = 0;
			TaxingPercent = taxingPercent;
		}
		public float CalculateTaxPoint(out float? leftOver)
		{
			Value *= (1 - TaxingPercent);
			if (Value > maxTax)
			{
				leftOver = Value - maxTax;
				return maxTax;
			}
			leftOver = null;
			return Value;
		}
	}
	public struct TaxPoint
	{
		public float? cap;
		private float _taxingPercent;
		public float TaxingPercent { get => _taxingPercent; set => _taxingPercent = value > 1 ? 1 : value < 0 ? 0 : value; }

		public TaxPoint(float? cap, float taxingPercent)
		{
			this.cap = cap;
			_taxingPercent = 0;
			TaxingPercent = taxingPercent;
		}
	}
}