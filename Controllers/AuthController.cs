using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Order66exe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order66exe.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<DiscordUser> _signInManager;

        public AuthController(SignInManager<DiscordUser> sManager)
        {
            _signInManager = sManager;
        }

        public async Task<IActionResult> OAuthCallback(string returnUrl = null)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                return RedirectToAction(nameof(HomeController.AuthFailed));
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(
                info.LoginProvider,
                info.ProviderKey,
                isPersistent: false,
                bypassTwoFactor: true);

            return RedirectToAction(nameof(HomeController.Index));
        }
    }
}
