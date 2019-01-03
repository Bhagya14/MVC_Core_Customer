using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC_Core_Customer.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "*")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "*")]
        public string CustomerCity { get; set; }
        [Required(ErrorMessage = "*")]
        public string CustomerPassword { get; set; }

    }
}
