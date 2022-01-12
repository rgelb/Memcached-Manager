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

        // Memcached Clusters Table
        const string TBL_Clusters = "Clusters";
        const string TBL_Servers = "Servers";

        var table = connection.Query<string>($"SELECT name FROM sqlite_master WHERE type='table' AND name = '{TBL_Clusters}';");
        if (string.IsNullOrEmpty(table.FirstOrDefault())) {

            // no need to specify Id because its automatically provided by the rowid feature of SQLite
            connection.Execute($@"
                    CREATE TABLE {TBL_Clusters} (
                        ClusterId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name VARCHAR(100) NOT NULL
                    );");
        }

        table = connection.Query<string>($"SELECT name FROM sqlite_master WHERE type='table' AND name = '{TBL_Servers}';");
        if (string.IsNullOrEmpty(table.FirstOrDefault())) {

            // no need to specify Id because its automatically provided by the rowid feature of SQLite
            connection.Execute($@"
                    CREATE TABLE {TBL_Servers} (
                        ServerId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Address VARCHAR(100) NOT NULL,
                        Port INT NOT NULL,
                        ClusterId INT NOT NULL,
                        FOREIGN KEY(ClusterId) REFERENCES {TBL_Clusters}(ClusterId)
                    );");
        }

        // insert sample data only if we are in the dev environement and there is no data
        if (Debugger.IsAttached && connection.ExecuteScalar<bool>($"select count(1) from {TBL_Clusters}") == false) {
            // add sample InventoryItem data to the table
            var lst = new List<Cluster> {
                    new Cluster {
                        Name = "Dev",
                        Servers = new List<Server> {
                            new Server{ Address = "10.147.31.171", Port = 11211},
                            new Server{ Address = "10.147.31.172", Port = 11211}
                        }
                    },
                    new Cluster {
                        Name = "Prod",
                        Servers = new List<Server> {
                            new Server{ Address = "10.147.20.50", Port = 11211},
                            new Server{ Address = "10.147.20.51", Port = 11211}
                        }
                    }
                };

            foreach (var memcachedCluster in lst) {
                long clusterId = connection.Insert<Cluster>(memcachedCluster);

                foreach (var server in memcachedCluster.Servers) {
                    server.ClusterId = (int) clusterId;
                    connection.Insert<Server>(server);
                }
            }
        }
    }
}
