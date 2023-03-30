using System.Data.Common;

namespace Infrastructure.DatabaseProviders;

public interface IDatabaseProvider
{
    public DbConnection Connection(string connectionString);
}