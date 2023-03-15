using MFIHub.Infra.Data.Entities;
using MFIHub.Shared.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFIHub.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task Login(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) throw new Exception("User does not exist");
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!singInResult.Succeeded) throw new Exception("Invalid password");
            await _signInManager.SignInAsync(user, request.RememberMe);

        }

        public async Task Register(RegisterRequest parameters)
        {
            var user = new User();
            user.UserName = parameters.UserName;
            var result = await _userManager.CreateAsync(user, parameters.Password);
            if (!result.Succeeded) throw new Exception(result.Errors.FirstOrDefault()?.Description);

        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();

        }


    }
}
