using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSClientServerManager.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Server> Servers { get; set; }
        public IEnumerable<VPN> Vpns { get; set; }
        public IEnumerable<SqlServer> SqlServers{ get; set; }

    }
}