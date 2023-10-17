using System.ComponentModel.DataAnnotations;

namespace AnnualInformation.API.Models
{
    public class CommonModel:BaseModel 
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
