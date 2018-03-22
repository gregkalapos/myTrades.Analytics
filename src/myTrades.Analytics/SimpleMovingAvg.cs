using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyTrades.Analytics.Model;

namespace MyTrades.Analytics
{
	public static class SimpleMovingAvg
	{
		public static List<Quote> CalculateSMA(List<HistoricalValue> Price, int SMALength)
		{
			return CalculateSMA(Price, SMALength, CancellationToken.None);
		}

		public static List<Quote> CalculateSMA(List<HistoricalValue> Price, int SMALength, CancellationToken CT)
		{
			List<Quote> retVal = new List<Quote>(Price.Count - SMALength + 1);

			decimal[] buffer = new decimal[SMALength];
			var current_index = 0;
			for (int i = 0; i < Price.Count; i++)
			{
				buffer[current_index] = Price[i].Close / SMALength;
				if (i >= SMALength - 1)
				{
					decimal ma = 0m;
					for (int j = 0; j < SMALength; j++)
					{
						ma += buffer[j];
					}

					retVal.Add(new Quote { Value = ma, Date = Price[i].Date });
				}

				current_index = (current_index + 1) % SMALength;
			}

			return retVal;
		}
	}
}
