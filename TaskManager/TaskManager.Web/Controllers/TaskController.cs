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

        [Route("editar-tarefa/{id:int:min(1)}/{taskName}")]
        [HttpGet]
        public IActionResult EditTask([FromRoute] int id, 
            [FromRoute] string taskName)
        {
            var task = _taskRepository.GetById(id);

            if(task == null || task.TaskName != taskName)
            {
                return NotFound();
            }

            return View(EditTaskViewModel.ToViewModel(task));
        }

        [Route("editar-tarefa/{id:int:min(1)}/{taskName}")]
        [HttpPost]
        public IActionResult EditTask([FromRoute] int id, EditTaskViewModel viewModel)
        {
            if(id != viewModel.TaskID)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                if(_taskRepository.UpdateTask(EditTaskViewModel.ToModel(viewModel)))
                {
                    RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }

            ModelState.AddModelError("", "Erro ao atualizar tarefa.");
            return View(viewModel);
        }
    }
}
