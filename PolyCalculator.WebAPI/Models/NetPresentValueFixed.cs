using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace PolyCalculator.WebAPI
{
    public sealed class NetPresentValueFixed : NetPresentValueBase
    {
        [JsonPropertyName("discount_rate_percentage")]
        public decimal DiscountRatePercentage { get; set; }

        [JsonPropertyName("cash_inflow")]
        public decimal CashInflow { get; set; }

        public override decimal Calculate()
        {
            if (NoOfYear <= 0)
                throw new Exception("No of year must be more than zero");

            if (InitialInvestment <= 0)
                throw new Exception("Investment must be more than zero");

            var presentValues = new List<decimal>();
            presentValues.Add(-InitialInvestment);
            presentValues.Add(CashInflow / ((1 + (DiscountRatePercentage / 100)) * NoOfYear));

            return Math.Round(presentValues.Sum(x => x), 2);
        }
    }
}
