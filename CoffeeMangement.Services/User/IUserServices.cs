using CoffeeMangement.Services.User.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMangement.Services.User
{
    public interface IUserServices
    {
        Task<string> AuthentiCate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
