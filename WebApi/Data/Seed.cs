using ProductInventory.Api.Data.Entities;
using ProductInventory.Api.Models;

namespace ProductInventory.Api.Data;

public static class Seed
{
    public static async Task SeedData(InventoryDataContext context)
    {
        if (!context.Products.Any() && !context.InventoryTransactions.Any())
        {
            // Create products
            var products = new List<ProductEntity>
            {
                new ProductEntity { Id = 1, Name = "Laptop", Category = "Electronics", UnitPrice = 999.99f },
                new ProductEntity { Id = 2, Name = "Smartphone", Category = "Electronics", UnitPrice = 699.99f },
                new ProductEntity { Id = 3, Name = "Coffee Maker", Category = "Appliances", UnitPrice = 79.99f },
                new ProductEntity { Id = 4, Name = "Running Shoes", Category = "Sports", UnitPrice = 89.99f },
                new ProductEntity { Id = 5, Name = "Backpack", Category = "Accessories", UnitPrice = 49.99f }
            };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

            // Create inventory transactions
            var transactions = new List<InventoryTransactionEntity>
            {
                new InventoryTransactionEntity 
                { 
                    Id = 1, 
                    ProductId = 1, 
                    Date = new DateTime(2025, 2, 1), 
                    Quantity = 10, 
                    TransactionType = eTransactionType.Purchase 
                },
                new InventoryTransactionEntity 
                { 
                    Id = 2, 
                    ProductId = 1, 
                    Date = new DateTime(2025, 2, 10), 
                    Quantity = -2, 
                    TransactionType = eTransactionType.Sale 
                },
                new InventoryTransactionEntity 
                { 
                    Id = 3, 
                    ProductId = 2, 
                    Date = new DateTime(2025, 3, 16), 
                    Quantity = 15, 
                    TransactionType = eTransactionType.Purchase 
                },
                new InventoryTransactionEntity 
                { 
                    Id = 4, 
                    ProductId = 3, 
                    Date = new DateTime(2025, 3, 15), 
                    Quantity = 5, 
                    TransactionType = eTransactionType.Purchase 
                },
                new InventoryTransactionEntity 
                { 
                    Id = 5, 
                    ProductId = 2, 
                    Date = new DateTime(2025, 3, 16), 
                    Quantity = -3, 
                    TransactionType = eTransactionType.Sale 
                }
            };

            await context.InventoryTransactions.AddRangeAsync(transactions);
            await context.SaveChangesAsync();
        }
    }
} 