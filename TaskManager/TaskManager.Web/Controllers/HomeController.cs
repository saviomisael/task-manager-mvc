using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManager.Web.Models;
using TaskManager.Web.Repositories.Contracts;

namespace TaskManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public HomeController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public ViewResult Index()
        {
            var allTasks = _taskRepository.ListAllTasks();

            return View(allTasks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
