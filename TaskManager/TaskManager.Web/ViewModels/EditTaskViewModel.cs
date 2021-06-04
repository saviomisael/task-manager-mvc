using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using TaskManager.Web.Common;
using TaskManager.Web.Models;

namespace TaskManager.Web.ViewModels
{
    public class EditTaskViewModel
    {
        public int TaskID { get; set; }

        public int CategoryID { get; set; }

        [Required(ErrorMessage = "A tarefa deve ter um nome.")]
        [StringLength(50, ErrorMessage = "O nome da tarefa só pode conter até 50 caracteres.")]
        [Display(Name = "Nome da Tarefa")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "A tarefa deve ter uma prioridade.")]
        [Range(1, 3, ErrorMessage = "Valor da prioridade é inválido.")]
        [Display(Name = "Prioridade")]
        public int TaskPriority { get; set; }
        public SelectList Priorities { get; set; }

        [Required(ErrorMessage = "A tarefa deve conter uma descrição.")]
        [StringLength(8000, ErrorMessage = "A descrição só permite até 8000 caracteres.")]
        [Display(Name = "Descrição")]
        public string TaskDescription { get; set; }

        [Required(ErrorMessage = "A tarefa deve conter uma data.")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data incorreto")]
        [Display(Name = "Data da tarefa")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime TaskDate { get; set; }

        [Required(ErrorMessage = "A tarefa deve conter uma categoria")]
        [StringLength(50, ErrorMessage = "A categoria da tarefa só permite até 50 caracteres.")]
        [Display(Name = "Categoria da tarefa")]
        public string CategoryName { get; set; }

        public EditTaskViewModel()
        {
            TaskDate = DateTime.Now;
            Priorities = Priority.ReturnPrioritiesForSelectList();
        }

        public static EditTaskViewModel ToViewModel(Task model)
        {
            return new EditTaskViewModel()
            {
                TaskID = model.TaskID,
                TaskDate = model.TaskDate,
                TaskDescription = model.TaskDescription,
                TaskName = model.TaskName,
                TaskPriority = model.TaskPriority,
                CategoryID = model.Category.CategoryID,
                CategoryName = model.Category.CategoryName
            };
        }

        public static Task ToModel(EditTaskViewModel viewModel)
        {
            var category = new Category()
            {
                CategoryID = viewModel.CategoryID,
                CategoryName = viewModel.CategoryName
            };

            return new Task()
            {
                TaskID = viewModel.TaskID,
                TaskName = viewModel.TaskName,
                TaskDescription = viewModel.TaskDescription,
                TaskDate = viewModel.TaskDate,
                TaskPriority = viewModel.TaskPriority,
                CategoryFK = viewModel.CategoryID,
                Category = category
            };
        }
    }
}
