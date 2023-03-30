using Core.Auth;
using Dapper;
using Infrastructure.DatabaseProviders;
using Infrastructure.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Auth;

public class RoleRepository : DatabaseConnectionRepository, IRoleRepository
{
    private const string InsertRoleQuery = @"INSERT INTO Roles (name) VALUES (@name) RETURNING id";
    private const string SelectRoleQuery = @"SELECT id, name, createdAt, updatedAt, DeletedAt FROM Roles WHERE id = @id";
    private const string UpdateRoleQuery = @"UPDATE Roles SET name=@name,updatedAt=@updatedAt WHERE id=@id";

    public RoleRepository(IConfiguration configuration, IDatabaseProvider databaseProvider)
        : base(configuration, databaseProvider)
    {
    }

    public async Task<RoleResponse> InsertRoleAsync(string name)
    {
        await using var connection = GetConnection();

        var roleId = await connection.ExecuteScalarAsync<int>(InsertRoleQuery, new
        {
            name
        });

        return await GetRoleByIdAsync(roleId);
    }

    public async Task<RoleResponse> UpdateRoleAsync(UpdateRoleRequest roleRequest)
    {
        await using var connection = GetConnection();

        var rows = await connection.ExecuteAsync(UpdateRoleQuery, new
        {
            name = roleRequest.Name,
            id = roleRequest.Id,
            updatedAt = DateTime.UtcNow
        });
        
        if (rows < 1)
        {
            throw new NotFoundDataException(roleRequest.Id.ToString());
        }

        return await GetRoleByIdAsync(roleRequest.Id);
    }

    public async Task<RoleResponse> GetRoleByIdAsync(int id)
    {
        await using var connection = GetConnection();

        var role = await connection.QueryFirstOrDefaultAsync<Role>(SelectRoleQuery, new
        {
            id
        });

        return new RoleResponse(role.Id, role.Name);
    }
}