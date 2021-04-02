using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSClientServerManager.Models.ViewModels
{
    public class ServerViewModel
    {
        public enum ServerType
        {
            Test = 1,
            Live = 2


        }
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ServerTypeId { get; set; }
        public int ClientId { get; set; }
        public ServerType ServerTypeName { get; set; }
    }
}