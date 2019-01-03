using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC_Core_Customer.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Login ID")]
        [Required(ErrorMessage = "*")]

        public int LoginID { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
