using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moneytor_api.DbContexts;
using moneytor_api.Models;

namespace moneytor_api.Controllers
{
    //Temporary Class for userInfo:
    public class UserInfo()
    {
        public string UserName { get; set; } = "moneytor_admin";
    }

    //Temporary Class for MoneytorTransactionStatus
    public class MoneytorTransactionStatus
    {
        string Active = "A";
        string Cancelled = "C";
    }

    [Route("Moneytor/[controller]")]
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
            return Ok(await _context.ExpenseCategory
                .Include(et => et.ExpenseType)
                .Include(dt => dt.DeductionType)
                .Include(bt => bt.BudgetType)
                //.Where(ec => ec.Status != MoneytorTransactionStatus.Cancelled //TODO: FIX This using Enum
                //    && ec.UserId == UserInfo.Username) //TODO: Cix using authentication
                .ToListAsync());
        }

        /*
         * Retrieve a single expense category by code (Primary Key)
         */
        [HttpGet("{code}")]
        public async Task<ActionResult<ExpenseCategoryModel>> GetExpensesCategoryByCode(string code)
        {
            var category = await _context.ExpenseCategory
                .Include(bc => bc.ExpenseType)
                .Include(bc => bc.DeductionType)
                .Include(bc => bc.BudgetType)
                .FirstOrDefaultAsync(category => category.Code == code);
                
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
