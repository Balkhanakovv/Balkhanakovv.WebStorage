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
