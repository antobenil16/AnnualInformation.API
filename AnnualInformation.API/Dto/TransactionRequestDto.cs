namespace AnnualInformation.API.Dto
{
    public class TransactionRequestDto
    {
        public TransactionSourceDto Source { get; set; }
        public TransactionDestinationDto Destination { get; set; }
        public DateTime TransactionDate {  get; set; }
        public decimal Amount { get; set; }
    }
}
