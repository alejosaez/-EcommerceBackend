namespace EcommerceBackend.Application.DTOs;

public class ProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
    public string ImageUrl { get; set; }
}