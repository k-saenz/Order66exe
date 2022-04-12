using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Order66exe.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace Order66exe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SignInManager<DiscordUser> _signInManager;
        private readonly UserManager<DiscordUser> _userManager;

        public LoginController(IConfiguration config, SignInManager<DiscordUser> sManager, UserManager<DiscordUser> uManager)
        {
            _config = config;
            _signInManager = sManager;
            _userManager = uManager;
        }

        [AllowAnonymous]
        public IActionResult DiscordLogin(string returnUrl = null)
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/"}, "Discord");
        }

        [HttpGet("GetToken")]
        [Authorize(AuthenticationSchemes = "Discord")]
        public object GetToken()
        {
            ///<remarks>
            ///Generates API authentication token. Without it, some pages display 404 error
            /// </remarks>
            string userId = User.Claims.First(c => c.Type == ClaimTypes.PrimarySid).Value;
            string username = User.Claims.First(c => c.Type == ClaimTypes.Name).Value;
            string discriminator = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            string avatarHash = User.Claims.First(c => c.Type == "AvatarHash").Value;
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;

            string key = _config.GetValue<string>("Jwt:EncryptionKey");
            string issuer = _config.GetValue<string>("Jwt:Issuer");
            string audience = _config.GetValue<string>("Jwt:Audience");
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(ClaimTypes.PrimarySid, userId));
            permClaims.Add(new Claim(ClaimTypes.Name, username));
            permClaims.Add(new Claim(ClaimTypes.NameIdentifier, discriminator));
            permClaims.Add(new Claim("AvatarHash", avatarHash));
            permClaims.Add(new Claim(ClaimTypes.Email, email));

            var token = new JwtSecurityToken(
                issuer, 
                audience,
                permClaims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
                );

            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

            return new
            {
                ApiToken = jwt_token
            };
        }
    }
}
