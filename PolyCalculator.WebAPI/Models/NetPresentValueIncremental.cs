using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace PolyCalculator.WebAPI
{
    
    public sealed class NetPresentValueIncremental : NetPresentValueBase
    {
        [JsonPropertyName("lower_bound")]
        public decimal LowerBound { get; set; }

        [JsonPropertyName("upper_bound")]
        public decimal UpperBound { get; set; }

        [JsonPropertyName("increment_rate")]
        public decimal IncrementRate { get; set; }

        [JsonPropertyName("cash_inflow")]
        public List<CashInflows> CashInflows { get; set; }

        public override decimal Calculate()
        {
            if (LowerBound <= 0)
                throw new Exception("Lowerbound must be more than zero.");

            if (UpperBound <= 0)
                throw new Exception("Upperbound must be more than zero.");


            var presentValues = new List<decimal>();
            presentValues.Add(-InitialInvestment);

            while (LowerBound <= UpperBound)
            {
                decimal discountRatePercentage = LowerBound / 100;

                presentValues.Add(CashInflows.Sum(c => c.CashFlow / ((1 + discountRatePercentage) * c.Year)));

                LowerBound += Math.Min(UpperBound, IncrementRate);

                var boundaryDifference = UpperBound - LowerBound;
                if (boundaryDifference > 0)
                    LowerBound += Math.Min(boundaryDifference, IncrementRate);
                else
                    LowerBound++;
            }

            return Math.Round(presentValues.Sum(x => x), 2);
        }


    }
}
