using AnnualInformation.API.Dto;
using AnnualInformation.API.Models;

namespace AnnualInformation.API.Service.Interface
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAll();
        Task<Customer> GetById(int id);
    }
}
