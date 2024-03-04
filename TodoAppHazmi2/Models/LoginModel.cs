using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAppHazmi2.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{5,}$",
            ErrorMessage = "Minimum five characters, at least one uppercase letter, one lowercase letter, one number and one special character")]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
    }
}
