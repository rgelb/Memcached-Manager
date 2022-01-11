using Dapper;
using MemcachedManager.Entities.Models;
using MemcachedManagerDB.DbAccess;
using Microsoft.Data.Sqlite;

namespace MemcachedManagerDB.Data;

public class AppConnection {
    private readonly string connectionString;
    private readonly SqlDataAccess db;

    public AppConnection(string connectionString) {
        this.connectionString = connectionString;
        db = new SqlDataAccess(connectionString);
    }

	// TODO: make this method generic and move to SqlDataAccess class
    public IEnumerable<Connection> GetAll() {

		var lookup = new Dictionary<int, Connection>();

		using (var conn = new SqliteConnection(connectionString)) {
			var result = conn.Query<Connection, Server, Connection>
			(
				splitOn: "ConnectionId",
				
				sql: @"select c.Name, c.ConnectionId, s.ConnectionId, s.Address, s.Port
					from Connections c
					join Servers s on c.ConnectionId = s.ConnectionId",

				map: (parent, child) => {

					Connection memcachedConnection;

					if (!lookup.TryGetValue(parent.ConnectionId, out memcachedConnection)) {
						lookup.Add(parent.ConnectionId, memcachedConnection = parent);
                    }
					memcachedConnection.Servers.Add(child);
					return memcachedConnection;
				}
				
			);

			return lookup.Values;
        }

    }

}
