using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace PolyCalculator.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolyCalculatorControllerBase : ControllerBase
    {
        public string SerializerPrettyPrint<T>(T value)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return JsonSerializer.Serialize<T>(value, options);
        }
    }
}
