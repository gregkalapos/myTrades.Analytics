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

        public static List<Quote> CalculateSMA(List<HistoricalValue> Price, int SMALength, CancellationToken CT)
        {
                List<Quote> retVal = new List<Quote>();
                for (int i = 0; i < Price.Count() - SMALength + 1; i++)
                {
                    var firstSmaLengthItems = Price.Skip(i).Take(SMALength);
                    var fistAvg = firstSmaLengthItems.Average(n => n.Close);
                    retVal.Add(new Quote { Date = firstSmaLengthItems.Last().Date, Value = fistAvg });
                    CT.ThrowIfCancellationRequested();
                }

                return retVal;           
        }
    }
}
