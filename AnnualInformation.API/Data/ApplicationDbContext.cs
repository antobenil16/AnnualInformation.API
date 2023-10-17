using Microsoft.EntityFrameworkCore;

namespace AnnualInformation.API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
                
        }
    }
}
