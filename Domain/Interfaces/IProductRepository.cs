namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<string> GetProducts();
    }
}