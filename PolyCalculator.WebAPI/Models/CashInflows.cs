using System.Text.Json.Serialization;

namespace PolyCalculator.WebAPI
{
    public class CashInflows
    {
        public int Year { get; set; }
        [JsonPropertyName("cash")]
        public decimal CashFlow { get; set; }
    }
}
