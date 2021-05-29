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
            if (ModelState.IsValid)
            {
                var model = CreateTaskViewModel.ToTaskModel(viewModel);

                if (_taskRepository.CreateTask(model))
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }

            }
            ModelState.AddModelError("", "Erro ao criar tarefa");

            return View(nameof(CreateTask), viewModel);
        }
    }
}
