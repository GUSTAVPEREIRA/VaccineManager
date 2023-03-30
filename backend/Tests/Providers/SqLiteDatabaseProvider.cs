using System.Data.Common;
using Infrastructure.DatabaseProviders;
using Microsoft.Data.Sqlite;

namespace Tests.Providers;

public class SqLiteDatabaseProvider : IDatabaseProvider
{
    public DbConnection Connection(string connectionString)
    {
        return new SqliteConnection(connectionString);
    }
}