using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Balkhanakovv.WebStorage.Models.DB;
using Balkhanakovv.WebStorage.Services.StoragePathService;

namespace Balkhanakovv.WebStorage.Controllers
{
    public class StorageController : Controller
    {
        private readonly IStorageService _storageService;

        private readonly WebStorageContext _db;

        public StorageController(IStorageService storageService, WebStorageContext db)
        {
            _storageService = storageService;
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void UploadFiles(IFormFileCollection uploads)
        {
            User? user = _db.Users.FirstOrDefault(x => x.Name == User.Identity.Name);
            if (user != null)
            {
                string path = _storageService.StoragePathString + '/' + user.Name;
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                foreach (var uploadedFile in uploads)
                {
                    path += '/' + uploadedFile.FileName;
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        uploadedFile.CopyTo(fileStream);
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
