using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemcachedManager.Entities.Models;

public class Connection {
    [Key]
    public int ConnectionId { get; set; }
    public string Name { get; set; } = string.Empty;

    [Write(false)]
    public List<Server> Servers { get; set; } = new List<Server>();
}
