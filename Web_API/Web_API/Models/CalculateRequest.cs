namespace Web_API.Models
{
    public class CalculateRequest
    {
        public int Weight { get; set; }
        public int[] Dimensions { get; set; }
        public string FromCityCode { get; set; }
        public string ToCityCode { get; set;}
        public bool Production { get; set; }

    }
}
