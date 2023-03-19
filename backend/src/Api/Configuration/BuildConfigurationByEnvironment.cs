namespace Api.Configuration;

public static class BuildConfigurationByEnvironment
{
    public static IConfiguration BuildConfiguration(this ConfigurationBuilder builder)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        
        var configuration = builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", true)
            .Build();

        return configuration;
    }
}