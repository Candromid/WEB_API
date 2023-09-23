using System.Text.Json;
using System.Text;
using Web_API.Models;

namespace Web_API.Services
{
    public class CdekClient
    {
        private readonly string _testUrl;
        private readonly string _productionUrl;

        public CdekClient (string testUrl, string productionUrl)
        {
            _testUrl = testUrl;
            _productionUrl = productionUrl;
        }

        public async Task<CalculateResponse> Calculate(CalculateRequest request)
        {
            string url = _testUrl;
            if (request.Production)
            {
                url = _productionUrl;
            }

            var client = new HttpClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var calculateResponse = JsonSerializer.Deserialize<CalculateResponse>(json);

            return calculateResponse;
        }

    }
}
