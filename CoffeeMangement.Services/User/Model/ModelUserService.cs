using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMangement.Services.User.Model
{
    class ModelUserService
    {
    }
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
    public class RegisterRequest
    {
        
        public string DisplayName { get; set; }
        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string ConfirmPassWord { get; set; }
    }
}
