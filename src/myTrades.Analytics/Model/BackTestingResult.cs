using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrades.Analytics.Model
{
    public class BackTestingResult
    {    
        public IEnumerable<QuoteWithResult> Buys { get; set; }
        public IEnumerable<QuoteWithResult> Sells { get; set; }

		/// <summary>
		/// Returns the result without reinvesting! 
		/// E.g. you invest 100USD in every deal (always), no matter if you win or not, you invest 100USD in you next deal and take your profil/loss
		/// </summary>
        public double ChangeInPercent
        {
            get
            {
                double retVal = 0;

                foreach (var item in AllTransactions)
                {
                    retVal += item.ResultInPercent;
                }

                return retVal;
            }
        }

		/// <summary>
		/// Returns the Compound result. Here you reinvest your profit/loss/. Eg. you start with 100USD, you make 10%, so in your next deal you invest 110. 
		/// Then you make 20%, so you invest 132 in your 3. deal. End so on...
		/// </summary>
		public double ChangeInPercentCompound
		{
			get
			{
				double retVal = 1;
				foreach (var item in Sells) {
					var percent = (item.ResultInPercent / 100) + 1;
					retVal *= percent;
				}

				return retVal*100-100;
			}
		}

        public IEnumerable<QuoteWithOrderAndResult> AllTransactions
        {
            get
            {
                List<QuoteWithOrderAndResult> retVal = new List<QuoteWithOrderAndResult>();

                int itemAdded = 0;

                int lastFromBuy = 0, lastFromSell = 0;

                while(itemAdded != (Buys.Count() + Sells.Count()))
                {
                    if(lastFromBuy < Buys.Count())
                    {
                        var item = Buys.ElementAt(lastFromBuy);
                        retVal.Add(new QuoteWithOrderAndResult { Date = item.Date, Order = Order.Buy, Value = item.Value, ResultInPercent = item.ResultInPercent });
                        lastFromBuy++;
                    }
                    if (lastFromSell < Sells.Count())
                    {
                        var item = Sells.ElementAt(lastFromSell);
                        retVal.Add(new QuoteWithOrderAndResult { Date = item.Date, Order = Order.Sell, Value = item.Value, ResultInPercent = item.ResultInPercent });
                        lastFromSell++;
                    }

                    itemAdded++;
                }

                return retVal.OrderBy(n=>n.Date);
            }
        }

        public BackTestingResult()
        {
            Buys = new List<QuoteWithResult>();
            Sells = new List<QuoteWithResult>();
        }
    }
}