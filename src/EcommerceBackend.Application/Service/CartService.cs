using EcommerceBackend.Application.DTOs;
using EcommerceBackend.Application.Interface;
using EcommerceBackend.Domain.Entities;
using EcommerceBackend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBackend.Application.Service;

public class CartService : ICartService
{
    private readonly EcommerceDbContext _dbContext;

    public CartService(EcommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CartDto> GetCartByUserIdAsync(int userId)
    {
        var cart = await _dbContext.Carts
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
            throw new KeyNotFoundException($"Cart for user {userId} not found.");

        return new CartDto
        {
            UserId = cart.UserId,
            Products = cart.Products.Select(p => new ProductDto
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Category = p.Category,
                Stock = p.Stock,
                ImageUrl = p.ImageUrl
            }).ToList()
        };
    }

    public async Task<bool> AddProductToCartAsync(int userId, int productId)
    {
        var cart = await _dbContext.Carts
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
            throw new KeyNotFoundException($"Cart for user {userId} not found.");

        var product = await _dbContext.Products.FindAsync(productId);

        if (product == null)
            throw new KeyNotFoundException($"Product with ID {productId} not found.");

        cart.Products.Add(product);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveProductFromCartAsync(int userId, int productId)
    {
        var cart = await _dbContext.Carts
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
            throw new KeyNotFoundException($"Cart for user {userId} not found.");

        var product = cart.Products.FirstOrDefault(p => p.Id == productId);

        if (product == null)
            throw new KeyNotFoundException($"Product with ID {productId} not found in the cart.");

        cart.Products.Remove(product);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ClearCartAsync(int userId)
    {
        var cart = await _dbContext.Carts
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
            throw new KeyNotFoundException($"Cart for user {userId} not found.");

        cart.Products.Clear();
        await _dbContext.SaveChangesAsync();

        return true;
    }
}