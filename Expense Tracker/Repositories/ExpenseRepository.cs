using Expense_Tracker.Models;
using Expense_Tracker.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Expense_Tracker.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _dbContext;
        public ExpenseRepository(AppDbContext Context)
        {
            _dbContext = Context;
        }
        public IEnumerable<ExpenseCategoryViewModel> GetAllCategories()
        {
            List<ExpenseCategoryViewModel> categories = _dbContext.ExpenseCategories.Select(c => new ExpenseCategoryViewModel
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
            }).ToList();
            return categories;
        }

        public ExpenseCategory GetCategoryByID(int id)
        {
           ExpenseCategory category = _dbContext.ExpenseCategories.Find(id);
            return category;
        }

        public ExpenseCategory SaveCategory(ExpenseCategory obj)
        {
           _dbContext.ExpenseCategories.Add(obj);
           _dbContext.SaveChanges();
            return obj;
        }

        public ExpenseCategory UpdateCategory(ExpenseCategory upObj)
        {
           var upCategory = _dbContext.ExpenseCategories.Attach(upObj);
           upCategory.State = EntityState.Modified;
           _dbContext.SaveChanges();
           return upObj;
        }

        public ExpenseCategory DeleteCategory(int id)
        {
           ExpenseCategory delCategory = GetCategoryByID(id);
            _dbContext.ExpenseCategories.Remove(delCategory);
            _dbContext.SaveChanges();
            return delCategory;
        }

        public bool GetCategoryByName(string name)
        {
            ExpenseCategory category = _dbContext.ExpenseCategories.Where(c => c.CategoryName == name).FirstOrDefault();
            if (category != null)
            {
                return true;
            }
            return false;
        }

        



        public IEnumerable<ExpenseViewModel> GetAllExpenses()
        {
            IEnumerable <ExpenseViewModel> exp = _dbContext.Expenses.Select(e => new ExpenseViewModel
            {
                ExpenseID = e.ExpenseID,
                DateOfExpense = e.DateOfExpense,
                ExpenseAmount = e.ExpenseAmount,
                CategoryID = e.CategoryID,
                CategoryName = e.ExpenseCategory.CategoryName
            }).ToList();
            return exp;
        }

        public Expense GetExpenseByID(int id)
        {
            Expense exp = _dbContext.Expenses.Find(id);
            return exp;
        }

        public Expense SaveExpense(Expense obj)
        {
            _dbContext.Expenses.Add(obj);
            _dbContext.SaveChanges();
            return obj;
        }

        public Expense UpdateExpense(Expense upObj)
        {
            var upExp = _dbContext.Expenses.Attach(upObj);
            upExp.State = EntityState.Modified;
            _dbContext.SaveChanges();
            return upObj;
        }

        public Expense DeleteExpense(int id)
        {
            Expense delExp = GetExpenseByID(id);
            _dbContext.Expenses.Remove(delExp);
            _dbContext.SaveChanges();
            return delExp;
        }
    }
}