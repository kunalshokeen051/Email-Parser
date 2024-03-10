using Microsoft.AspNetCore.Mvc;

namespace PM.SkySync.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
