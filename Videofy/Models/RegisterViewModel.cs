using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Videofy.Models
{
    public class RegisterViewModel
    {
        [Required]  // Required to be filled-in
        [EmailAddress]  // Validation for a email address pattern
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]   // Validation for a passowrd pattern
        public string Password { get; set; }

        [DataType(DataType.Password)]   // Validation for a passowrd pattern
        [Display(Name = "Confirm Password")]
        [Compare("Password",
            ErrorMessage = "Password and Confirmation Password do not Match.")]
        public string ConfirmPassword { get; set; }
    }
}
