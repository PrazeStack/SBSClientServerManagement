using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBSClientServerManager.Models.ViewModels
{
    public class ClientFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression(@"^(([a-zA-Z]+[\s]{1}[A-Za-z]+)|([A-Za-z]+))$", ErrorMessage ="Name is Invalid")]
        public string Name { get; set; }

    }
}