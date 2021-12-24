using Microsoft.AspNetCore.Authorization;
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

namespace Order66exe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private DiscordSocketClient _client;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            //ViewBag.Username = GetUserName();
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Login()
        {
            string redirectURI = _config.GetValue<string>("Discord:RedirectURI");
            return Redirect(redirectURI);
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


        [HttpGet("GetToken")]
        [Authorize(AuthenticationSchemes = "Discord")]
        public string GetToken()
        {
            var userID = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            //get values from configuration files
            string key = _config.GetValue<string>("Jwt:EncryptionKey");
            string issuer = _config.GetValue<string>("Jwt:Issuer");
            string audience = _config.GetValue<string>("Jwt:Audience");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("discordId", userID));

            //Create JWT token
            var token = new JwtSecurityToken(issuer, audience, permClaims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials);

            //Convert token to string
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt_token;

        }

    }
}