using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProductInventory.Api.Models;

namespace ProductInventory.Api.Data.Entities;

[Table("inventory_transactions")]
public class InventoryTransactionEntity
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }

    public DateTime Date { get; set; }
    public int Quantity { get; set; }
    public eTransactionType TransactionType { get; set; }

    public virtual ProductEntity Product { get; set; } = null!;
} 