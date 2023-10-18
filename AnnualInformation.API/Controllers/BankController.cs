using AnnualInformation.API.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnnualInformation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
                _bankService = bankService;
        }
        /// <summary>
        /// Get bank with all branches details
        /// </summary>
        /// <param name="bankId"></param>
        /// <returns></returns>
        [HttpGet("GetBankWithBranches/{bankId}")]
        public async Task<IActionResult> GetBankWithBranches (int bankId)
        {
            var result = await _bankService.GetBankWithBranches(bankId);
            if(result == null)
            {
                return BadRequest(_bankService.GetErrors());
            }
            return Ok(result);
        }

    }
}
