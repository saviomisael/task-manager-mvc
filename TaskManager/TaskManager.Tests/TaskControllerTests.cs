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
    }
}
