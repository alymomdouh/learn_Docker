using Microsoft.EntityFrameworkCore;
using LearnDocker.Services.Data;
using LearnDocker.Services.Models;

namespace LearnDocker.Services.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> CreateAsync(CreateProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price
        };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> UpdateAsync(int id, Product product)
    {
        var existing = await _context.Products.FindAsync(id);
        if (existing is null) return null;

        existing.Name = product.Name;
        existing.Price = product.Price;
        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _context.Products.FindAsync(id);
        if (existing is null) return false;

        _context.Products.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}
