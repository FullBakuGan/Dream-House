using Dream_House.Models;
using Dream_House.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Threading.Tasks;

namespace Dream_House.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "Вход";
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            ViewBag.Title = "Вход";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, firstName, lastName) = await _authService.AuthenticateUserAsync(model.Email, model.Password);

            if (success)
            {
                return RedirectToAction("Welcome", new { firstName, lastName });
            }

            ModelState.AddModelError(string.Empty, "Неверный email или пароль");
            return View(model);
        }

        [HttpGet]
        public IActionResult Welcome(string firstName, string lastName)
        {
            ViewBag.Title = "Добро пожаловать";
            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roles = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Покупатель" },
                new SelectListItem { Value = "2", Text = "Риелтор" },
                new SelectListItem { Value = "3", Text = "Застройщик" },
                new SelectListItem { Value = "4", Text = "Администратор" }
            };
            ViewBag.Roles = roles;

            return View(new RegisterViewModel { RoleId = 1 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            ViewBag.Title = "Регистрация";

            if (ModelState.IsValid)
            {
                model.DateOfBirth = DateTime.SpecifyKind(model.DateOfBirth, DateTimeKind.Unspecified); // Устанавливаем Kind=Unspecified
                var result = await _authService.RegisterUserAsync(model);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Ошибка регистрации. Пользователь с таким email уже существует.");
            }
            return View(model);
        }
    }
}