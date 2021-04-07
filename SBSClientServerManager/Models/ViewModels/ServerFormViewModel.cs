using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        [RegularExpression(@"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$",
        ErrorMessage = "IP Address is Invalid")]
        public string Ip { get; set; }

        [Required(ErrorMessage = "Please Input Username")]
        [StringLength(255)]
        [RegularExpression(@"^([a-zA-Z0-9.]{3,20})$", ErrorMessage = "Username is Invalid")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Input Password")]
        [StringLength(255)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", 
        ErrorMessage = "Password must contain at least: one Uppercase, one Lowercase, one Number and Must have minimum of 8 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Select Live or Test Server")]
        [Range(1,2,ErrorMessage = "Select Live or Test Server")]
        public ServerType ServerTypeName { get; set; }

        
        public int? ClientId { get; set; }
        
    }
}