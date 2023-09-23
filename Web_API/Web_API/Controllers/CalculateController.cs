using Microsoft.AspNetCore.Mvc;
using Web_API.Models;
using Web_API.Services;

namespace Web_API.Controllers
{
    [Route("api/calculate")]
    public class CalculateController
    {
        private readonly CalculateService _calculateService;

        public CalculateController(CalculateService calculateService)
        {
            _calculateService = calculateService;
        }

        [HttpPost]
        public async Task<IActionResult> Calculate([FromBody] CalculateRequest request)
        {
            // Проверяем, не пустой ли запрос
            if (request == null)
            {
                return BadRequest(new BadRequestObjectResult("Запрос не может быть пустым."));
            }

            // Проверяем, корректны ли данные в запросе
            // Например, можно проверить, что вес посылки не меньше нуля
            if (request.Weight <= 0)
            {
                return BadRequest(new BadRequestObjectResult("Вес посылки должен быть больше нуля."));
            }

            // Получаем ответ от API
            var calculateResponse = await _calculateService.Calculate(request);

            // Проверяем, не возникла ли ошибка
            if (calculateResponse == null)
            {
                return BadRequest(new BadRequestObjectResult("Не удалось рассчитать стоимость доставки."));
            }

            // Возвращаем ответ
            return Ok(calculateResponse);
        }
    }

}
