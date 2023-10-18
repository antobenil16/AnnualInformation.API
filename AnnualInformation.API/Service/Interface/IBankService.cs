using AnnualInformation.API.Dto;

namespace AnnualInformation.API.Service.Interface
{
    public interface IBankService: IGenericService
    {
        Task<BankDto> GetBankWithBranches(int bankId);
    }
}
