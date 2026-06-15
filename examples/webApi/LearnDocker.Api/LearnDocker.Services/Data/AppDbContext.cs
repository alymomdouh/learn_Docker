using Microsoft.EntityFrameworkCore;
using LearnDocker.Services.Models;

namespace LearnDocker.Services.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasColumnType("varchar");
            entity.Property(e => e.Price).HasColumnType("decimal").IsRequired().HasDefaultValue(0);
        });
    }
}
