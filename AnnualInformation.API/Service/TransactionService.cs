using AnnualInformation.API.Common;
using AnnualInformation.API.Data;
using AnnualInformation.API.Dto;
using AnnualInformation.API.Models;
using AnnualInformation.API.Service.Interface;
using AutoMapper;

namespace AnnualInformation.API.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TransactionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Source data and destination data insertion
        /// </summary>
        /// <param name="transactionRequestDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> InsertTransactionAsync(TransactionRequestDto transactionRequestDto)
        {
            //get mapped transaction details
            var transactions = MapDtoToTransaction(transactionRequestDto);
            try
            {
                foreach (var transaction in transactions)
                {   
                    await _context.Transactions.AddAsync(transaction);
                    await _context.SaveChangesAsync();
                }
                return true;

            }catch(Exception ex)
            {
                throw;
            }
        }
        private List<Transaction> MapDtoToTransaction(TransactionRequestDto trans)
        {
            List<Transaction> transactions = new List<Transaction>();
            // map source data
            Transaction source = new Transaction
            {
                IsDeleted =false,
                CreatedDate = DateTime.Now,
                Amount =trans.Amount * -1,  // debit from source
                BranchId = trans.Source.BranchId,
                CustomerId = trans.Source.CustomerId,
                UpdatedDate = DateTime.MinValue,
                TransactionType = (int)CommonValues.TransactionType.Debit,
                TransactionIdentifier = Guid.NewGuid(),
                TransactionDate = trans.TransactionDate
            };
            Transaction destination = new Transaction
            {
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                Amount = trans.Amount,  // credit to destination
                BranchId = trans.Destination.BranchId,
                CustomerId = trans.Destination.CustomerId,
                UpdatedDate = DateTime.MinValue,
                TransactionType = (int)CommonValues.TransactionType.Credit,
                TransactionIdentifier = Guid.NewGuid(),
                TransactionDate = trans.TransactionDate
            };
            transactions.Add(source);
            transactions.Add(destination);

            return transactions;
        }
    }
}
