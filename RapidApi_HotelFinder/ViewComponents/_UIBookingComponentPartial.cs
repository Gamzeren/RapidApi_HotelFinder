using Microsoft.AspNetCore.Mvc;

namespace RapidApi_HotelFinder.ViewComponents
{
    public class _UIBookingComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
