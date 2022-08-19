using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanMangement.Models
{
    public class AddLoan
    {
        [Key]
        public int LoanId { get; set; }
        public string Name { get; set; }
        public string LoanType { get; set; }
        public Decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
