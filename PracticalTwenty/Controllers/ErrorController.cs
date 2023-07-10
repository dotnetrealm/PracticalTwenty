using Microsoft.AspNetCore.Mvc;
using PracticalTwenty.Models;
using System.Diagnostics;

namespace PracticalTwenty.Controllers
{
    public class ErrorController : Controller
    {

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
