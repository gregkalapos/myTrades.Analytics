using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrades.Analytics.Tests.TestData;

namespace MyTrades.Analytics.Tests
{
	[TestClass]
	public class ExponentialMovingAvgTest
	{
		[TestMethod]
		public void TestExponentialMovingAvg()
		{
			var ema = ExponentialMovingAvg.CalculateEma(TestDataSource.HistoricalData30Days, 10);

			for (int i = 0; i < ema.Count; i++)
			{
				Assert.AreEqual(TestDataSource.HistoricalData30Days[9 + i].Date, ema[i].Date);
			}

			Assert.AreEqual(22.22475000m, ema[0].Value);
			Assert.AreEqual(22.21192273m, ema[1].Value);
			Assert.AreEqual(22.24477314m, ema[2].Value);
			Assert.AreEqual(22.26965075m, ema[3].Value);
			Assert.AreEqual(22.33169607m, ema[4].Value);
			Assert.AreEqual(22.51789678m, ema[5].Value);
			Assert.AreEqual(22.79680646m, ema[6].Value);
			Assert.AreEqual(22.97065983m, ema[7].Value);
			Assert.AreEqual(23.12733986m, ema[8].Value);
			Assert.AreEqual(23.27720534m, ema[9].Value);
			Assert.AreEqual(23.34204073m, ema[10].Value);
			Assert.AreEqual(23.42939696m, ema[11].Value);
			Assert.AreEqual(23.50990661m, ema[12].Value);
			Assert.AreEqual(23.53605086m, ema[13].Value);
			Assert.AreEqual(23.47258707m, ema[14].Value);
			Assert.AreEqual(23.40440760m, ema[15].Value);
			Assert.AreEqual(23.39015167m, ema[16].Value);
			Assert.AreEqual(23.26112410m, ema[17].Value);
			Assert.AreEqual(23.23139244m, ema[18].Value);
			Assert.AreEqual(23.08068473m, ema[19].Value);
			Assert.AreEqual(22.91556023m, ema[20].Value);
		}
	}
}























