using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Balkhanakovv.WebStorage.Services.StoragePathService;
using Balkhanakovv.WebStorage.Models.DB;
using Balkhanakovv.WebStorage.ViewModels;

namespace Balkhanakovv.WebStorage.Controllers
{
    public class AdminController : Controller
    {
        private readonly IStorageService _storageService;

        private readonly WebStorageContext _db;

        public AdminController(IStorageService storageService, WebStorageContext db)
        {
            _storageService = storageService;
            _db = db;
        }

        [Authorize]
        public IActionResult AdminPage()
        {
            if (User?.Identity?.Name == "admin")
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

        [HttpPost]
        public IActionResult PartialChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(User?.Identity?.Name))
                {
                    return RedirectToAction("AdminPage", "Admin");
                }

                var user = _db.Users.Where(x => x.Name == User.Identity.Name).FirstOrDefault();

                if (user?.Password != model.OldPassword)
                {
                    ModelState.AddModelError("", "Введен не правильный текущий пароль");
                }

                if (model.NewPassword != model.RepeatPassword)
                {
                    ModelState.AddModelError("", "Неверно повторили пароль");
                }

                if (user?.Password == model.OldPassword && model.NewPassword == model.RepeatPassword)
                {
                    user.Password = model.NewPassword;

                    _db.SaveChanges();
                    ModelState.AddModelError("", "Пароль успешно изменен");
                    return PartialView("PartialChangePassword", model);
                }
            }
            return PartialView("PartialChangePassword", model);
        }

        [HttpPost]
        public void RestorePassword(int userId)
        {

        }
    }
}
