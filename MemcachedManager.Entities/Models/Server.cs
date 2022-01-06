using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemcachedManager.Entities.Models;

public class Server {
    public string Address { get; set; } = string.Empty;
    public int Port { get; set; }
    public int ConnectionId { get; set; }
}
