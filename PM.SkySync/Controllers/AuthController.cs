using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PM.Entities.Models;
using System.Data.Common;
using System.Security.Claims;

namespace PM.SkySync.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            return Json(new { status = 1});
        }
    }
}
