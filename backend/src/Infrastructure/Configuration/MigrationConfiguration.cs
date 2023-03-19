using System.Reflection;
using Infrastructure.Migrations;

namespace Infrastructure.Configuration;

public static class MigrationConfiguration
{
    public static Assembly[] GetMigrations()
    {
        return new[]
        {
            typeof(CreateRoleTable).Assembly
        };
    }
}