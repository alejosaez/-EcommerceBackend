namespace EcommerceBackend.Application.Interface;

using EcommerceBackend.Application.DTOs;

public interface ICartService
{
    Task<CartDto> GetCartByUserIdAsync(int userId);
    Task<bool> AddProductToCartAsync(int userId, int productId);
    Task<bool> RemoveProductFromCartAsync(int userId, int productId);
    Task<bool> ClearCartAsync(int userId);
}