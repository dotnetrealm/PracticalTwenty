using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PracticalTwenty.Commons;
using PracticalTwenty.Models;
using System.Diagnostics;

namespace PracticalTwenty.Controllers
{
    [LogMethod]
    public class ErrorController : Controller
    {
        readonly IDictionary<int, string> statusMessages = new Dictionary<int, string>();

        // Predefined messages for diffrent error codes
        public ErrorController()
        {
            statusMessages.Add(401, "User identity was not found!");
            statusMessages.Add(403, "You don't have permission to access this resources!");
            statusMessages.Add(404, "Sorry, the page you are looking for could not be found.");
            statusMessages.Add(500, "Whoops, something went wrong on our servers!");
            statusMessages.Add(503, "Service unavailable!");
        }

        /// <summary>
        /// Redirect to the exception page
        /// </summary>
        /// <returns></returns>
        [Route("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //fetch information about thrown exception
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            string message = exceptionFeature?.Error.Message ?? statusMessages[500];
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                StatusCode = 500,
                Message = message,
                OriginalPath = exceptionFeature?.Path ?? string.Empty,
            });
        }


        /// <summary>
        /// Handles error codes like 404, 403, 401, etc.
        /// </summary>
        [Route("Error/PageNotFound/{statusCode?}")]
        [HttpGet]
        public IActionResult PageNotFound(int statusCode)
        {
            //fetch information about error
            var errorFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            string message = (statusMessages.ContainsKey(statusCode)) ? statusMessages[statusCode] : "Page not found!";
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                StatusCode = statusCode,
                Message = message,
                OriginalPath = errorFeature?.OriginalPath ?? string.Empty,
            });
        }
    }
}
