using System.Text.Json.Serialization;

namespace RapidApi_HotelFinder.Models
{
    public class DestinationResultViewModel
    {
        [JsonPropertyName("dest_id")]
        public string DestId { get; set; }

        [JsonPropertyName("city_name")]
        public string CityName { get; set; }
    }
}
