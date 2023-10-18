namespace AnnualInformation.API.Dto
{
    public class CustomerTransactionDto : CustomerDto
    {
        public string BranchAddress { get; set; }
        public string BankName { get; set; }
        public string TransactionTypeName { get; set; }
        public int TransactionType { get; set; }
        public Guid TransactionIdentifier { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
    }
}
