using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Videofy.Models
{
    public class LoginViewModel
    {
        [Required]  // Required to be filled-in
        [EmailAddress]  // Validation for a email address pattern
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]   // Validation for a passowrd pattern
        public string Password { get; set; }

        [Display(Name = "Remember Me")] 
        public bool RememberMe { get; set; }
    }
}
