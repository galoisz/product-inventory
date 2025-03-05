namespace ProductInventory.Api.Models;

public class InventoryTransactionDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
    public string TransactionType { get; set; } = string.Empty;
} 