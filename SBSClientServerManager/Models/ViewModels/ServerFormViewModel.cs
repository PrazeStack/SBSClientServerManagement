using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBSClientServerManager.Models.ViewModels
{
    public class ServerFormViewModel
    {
        public enum ServerType
        {
            Test = 1,
            Live = 2


        }
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please Input Server IP Address")]
        [Display(Name ="IP Address")]
        public string Ip { get; set; }

        [Required(ErrorMessage = "Please Input Username")]
        [StringLength(255)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Input Username")]
        [StringLength(255)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Select Live or Test Server")]
        [Range(1,2)]
        public ServerType ServerTypeName { get; set; }

        
        public int? ClientId { get; set; }
        
    }
}