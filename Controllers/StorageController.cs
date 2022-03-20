using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Balkhanakovv.WebStorage.Controllers
{
    public class StorageController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
