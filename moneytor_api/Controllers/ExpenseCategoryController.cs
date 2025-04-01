using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moneytor_api.DbContexts;
using moneytor_api.Models;

namespace moneytor_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseCategoryController(MoneytorDbContext expensesCategoryContext) : ControllerBase
    {
        private readonly MoneytorDbContext _context = expensesCategoryContext;

        /*
         * Retrieve list of all registered Active Expenses Categories
         */
        [HttpGet]
        public async Task<ActionResult<List<ExpenseCategoryModel>>> GetExpensesCategories()
        {
            return Ok(await _context.ExpenseCategory.ToListAsync());
        }

        /*
         * Retrieve a single expense category by code (Primary Key)
         */
        [HttpGet("{code}")]
        public async Task<ActionResult<ExpenseCategoryModel>> GetExpensesCategoryByCode(string code)
        {
            var category = await _context.ExpenseCategory.FindAsync(code);
            if (category is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }
    }
}
