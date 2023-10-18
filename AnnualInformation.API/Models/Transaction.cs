using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnnualInformation.API.Models
{
    public class Transaction : BaseModel
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public int BranchId { get; set; }
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        public int TransactionType { get; set; }
        public Guid TransactionIdentifier { get; set; }
        public DateTime TransactionDate { get; set; }
        
        // Navigation properties
        public Customer Customer { get; set; }
        public Branch Branch { get; set; }
    }
}
