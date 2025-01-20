namespace EcommerceBackend.Domain.Entities;

public class Cart
{
    public int Id { get; set; }

    
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    
    public ICollection<Product> Products { get; set; } = new List<Product>();
}