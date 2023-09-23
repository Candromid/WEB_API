using Microsoft.AspNetCore.Mvc;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/calculate")]
    public class CalculateController : Controller
    {
        private readonly CalculateServices _calculateServices;

        public CalculateController(CalculateServices calculateServices)
        {
            _calculateServices = calculateServices;
        }

        [HttpPost]

        public async Task<IActionResult> Calculate(
            [FromBody] CalculateRequest request)
        {
            var calculateResponse = await _calculateServices.Calculate(request);

            return Ok(calculateResponse);
        }
    }
}
