using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moneytor_api.DbContexts;
using moneytor_api.Models;
using moneytor_api.Models.MasterModels;

namespace moneytor_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyBudgetController(MoneytorDbContext MoneytorContext) : ControllerBase
    {
        private readonly MoneytorDbContext _context = MoneytorContext;

        /*
         * Add a new monthly budget
         */
        [HttpGet]
        public async Task<ActionResult<List<FundSourceModel>>> AddMonthlyBudget()
        {
            return Ok(await _context.FundSource.ToListAsync());
        }
    }
}
