using Microsoft.Extensions.Configuration;

namespace Tests.Configuration;

public class RepositoryTestConfiguration
{
    private readonly Dictionary<string, string> _myConfigurations;

    public RepositoryTestConfiguration()
    {
        _myConfigurations = new Dictionary<string, string>();
    }

    public RepositoryTestConfiguration(Dictionary<string, string> configurations)
    {
        _myConfigurations = configurations;
    }
        
    public IConfigurationRoot CreateConfigurations(string databaseName = "")
    {
        _myConfigurations.Add("ConnectionString", DatabaseConfiguration.GetConnectionString(databaseName));

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(_myConfigurations)
            .Build();

        return configuration;
    }
}