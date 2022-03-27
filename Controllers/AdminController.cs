using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Balkhanakovv.WebStorage.Services.StorageService;

namespace Balkhanakovv.WebStorage.Controllers
{
    public class AdminController : Controller
    {
        private readonly StorageService _storageService;

        public AdminController(StorageService storageService)
        {
            _storageService = storageService;
        }

        [Authorize]
        public IActionResult AdminPage()
        {
            return View();
        }

        public void SetDocumentPath(string path)
        {
            if (!String.IsNullOrWhiteSpace(path))
            {
                _storageService.StoragePathString = path;
            }
        }
    }
}
