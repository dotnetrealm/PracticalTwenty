using Microsoft.AspNetCore.Mvc;
using PracticalTwenty.Commons;
using PracticalTwenty.Data.Interfaces;
using PracticalTwenty.Data.Models;

namespace PracticalTwenty.Controllers
{
    [LogMethod]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all user list
        /// </summary>
        public async Task<IActionResult> IndexAsync()
        {
            var users = await _unitOfWork.Users.GetAll();
            return View(users);
        }

        /// <summary>
        /// Get detailed information of specific user by Id
        /// </summary>
        /// <param name="id">User Id</param>
        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            if (user is null) return NotFound();
            return View(user);
        }

        /// <summary>
        /// Return form for create new user
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            return View(new User());
        }

        /// <summary>
        /// Create new user
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(User user)
        {
            if (ModelState.IsValid)
            {
                bool isInserted = await _unitOfWork.Users.Insert(user);
                await _unitOfWork.CompleteAsync();
                if (!isInserted) return BadRequest("User has not been inserted!");
                return RedirectToAction("Index");
            }
            return View(user);
        }

        /// <summary>
        /// Return forms for update existing user
        /// </summary>
        /// <param name="id">User Id</param>
        [HttpGet]
        
        public async Task<IActionResult> EditAsync(int id)
        {
            User? user = await _unitOfWork.Users.GetById(id);
            if (user is null) return NotFound();
            return View(user);
        }

        /// <summary>
        /// Update existing user
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(User user)
        {
            if (!ModelState.IsValid) return View(user);

            bool isUpdated = await _unitOfWork.Users.Update(user);
            await _unitOfWork.CompleteAsync();

            if (!isUpdated) return BadRequest("User details has not been update.");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id">User Id</param>
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            User? user = await _unitOfWork.Users.GetById(id);
            if (user is null) return NotFound();

            bool isDeleted = await _unitOfWork.Users.Delete(id);
            await _unitOfWork.CompleteAsync();

            if (isDeleted) return RedirectToAction("Index");
            return BadRequest();
        }
    }
}