using Enyim.Caching.Configuration;
using Enyim.Caching;
using Enyim.Caching.Memcached;
using System.Net;
using System.Diagnostics;
using Humanizer;
using Humanizer.Localisation;
using System.Text;

namespace MemcachedManager.UI;

public class MemcachedAccess {

    private readonly MemcachedClient client;
    private readonly Entities.Models.Connection connection;

    public event EventHandler<ProgressEventArgs> Progress;

    public MemcachedAccess(Entities.Models.Connection connection) {
        var loggerFactory = new Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory();
        var configuration = new MemcachedClientConfiguration(loggerFactory, new MemcachedClientOptions {
            Servers = connection.Servers.Select(s => new Server { Address = s.Address, Port = s.Port }).ToList()
        });

        this.client = new MemcachedClient(loggerFactory, configuration);
        this.connection = connection;
    }

    public List<MemcachedServerStats>  Stats() {

        List<MemcachedServerStats> stats = new();

        foreach (var server in connection.Servers) {
            stats.Add(this.Stats(server));
        }

        return stats;
    }

    public MemcachedServerStats Stats(Entities.Models.Server server) {
        ServerStats serverStats = client.Stats();

        var endPoint = new IPEndPoint(IPAddress.Parse(server.Address), server.Port);
        var statItems = new List<StatPair>();

        // loop through all the statItems
        foreach (StatItem item in Enum.GetValues((typeof(StatItem)))) {
            Debug.WriteLine($"{item}: {serverStats.GetRaw(endPoint, item)}");

            var statItem = new StatPair(item.ToString(), serverStats.GetRaw(endPoint, item));
            statItems.Add(statItem);
        }

        return new MemcachedServerStats { Server = server, StatItems = statItems };
    }

    public void Flush() {
        client.FlushAll();
    }

    public string StatItems(Entities.Models.Server server) {
        TelnetConnection tc = new(server.Address, server.Port);

        tc.WriteLine("stats items");
        string results = tc.Read();

        return results;
    }

    public string CacheDump(Entities.Models.Server server, List<int> slabIds, CancellationToken cancellationToken) {
        TelnetConnection tc = new(server.Address, server.Port);

        StringBuilder cacheDumpResults = new();

        int index = 0;
        foreach (var slabId in slabIds) {

            if (cancellationToken.IsCancellationRequested) {
                break;
            }

            tc.WriteLine($"stats cachedump {slabId} 0");
            string results = tc.Read(cancellationToken);

            // only get items that start with ITEM 
            List<string> lines = results.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var line in lines) {
                if (line.StartsWith("ITEM ")) {
                    cacheDumpResults.AppendLine(line);
                }
            }

            index++;
            int percent = index * 100 / slabIds.Count;
            OnProgress(new ProgressEventArgs { Percent = percent });
        }

        return cacheDumpResults.ToString();
    }

    protected virtual void OnProgress(ProgressEventArgs e) {
        EventHandler<ProgressEventArgs> handler = Progress;
        if (handler != null) {
            handler(this, e);
        }
    }
}

public class ProgressEventArgs : EventArgs {
    public int Percent { get; set; }
}

public class MemcachedServerStats {
    public Entities.Models.Server Server { get; set; }
    public List<StatPair> StatItems { get; set; } = new();

    public override string ToString() {
        string statDescription = string.Empty;

        foreach (var item in this.StatItems) {
            statDescription += $"{item.Name}: {item.Value}{Environment.NewLine}";
        }

        return statDescription;
    }
}

public class StatPair {
    public StatPair(string name, string value) {
        this.Name = name;
        this.Value = value;
    }

    public string Name { get; set; }
    public string Value { get; set; }

    public string Notes {
        get {
            switch (Name) {
                case "Uptime":
                    return TimeSpan.FromSeconds(int.Parse(Value)).Humanize(maxUnit: TimeUnit.Year, precision: 7);
                case "ServerTime":
                    DateTime dt = UnixTimeStampToDateTime(int.Parse(Value));
                    return $"{dt.ToShortDateString()} {dt.ToShortTimeString()}";
                case "MaxBytes":
                case "BytesWritten":
                case "BytesRead":
                case "UsedBytes":
                    return BytesToSize(long.Parse(Value));
                default:
                    break;
            }

            return string.Empty;
        }
    }

    private static DateTime UnixTimeStampToDateTime(double unixTimeStamp) {
        // Unix timestamp is seconds past epoch
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dateTime;
    }

    private static string BytesToSize(long bytes) {
        long len = bytes;
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };        
        int order = 0;
        while (len >= 1024 && order < sizes.Length - 1) {
            order++;
            len = len / 1024;
        }

        // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
        // show a single decimal place, and no space.
        return String.Format("{0:0.##} {1}", len, sizes[order]);
    }

}
