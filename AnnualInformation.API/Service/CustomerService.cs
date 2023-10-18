using AnnualInformation.API.Data;
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

        public Task<Customer> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
