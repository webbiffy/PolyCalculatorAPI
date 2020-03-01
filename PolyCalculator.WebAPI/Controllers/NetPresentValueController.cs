using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolyCalculator.WebAPI.Models;
using PolyCalculator.WebAPI.Services;

namespace PolyCalculator.WebAPI.Controllers
{

    [Route("api/nvp")]
    public class NetPresentValueController : PolyCalculatorControllerBase
    {
        private readonly ILogger<NetPresentValueController> _logger;
        private readonly NetPresentValueCalculatorService _netPresentValueService;
        public NetPresentValueController(ILogger<NetPresentValueController> logger, 
                                            NetPresentValueCalculatorService netPresentValueService)
        {
            _logger = logger;
            _netPresentValueService = netPresentValueService;
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

        [HttpGet]
        public string Get()
        {
            var netPresentValues = _netPresentValueService.Get();
            return SerializerPrettyPrint(netPresentValues);
        }

        [HttpGet("{id:length(24)}")]
        public string Get(string id)
        {
            var netPresentValue = _netPresentValueService.Get(id);
            return SerializerPrettyPrint(netPresentValue);
        }

        [HttpPost]
        public string Create(NetPresentValueTransaction netPresentValue)
        {
            _netPresentValueService.Create(netPresentValue);
            return SerializerPrettyPrint(netPresentValue);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Edit(string id, NetPresentValueTransaction newNetPresentValue)
        {
            var netPresentValue = _netPresentValueService.Get(id);
            if(netPresentValue == null)
            {
                return NotFound();
            }

            _netPresentValueService.Update(id, newNetPresentValue);

            return Ok();
        }
    }
}
