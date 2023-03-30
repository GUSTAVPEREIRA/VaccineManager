using Bogus;
using Core.Auth;
using FluentAssertions;
using Infrastructure.Auth;
using Infrastructure.Exceptions;
using Tests.Configuration;

namespace Tests.Auth;

public class RoleRepositoryTest : IDisposable
{
    private const string DatabaseName = "rolesTestDatabase";
    private readonly RoleRepository _roleRepository;

    public RoleRepositoryTest()
    {
        var testConfiguration = new RepositoryTestConfiguration();
        var configuration = testConfiguration.CreateConfigurations(DatabaseName);
        var sqliteDatabaseConnection = new SqliteDatabaseConnectionProvider();
        DatabaseConfiguration.CreateOrRemoveMigrations(true, DatabaseName);

        _roleRepository = new RoleRepository(configuration, sqliteDatabaseConnection);
    }

    [Fact]
    public async Task CreateRoleDate_ShouldRoleResponse()
    {
        var expectedName = new Faker().Lorem.Letter(256);
        var expectedRoleResponse = new RoleResponse(1, expectedName);
        var roleResponse = await _roleRepository.InsertRoleAsync(expectedName);

        roleResponse.Should().BeEquivalentTo(expectedRoleResponse);
    }

    [Fact]
    public async Task UpdateRoleDate_ShouldRoleResponseHasUpdated()
    {
        var roleResponse = await _roleRepository.InsertRoleAsync(new Faker().Lorem.Letter(256));
        var expectedName = "newName";

        var expectedResponse = new RoleResponse(roleResponse.Id, expectedName);

        var result = await _roleRepository.UpdateRoleAsync(new UpdateRoleRequest()
        {
            Id = roleResponse.Id,
            Name = expectedName
        });

        expectedResponse.Should().BeEquivalentTo(result);
    }

    [Fact]
    public async Task UpdateRoleDateWithInvalidId_ShouldThrownANotFoundException()
    {
        var updateRoleRequest = new UpdateRoleRequest
        {
            Id = 5,
            Name = new Faker().Lorem.Letter(256)
        };

        await Assert.ThrowsAsync<NotFoundDataException>(() => _roleRepository.UpdateRoleAsync(updateRoleRequest));
    }

    [Fact]
    public async Task GetRoleById_ShouldGetRole()
    {
        var roleResponse = await _roleRepository.InsertRoleAsync(new Faker().Lorem.Letter(256));

        var result = await _roleRepository.GetRoleByIdAsync(roleResponse.Id);

        roleResponse.Should().BeEquivalentTo(result);
    }
    
    public void Dispose()
    {
        DatabaseConfiguration.CreateOrRemoveMigrations(false, DatabaseName);
    }
}