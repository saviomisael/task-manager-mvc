using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Web.Validators
{
    public class MinTodayDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = (DateTime)value;

            return date >= DateTime.Now ? ValidationResult.Success : new ValidationResult("Você deve informar uma data maior ou igual a data de hoje.");
        }
    }
}
