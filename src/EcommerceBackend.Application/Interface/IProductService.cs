namespace EcommerceBackend.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(int id, Product product);
        Task<bool> DeleteProduct(int id);
        Task<Product?> GetProductById(int id);
        Task<IEnumerable<Product>> GetAllProducts();
    }
}