using System.Runtime.CompilerServices;

namespace Web_API.Models
{
    public class CalculationResponse
    {
        public decimal Cost { get; set; }

        public TaskAwaiter GetAwaiter()
        {
            return Task.CompletedTask.GetAwaiter();
        }

    }
}
