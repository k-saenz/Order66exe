using Microsoft.AspNetCore.Identity;

namespace Order66exe.Models
{
    public class DiscordUser : IdentityUser
    {
        [PersonalData]
        public string Discriminator { get; set; }
        [PersonalData]
        public string AvatarHash { get; set; }
    }
}
