using Microsoft.EntityFrameworkCore;
using StockControlApi.Core.Entities;

namespace StockControlApi.Infrastructure.Data;

public class StockContext : DbContext
{
    public StockContext(DbContextOptions<StockContext> options) : base(options) { }

    // Tabelas do banco de dados
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relacionamento de Order com OriginWarehouse
        modelBuilder.Entity<Order>()
            .HasOne(o => o.OriginWarehouse)
            .WithMany()
            .HasForeignKey(o => o.OriginWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento de Order com DestinationWarehouse
        modelBuilder.Entity<Order>()
            .HasOne(o => o.DestinationWarehouse)
            .WithMany()
            .HasForeignKey(o => o.DestinationWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento de Order com Item
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Item)
            .WithMany()
            .HasForeignKey(o => o.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento de Item com Warehouse
        modelBuilder.Entity<Item>()
            .HasOne(i => i.Warehouse)
            .WithMany()
            .HasForeignKey(i => i.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}