using Microsoft.AspNetCore.Mvc;
using Web_API.Models;
using Web_API.Services;

namespace Web_API.Controllers
{
    
    public class CalculationController : Controller
    {
        private readonly ICalculationService _calculationService;

        public CalculationController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        [HttpGet]
        [Route("api/calculation")]
        public async Task<CalculationResponse> Get(CalculationRequest request)
        {
            return await _calculationService.CalculateCostAsync(request);
        }
    }

}
