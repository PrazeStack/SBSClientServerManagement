using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSClientServerManager.Models.ViewModels
{
    public class VpnViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ClientId { get; set; }
    }
}