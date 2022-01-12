using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using System.Data;

namespace MemcachedManagerDB.DbAccess;

internal class SqlDataAccess {

    private readonly string connectionString;

    public SqlDataAccess(string connectionString) {
        this.connectionString = connectionString;
    }

    public async Task<T> GetById<T>(int Id) where T : class {
        using IDbConnection connection = new SqliteConnection(connectionString);
        return await connection.GetAsync<T>(Id);
    }

    public int Execute(string sql) {
        using IDbConnection connection = new SqliteConnection(connectionString);
        return connection.Execute(sql);
    }

    public async Task<IEnumerable<T>> GetAll<T>() where T : class {
        using IDbConnection connection = new SqliteConnection(connectionString);
        return await connection.GetAllAsync<T>();
    }

    public async Task<int> Insert<T>(T entity) where T : class {
        using IDbConnection connection = new SqliteConnection(connectionString);
        int identity = await connection.InsertAsync(entity);

        return identity;
    }

    public async Task<bool> Update<T>(T entity) where T : class {
        using IDbConnection connection = new SqliteConnection(connectionString);
        bool result = await connection.UpdateAsync(entity);

        return result;
    }

    public async Task<bool> Delete<T>(T entity) where T : class {
        using IDbConnection connection = new SqliteConnection(connectionString);
        bool result = await connection.DeleteAsync(entity);

        return result;
    }

    public async Task<IEnumerable<T>> Search<T>(string sql) where T : class {
        using IDbConnection connection = new SqliteConnection(connectionString);
        return await connection.QueryAsync<T>(sql);
    }
}
