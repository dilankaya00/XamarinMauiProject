using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinMauiProject.Models
{
    public static class APIs
    {

        //public static string AuthenticateUser = @" https://localhost:7215/api";
        public const string AuthenticateUser = "/api/Auth/Login";
        public const string AuthenticateRegister = "/api/Auth/Register";
    }
}
