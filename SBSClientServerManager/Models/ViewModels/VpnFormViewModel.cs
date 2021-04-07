using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBSClientServerManager.Models.ViewModels
{
    public class VpnFormViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Input Name")]
        [StringLength(255)]
        [RegularExpression(@"^([a-zA-Z0-9.]{3,20})$", ErrorMessage = "Name is Invalid")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Input Username")]
        [StringLength(255)]
        [RegularExpression(@"^([a-zA-Z0-9.]{3,20})$", ErrorMessage = "Username is Invalid")]

        public string Username { get; set; }
        [Required(ErrorMessage = "Please Input Password")]
        [StringLength(255)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$",
        ErrorMessage = "Password must contain at least: one Uppercase, one Lowercase, one Number and Must have minimum of 8 characters")]
        public string Password { get; set; }
        public int? ClientId { get; set; }
    }
}