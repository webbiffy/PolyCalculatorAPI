

namespace PolyCalculator.WebAPI.Models
{
    public class PolyCalculatorDatabaseSettings : IPolyCalculatorDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPolyCalculatorDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
