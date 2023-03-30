using System.Data.Common;
using System.Data.SQLite;
using Infrastructure.DatabaseProviders;

namespace Tests.Configuration;

public class SqliteDatabaseConnectionProvider : IDatabaseProvider
{
    public DbConnection Connection(string connectionString)
    {
        return new SQLiteConnection(connectionString);
    }
}