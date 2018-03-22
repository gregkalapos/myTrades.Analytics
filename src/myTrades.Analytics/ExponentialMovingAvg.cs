using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyTrades.Analytics.Model;

namespace MyTrades.Analytics
{
	public static class ExponentialMovingAvg
	{
		public static List<Quote> CalculateEma(List<HistoricalValue> Price, int EmaLength)
		{
			return CalculateEMA(Price, EmaLength, CancellationToken.None);
		}

		public static List<Quote> CalculateEMA(List<HistoricalValue> Price, int EmaLength, CancellationToken CT)
		{
			List<Quote> retVal = new List<Quote>();
			var k = 2.0M / (EmaLength + 1.0M);

			var firstAvg = Price.Take(EmaLength).Average(n => n.Close);
			var firstEma = Price[EmaLength + 1].Close * k + firstAvg * (1 - k);
			retVal.Add(new Quote { Value = firstEma, Date = Price[EmaLength + 1].Date });

			var lastEma = firstEma;
			for (int i = EmaLength + 1; i < Price.Count - 1; i++)
			{
				var newEma = k * (Price[i + 1].Close - lastEma) + lastEma;
				retVal.Add(new Quote { Date = Price[i + 1].Date, Value = newEma });
				lastEma = newEma;
			}

			return retVal;
		}
	}
}