using Expense_Tracker.CustomValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models.ViewModels
{
    public class ExpenseCategoryViewModel
    {
        [Key]
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Please Insert Category Name")]
        [Remote(action: "IsNameInUse", controller: "ExpenseCategory")]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }
    }

    public class ExpenseViewModel
    {
        [Key]
        [Display(Name = "Expense ID")]
        public int ExpenseID { get; set; }

        [Required(ErrorMessage = "Please Select Category")]
        public int CategoryID { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Date Of Expense")]
        [DataType(DataType.Date)]
        [DateValidation]
        public DateTime DateOfExpense { get; set; }

        [Display(Name = "Expense Amount")]
        public decimal ExpenseAmount { get; set; }
    }
}