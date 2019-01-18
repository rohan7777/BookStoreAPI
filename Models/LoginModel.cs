using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class LoginModel
    {
        public bool AuthenticationStatus { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; } = "";
        public string password { get; set; } = "";
    }
}