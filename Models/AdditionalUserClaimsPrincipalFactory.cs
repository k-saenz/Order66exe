using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Order66exe.Models
{
    public class AdditionalUserClaimsPrincipalFactory
        : UserClaimsPrincipalFactory<DiscordUser, IdentityRole>
    {
        public AdditionalUserClaimsPrincipalFactory(
            UserManager<DiscordUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccesor)
            : base(userManager, roleManager, optionsAccesor)
        {}

        public async Task<ClaimsPrincipal> CreateAsync(DiscordUser user, List<Claim> claims)
        {
            var principal = await base.CreateAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;

            identity.AddClaims(claims);
            return principal;
        }
    }
}
