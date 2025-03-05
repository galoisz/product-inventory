using Microsoft.AspNetCore.Mvc;
using ProductInventory.Api.Models;
using ProductInventory.Api.Services;

namespace ProductInventory.Api.Controllers;

[ApiController]
[Route("inventory-transactions")]
public class InventoryTransactionsController : ControllerBase
{
    private readonly IInventoryTransactionService _inventoryTransactionService;

    public InventoryTransactionsController(IInventoryTransactionService inventoryTransactionService)
    {
        _inventoryTransactionService = inventoryTransactionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InventoryTransactionDto>>> GetInventoryTransactions(
        [FromQuery] DateTime fromDate,
        [FromQuery] DateTime toDate)
    {
        var transactions = await _inventoryTransactionService.GetInventoryTransactions(fromDate, toDate);
        return Ok(transactions);
    }
} 