namespace RapidApi_HotelFinder.Models
{
    public class HotelResultViewModel
    {
        public string HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelImage { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int AccuratePropertyClass { get; set; }
        public decimal ReviewScore { get; set; }
        public string ReviewScoreWord { get; set; }
        public int ReviewCount { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public string CityName { get; set; }
        public string CountryCode { get; set; }
        public string Description { get; set; }
    }
}
