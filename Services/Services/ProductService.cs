using Services.Interfaces;
using Domain.Entities;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await Task.FromResult(new List<Product>
                    {
                        new Product { Id = 1, Name = "Laptop", Price = 1000 },
                        new Product { Id = 2, Name = "Phone", Price = 500 },
                        new Product { Id = 3, Name = "Tablet", Price = 700 }
                    });
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var products = await GetAllProductsAsync();
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {id} not found.");
            }
            return await Task.FromResult(product);
        }

        public async Task AddProductAsync(Product product)
        {
            await Task.CompletedTask;
        }
    }
}
