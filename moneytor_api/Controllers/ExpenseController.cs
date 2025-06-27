using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moneytor_api.DbContexts;
using moneytor_api.Models.MasterModels;

namespace moneytor_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController(MoneytorDbContext MoneytorContext) : ControllerBase
    {
        private readonly MoneytorDbContext _context = MoneytorContext;

        /*
         * Add a new expense item
         */
        [HttpPost]
        public async Task<ActionResult<List<FundSourceModel>>> AddMonthlyBudget()
        {
            return Ok(await _context.FundSource.ToListAsync());
        }
    }
}
