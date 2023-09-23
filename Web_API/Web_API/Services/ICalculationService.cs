using Web_API.Models;

namespace Web_API.Services
{
    public interface ICalculationService
    {
        Task<CalculationResponse> CalculateCostAsync(CalculationRequest request);
    }
}
