using Infrastructure.Auth;

namespace Core.Auth;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Role Role { get; set; }
}