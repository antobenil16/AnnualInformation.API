namespace AnnualInformation.API.Dto
{
    public class CustomerTransactionDto : CustomerDto
    {
        public string BranchAddress { get; set; }
        public string BankName { get; set; }
        public int BankId { get; set; }
        public int TransactionType { get; set; }
        public Guid TransactionIdentifier { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }
    }
}
