using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Balkhanakovv.WebStorage.Services.StoragePathService;

namespace Balkhanakovv.WebStorage.Controllers
{
    public class AdminController : Controller
    {
        private readonly IStorageService _storageService;

        public AdminController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [Authorize]
        public IActionResult AdminPage()
        {
            if (User.Identity.Name == "admin")
            {
                return View();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult SetDocumentPath(string path)
        {
            if (!String.IsNullOrWhiteSpace(path))
            {
                _storageService.StoragePathString = path;
            }

            return RedirectToAction("AdminPage", "Admin");
        }
    }
}
