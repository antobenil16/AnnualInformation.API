using System.ComponentModel.DataAnnotations.Schema;

namespace AnnualInformation.API.Models
{
    public class Customer : CommonModel
    {       
        [ForeignKey("Branch")]
        public int BranchId { get; set; } // This is home branch for the customer
        public Branch Branch { get; set; }
        public int AccountNumber { get; set; }
        public List<Transaction> SentTransactions { get; set; }
        public List<Transaction> ReceivedTransactions { get; set; }
    }
}
