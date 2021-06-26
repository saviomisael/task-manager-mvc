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
        [Fact]
        public void CreateTask_ShouldReturnViewResult()
        {
            var taskRepositoryMock = new Mock<ITaskRepository>();

            var taskController = new TaskController(taskRepositoryMock.Object);

            var result = taskController.CreateTask();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CreateTask_ShouldReturnModelTypeAsEditorTaskViewModel()
        {
            var taskRepositoryMock = new Mock<ITaskRepository>();

            var taskController = new TaskController(taskRepositoryMock.Object);

            var result = taskController.CreateTask();

            Assert.IsType<EditorTaskViewModel>(result.Model);
        }
    }
}
