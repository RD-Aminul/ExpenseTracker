using Expense_Tracker.Models;
using Expense_Tracker.Models.ViewModels;
using Expense_Tracker.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace Expense_Tracker.Controllers
{
    public class ExpenseController : Controller
    {
        private IExpenseRepository _expenseRepository;
        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public IActionResult Index()
        {
            List<ExpenseViewModel> list = _expenseRepository.GetAllExpenses().ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ExpenseCategories = _expenseRepository.GetAllCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExpenseViewModel obj)
        {
            if (ModelState.IsValid)
            {
                Expense exp = new Expense
                {
                    ExpenseID = obj.ExpenseID,
                    DateOfExpense = obj.DateOfExpense,
                    ExpenseAmount = obj.ExpenseAmount,
                    CategoryID = obj.CategoryID
                };
                _expenseRepository.SaveExpense(exp);
                return RedirectToAction("Index");
            }
            ViewBag.ExpenseCategories = _expenseRepository.GetAllCategories();
            return View();
        }

        public IActionResult Edit(int id)
        {
            ViewBag.ExpenseCategories = _expenseRepository.GetAllCategories();
            Expense exp = _expenseRepository.GetExpenseByID(id);
            ExpenseViewModel viewModel = GetEditExpense(exp);
            return View(viewModel);
        }

        private ExpenseViewModel GetEditExpense(Expense exp)
        {
            ExpenseViewModel viewModel = new ExpenseViewModel
            {
                ExpenseID = exp.ExpenseID,
                DateOfExpense = exp.DateOfExpense,
                ExpenseAmount = exp.ExpenseAmount,
                CategoryID = exp.CategoryID
            };
            return viewModel;
        }

        [HttpPost]
        public IActionResult Edit(ExpenseViewModel obj)
        {
            Expense exp = _expenseRepository.GetExpenseByID(obj.ExpenseID);
            if (ModelState.IsValid)
            {
                exp.DateOfExpense = obj.DateOfExpense;
                exp.ExpenseAmount = obj.ExpenseAmount;
                exp.CategoryID = obj.CategoryID;

                Expense exps = _expenseRepository.UpdateExpense(exp);
                return RedirectToAction("Index");
            }
            ViewBag.ExpenseCategories = _expenseRepository.GetAllCategories();
            ExpenseViewModel viewModel = GetEditExpense(exp);
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            ViewBag.ExpenseCategories = _expenseRepository.GetAllCategories();
            Expense exp = _expenseRepository.GetExpenseByID(id);
            ExpenseViewModel viewModel = GetEditExpense(exp);
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult PoDelete(int id)
        {
            _expenseRepository.DeleteExpense(id);
            return RedirectToAction("Index");
        }
    }
}