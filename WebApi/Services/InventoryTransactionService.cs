using Microsoft.EntityFrameworkCore;
using ProductInventory.Api.Data;
using ProductInventory.Api.Models;

namespace ProductInventory.Api.Services;

public class InventoryTransactionService : IInventoryTransactionService
{
    private readonly InventoryDataContext _context;

    public InventoryTransactionService(InventoryDataContext context)
    {
        _context = context;
    }

    public async Task<List<InventoryTransactionDto>> GetInventoryTransactions(DateTime fromDate, DateTime toDate)
    {
        var transactions = await _context.InventoryTransactions
            .Include(t => t.Product)
            .Where(t => t.Date.Date >= fromDate.Date && t.Date.Date <= toDate.Date)
            .Select(t => new InventoryTransactionDto
            {
                Id = t.Id,
                ProductId = t.ProductId,
                ProductName = t.Product.Name,
                Date = t.Date,
                Quantity = t.Quantity,
                TransactionType = t.TransactionType.ToString()
            })
            .ToListAsync();

        return transactions;
    }
} 