using Microsoft.AspNetCore.Mvc;

namespace Dream_House.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
