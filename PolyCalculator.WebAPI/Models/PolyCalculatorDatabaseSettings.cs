

namespace PolyCalculator.WebAPI.Models
{
    public class PolyCalculatorDatabaseSettings : IPolyCalculatorDatabaseSettings
    {
        public string CalculatorCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPolyCalculatorDatabaseSettings
    {
        string CalculatorCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
