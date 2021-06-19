using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using TaskManager.Web.Controllers;
using TaskManager.Web.Models;
using TaskManager.Web.Repositories.Contracts;
using Xunit;

namespace TaskManager.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ShouldReturnListTasks()
        {
            IList<Task> tasks = new List<Task>();
            Category category1 = new Category("Category 1");
            Task task1 = new Task("Test 1", 1, "Description test 1", DateTime.Now, category1);
            tasks.Add(task1);

            Category category2 = new Category("Category 2");
            Task task1 = new Task("Test 1", 1, "Description test 1", DateTime.Now, category1);
            tasks.Add(task1);

            Mock<ITaskRepository> taskRepositoryMock = new Mock<ITaskRepository>();

            taskRepositoryMock.Setup(x => x.ListAllTasks()).Returns(tasks);

            HomeController homeController = new HomeController(taskRepositoryMock.Object);

            var result = homeController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            IEnumerable<Task> modelViewResult = Assert.IsAssignableFrom<IEnumerable<Task>>(viewResult.Model);
        }
    }
}
