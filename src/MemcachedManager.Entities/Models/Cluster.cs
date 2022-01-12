using Dapper.Contrib.Extensions;

namespace MemcachedManager.Entities.Models;

public class Cluster {
    [Key]
    public int ClusterId { get; set; }
    public string Name { get; set; } = string.Empty;

    [Write(false)]
    public List<Server> Servers { get; set; } = new List<Server>();
}
