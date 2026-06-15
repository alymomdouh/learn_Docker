using LearnDocker.Services.Models;

namespace LearnDocker.Services.Services;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(CreateProductRequest request);
    Task<Product?> UpdateAsync(int id, Product product);
    Task<bool> DeleteAsync(int id);
}
