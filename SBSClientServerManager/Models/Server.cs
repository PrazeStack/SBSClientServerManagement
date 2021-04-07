using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBSClientServerManager.Models
{
    public class Server
    {

        public enum ServerType
        {
           Test=1,
            Live=2


         }
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public ServerType ServerTypeName { get; set; }
        public Client Client { get; set; }
        [Required]
        public int ClientId { get; set; }
      

    }
}