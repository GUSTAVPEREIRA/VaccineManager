using FluentMigrator.Runner;
using Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Configuration;

public static class DatabaseConfiguration
{
    public static void CreateOrRemoveMigrations(bool create, string databaseName)
    {
        var connectionString = GetConnectionString(databaseName);
        var service = CreateServiceProvider(connectionString);

        using var scope = service.CreateScope();
        var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

        if (create)
        {
            runner.MigrateUp();
            return;
        }

        runner.MigrateDown(-1);
    }

    private static ServiceProvider CreateServiceProvider(string connectionString)
    {
        var buildServiceProvider = new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(
                builder => builder
                    .AddSQLite()
                    .WithGlobalConnectionString(connectionString)
                    .WithMigrationsIn(MigrationConfiguration.GetMigrations())).BuildServiceProvider();

        return buildServiceProvider;
    }

    public static string GetConnectionString(string databaseName = "")
    {
        if (string.IsNullOrEmpty(databaseName))
        {
            databaseName = "VaccineManagerTestDatabase";
        }

        var appContextPath = AppContext.BaseDirectory;
        return $"Data Source={appContextPath}/{databaseName}.db;Version=3;";
    }
}