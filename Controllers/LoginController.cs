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

namespace Order66exe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("GetToken")]
        [Authorize(AuthenticationSchemes = "Discord")]
        public object GetToken()
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

            return new
            {
                ApiToken = jwt_token
            };
        }
    }
}
