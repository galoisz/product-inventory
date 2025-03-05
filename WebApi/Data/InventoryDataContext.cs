using Microsoft.EntityFrameworkCore;
using ProductInventory.Api.Data.Entities;

namespace ProductInventory.Api.Data;

public class InventoryDataContext : DbContext
{
    public InventoryDataContext(DbContextOptions<InventoryDataContext> options)
        : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<InventoryTransactionEntity> InventoryTransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductEntity>()
            .HasMany(p => p.InventoryTransactions)
            .WithOne(t => t.Product)
            .HasForeignKey(t => t.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 