using Web_API.Models;
using Newtonsoft.Json;

namespace Web_API.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly HttpClient _httpClient;

        public CalculationService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<CalculationResponse> CalculateCostAsync(CalculationRequest request)
        {
            
            var requestBody = new Dictionary<string, object>
    {
      { "Weight", request.Weight },
      { "Dimensions", request.Dimensionss.Width * request.Dimensionss.Height * request.Dimensionss.Length },
      { "CityFrom", request.CityFrom },
      { "CityTo", request.CityTo },
      { "DeliveryType", "COURIER" },
      { "ServiceType", "ONE_PACKAGE" },
    };

            // Convert the Dictionary<string, object> to an IEnumerable<KeyValuePair<string, string>>
            var requestBodyAsKeyValuePairs = requestBody.Select(x => new KeyValuePair<string, string>(x.Key, x.Value.ToString()));

            
            var response = await _httpClient.PostAsync("https://api.cdek.ru/v2/calculator/tarifflist", new FormUrlEncodedContent(requestBodyAsKeyValuePairs))
              .Result
              .Content
              .ReadAsStringAsync();
            
            var json = JsonConvert.DeserializeObject<CalculationResponse>(response);

            return json;
        }
    }
}
