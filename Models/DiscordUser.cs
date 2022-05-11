using Microsoft.AspNetCore.Identity;

namespace Order66exe.Models
{
    public class DiscordUser : IdentityUser
    {
        [PersonalData]
        public int Discriminator { get; set; }
        [PersonalData]
        public string AvatarUrl { get; set; }
    }
}
