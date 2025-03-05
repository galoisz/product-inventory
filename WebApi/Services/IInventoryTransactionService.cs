using ProductInventory.Api.Models;

namespace ProductInventory.Api.Services;

public interface IInventoryTransactionService
{
    Task<List<InventoryTransactionDto>> GetInventoryTransactions(DateTime fromDate, DateTime toDate);
} 