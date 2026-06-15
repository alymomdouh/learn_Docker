using Microsoft.AspNetCore.Mvc;
using LearnDocker.Services.Models;
using LearnDocker.Services.Services;

namespace LearnDocker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
        return await _productService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product is null) return NotFound();
        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Create(CreateProductRequest request)
    {
        var created = await _productService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> Update(int id, Product product)
    {
        var updated = await _productService.UpdateAsync(id, product);
        if (updated is null) return NotFound();
        return updated;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _productService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
