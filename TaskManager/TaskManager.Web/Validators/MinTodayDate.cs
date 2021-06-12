using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
