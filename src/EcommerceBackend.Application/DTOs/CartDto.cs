namespace EcommerceBackend.Application.DTOs;

public class CartDto
{
    public int UserId { get; set; }
    public List<ProductDto> Products { get; set; } = new();
}