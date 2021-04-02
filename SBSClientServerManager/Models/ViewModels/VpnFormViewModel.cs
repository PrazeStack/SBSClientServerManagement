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
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Input Username")]
        [StringLength(255)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Input Password")]
        [StringLength(255)]
        public string Password { get; set; }
        public int? ClientId { get; set; }
    }
}