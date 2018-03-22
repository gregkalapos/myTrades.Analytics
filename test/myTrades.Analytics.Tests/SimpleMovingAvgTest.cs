using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrades.Analytics;
using MyTrades.Analytics.Model;
using MyTrades.Analytics.Tests.TestData;

namespace MyTrades.Analytics.Tests
{
	[TestClass]
	public class MovingAvgTest
	{
		[TestMethod]
		public void TestSimpleMovingAvg()
		{
			var sma = SimpleMovingAvg.CalculateSMA(TestDataSource.HistoricalData30Days, 10);

			for (int i = 0; i < sma.Count; i++)
			{
				Assert.AreEqual(TestDataSource.HistoricalData30Days[9 + i].Date, sma[i].Date);
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
	}
}
