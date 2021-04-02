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
        public string InstanceName { get; set; }
        [Required(ErrorMessage = "Please Input UserName")]
        [StringLength(255)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Input Password")]
        [StringLength(255)]
        public string Password { get; set; }
      
        public int? ClientId { get; set; }
    }
}