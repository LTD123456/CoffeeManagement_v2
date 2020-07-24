using CoffeeMangement.Services.User.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using CoffeeMangement.Data.Entities;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace CoffeeMangement.Services.User
{
    public class UserServices : IUserServices
    {
        //private readonly UserManager _userManager;
        //private readonly SignInManager _signInManager;
        private readonly UserManager<Data.Entities.User> _userManager;
        private readonly SignInManager<Data.Entities.User> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        public UserServices(UserManager<Data.Entities.User> userManager, SignInManager<Data.Entities.User> signInManager, 
            RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }
        public async Task<string> AuthentiCate(LoginRequest request)
        {
            var userAccount = await _userManager.FindByNameAsync(request.UserName);
            if (userAccount == null)
            {
                return null;
            }
            var result = await _signInManager.PasswordSignInAsync(userAccount, request.Password, true, true);
            if (!result.Succeeded)
                return null;
            var roles = await _userManager.GetRolesAsync(userAccount);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, userAccount.Email),
                new Claim(ClaimTypes.GivenName, userAccount.DisplayName),
                new Claim(ClaimTypes.Role, string.Join(";",roles))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new CoffeeMangement.Data.Entities.User()
            {
                Email = request.Email,
                DisplayName = request.DisplayName,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName,
                PassWord = request.PassWord
            };
            var rs = await _userManager.CreateAsync(user, request.PassWord);
            if(rs.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
