using Expense_Tracker.Models;
using Expense_Tracker.Models.ViewModels;
using Expense_Tracker.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Expense_Tracker.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        private IExpenseRepository _expenseRepository;
        public ExpenseCategoryController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public IActionResult Index()
        {
            return View(_expenseRepository.GetAllCategories());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExpenseCategoryViewModel obj)
        {
            if (ModelState.IsValid)
            {
                ExpenseCategory category = new ExpenseCategory
                {
                    CategoryID = obj.CategoryID,
                    CategoryName = obj.CategoryName
                };
                _expenseRepository.SaveCategory(category);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ExpenseCategory category = _expenseRepository.GetCategoryByID(id);
            ExpenseCategoryViewModel viewModel = GetEditCategory(category);
            return View(viewModel);
        }

        private ExpenseCategoryViewModel GetEditCategory(ExpenseCategory category)
        {
            ExpenseCategoryViewModel viewModel = new ExpenseCategoryViewModel
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName
            };
            return viewModel;
        }

        [HttpPost]
        public IActionResult Edit(ExpenseCategoryViewModel obj)
        {
            ExpenseCategory category = _expenseRepository.GetCategoryByID(obj.CategoryID);
            if (ModelState.IsValid)
            {
                category.CategoryName = obj.CategoryName;

                ExpenseCategory expCategory = _expenseRepository.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            ExpenseCategoryViewModel viewModel = GetEditCategory(category);
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            ExpenseCategory category = _expenseRepository.GetCategoryByID(id);
            ExpenseCategoryViewModel viewModel = GetEditCategory(category);
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult PoDelete(int id)
        {
            _expenseRepository.DeleteCategory(id);
            return RedirectToAction("Index");
        }

        [AcceptVerbs("Get", "Post")]
        public JsonResult IsNameInUse(string CategoryName)
        {
            bool category = _expenseRepository.GetCategoryByName(CategoryName);
            if (category)
            {
                return Json($"'{CategoryName}' is already Exists...!!");
            }
            else
            {
                return Json(true);
            }
        }
    }
}