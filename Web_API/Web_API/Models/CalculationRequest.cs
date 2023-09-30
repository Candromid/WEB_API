namespace Web_API.Models
{
    public class CalculationRequest
    {
        public int Weight { get; set; } // Вес посылки
        public Dimensions dimensions { get; set; } // Габариты посылки
        public string CityFrom { get; set; } // Город отправления
        public string CityTo { get; set; } // Город назначения

        public class Dimensions
        {
            public int Width { get; set; } // Ширина посылки
            public int Height { get; set; } // Высота посылки
            public int Length { get; set; } // Длина посылки
        }
    }
}
