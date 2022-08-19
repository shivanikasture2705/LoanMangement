using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanMangement.Data;
using LoanMangement.Models;

namespace LoanMangement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddLoansController : ControllerBase
    {
        private readonly LoanMangementContext _context;

        public AddLoansController(LoanMangementContext context)
        {
            _context = context;
        }

        // GET: api/AddLoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddLoan>>> GetAddLoan()
        {
            return await _context.AddLoan.ToListAsync();
        }

        // GET: api/AddLoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddLoan>> GetAddLoan(int id)
        {
            var addLoan = await _context.AddLoan.FindAsync(id);

            if (addLoan == null)
            {
                return NotFound();
            }

            return addLoan;
        }

        // PUT: api/AddLoans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddLoan(int id, AddLoan addLoan)
        {
            if (id != addLoan.LoanId)
            {
                return BadRequest();
            }

            _context.Entry(addLoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddLoanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AddLoans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddLoan>> PostAddLoan(AddLoan addLoan)
        {
            _context.AddLoan.Add(addLoan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddLoan", new { id = addLoan.LoanId }, addLoan);
        }

        // DELETE: api/AddLoans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddLoan(int id)
        {
            var addLoan = await _context.AddLoan.FindAsync(id);
            if (addLoan == null)
            {
                return NotFound();
            }

            _context.AddLoan.Remove(addLoan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddLoanExists(int id)
        {
            return _context.AddLoan.Any(e => e.LoanId == id);
        }
    }
}
