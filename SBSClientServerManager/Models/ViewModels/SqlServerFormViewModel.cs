using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBSClientServerManager.Models.ViewModels
{
    public class SqlServerFormViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Input Instance Name")]
        [Display(Name = " Instance Name")]
        [RegularExpression(@"^([a-zA-Z0-9.]{3,20})$", ErrorMessage = "Instance Name is Invalid")]
        public string InstanceName { get; set; }
        [Required(ErrorMessage = "Please Input Username")]
        [StringLength(255)]
        [RegularExpression(@"^([a-zA-Z0-9.]{3,20})$", ErrorMessage = "Username is Invalid; Username must be a single word")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Input Password")]
        [StringLength(255)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$",
        ErrorMessage = "Password must be a single word containing at least: one Uppercase, one Lowercase, one Number and Must have 8-15 characters. ")]
        public string Password { get; set; }
      
        public int? ClientId { get; set; }
    }
}