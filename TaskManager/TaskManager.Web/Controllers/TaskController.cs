using Microsoft.AspNetCore.Mvc;
using TaskManager.Web.Models;
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
            var viewModel = new EditorTaskViewModel();

            return View(viewModel);
        }

        [Route("criar-tarefa")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTask(EditorTaskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = EditorTaskViewModel.ToModel(viewModel);

                if (_taskRepository.CreateTask(model))
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }

            }
            ModelState.AddModelError("", "Erro ao criar tarefa");

            return View(nameof(CreateTask), viewModel);
        }

        [Route("editar-tarefa/{id:int:min(1)}/{taskName}")]
        [HttpGet]
        public IActionResult EditTask([FromRoute] int id,
            [FromRoute] string taskName)
        {
            var task = _taskRepository.GetById(id);

            if (task == null || task.TaskName != taskName)
            {
                return NotFound();
            }

            return View(EditorTaskViewModel.ToViewModel(task));
        }

        [Route("editar-tarefa/{id:int:min(1)}/{taskName}")]
        [HttpPost]
        public IActionResult EditTask([FromRoute] int id, EditorTaskViewModel viewModel)
        {
            if (id != viewModel.TaskID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (_taskRepository.UpdateTask(EditorTaskViewModel.ToModel(viewModel)))
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }

            ModelState.AddModelError("", "Erro ao atualizar tarefa.");
            return View(viewModel);
        }

        [Route("excluir-tarefa")]
        [HttpPost]
        public IActionResult DeleteTask(int taskId, int categoryId)
        {
            var task = _taskRepository.GetById(taskId);

            if (task is null || task.Category.CategoryID != categoryId)
            {
                return NotFound();
            }

            if (_taskRepository.DeleteTask(task))
            {
                ViewData["resultMessage"] = $"Tarefa {task.TaskName} excluída com sucesso.";

                return View();
            }

            ViewData["resultMessage"] = "Erro ao excluir tarefa.";

            return View();
        }
    }
}
