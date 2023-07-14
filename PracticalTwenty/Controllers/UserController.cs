using Microsoft.AspNetCore.Mvc;
using PracticalTwenty.Data.Interfaces;
using PracticalTwenty.Data.Models;
using ILogger = Serilog.ILogger;

namespace PracticalTwenty.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        public UserController(IUnitOfWork unitOfWork, ILogger logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> IndexAsync()
        {
            for (int i = 0; i < 100; i++)
            {
                _logger.Information("Serilog loop {@loopcount}", i);
            }
            var users = await _unitOfWork.Users.GetAll();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var users = await _unitOfWork.Users.GetById(id);
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            return View(new User());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(User user)
        {
            if (ModelState.IsValid)
            {
                bool isInserted = await _unitOfWork.Users.Insert(user);
                await _unitOfWork.CompleteAsync();
                if (isInserted)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            User user = await _unitOfWork.Users.GetById(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(User user)
        {
            if (!ModelState.IsValid) return View(user);

            bool isUpdated = await _unitOfWork.Users.Update(user);
            await _unitOfWork.CompleteAsync();
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "User");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool isDeleted = await _unitOfWork.Users.Delete(id);
            await _unitOfWork.CompleteAsync();
            if (isDeleted) return RedirectToAction("Index");
            return RedirectToAction("Error", "User");
        }
    }
}