namespace Core.Auth;

public interface IRoleRepository
{
    public Task<RoleResponse> InsertRoleAsync(string name);
    public Task<RoleResponse> GetRoleByIdAsync(int id);
    public Task<RoleResponse> UpdateRoleAsync(UpdateRoleRequest roleRequest);
}