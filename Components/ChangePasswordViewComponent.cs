using Microsoft.AspNetCore.Mvc;

namespace Balkhanakovv.WebStorage.Components
{
    public class ChangePasswordViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
