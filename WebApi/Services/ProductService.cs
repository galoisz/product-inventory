using Microsoft.EntityFrameworkCore;
using ProductInventory.Api.Data;
using ProductInventory.Api.Data.Entities;
using ProductInventory.Api.Models;

namespace ProductInventory.Api.Services;

public class ProductService : IProductService
{
    private readonly InventoryDataContext _context;

    public ProductService(InventoryDataContext context)
    {
        _context = context;
    }

    public async Task<List<ProductDto>> GetAllProducts()
    {
        var products = await _context.Products
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                UnitPrice = p.UnitPrice
            })
            .ToListAsync();

        return products;
    }

    public async Task<ProductDto> UpdateProduct(int id, ProductDto updatedProduct)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found");
        }

        product.Name = updatedProduct.Name;
        product.Category = updatedProduct.Category;
        product.UnitPrice = updatedProduct.UnitPrice;

        await _context.SaveChangesAsync();

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Category = product.Category,
            UnitPrice = product.UnitPrice
        };
    }
} 