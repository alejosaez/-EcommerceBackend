namespace EcommerceBackend.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;

    // Relación 1:1 con Cart
    public Cart Cart { get; set; } = null!;
}
