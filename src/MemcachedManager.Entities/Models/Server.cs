using Dapper.Contrib.Extensions;

namespace MemcachedManager.Entities.Models;

public class Server {
    [Key]
    public int ServerId { get; set; }
    public string Address { get; set; } = string.Empty;
    public int Port { get; set; }
    public int ClusterId { get; set; }
}
