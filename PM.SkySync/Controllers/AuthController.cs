using Microsoft.AspNetCore.Mvc;
using PM.Entities.Models;

namespace PM.SkySync.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            ViewBag.link = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            return Json(new { status = 1 });
        }
    }
}
