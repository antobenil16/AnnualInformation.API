using AnnualInformation.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AnnualInformation.API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
                
        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Customer> Customers { get; set; }  
        //public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bank>().HasData(new Bank
            {
                Id = 1,
                Name = "ICICI Bank",
                Address= "Mumbai, Maharashtra, India",
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.MinValue
            });
        }
    }
}
