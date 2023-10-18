﻿using AnnualInformation.API.Dto;
using AnnualInformation.API.Models;

namespace AnnualInformation.API.Service.Interface
{
    public interface ICustomerService:IGenericService
    {
        Task<List<CustomerDto>> GetAll();
        Task<Customer> GetById(int id);

        Task<List<CustomerTransactionDto>> GetAllCustomerTransactions(int customerId);
    }
}
