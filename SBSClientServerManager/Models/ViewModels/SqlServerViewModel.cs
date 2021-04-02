using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSClientServerManager.Models.ViewModels
{
    public class SqlServerViewModel
    {
        public int Id { get; set; }
        public string InstanceName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}