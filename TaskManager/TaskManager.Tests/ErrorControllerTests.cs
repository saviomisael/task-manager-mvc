using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Web.Controllers;
using Xunit;

namespace TaskManager.Tests
{
    public class ErrorControllerTests
    {
        [Fact]
        public void ErrorStatusCode_ShouldReturnViewResult()
        {
            ErrorController errorController = new ErrorController();

            var result = errorController.ErrorStatusCode(404);

            Assert.IsType<ViewResult>(result);
        }
    }
}
