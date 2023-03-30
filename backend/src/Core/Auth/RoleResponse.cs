namespace Core.Auth;

public class RoleResponse
{
    public RoleResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
}