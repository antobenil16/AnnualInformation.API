using AnnualInformation.API.Dto;
using AnnualInformation.API.Models;
using Microsoft.Data.SqlClient;
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
        public DbSet<Transaction> Transactions { get; set; }
        // DbSet for  stored procedure result model
        public DbSet<CustomerTransactionDto> CustomerTransactionsStoreProcedure { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Bank>().HasData(new Bank
            {
                Id = 1,
                Name = "ICICI Bank",
                Address= "Mumbai, Maharashtra, India",
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.MinValue
            });
            modelBuilder.Entity<Customer>()
               .HasIndex(e => e.AccountNumber)
               .IsUnique();

            modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Customer)
            .WithMany(c => c.Transactions)
            .HasForeignKey(t => t.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
        public async Task<List<CustomerTransactionDto>> GetCustomerTransactionsStoreProcedure(int customerId)
        {
            // Call the stored procedure using FromSqlRaw
            return await CustomerTransactionsStoreProcedure.FromSqlRaw("EXEC sp_GetCustomerTransactions @CustomerId", new SqlParameter("@CustomerId", customerId)).ToListAsync();
        }
    }
    
}
