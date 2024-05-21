using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationLumia.DAL;
using WebApplicationLumia.Models;

namespace WebApplicationLumia.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext dbcontext;

        public HomeController(AppDbContext dbContext)
        {
            this.dbcontext = dbContext;
        }

        public IActionResult Index()
        {
            return View(dbcontext.Teams.ToList());
        }

    }
}