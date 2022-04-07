using Expense_Tracker.Models;
using Expense_Tracker.Models.ViewModels;
using System.Collections.Generic;

namespace Expense_Tracker.Repositories
{
    public interface IExpenseRepository
    {
        IEnumerable<ExpenseCategoryViewModel> GetAllCategories();
        ExpenseCategory GetCategoryByID(int id);
        ExpenseCategory SaveCategory(ExpenseCategory obj);
        ExpenseCategory UpdateCategory(ExpenseCategory upObj);
        ExpenseCategory DeleteCategory(int id);
        bool GetCategoryByName(string name);

        

        IEnumerable<ExpenseViewModel> GetAllExpenses();
        Expense GetExpenseByID(int id);
        Expense SaveExpense(Expense obj);
        Expense UpdateExpense(Expense upObj);
        Expense DeleteExpense(int id);
    }
}