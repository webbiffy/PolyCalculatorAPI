using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PolyCalculator.WebAPI.Controllers
{

    [Route("api/nvp")]
    public class NetPresentValueController : PolyCalculatorControllerBase
    {
        private readonly ILogger<NetPresentValueController> _logger;

        public NetPresentValueController(ILogger<NetPresentValueController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Welcome to net present value calculator";
        }

        [HttpPost("fix/calculate")]
        public decimal Calculate(NetPresentValueFixed netPresentValue)
        {
            return netPresentValue.Calculate();
        }

        [HttpPost("incremental/calculate")]
        public decimal Calculate(NetPresentValueIncremental netPresentValue)
        {
            return netPresentValue.Calculate();
        }
    }
}
