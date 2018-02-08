using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MyTrades.Analytics.Model;

namespace MyTrades.Analytics
{
    public static class Rsi
    {
        public class Change
        {
            public enum Trend { Upward, Downward, Equal }
            public Trend TrendP { get; set; }
            public Decimal ChangeInDec { get; set; }

            public Change(Trend T, Decimal D)
            {
                TrendP = T;
                ChangeInDec = D;
            }
        }

        internal static decimal getDownwardValue(Rsi.Change changeValue)
        {
            if (changeValue.TrendP == Change.Trend.Downward)
            {
                return changeValue.ChangeInDec;
            }
            return 0m;
        }

        internal static decimal getUpwardValue(Rsi.Change changeValue)
        {
            if (changeValue.TrendP == Change.Trend.Upward)
            {
                return changeValue.ChangeInDec;
            }
            return 0m;
        }

        public class DateWithChange
        {
            public DateTime Date { get; set; }
            public Change Change { get; set; }

            public DateWithChange(DateTime D, Change C)
            {
                Date = D;
                Change = C;
            }
        }

        static Rsi.DateWithChange getChange(Quote closeDayN, Quote closeDayNminus1)
        {

            if (closeDayNminus1.Value < closeDayN.Value)
            {
                return new Rsi.DateWithChange(closeDayN.Date, new Change(Change.Trend.Upward, closeDayN.Value - closeDayNminus1.Value));
            }
            if (closeDayNminus1.Value > closeDayN.Value)
            {
                return new Rsi.DateWithChange(closeDayN.Date, new Rsi.Change(Change.Trend.Downward, closeDayNminus1.Value - closeDayN.Value));
            }

            return new Rsi.DateWithChange(closeDayN.Date, new Change(Change.Trend.Equal, 0));
        }

        public static List<DateWithChange> calculateChanges(List<Quote> stockData)
        {
            var retVal = new List<DateWithChange>();

            for (int i = 1; i < stockData.Count; i++)
            {
                retVal.Add(getChange(stockData[i], stockData[i - 1]));
            }
            return retVal;
        }

        static decimal calculateRsi(decimal avgGain, decimal avgLoss)
        {
            if (avgLoss == decimal.Zero)
            {
                return 100m;
            }
            if (avgGain == decimal.Zero)
            {
                return 0m;
            }
            decimal rs = avgGain / avgLoss;
            return 100m - 100m / (1m + rs);
        }

        public static IEnumerable<Quote> CalculateRsi(List<Quote> Price, int RsiLength, CancellationToken CT)
        {          
                var changes = calculateChanges(Price);
                var changesInRange = changes.Take(RsiLength);
                int num = changesInRange.Count();

                var changeValuesinRange = changesInRange.Select(n => n.Change);

                CT.ThrowIfCancellationRequested();
                var allGain = 0m;
                foreach (var item in changeValuesinRange)
                {
                    allGain += getUpwardValue(item);
                }

                CT.ThrowIfCancellationRequested();
                var allLost = 0m;
                foreach (var item in changeValuesinRange)
                {
                    allLost += getDownwardValue(item);
                }

                var avgGain = allGain / RsiLength;
                var avgLoss = allLost / RsiLength;

                var newRsiVal = calculateRsi(avgGain, avgLoss);
                var newRsi = new Quote(changesInRange.Last().Date, newRsiVal);

                CT.ThrowIfCancellationRequested();
                return RsiHelper(changes.Skip(1).ToList(), RsiLength, new List<Quote> { newRsi }, avgGain, avgLoss, CT);        
        }


        private static IEnumerable<Quote> RsiHelper(List<DateWithChange> changes, int rsiLength, List<Quote> res, decimal lastAvgGain, decimal lastAvgLoss, CancellationToken CT)
        {
            while (true)
            {
                if (changes.Count < rsiLength)
                {
                    break;
                }
                decimal currentGain = getUpwardValue(changes[rsiLength - 1].Change); // Rsi.getUpwardValue(ArrayModule.Item<Rsi.DateWithChange>(rsiLength - 1, changes).Change@);
                decimal avgGain = (lastAvgGain * (Convert.ToDecimal(rsiLength) - 1m) + currentGain) / Convert.ToDecimal(rsiLength);
                decimal currentLoss = getDownwardValue(changes[rsiLength - 1].Change);
                decimal avgLoss = (lastAvgLoss * (Convert.ToDecimal(rsiLength) - 1m) + currentLoss) / Convert.ToDecimal(rsiLength);
                decimal newrsiValue = calculateRsi(avgGain, avgLoss);
                Quote newRsi = new Quote(changes[rsiLength - 1 ].Date, newrsiValue);
                changes = changes.Skip(1).ToList(); // = ArrayModule.Tail<Rsi.DateWithChange>(changes);
                int arg_F5_0 = rsiLength;
                res.Add(newRsi);
                //FSharpList<Quote> arg_F3_0 = Operators.op_Append<Quote>(res, FSharpList<Quote>.Cons(newRsi, FSharpList<Quote>.Empty));

                lastAvgLoss = avgLoss;
                lastAvgGain = avgGain;

                CT.ThrowIfCancellationRequested();
            }
            return res;
        }



        public static Task<BackTestingResult> BackTestRsiAsync(List<Quote> RsiData, List<HistoricalValue> Price, int SellThreashold, int BuyThresold, CancellationToken CancellationToken)
        {
           return Task.Run<BackTestingResult>(() =>
           {
               var lastOrder = Order.Sell;
               List<QuoteWithResult> buys = new List<QuoteWithResult>();
               List<QuoteWithResult> sells = new List<QuoteWithResult>();
               decimal lastBuyPrice = 0;

               for (int i = 0; i < RsiData.Count; i++)
               {
                   CancellationToken.ThrowIfCancellationRequested();

                   if (RsiData[i].Value < BuyThresold && lastOrder == Order.Sell)
                   {
                       lastOrder = Order.Buy;
                       buys.Add(new QuoteWithResult { Date = RsiData[i].Date, Value = Price[i].Close });
                       lastBuyPrice = Price[i].Close;
                   }
                   if (RsiData[i].Value > SellThreashold && lastOrder == Order.Buy)
                   {
                       lastOrder = Order.Sell;
                       var resultInPercent = ((((double)((Price[i].Close / lastBuyPrice))) - 1.0) * 100.0);
                       sells.Add(new QuoteWithResult { Date = RsiData[i].Date, Value = Price[i].Close, ResultInPercent = resultInPercent });
                   }
               }

               return new BackTestingResult { Buys = buys, Sells = sells };
           });
        }
    }
}
