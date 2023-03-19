using Core.Extensions;
using FluentMigrator.Runner;
using Infrastructure.Configuration;

namespace Api.Configuration;

public static class FluentMigrationConfiguration
{
    public static void AddMigrationConfiguration(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var settings = configuration.GetSetting();

        if (settings == null)
        {
            throw new ArgumentNullException(nameof(settings));
        }

        var service = serviceCollection
            .AddFluentMigratorCore()
            .ConfigureRunner(cr =>
                cr.AddPostgres()
                .WithGlobalConnectionString(settings.ConnectionString)
                .ScanIn(MigrationConfiguration.GetMigrations()).For.Migrations())
            .BuildServiceProvider(false);

        using var scope = service.CreateScope();
        scope.ServiceProvider.GetRequiredService<IMigrationRunner>().MigrateUp();
    }
}