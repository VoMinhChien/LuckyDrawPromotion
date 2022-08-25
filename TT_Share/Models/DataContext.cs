using Microsoft.EntityFrameworkCore;

namespace TT_Share.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<BarcodeHistory> BarcodeHistorys { get; set; }
        public DbSet<BarCodes> BarCodes { get; set; }
        public DbSet<Gifts> Giftss { get; set; }
        public DbSet<Rules> Ruless { get; set; }
        
        public DbSet<Users> Users { get; set; }
        public DbSet<Winner> Winners { get; set; }
    }
}
