using Microsoft.AspNetCore.Mvc;

namespace RapidApi_HotelFinder.ViewComponents
{
    public class _UIScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
