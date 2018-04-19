using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DefensiveCodeDemo.Models.HomeViewModels
{
    public class DefensiveCodeFormDemoViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        //[Display(Name = "Last Name")]
        //public decimal LastName { get; set; }

        public Order Order { get; set; }
    }
}
