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
				Assert.AreEqual(GetHistoricalData()[9 + i].Date, sma[i].Date);
			}
			
			Assert.AreEqual(22.224750000m, sma[0].Value);
			Assert.AreEqual(22.212830000m, sma[1].Value);
			Assert.AreEqual(22.232690000m, sma[2].Value);
			Assert.AreEqual(22.262380000m, sma[3].Value);
			Assert.AreEqual(22.306060000m, sma[4].Value);
			Assert.AreEqual(22.423240000m, sma[5].Value);
			Assert.AreEqual(22.614990000m, sma[6].Value);
			Assert.AreEqual(22.766920000m, sma[7].Value);
			Assert.AreEqual(22.906930000m, sma[8].Value);
			Assert.AreEqual(23.077730000m, sma[9].Value);
			Assert.AreEqual(23.211780000m, sma[10].Value);
			Assert.AreEqual(23.378610000m, sma[11].Value);
			Assert.AreEqual(23.526570000m, sma[12].Value);
			Assert.AreEqual(23.653780000m, sma[13].Value);
			Assert.AreEqual(23.711390000m, sma[14].Value);
			Assert.AreEqual(23.685570000m, sma[15].Value);
			Assert.AreEqual(23.612980000m, sma[16].Value);
			Assert.AreEqual(23.505730000m, sma[17].Value);
			Assert.AreEqual(23.432250000m, sma[18].Value);
			Assert.AreEqual(23.277340000m, sma[19].Value);
			Assert.AreEqual(23.131210000m, sma[20].Value);
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
