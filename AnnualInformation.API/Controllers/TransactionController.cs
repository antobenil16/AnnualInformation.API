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
            if(requestDto.Amount > 100000)
            {
                return BadRequest("Amount should not more that 100000");
            }
            var result = await _transactionService.InsertTransactionAsync(requestDto);
            return Ok();
        }
    }
}
