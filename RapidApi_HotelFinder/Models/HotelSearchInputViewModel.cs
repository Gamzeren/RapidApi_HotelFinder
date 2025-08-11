using System.Text.Json.Serialization;

namespace RapidApi_HotelFinder.Models
{
    public class HotelSearchInputViewModel
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("checkin_date")]
        public DateTime CheckInDate { get; set; }

        [JsonPropertyName("checkout_date")]
        public DateTime CheckOutDate { get; set; }

        [JsonPropertyName("adults_number")]
        public int Adults { get; set; }

        [JsonPropertyName("children_number")]
        public int Children { get; set; }
    }
}
