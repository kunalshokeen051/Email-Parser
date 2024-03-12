using Microsoft.AspNetCore.Mvc;
using System.Data;
using PM.SkySync.Filter;

namespace PM.SkySync.Controllers
{
    public class HomeController : Controller
    {
        public readonly IDbConnection _db;

        public HomeController(IDbConnection dbConnection)
        {
            _db = dbConnection;
        }

        [CheckAuth]
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
