using Balkhanakovv.WebStorage.Models.DB;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace Balkhanakovv.WebStorage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly WebStorageContext _context;

        public HomeController(ILogger<HomeController> logger, WebStorageContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}