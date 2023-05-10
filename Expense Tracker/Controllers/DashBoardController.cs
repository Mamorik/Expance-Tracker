using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Controllers
{
    public class DashBoardController : Controller
    {

        private readonly ApplicationDbContext _context;
        public DashBoardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            List<Transaction> SelectedTransaction = await _context.Transactions
                .Include(x => x.Category)
                .Where(y => y.Date >= StartDate && y.Date <= EndDate)
                .ToListAsync();

            int totalIncome = SelectedTransaction
                .Where(i => i.Category.Type == "Доходы")
                .Sum(j => j.Amount);

            ViewBag.TotalIncome = totalIncome.ToString("C0");

            int totalExpense = SelectedTransaction
                .Where(i => i.Category.Type == "Расходы")
                .Sum(j => j.Amount);

            ViewBag.TotalExpense = totalExpense.ToString("C0");

            int Balance = totalIncome - totalExpense;
            ViewBag.Balance = Balance.ToString("C0");

            return View();
        }
    }
}
