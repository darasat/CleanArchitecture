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
            return await Task.FromResult(products.FirstOrDefault(p => p.Id == id));
        }

        public async Task AddProductAsync(Product product)
        {
            await Task.CompletedTask;
        }
    }
}
