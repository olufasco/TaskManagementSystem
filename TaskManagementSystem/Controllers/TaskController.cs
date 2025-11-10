using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    [Authorize(Roles = "Member")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly UserManager<ApplicationUser> _userManager;

        public TaskController(ITaskService taskService, UserManager<ApplicationUser> userManager)
        {
            _taskService = taskService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var tasks = await _taskService.GetUserTasks(userId);
            return View(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            task.UserId = _userManager.GetUserId(User);
            await _taskService.CreateTask(task);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskService.DeleteTask(id);
            return RedirectToAction("Index");
        }
    }
}