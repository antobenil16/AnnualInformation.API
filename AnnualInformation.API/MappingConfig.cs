using AnnualInformation.API.Dto;
using AnnualInformation.API.Models;
using AutoMapper;

namespace AnnualInformation.API
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Customer, CustomerDto>();
        }
    }
}
