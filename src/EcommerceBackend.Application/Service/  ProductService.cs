using EcommerceBackend.Application.Interface;
using EcommerceBackend.Domain.Entities;
using EcommerceBackend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBackend.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly EcommerceDbContext _context;

        public ProductService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProduct(int id, Product product)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null) return false;

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
            existingProduct.ImageUrl = product.ImageUrl;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}