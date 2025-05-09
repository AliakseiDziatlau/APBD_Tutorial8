using Microsoft.Data.SqlClient;

namespace APBD_Tutorial8.Infrastructure.Repository;

public abstract class RepositoryBase
{
    protected readonly string _connectionString;

    public RepositoryBase(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected void AddParameter(SqlCommand command, string name, object? value)
    {
        var param = command.CreateParameter();
        param.ParameterName = name;
        param.Value = value ?? DBNull.Value;
        command.Parameters.Add(param);
    }
}