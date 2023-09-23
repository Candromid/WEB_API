using Web_API.Models;

namespace Web_API.Services
{
    public class CalculateService
    {
        private readonly CdekClient _cdekClient;

        public CalculateService(CdekClient cdekClient)
        {
            _cdekClient = cdekClient;
        }

        public CalculateResponse Calculate(CalculateRequest request)
        {
            // Проверяем, корректны ли данные в запросе
            // Например, можно проверить, что вес посылки не меньше нуля
            if (request.Weight <= 0)
            {
                throw new Exception("Вес посылки должен быть больше нуля.");
            }

            // Получаем ответ от API
            var calculateResponse = _cdekClient.Calculate(request);

            // Возвращаем результат
            return calculateResponse;
        }
    }
}
