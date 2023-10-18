using AnnualInformation.API.Dto;

namespace AnnualInformation.API.Service.Interface
{
    public interface IGenericService
    {
        List<string> Errors { get; set; }
        List<ErrorMessage> GetErrors();
    }
}
