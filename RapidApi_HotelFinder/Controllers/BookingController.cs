using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RapidApi_HotelFinder.Models;

namespace RapidApi_HotelFinder.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string apiKey = "my_api_key";
        private const string apiHost = "booking-com15.p.rapidapi.com";

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new HotelSearchInputViewModel());
        }

        [HttpGet]
        public IActionResult HotelList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(HotelSearchInputViewModel model)
        {
            var destId = await GetDestinationId(model.City);
            if (string.IsNullOrEmpty(destId))
            {
                ViewBag.Error = "Şehir bulunamadı.";
                return View("Index", model);
            }

            var hotels = await GetHotels(destId, model);
            return View("HotelList", hotels);
        }

        private async Task<string> GetDestinationId(string city)
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://{apiHost}/api/v1/hotels/searchDestination?query={city}");

            request.Headers.Add("x-rapidapi-key", apiKey);
            request.Headers.Add("x-rapidapi-host", apiHost);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(json);

            return result?.data?[0]?.dest_id; // İlk eşleşen şehri alıyoruz
        }

        private async Task<List<HotelResultViewModel>> GetHotels(string destId, HotelSearchInputViewModel model)
        {
            var client = _httpClientFactory.CreateClient();

            string url = $"https://{apiHost}/api/v1/hotels/searchHotels?" +
                $"dest_id={destId}" +
                $"&search_type=CITY" +
                $"&arrival_date={model.CheckInDate:yyyy-MM-dd}" +
                $"&departure_date={model.CheckOutDate:yyyy-MM-dd}" +
                $"&adults={model.Adults}" +
                $"&children_age=0,17" +
                $"&room_qty=1" +
                $"&page_number=1" +
                $"&units=metric" +
                $"&temperature_unit=c" +
                $"&languagecode=en-us" +
                $"&currency_code=AED";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("x-rapidapi-key", apiKey);
            request.Headers.Add("x-rapidapi-host", apiHost);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

            var hotelList = new List<HotelResultViewModel>();

            var hotels = data?.data?.hotels;
            if (hotels != null)
            {
                foreach (var item in hotels)
                {
                    var hotel = new HotelResultViewModel
                    {
                        HotelId = item.hotel_id?.ToString(),

                        HotelName = item.property?.name != null
                            ? (string)item.property.name
                            : "İsim yok",

                        HotelImage = item.property?.photoUrls != null && item.property.photoUrls.Count > 0
                            ? (string)item.property.photoUrls[0]
                            : "/images/no-image.png",

                        CheckInDate = item.property?.checkinDate ?? DateTime.Today.ToString("yyyy-MM-dd"),
                        CheckOutDate = item.property?.checkoutDate ?? DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"),

                        AccuratePropertyClass = item.property?.accuratePropertyClass,

                        ReviewScore = item.property?.reviewScore ?? 0,

                        ReviewScoreWord = item.property?.reviewScoreWord ?? "Hatalı veri",

                        ReviewCount = item.property?.reviewScore ?? 0,

                        CheckInTime = item.property?.checkin?.fromTime + " - " + item.property?.checkin?.untilTime,

                        CheckOutTime = item.property?.checkout?.fromTime + " - " + item.property?.checkout?.untilTime,

                        CityName = item.property?.wishlistName,

                        CountryCode = item.property?.countryCode,

                        Description = item.accessibilityLabel
                    };

                    hotelList.Add(hotel);
                }
            }

            return hotelList;
        }

        [HttpGet]
        public async Task<IActionResult> HotelDetail(string hotelId, string checkInDate, string checkOutDate)
        {
            checkInDate ??= DateTime.Today.ToString("yyyy-MM-dd");
            checkOutDate ??= DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");

            var hotel = await GetHotelDetails(hotelId, checkInDate, checkOutDate);
            return View(hotel);
        }

        private async Task<HotelDetailViewModel> GetHotelDetails(string hotelId, string arrivalDate, string departureDate)
        {
            var client = _httpClientFactory.CreateClient();

            string url = $"https://{apiHost}/api/v1/hotels/getHotelDetails" +
                         $"?hotel_id={hotelId}" +
                         $"&arrival_date={arrivalDate}" +
                         $"&departure_date={departureDate}" +
                         $"&adults=2" +
                         $"&children_age=1%2C17" +
                         $"&room_qty=1" +
                         $"&units=metric" +
                         $"&temperature_unit=c" +
                         $"&languagecode=en-us" +
                         $"&currency_code=EUR";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("x-rapidapi-key", apiKey);
            request.Headers.Add("x-rapidapi-host", apiHost);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(json);

            List<string> spokenLanguages = new List<string>();

            if (result.data.spoken_languages != null)
            {
                for (int i = 0; i < result.data.spoken_languages.Count; i++)
                {
                    // spoken_languages[i] dinamik ise direkt stringe çevir
                    string lang = (string)result.data.spoken_languages[i];
                    if (!string.IsNullOrEmpty(lang))
                        spokenLanguages.Add(lang);
                }
            }
            else
            {
                spokenLanguages = new List<string>();
            }

            var roomId = result.data.block[0].room_id.ToString();
            JObject rooms = result.data.rooms as JObject;

            List<string> hotelImages = new List<string>();

            if (rooms != null)
            {
                // rooms içindeki anahtarları string olarak al ve roomId ile karşılaştır
                if (rooms.Properties().Any(p => p.Name == roomId) && rooms[roomId]?["photos"] != null)
                {
                    var photos = rooms[roomId]["photos"] as JArray;
                    if (photos != null)
                    {
                        int count = photos.Count < 5 ? photos.Count : 5;
                        for (int i = 0; i < count; i++)
                        {
                            var photo = photos[i];
                            if (photo["url_max1280"] != null)
                            {
                                hotelImages.Add((string)photo["url_max1280"]);
                            }
                        }
                    }
                }
            }

            if (hotelImages.Count == 0)
            {
                hotelImages.Add("varsayilan-fotograf.jpg");
            }

            string bedConfig = "";

            if (result.data.rooms != null &&
                result.data.rooms.ContainsKey(roomId) &&
                result.data.rooms[roomId].bed_configurations != null)
            {
                var bedTypesList = new List<string>();

                foreach (var config in result.data.rooms[roomId].bed_configurations)
                {
                    if (config.bed_types != null)
                    {
                        foreach (var bed in config.bed_types)
                        {
                            if (bed.name_with_count != null)
                            {
                                bedTypesList.Add((string)bed.name_with_count);
                            }
                        }
                    }
                }

                bedConfig = string.Join(" / ", bedTypesList);
            }


            // Facilities listesi için yine lambda kullanmadan döngü ile:

            List<string> facilities = new List<string>();
            if (result.data.facilities_block != null && result.data.facilities_block.facilities != null)
            {
                foreach (var f in result.data.facilities_block.facilities)
                {
                    if (f.name != null)
                        facilities.Add((string)f.name);
                }
            }

            return new HotelDetailViewModel
            {
                HotelId = hotelId,
                HotelName = result.data.hotel_name,
                RoomId = roomId,
                HotelImages = hotelImages,
                Address = result.data.address,
                PricePerNight = (decimal)result.data.product_price_breakdown.gross_amount_per_night.value,
                WebSiteUrl = result.data.url,
                Description = rooms != null && rooms.ContainsKey(roomId) && rooms[roomId]["description"] != null
                    ? (string)rooms[roomId]["description"]
                    : "Açıklama mevcut değil.",
                AvailableRoomCount = result.data.available_rooms,
                Facilities = facilities,
                BedConfig = bedConfig,
                RoomSize = result.data.average_room_size_for_ufi_m2,
                Latitude = result.data.latitude,
                Longitude = result.data.longitude,
                DistanceToCityCenterKm = result.data.distance_to_cc,
                SpokenLanguages = spokenLanguages
            };
        }
    }
}
