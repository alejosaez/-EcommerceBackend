namespace EcommerceBackend.Domain.Entities;

public class Cart
{
    public int Id { get; set; }

    // Relación 1:1 con User
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    // Relación 1:N con Product
    public ICollection<Product> Products { get; set; } = new List<Product>();
}