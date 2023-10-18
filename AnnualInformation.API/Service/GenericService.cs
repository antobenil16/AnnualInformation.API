using AnnualInformation.API.Dto;
using AnnualInformation.API.Service.Interface;

namespace AnnualInformation.API.Service
{
    public class GenericService : IGenericService
    {
        public List<string> Errors { get; set; } = new List<string>();

        public List<ErrorMessage> GetErrors()
        {
            var errors = new List<ErrorMessage>();
            foreach (var error in Errors)
            {
                errors.Add(new ErrorMessage { Error = error });
            }
            return errors;
        }
    }
}
