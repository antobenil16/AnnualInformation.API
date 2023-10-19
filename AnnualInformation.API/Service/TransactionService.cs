using AnnualInformation.API.Common;
using AnnualInformation.API.Data;
using AnnualInformation.API.Dto;
using AnnualInformation.API.Models;
using AnnualInformation.API.Service.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnnualInformation.API.Service
{
    public class TransactionService : GenericService, ITransactionService
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
           // check the transaction limit
            if(!await CheckLimit(transactionRequestDto))
            {
                // add message don't have enough limit
                Errors.Add("Transaction limit crossed");
                return false;
            }
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
                Errors.Add(ex.Message);
                return false;
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

        private async Task<bool> CheckLimit(TransactionRequestDto trans)
        {
            try
            {
                var transactions = await _context.Transactions.Where(t => t.CustomerId == trans.Source.CustomerId && t.TransactionType == (int)CommonValues.TransactionType.Debit && t.TransactionDate.Date.Year == trans.TransactionDate.Date.Year).ToListAsync();
                if (transactions != null)
                {
                    // get existing transactions amount
                    decimal existingTransferedAmount = Math.Abs(transactions.Sum(a=> a.Amount));

                    if (existingTransferedAmount > 1000000)
                    {
                        var todaysTransactionAmount= Math.Abs( transactions.Where(t=> t.TransactionDate.Date == trans.TransactionDate.Date).Sum(a=> a.Amount));

                        if((trans.Amount + todaysTransactionAmount) <= 100000)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Errors.Add(ex.Message);
                return false;
            }
            
        }

        public async Task<List<TransactionSummaryDto>> GetTransactionsSummaryAsync(int bankId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                // get data using store procedure
                var data = await _context.GetTransactionSummaryAsync(bankId, fromDate, toDate);
                return data;
            }
            catch(Exception ex)
            {
                Errors.Add(ex.Message);
                return null;
            }
            
        }
    }
}
