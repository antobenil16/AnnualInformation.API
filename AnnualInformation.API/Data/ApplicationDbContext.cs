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
        public DbSet<Transaction> Transactions { get; set; }

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
            .HasOne(t => t.Sender)
            .WithMany(c => c.SentTransactions)
            .HasForeignKey(t => t.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Receiver)
            .WithMany(c => c.ReceivedTransactions)
            .HasForeignKey(t => t.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
