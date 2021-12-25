﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Order66exe.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using Discord.WebSocket;
using Newtonsoft.Json;
using Discord;
using Microsoft.AspNetCore.Identity;

namespace Order66exe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly SignInManager<DiscordUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, SignInManager<DiscordUser> sManager)
        {
            _logger = logger;
            _config = config;
            _signInManager = sManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> InfoAsync()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            var result = await _signInManager.ExternalLoginSignInAsync(
                info.LoginProvider,
                info.ProviderKey,
                isPersistent: false,
                bypassTwoFactor: true);
            if (result.Succeeded)
            {
                return LocalRedirect(nameof(AuthFailed));
            }
            return View();
        }

        [Authorize(AuthenticationSchemes = "Discord")]
        public IActionResult Events()
        {

            return View();
        }

        [Authorize(AuthenticationSchemes = "Discord")]
        public async Task<IActionResult> Admin()
        {
            //Get ID and Username of logged in user
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var username = User.Claims.First(c => c.Type == ClaimTypes.Name).Value;

            ulong guildId = _config.GetValue<ulong>("Discord:GuildID");
            ulong userIdUlong = Convert.ToUInt64(userId);

            DiscordUtils util = new DiscordUtils(guildId, userIdUlong);

            List<string> roles = util.UserRoles();

            if (!util.IsAdmin())
            {
                return Unauthorized();
            }
            else
            {
                return View();
            }
        }

        public IActionResult AuthFailed()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}