using Microsoft.EntityFrameworkCore;
using Expense_Tracker.Models.ViewModels;

namespace Expense_Tracker.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    }
}