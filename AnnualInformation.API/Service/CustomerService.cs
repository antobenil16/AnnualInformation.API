﻿using AnnualInformation.API.Data;
using AnnualInformation.API.Dto;
using AnnualInformation.API.Models;
using AnnualInformation.API.Service.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnnualInformation.API.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CustomerService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
                
        }
        /// <summary>
        /// Get All Customers with branch details
        /// </summary>
        /// <returns></returns>
        public async Task<List<CustomerDto>> GetAll()
        {
            var customers = await _context.Customers.Include(b=> b.Branch).ToListAsync();
            var customerList = _mapper.Map<List<CustomerDto>>(customers);
            return customerList;
            
        }

        public async Task<List<CustomerTransactionDto>> GetAllCustomerTransactions(int customerId)
        {
            // get data using store procedure
            var data =  _context.GetCustomerTransactionsStoreProcedure(customerId);
            return null;
        }

        public async Task<Customer> GetById(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(b => b.Id == id);
            if(customer == null)
            {
                return null;
            }
            return customer;
        }
    }
}
