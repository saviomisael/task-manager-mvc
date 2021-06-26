using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskManager.Web.Controllers;
using TaskManager.Web.Repositories.Contracts;
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
    }
}
