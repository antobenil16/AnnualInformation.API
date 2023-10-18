namespace AnnualInformation.API.Dto
{
    public class CustomerDto: CommonDto
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int AccountNumber { get; set; }
    }
}
