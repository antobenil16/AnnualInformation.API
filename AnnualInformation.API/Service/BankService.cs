﻿using AnnualInformation.API.Data;
using AnnualInformation.API.Dto;
using AnnualInformation.API.Service.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnnualInformation.API.Service
{
    public class BankService : IBankService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BankService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BankDto> GetBankWithBranches(int bankId)
        {
            try
            {
                var bank = await _context.Banks.Include(b => b.Branches).FirstOrDefaultAsync(bank=> bank.Id == bankId);
                if(bank != null)
                {
                    var bankDto = _mapper.Map<BankDto>(bank);
                    return bankDto;
                }
                else
                {
                    return new BankDto();
                }
               
            }catch (Exception ex)
            {
                throw;
            }
        }
    }
}
