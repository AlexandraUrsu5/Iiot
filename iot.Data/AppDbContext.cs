using iot.Core.Entities;
using iot.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace iot.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
