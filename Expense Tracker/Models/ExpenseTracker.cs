using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class ExpenseCategory
    {
        [Key]
        public int CategoryID { get; set; }

        [Required, MaxLength(25)]
        public string CategoryName { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }

    public class Expense
    {
        [Key]
        public int ExpenseID { get; set; }

        [Required]
        public DateTime DateOfExpense { get; set; }

        [Required]
        public decimal ExpenseAmount { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ExpenseCategory ExpenseCategory { get; set; }
    }
}