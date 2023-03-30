using System.Data.Common;
using Core.Extensions;
using Infrastructure.DatabaseProviders;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public abstract class DatabaseConnectionRepository
{
    private readonly IDatabaseProvider _databaseProvider;
    private readonly string _connectionString;

    protected DatabaseConnectionRepository(IConfiguration configuration, IDatabaseProvider databaseProvider)
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        var settings = configuration.GetSetting();
        
        _connectionString = settings.ConnectionString;
        _databaseProvider = databaseProvider;
    }

    protected DbConnection GetConnection()
    {
        return _databaseProvider.Connection(_connectionString);
    }
}