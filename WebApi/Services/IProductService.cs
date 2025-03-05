using ProductInventory.Api.Models;

namespace ProductInventory.Api.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetAllProducts();
    Task<ProductDto> UpdateProduct(int id, ProductDto updatedProduct);
} 