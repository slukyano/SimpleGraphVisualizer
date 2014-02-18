using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProgTech
{
    class RateList : List<ForexRate>
    {
        public string Month { get; private set; }

        private RateList()
        {

        }

        public static RateList ReadFromFile(string filepath)
        {
            using (StreamReader reader = new StreamReader(filepath))
            {
                RateList rateList = new RateList();

                rateList.Month = reader.ReadLine();

                for (int i = 0; i < 30; i++)
                {
                    rateList.Add(new ForexRate(Currency.USD, reader.ReadLine(), i + 1));
                    rateList.Add(new ForexRate(Currency.EUR, reader.ReadLine(), i + 1));
                    rateList.Add(new ForexRate(Currency.DM, reader.ReadLine(), i + 1));
                }

                return rateList;
            }
        }

        public IEnumerable<ForexRate> GetRates(Currency currency)
        {
            foreach (ForexRate rate in this)
                if (rate.Currency == currency)
                    yield return rate;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Month);

            for (int i = 0; i < 30; i++) 
            {
                for (int j = 0; j < 3; j++)
                    sb.AppendLine(this[i * 3 + j].ToString());
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
