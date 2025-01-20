namespace EcommerceBackend.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;

    public Cart Cart { get; set; } = null!;
}
