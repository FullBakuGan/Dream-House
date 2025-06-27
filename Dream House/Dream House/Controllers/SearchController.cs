using Dream_House.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dream_House.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CostFilter(int? min, int? max)
        {
            var ad = _context.ads.Where(a => a.cost >= min && a.cost <= max);
            var resultList = ad.ToList();
            return View(resultList);
        }
        public IActionResult DistrictFilter(string district) 
        {
            var ad = _context.ads.AsQueryable();
            ad = ad.Include(a => a.city_district).Where(c => c.city_district.city_district_name == district);
            return View(ad.ToList());
        }
        public IActionResult RoomsFilter(int count)
        {
            var ad = _context.ads.Where(a => a.count_of_rooms == count);
            return View(ad.ToList());
        }
        //public IActionResult residentialcomplex

    }
}
