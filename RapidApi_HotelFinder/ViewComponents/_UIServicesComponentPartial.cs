using Microsoft.AspNetCore.Mvc;

namespace RapidApi_HotelFinder.ViewComponents
{
    public class _UIServicesComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
