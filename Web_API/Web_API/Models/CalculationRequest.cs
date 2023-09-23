namespace Web_API.Models
{
    public class CalculationRequest
    {
        public int Weight { get; set; }

        public Dimensions Dimensionss { get; set; }

        public string CityFrom { get; set; }

        public string CityTo { get; set; }

        public class Dimensions
        {
            public int Width { get; set; }

            public int Height { get; set; }

            public int Length { get; set; }
        }
    }
}
