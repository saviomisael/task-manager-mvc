using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using TaskManager.Web.Controllers;
using TaskManager.Web.Repositories.Contracts;
using TaskManager.Web.ViewModels;
using Xunit;

namespace TaskManager.Tests
{
    public class TaskControllerTests
    {
        private readonly Mock<ITaskRepository> _taskRepositoryMock;

        public TaskControllerTests()
        {
            _taskRepositoryMock = new Mock<ITaskRepository>();
        }

        [Fact]
        public void CreateTask_ShouldReturnViewResult()
        {
            var taskController = new TaskController(_taskRepositoryMock.Object);

            var result = taskController.CreateTask();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CreateTask_ShouldReturnModelTypeAsEditorTaskViewModel()
        {
            var taskController = new TaskController(_taskRepositoryMock.Object);

            var result = taskController.CreateTask();

            Assert.IsType<EditorTaskViewModel>(result.Model);
        }

        [Fact]
        public void CreateTask_ShouldCreateTask_WhenViewModelIsValid()
        {
            var taskController = new TaskController(_taskRepositoryMock.Object);

            var viewModel = new EditorTaskViewModel()
            {
                CategoryID = 1,
                CategoryName = "Category 1",
                TaskDate = DateTime.Today,
                TaskName = "task 1",
                TaskDescription = "Description task 1",
                TaskPriority = 1
            };

            var model = EditorTaskViewModel.ToModel(viewModel);

            _taskRepositoryMock.Setup(x => x.CreateTask(model)).Returns(true);

            var action = taskController.CreateTask(viewModel);

            var resultAction = Assert.IsType<RedirectToActionResult>(action);

            Assert.Equal(nameof(HomeController.Index), resultAction.ActionName);
            Assert.Equal("Home", resultAction.ControllerName);
        }
    }
}
