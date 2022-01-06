using Dapper;
using Dapper.Contrib.Extensions;
using MemcachedManager.Entities.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemcachedManagerDB.Setup;

public class Bootstrap {
    private readonly string connectionString;

    public Bootstrap(string connectionString) {
        this.connectionString = connectionString;
    }

    public void BuildDb() {


        using var connection = new SqliteConnection(connectionString);

        // Memcached Connections Table
        const string TBL_Connections = "Connections";
        const string TBL_Servers = "Servers";

        var table = connection.Query<string>($"SELECT name FROM sqlite_master WHERE type='table' AND name = '{TBL_Connections}';");
        if (string.IsNullOrEmpty(table.FirstOrDefault())) {

            // no need to specify Id because its automatically provided by the rowid feature of SQLite
            connection.Execute($@"
                    CREATE TABLE {TBL_Connections} (
                        ConnectionId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name VARCHAR(100) NOT NULL
                    );");
        }

        table = connection.Query<string>($"SELECT name FROM sqlite_master WHERE type='table' AND name = '{TBL_Servers}';");
        if (string.IsNullOrEmpty(table.FirstOrDefault())) {

            // no need to specify Id because its automatically provided by the rowid feature of SQLite
            connection.Execute($@"
                    CREATE TABLE {TBL_Servers} (
                        Address VARCHAR(100) NOT NULL,
                        Port INT NOT NULL,
                        ConnectionId INT NOT NULL,
                        FOREIGN KEY(ConnectionId) REFERENCES {TBL_Connections}(ConnectionId)
                    );");
        }

        // insert sample data only if we are in the dev environement and there is no data
        if (Debugger.IsAttached && connection.ExecuteScalar<bool>($"select count(1) from {TBL_Connections}") == false) {
            // add sample InventoryItem data to the table
            var lst = new List<Connection> {
                    new Connection {
                        Name = "Dev",
                        Servers = new List<Server> {
                            new Server{ Address = "10.147.31.171", Port = 11211},
                            new Server{ Address = "10.147.31.172", Port = 11211}
                        }
                    },
                    new Connection {
                        Name = "Prod",
                        Servers = new List<Server> {
                            new Server{ Address = "10.147.20.50", Port = 11211},
                            new Server{ Address = "10.147.20.51", Port = 11211}
                        }
                    }
                };

            foreach (var memcachedConnection in lst) {
                long connectionId = connection.Insert<Connection>(memcachedConnection);

                foreach (var server in memcachedConnection.Servers) {
                    server.ConnectionId = (int) connectionId;
                    connection.Insert<Server>(server);
                }
            }
        }
    }
}
