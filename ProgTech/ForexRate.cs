using System;
using System.Collections.Generic;
using System.Text;

namespace ProgTech
{
    struct ForexRate
    {
        public Currency Currency { get; private set; } 
        public double Rate { get; private set; }
        public int Day { get; private set; }

        public ForexRate(Currency currency, double rate, int day)
            :this()
        {
            Currency = currency;
            Rate = rate;
            Day = day;
        }

        public ForexRate(Currency currency, string rateString, int day)
            : this(currency, Convert.ToDouble(rateString), day)
        {

        }

        public override string ToString()
        {
            return String.Format("{0}, Day {1}, Rate {2}",
                Currency.ToString(),
                Day,
                Rate);
        }
    }
}
