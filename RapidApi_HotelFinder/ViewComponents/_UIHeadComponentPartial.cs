using Microsoft.AspNetCore.Mvc;

namespace RapidApi_HotelFinder.ViewComponents
{
    public class _UIHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
