using Balkhanakovv.WebStorage.Models.DB;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Balkhanakovv.WebStorage.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebStorageContext _db;

        public HomeController(WebStorageContext db)
        {
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = _db.Users.FirstOrDefault(x => x.Name == User.Identity.Name);
            if (user == null)
            {
                return null;
            }

            var files = _db.Documents.Where(x => x.UserId == user.Id || x.IsShared == true).ToList();
            return View(files);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}