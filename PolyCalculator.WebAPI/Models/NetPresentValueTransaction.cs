using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PolyCalculator.WebAPI.Models
{
    public class NetPresentValueTransaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [JsonPropertyName("initial_investment")]
        public decimal InitialInvestment { get; set; }

        [JsonPropertyName("discount_rate_percentage")]
        public decimal DiscountRatePercentage { get; set; }

        [JsonPropertyName("number_of_year")]
        public int NoOfYear { get; set; }

        [JsonPropertyName("lower_bound")]
        public decimal LowerBound { get; set; }

        [JsonPropertyName("upper_bound")]
        public decimal UpperBound { get; set; }

        [JsonPropertyName("increment_rate")]
        public decimal IncrementRate { get; set; }

        [JsonPropertyName("cash_inflow")]
        public List<CashInflows> CashInflows { get; set; }

        [JsonPropertyName("net_present_value")]
        public decimal NetPresentValue { get; set; }
    }
}
