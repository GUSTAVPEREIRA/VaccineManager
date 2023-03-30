using System.Data.Common;
using Npgsql;

namespace Infrastructure.DatabaseProviders;

public class PostgresDatabaseProvider: IDatabaseProvider
{
    public DbConnection Connection(string connectionString)
    {
        return new NpgsqlConnection(connectionString);
    }
}