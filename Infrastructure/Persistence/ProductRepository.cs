using Domain.Interfaces;

namespace Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<string> GetProducts()
        {
            return new List<string> { "Repo Product 1", "Repo Product 2" };
        }
    }
}