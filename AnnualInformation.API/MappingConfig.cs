using AnnualInformation.API.Dto;
using AnnualInformation.API.Models;
using AutoMapper;

namespace AnnualInformation.API
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(d=> d.BranchName,opt=> opt.MapFrom(s=> s.Branch.Name));

            CreateMap<Bank, BankDto>()
                .ForMember(d => d.Branches, opt => opt.MapFrom(s=> s.Branches));

            CreateMap<Branch, BranchDto>();
        }
    }
}
