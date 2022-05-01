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

        public int[] DownloadFile(string path)
        {
            var byteArray = System.IO.File.ReadAllBytes(path);
            return byteArray.Select(x => (int)x).ToArray();
        }

        [HttpPost]
        public IActionResult UploadFiles(IFormFileCollection uploads, bool isShared, int documentType)
        {
            if (ModelState.IsValid)
            {
                User? user = _db.Users.FirstOrDefault(x => x.Name == User.Identity.Name);
                if (user != null)
                {
                    string path = _storageService.StoragePathString + '/' + user.Name;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    foreach (var uploadedFile in uploads)
                    {
                        path = _storageService.StoragePathString + '/' + user.Name;

                        Document document = new Document()
                        {
                            UserId = user.Id,
                            Name = uploadedFile.FileName,
                            Size = (double)uploadedFile.Length / 1024.0 / 1024.0,
                            Path = path,
                            TypeId = documentType,
                            IsShared = isShared
                        };

                        if (user.MemorySize + document.Size > _db.Rates.Where(xx => xx.Id == user.RateId).FirstOrDefault()?.Size)
                        {
                            ModelState.AddModelError("", "Недостаточно места");
                            return View("Index");
                        }

                        user.MemorySize += document.Size;

                        path += '/' + uploadedFile.FileName;
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            uploadedFile.CopyTo(fileStream);
                        }

                        _db.Documents.Add(document);
                        _db.SaveChanges();
                    }
                }
            }
            ModelState.AddModelError("", "Все файлы успешно загружены");
            return View("Index");
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteFile(int fileId)
        {
            var document = _db.Documents.Where(x => x.Id == fileId)?.FirstOrDefault();

            var user = _db.Users.Where(x => x.Id == document.UserId).FirstOrDefault();
            user.MemorySize -= document.Size;
            _db.SaveChanges();
            
            _db.Documents.Remove(document);
            _db.SaveChanges();            

            return PartialView("~/Views/Home/PartialFileTable.cshtml", _db.Documents.ToList());
        }
    }
}
