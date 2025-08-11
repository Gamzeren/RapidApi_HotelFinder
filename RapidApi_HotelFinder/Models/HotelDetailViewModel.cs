namespace RapidApi_HotelFinder.Models
{
    public class HotelDetailViewModel
    {
        public string HotelId { get; set; }
        public string HotelName { get; set; }
        public List<string> HotelImages { get; set; }
        public string Address { get; set; }
        public decimal PricePerNight { get; set; }
        public string WebSiteUrl { get; set; }
        public string Description { get; set; }
        public int AvailableRoomCount { get; set; }
        public List<string> Facilities { get; set; }
        public string BedConfig { get; set; }
        public decimal RoomSize { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal DistanceToCityCenterKm { get; set; }
        public List<string> SpokenLanguages { get; set; }
        public string RoomId { get; set; }
    }
}
