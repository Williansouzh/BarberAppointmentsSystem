﻿using BarberFlow.Domain.Account;
using Microsoft.AspNetCore.Identity;
namespace BarberFlow.Infra.Data.Identity;

public class AuthenticateService : IAuthenticate
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<bool> Authenticate(string email, string pasword)
    {
        var result = await _signInManager.PasswordSignInAsync(email, pasword, false, false);
        return result.Succeeded;
    }
    public async Task<bool> RegisterUser(string email, string password)
    {
        var applicationUser = new ApplicationUser
        {
            UserName = email,
            Email = email,
        };

        var result = await _userManager.CreateAsync(applicationUser, password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(applicationUser, isPersistent: false);
        }
        return result.Succeeded;
    }
    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

}
