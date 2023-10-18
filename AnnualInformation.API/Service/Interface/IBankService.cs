using AnnualInformation.API.Dto;

namespace AnnualInformation.API.Service.Interface
{
    public interface IBankService
    {
        Task<BankDto> GetBankWithBranches(int bankId);
    }
}
