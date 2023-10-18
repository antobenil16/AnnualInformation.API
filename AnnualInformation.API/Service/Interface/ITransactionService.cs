using AnnualInformation.API.Dto;

namespace AnnualInformation.API.Service.Interface
{
    public interface ITransactionService:IGenericService
    {
        Task<bool> InsertTransactionAsync(TransactionRequestDto transactionRequestDto);
        Task<List<TransactionSummaryDto>> GetTransactionsSummaryAsync(int bankId, DateTime fromDate,DateTime toDate);
    }
}
