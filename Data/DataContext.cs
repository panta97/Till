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
        
    }
}