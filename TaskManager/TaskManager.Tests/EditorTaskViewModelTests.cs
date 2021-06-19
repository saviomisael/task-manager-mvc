using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Web.Models;
using TaskManager.Web.ViewModels;
using Xunit;

namespace TaskManager.Tests
{
    public class EditorTaskViewModelTests
    {
        [Fact]
        public void ToViewModel_ShouldReturnEditorTaskViewModel()
        {
            var category = new Category("category 1");
            var task = new Task("task 1", 1, "Descrition task 1", DateTime.Now, category);

            var result = EditorTaskViewModel.ToViewModel(task);

            Assert.IsType<EditorTaskViewModel>(result);

            Assert.Equal(category.CategoryName, result.CategoryName);

            Assert.Equal(task.TaskName, result.TaskName);
            Assert.Equal(task.TaskPriority, result.TaskPriority);
            Assert.Equal(task.TaskDescription, result.TaskDescription);
            Assert.Equal(task.TaskDate, result.TaskDate);
        }

        [Fact]
        public void ToViewModel_ShouldThrowException_WhenModelParameterIsNull()
        {
            Assert.Throws<NullReferenceException>(() => EditorTaskViewModel.ToViewModel(null));
        }
    }
}
