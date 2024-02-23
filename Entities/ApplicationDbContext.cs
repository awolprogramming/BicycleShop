using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BicycleShop.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BicycleShopEntity> BicycleShop {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BicycleShop;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
