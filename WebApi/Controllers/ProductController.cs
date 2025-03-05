using Microsoft.AspNetCore.Mvc;
using ProductInventory.Api.Models;
using ProductInventory.Api.Services;

namespace ProductInventory.Api.Controllers;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
    {
        var products = await _productService.GetAllProducts();
        return Ok(products);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<ProductDto>> UpdateProduct(int id, ProductDto updatedProduct)
    {
        try
        {
            var product = await _productService.UpdateProduct(id, updatedProduct);
            return Ok(product);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
} 