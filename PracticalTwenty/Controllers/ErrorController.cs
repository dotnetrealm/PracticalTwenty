using Microsoft.AspNetCore.Mvc;
using PracticalTwenty.Commons;
using PracticalTwenty.Models;
using System.Diagnostics;

namespace PracticalTwenty.Controllers
{
    [LogMethod]
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
