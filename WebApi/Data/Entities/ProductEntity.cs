using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductInventory.Api.Data.Entities;

[Table("products")]
public class ProductEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public float UnitPrice { get; set; }

    public virtual ICollection<InventoryTransactionEntity> InventoryTransactions { get; set; } = new List<InventoryTransactionEntity>();
} 