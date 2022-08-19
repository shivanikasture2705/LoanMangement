using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanMangement.Models;

namespace LoanMangement.Data
{
    public class LoanMangementContext : DbContext
    {
        public LoanMangementContext (DbContextOptions<LoanMangementContext> options)
            : base(options)
        {
        }

        public DbSet<LoanMangement.Models.AddLoan> AddLoan { get; set; }

        public DbSet<LoanMangement.Models.DisplayLoan> DisplayLoan { get; set; }
    }
}
