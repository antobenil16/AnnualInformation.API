namespace AnnualInformation.API.Dto
{
    public class TransactionSummaryDto
    {
        // bank id
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string CustomerName { get; set; }
        public int TransactionYear { get; set; }
        public int TransactionMonth { get; set; }
        public int TransactionDay { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
