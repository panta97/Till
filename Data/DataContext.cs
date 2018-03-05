using caja.Models;
using Microsoft.EntityFrameworkCore;

namespace caja.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        
        public DbSet<User> Users { get; set; }
        public DbSet<Till> Tills { get; set; }
        public DbSet<Tally> Tallies { get; set; }
        public DbSet<Earning> Earnings { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<TallyEarning> TallyEarnings { get; set; }
        public DbSet<TallyExpense> TallyExpenses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Tally Earnings
            builder.Entity<TallyEarning>()
                .HasKey(k => new {k.EarningId, k.TallyId});

            builder.Entity<TallyEarning>()
                .HasOne(t => t.Tally)
                .WithMany(t => t.Earnings)
                .HasForeignKey(t => t.TallyId);
            
            builder.Entity<TallyEarning>()
                .HasOne(t => t.Earning)
                .WithMany(t => t.Tally)
                .HasForeignKey(t => t.EarningId);

            // Tally Expenses
            builder.Entity<TallyExpense>()            
                .HasKey(k => new {k.ExpenseId, k.TallyId});
            
            builder.Entity<TallyExpense>()
                .HasOne(t => t.Tally)
                .WithMany(t => t.Expenses)
                .HasForeignKey(t => t.TallyId);
            
            builder.Entity<TallyExpense>()
                .HasOne(t => t.Expense)
                .WithMany(t => t.Tally)
                .HasForeignKey(t => t.ExpenseId);

            // Tally
            builder.Entity<Tally>()
                .HasOne(t => t.Till)
                .WithMany(t => t.Tallies)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Tally>()
                .HasOne(t => t.User)
                .WithMany(t => t.Tallies)
                .OnDelete(DeleteBehavior.Restrict);

        }
        
    }
}