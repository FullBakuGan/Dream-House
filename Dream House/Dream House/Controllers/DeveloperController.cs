using Microsoft.AspNetCore.Mvc;

namespace Dream_House.Controllers
{
    public class DeveloperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
