using System;
using System.Collections.Generic;
using System.Text;
using MyTrades.Analytics.Model;

namespace MyTrades.Analytics.Tests.TestData
{
	static class TestDataSource
	{
		public static List<HistoricalValue> HistoricalData30Days =>
			new List<HistoricalValue>
			{
				new HistoricalValue{Date = new DateTime( 2010, 3, 24), Close =     22.273400m },
				new HistoricalValue{Date = new DateTime( 2010, 3, 25),  Close =    22.194000m },
				new HistoricalValue{Date = new DateTime( 2010, 3, 26),    Close =  22.084700m },
				new HistoricalValue{Date = new DateTime( 2010, 3, 29),    Close =  22.174100m },
				new HistoricalValue{Date = new DateTime( 2010, 3, 30),    Close =  22.184000m },
				new HistoricalValue{Date = new DateTime( 2010, 3, 31),    Close =  22.134400m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 1),     Close =  22.233700m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 5),     Close =  22.432300m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 6),     Close =  22.243600m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 7),     Close =  22.293300m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 8),     Close =  22.154200m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 9),     Close =  22.392600m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 12),  Close =    22.381600m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 13),  Close =    22.610900m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 14),  Close =    23.355800m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 15),  Close =    24.051900m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 16),  Close =    23.753000m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 19),  Close =    23.832400m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 20),  Close =    23.951600m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 21),  Close =    23.633800m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 22),  Close =    23.822500m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 23),  Close =    23.872200m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 26),  Close =    23.653700m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 27),  Close =    23.187000m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 28),  Close =    23.097600m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 29),  Close =    23.326000m },
				new HistoricalValue{Date = new DateTime( 2010, 4, 30),  Close =    22.680500m },
				new HistoricalValue{Date = new DateTime( 2010, 5, 3),     Close =  23.097600m },
				new HistoricalValue{Date = new DateTime( 2010, 5, 4),     Close =  22.402500m },
				new HistoricalValue{Date = new DateTime( 2010, 5, 5 ),   Close =   22.172500m }
			};
	}
}