using AnnualInformation.API.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnnualInformation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController( ICustomerService customerService)
        {
                _customerService = customerService;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(await _customerService.GetAll());
        }

        [HttpGet("GetCustomerTransactions/{customerId}")]
        public async Task<IActionResult> GetTransactions(int customerId)
        {
            return Ok(await _customerService.GetAllCustomerTransactions(customerId));
        }

    }
}
