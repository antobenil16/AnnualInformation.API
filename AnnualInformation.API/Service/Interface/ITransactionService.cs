using AnnualInformation.API.Dto;

namespace AnnualInformation.API.Service.Interface
{
    public interface ITransactionService
    {
        Task<bool> InsertTransactionAsync(TransactionRequestDto transactionRequestDto);
    }
}
