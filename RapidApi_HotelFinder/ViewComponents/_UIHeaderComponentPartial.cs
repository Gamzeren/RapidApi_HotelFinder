using Microsoft.AspNetCore.Mvc;

namespace RapidApi_HotelFinder.ViewComponents
{
    public class _UIHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
