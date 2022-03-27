using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Balkhanakovv.WebStorage.Models.DB;
using Balkhanakovv.WebStorage.Services.StorageService;

namespace Balkhanakovv.WebStorage.Controllers
{
    public class StorageController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;

        private readonly IStorageService _storageService;

        private readonly WebStorageContext _db;

        public StorageController(IWebHostEnvironment appEnvironment, IStorageService storageService, WebStorageContext db)
        {
            _appEnvironment = appEnvironment;
            _storageService = storageService;
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async void UploadFiles(IFormFileCollection uploads)
        {
            User? user = _db.Users.FirstOrDefault(x => x.Name == User.Identity.Name);
            if (user != null)
            {
                foreach (var uploadedFile in uploads)
                {
                    string path = _storageService.StoragePathString + '/' + uploadedFile.FileName;
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }

                    Document document = new Document() {
                        UserId = user.Id,
                        Name = uploadedFile.FileName,
                        Size = uploadedFile.Length / 1024 / 1024,
                        Path = path,
                        TypeId = 1
                    };

                    _db.Documents.Add(document);
                    _db.SaveChanges();
                }
            }
        }
    }
}
