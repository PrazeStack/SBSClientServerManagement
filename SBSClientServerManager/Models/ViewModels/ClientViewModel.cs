using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSClientServerManager.Models.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
      
        public string Name { get; set; }
        public IEnumerable<ServerViewModel> Servers { get; set; }
        public IEnumerable<SqlServerViewModel> SqlServers { get; set; }
        public IEnumerable<VpnViewModel> Vpns { get; set; }
        
       
    }
}