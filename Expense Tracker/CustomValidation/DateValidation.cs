using System;
using System.ComponentModel.DataAnnotations;


namespace Expense_Tracker.CustomValidation
{
    public class DateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime CurrentDate = DateTime.Now;
            string msg = string.Empty;
            if (Convert.ToDateTime(value).Date <= CurrentDate.Date)
            {
                return ValidationResult.Success;
            }
            else
            {
                msg = "Can't record any expenditure in future date!!";
                return new ValidationResult(msg);
            }
        }
    }
}