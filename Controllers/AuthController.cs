using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Balkhanakovv.WebStorage.Models.DB;
using Balkhanakovv.WebStorage.ViewModels;

namespace Balkhanakovv.WebStorage.Controllers
{
    public class AuthController : Controller
    {
        private readonly WebStorageContext? _db;

        public AuthController(WebStorageContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _db.Users.FirstOrDefaultAsync(u => u.Name == model.Name && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Name);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _db.Users.FirstOrDefaultAsync(u => u.Name == model.Name);
                if (user == null)
                {
                    _db.Users.Add(new User { 
                        Name = model.Name, 
                        Password = model.Password, 
                        FullName = model.FullName, 
                        GroupId = model.GroupId, 
                        RateId = model.RateId 
                    });
                    await _db.SaveChangesAsync();

                    return RedirectToAction("AdminPage", "Admin");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return RedirectToAction("AdminPage", "Admin");
        }
    }
}
