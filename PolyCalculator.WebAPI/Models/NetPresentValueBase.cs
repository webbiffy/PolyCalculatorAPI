using System.Text.Json.Serialization;

namespace PolyCalculator.WebAPI
{
    public abstract class NetPresentValueBase
    {
        [JsonPropertyName("initial_investment")]
        public decimal InitialInvestment { get; set; }

        [JsonPropertyName("number_of_year")]
        public int NoOfYear { get; set; }

        public abstract decimal Calculate();
    }
}
