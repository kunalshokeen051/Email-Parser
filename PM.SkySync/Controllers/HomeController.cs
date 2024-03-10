using Microsoft.AspNetCore.Mvc;
using System.Data;
using PM.Entities.Models;
using Dapper;
using System.Collections.Generic;

namespace PM.SkySync.Controllers
{
    public class HomeController : Controller
    {
        public readonly IDbConnection _db;

        public HomeController(IDbConnection dbConnection)
        {
            _db = dbConnection;
        }

        //[CheckAuth]
        public IActionResult Index()
        {
            _db.Open();
            var Users = _db.Query<Login>("select * from Login");
            _db.Close();

            return View(Users);
        }
    }
}
