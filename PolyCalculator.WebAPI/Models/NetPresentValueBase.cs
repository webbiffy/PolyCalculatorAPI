using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PolyCalculator.WebAPI
{
    public abstract class NetPresentValueBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [JsonPropertyName("initial_investment")]
        public decimal InitialInvestment { get; set; }

        [JsonPropertyName("number_of_year")]
        public int NoOfYear { get; set; }

        [JsonPropertyName("net_present_value")]
        public decimal NetPresentValue { get; set; }

        public abstract decimal Calculate();
    }
}
