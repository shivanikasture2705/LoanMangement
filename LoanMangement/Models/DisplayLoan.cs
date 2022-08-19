using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanMangement.Models
{
    public class DisplayLoan
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LoanType { get; set; }
        public Decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public ICollection<AddLoan> LoanId { get; set; }
    }
}
