using Dream_House.Models;
using Dream_House.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Security.Claims;
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

            var (success, firstName, lastName, roleId) = await _authService.AuthenticateUserAsync(model.Email, model.Password);




            if (success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.Name, $"{firstName} {lastName}"),
                    new Claim(ClaimTypes.Role, roleId.ToString()),
            // Другие необходимые claims
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync("Cookies", claimsPrincipal);

                return roleId switch
                {
                    1 => RedirectToAction("Index", "Client"),
                    2 => RedirectToAction("Index", "Realtor"),
                    3 => RedirectToAction("Index", "Developer"),
                    _ => RedirectToAction("Index", "Home")
                };
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

            // Обязательно перезагружаем список ролей при ошибках валидации
            ViewBag.Roles = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Покупатель" },
                new SelectListItem { Value = "2", Text = "Риелтор" },
                new SelectListItem { Value = "3", Text = "Застройщик" }
            };

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var result = await _authService.RegisterUserAsync(model);
                if (!result)
                {
                    ModelState.AddModelError("", "Ошибка регистрации. Возможно, email уже занят.");
                    return View(model);
                }

                return model.RoleId switch
                {
                    1 => RedirectToAction("Index", "Client"),   
                    2 => RedirectToAction("Index", "Realtor"),   
                    3 => RedirectToAction("Index", "Developer"), 
                    _ => RedirectToAction("Index", "Home")         
                };
            }
            catch
            {
                ModelState.AddModelError("", "Произошла ошибка при регистрации");
                return View(model);
            }

        }
    }
}