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
    public class DisplayLoansController : ControllerBase
    {
        private readonly LoanMangementContext _context;

        public DisplayLoansController(LoanMangementContext context)
        {
            _context = context;
        }

        // GET: api/DisplayLoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisplayLoan>>> GetDisplayLoan()
        {
            return await _context.DisplayLoan.ToListAsync();
        }

        // GET: api/DisplayLoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisplayLoan>> GetDisplayLoan(int id)
        {
            var displayLoan = await _context.DisplayLoan.FindAsync(id);

            if (displayLoan == null)
            {
                return NotFound();
            }

            return displayLoan;
        }

        // PUT: api/DisplayLoans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisplayLoan(int id, DisplayLoan displayLoan)
        {
            if (id != displayLoan.Id)
            {
                return BadRequest();
            }

            _context.Entry(displayLoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisplayLoanExists(id))
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

        // POST: api/DisplayLoans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DisplayLoan>> PostDisplayLoan(DisplayLoan displayLoan)
        {
            _context.DisplayLoan.Add(displayLoan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisplayLoan", new { id = displayLoan.Id }, displayLoan);
        }

        // DELETE: api/DisplayLoans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisplayLoan(int id)
        {
            var displayLoan = await _context.DisplayLoan.FindAsync(id);
            if (displayLoan == null)
            {
                return NotFound();
            }

            _context.DisplayLoan.Remove(displayLoan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisplayLoanExists(int id)
        {
            return _context.DisplayLoan.Any(e => e.Id == id);
        }
    }
}
