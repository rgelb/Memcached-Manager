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
    public IEnumerable<Cluster> GetAll() {

		var lookup = new Dictionary<int, Cluster>();

        using var conn = new SqliteConnection(connectionString);
        var result = conn.Query<Cluster, Server, Cluster>
        (
            splitOn: "ClusterId",

            sql: @"select c.Name, c.ClusterId, s.ClusterId, s.Address, s.Port, s.ServerId
					from Clusters c
					join Servers s on c.ClusterId = s.ClusterId",

            map: (parent, child) => {
                if (!lookup.TryGetValue(parent.ClusterId, out Cluster memcachedCluster)) {
                    lookup.Add(parent.ClusterId, memcachedCluster = parent);
                }
                memcachedCluster.Servers.Add(child);
                return memcachedCluster;
            }

        );

        return lookup.Values;

    }


    public void Save(Cluster cluster) {

        if (cluster.ClusterId > 0) {

            // update cluster
            db.Update<Cluster>(cluster).Wait();

            // delete servers associated with cluster
            int value = db.Execute($"delete from Servers where ClusterId={cluster.ClusterId}");

            // re-insert servers
            foreach (var server in cluster.Servers) {
                db.Insert<Server>(server).Wait();
            }

        } else {
            int identity = db.Insert<Cluster>(cluster).Result;
            foreach (var server in cluster.Servers) {
                server.ClusterId = identity;
                db.Insert<Server>(server).Wait();
            }
        }
    }

    public void DeleteCluster(Cluster cluster) {
        // delete servers associated with cluster
        int value = db.Execute($"delete from Servers where ClusterId={cluster.ClusterId}");

        // delete cluster
        db.Delete<Cluster>(cluster).Wait();
    }
}
