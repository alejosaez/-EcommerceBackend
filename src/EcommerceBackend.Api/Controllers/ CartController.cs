using EcommerceBackend.Application.DTOs;
using EcommerceBackend.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<CartDto>> GetCart(int userId)
    {
        var cart = await _cartService.GetCartByUserIdAsync(userId);
        return Ok(cart);
    }

    [HttpPost("{userId}/products/{productId}")]
    public async Task<IActionResult> AddProduct(int userId, int productId)
    {
        await _cartService.AddProductToCartAsync(userId, productId);
        return NoContent();
    }

    [HttpDelete("{userId}/products/{productId}")]
    public async Task<IActionResult> RemoveProduct(int userId, int productId)
    {
        await _cartService.RemoveProductFromCartAsync(userId, productId);
        return NoContent();
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> ClearCart(int userId)
    {
        await _cartService.ClearCartAsync(userId);
        return NoContent();
    }
}