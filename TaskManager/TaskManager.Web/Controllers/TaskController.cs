using Microsoft.AspNetCore.Mvc;
using TaskManager.Web.Repositories.Contracts;
using TaskManager.Web.ViewModels;

namespace TaskManager.Web.Controllers
{
    [Route("tarefas")]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [Route("criar-tarefa")]
        [HttpGet]
        public IActionResult CreateTask()
        {
            var viewModel = new CreateTaskViewModel();

            return View(viewModel);
        }

        [Route("criar-tarefa")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTask(CreateTaskViewModel viewModel)
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
