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

        [Fact]
        public void ToModel_ShouldReturnTaskModel()
        {
            var viewModel = new EditorTaskViewModel()
            {
                CategoryID = 1,
                CategoryName = "category 1",
                TaskID = 1,
                TaskName = "task 1",
                TaskDescription = "description task 1",
                TaskPriority = 1,
                TaskDate = DateTime.Today
            };

            var result = EditorTaskViewModel.ToModel(viewModel);

            Assert.NotNull(result);
            Assert.IsType<Task>(result);

            Assert.NotNull(result.Category);
            Assert.IsType<Category>(result.Category);

            Assert.Equal(viewModel.CategoryID, result.Category.CategoryID);
            Assert.Equal(viewModel.CategoryName, result.Category.CategoryName);

            Assert.Equal(viewModel.TaskID, result.TaskID);
            Assert.Equal(viewModel.TaskName, result.TaskName);
            Assert.Equal(viewModel.TaskDescription, result.TaskDescription);
            Assert.Equal(viewModel.TaskPriority, result.TaskPriority);
            Assert.Equal(viewModel.TaskDate, result.TaskDate);
        }

        [Fact]
        public void ToModel_ShoulThrowException_WhenViewModelParameterIsNull()
        {
            Assert.Throws<NullReferenceException>(() => EditorTaskViewModel.ToModel(null));
        }
    }
}
