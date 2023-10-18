using AnnualInformation.API.Dto;
using AnnualInformation.API.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnnualInformation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
                _transactionService = transactionService;
        }

        [HttpPost("InsertTransactionAsync")]
        public async Task<IActionResult> InsertTransactionAsync([FromBody] TransactionRequestDto requestDto)
        {
            var result = await _transactionService.InsertTransactionAsync(requestDto);
            if (!result)
            {
                return BadRequest(_transactionService.GetErrors());
            }
            return Ok(result);
        }

        [HttpGet("GetTransactionSummary")]
        public async Task<IActionResult> GetTransactionSummary([FromQuery]int bankId, [FromQuery]DateTime fromDate, [FromQuery] DateTime toDate)
        {
            var result = await _transactionService.GetTransactionsSummaryAsync(bankId, fromDate, toDate);
            if(result == null)
            {
                return NotFound(_transactionService.GetErrors());
            }
            return Ok(result);
        }
    }
}
