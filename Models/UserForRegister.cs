using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class UserForRegister
    {
        public string Email { get; set; } = "";
         public string Password { get; set; } = "";
         public string PasswordConfirm { get; set; } = "";
    }
}