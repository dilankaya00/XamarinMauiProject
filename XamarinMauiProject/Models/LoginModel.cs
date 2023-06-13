using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinMauiProject.Models
{
    public class LoginModel
    {
          
       
            [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
            public string Username { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
            public string Password { get; set; }

        
    }
    }
