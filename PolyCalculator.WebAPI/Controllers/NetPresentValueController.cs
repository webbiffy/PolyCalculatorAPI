using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolyCalculator.WebAPI.Services;
using System.Collections.Generic;
using System.Text.Json;

namespace PolyCalculator.WebAPI.Controllers
{

    [Route("api/nvp")]
    public class NetPresentValueController : PolyCalculatorControllerBase
    {
        private readonly ILogger<NetPresentValueController> _logger;
        private readonly NetPresentValueCalculatorService _netPresentValueService;
        public NetPresentValueController(ILogger<NetPresentValueController> logger, NetPresentValueCalculatorService netPresentValueService)
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

        [HttpGet("{id:length(24)}", Name = "GetNetPresentValue")]
        public string Get(string id)
        {
            var netPresentValue = _netPresentValueService.Get(id);
            return SerializerPrettyPrint(netPresentValue);
        }

        [HttpPost("fix/create")]
        public string Create(NetPresentValueFixed netPresentValue)
        {
            _netPresentValueService.Create(netPresentValue);
            return SerializerPrettyPrint(netPresentValue);
        }

    }
}
