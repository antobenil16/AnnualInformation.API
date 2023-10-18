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
            var result = await _customerService.GetAll();
            if(result == null)
            {
                return NotFound(_customerService.GetErrors());
            }
            return Ok(result);
        }

        [HttpGet("GetCustomerTransactions/{customerId}")]
        public async Task<IActionResult> GetTransactions(int customerId)
        {
            var result = await _customerService.GetAllCustomerTransactions(customerId);
            if(result == null)
            {
                return NotFound(_customerService.GetErrors());
            }
            return Ok(result);
        }

    }
}
