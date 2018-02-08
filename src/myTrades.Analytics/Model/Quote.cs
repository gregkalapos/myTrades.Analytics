using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrades.Analytics.Model
{
    /// <summary>
    /// A simple quote to store a value with a date
    /// </summary>
    public class Quote
    {
        public DateTime Date { get; set; }
        public Decimal Value { get; set; }
        
        public Quote(DateTime date, Decimal value)
        {
            Date = date;
            Value = value;
        }

        public Quote()
        {

        }
    }

    public class QuoteWithOrderAndResult: QuoteWithResult
    {
        public Order Order { get; set; }
    }

    public class QuoteWithResult: Quote
    {
        public Double ResultInPercent { get; set; }
    }
}
