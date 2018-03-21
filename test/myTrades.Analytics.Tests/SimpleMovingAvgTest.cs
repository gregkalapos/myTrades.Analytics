using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrades.Analytics;
using MyTrades.Analytics.Model;

namespace MyTrades.Analytics.Tests
{
	[TestClass]
	public class MovingAvgTest
	{
		[TestMethod]
		public void TestSimpleMovingAvg()
		{
			var sma = SimpleMovingAvg.CalculateSMA(GetHistoricalData(), 10);

			for (int i = 0; i < sma.Count; i++)
			{
				Assert.AreEqual(sma[i].Date, GetHistoricalData()[9 + i].Date);
			}
			
			Assert.AreEqual(sma[0].Value, 22.224750000m);
			Assert.AreEqual(sma[1].Value, 22.212830000m);
			Assert.AreEqual(sma[2].Value, 22.232690000m);
			Assert.AreEqual(sma[3].Value, 22.262380000m);
			Assert.AreEqual(sma[4].Value, 22.306060000m);
			Assert.AreEqual(sma[5].Value, 22.423240000m);
			Assert.AreEqual(sma[6].Value, 22.614990000m);
			Assert.AreEqual(sma[7].Value, 22.766920000m);
			Assert.AreEqual(sma[8].Value, 22.906930000m);
			Assert.AreEqual(sma[9].Value, 23.077730000m);
			Assert.AreEqual(sma[10].Value,23.211780000m);
			Assert.AreEqual(sma[11].Value, 23.378610000m);
			Assert.AreEqual(sma[12].Value, 23.526570000m);
			Assert.AreEqual(sma[13].Value, 23.653780000m);
			Assert.AreEqual(sma[14].Value, 23.711390000m);
			Assert.AreEqual(sma[15].Value, 23.685570000m);
			Assert.AreEqual(sma[16].Value, 23.612980000m);
			Assert.AreEqual(sma[17].Value, 23.505730000m);
			Assert.AreEqual(sma[18].Value, 23.432250000m);
			Assert.AreEqual(sma[19].Value, 23.277340000m);
			Assert.AreEqual(sma[20].Value, 23.131210000m);
		}

		public List<HistoricalValue> GetHistoricalData()
		{
			return new List<HistoricalValue>
			{
				new HistoricalValue{Date = new System.DateTime( 2010, 3, 24), Close =     22.273400m },
				new HistoricalValue{Date = new System.DateTime( 2010, 3, 25),  Close =    22.194000m },
				new HistoricalValue{Date = new System.DateTime( 2010, 3, 26),    Close =  22.084700m },
				new HistoricalValue{Date = new System.DateTime( 2010, 3, 29),    Close =  22.174100m },
				new HistoricalValue{Date = new System.DateTime( 2010, 3, 30),    Close =  22.184000m },
				new HistoricalValue{Date = new System.DateTime( 2010, 3, 31),    Close =  22.134400m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 1),     Close =  22.233700m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 5),     Close =  22.432300m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 6),     Close =  22.243600m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 7),     Close =  22.293300m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 8),     Close =  22.154200m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 9),     Close =  22.392600m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 12),  Close =    22.381600m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 13),  Close =    22.610900m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 14),  Close =    23.355800m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 15),  Close =    24.051900m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 16),  Close =    23.753000m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 19),  Close =    23.832400m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 20),  Close =    23.951600m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 21),  Close =    23.633800m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 22),  Close =    23.822500m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 23),  Close =    23.872200m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 26),  Close =    23.653700m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 27),  Close =    23.187000m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 28),  Close =    23.097600m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 29),  Close =    23.326000m },
				new HistoricalValue{Date = new System.DateTime( 2010, 4, 30),  Close =    22.680500m },
				new HistoricalValue{Date = new System.DateTime( 2010, 5, 3),     Close =  23.097600m },
				new HistoricalValue{Date = new System.DateTime( 2010, 5, 4),     Close =  22.402500m },
				new HistoricalValue{Date = new System.DateTime( 2010, 5, 5 ),   Close =   22.172500m }
			};
		}
	}
}
