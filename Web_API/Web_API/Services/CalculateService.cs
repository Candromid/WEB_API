using Web_API.Models;

namespace Web_API.Services
{
    public class CalculateService
    {
        private readonly CdekCleint _cdekClient;

        public CalculateService (CdekCleint cdekClient)
        {
            _cdekClient = cdekClient;
        }

        public CalculateResponse Calculate(CalculateRequest request)
        {
            var calculateRequest = new CalculateRequest();
            {
                Weight = request.Weight,
                Dimensions = request.Dimensions,
                FromCityCode = request.FromCityCode,
                ToCityCode = request.ToCityCode,
            };

            var calculateResponse = _cdekClient.Calculate(calculateRequest);

            return calculateResponse;
        }
    }
}
