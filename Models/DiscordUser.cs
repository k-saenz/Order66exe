using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order66exe.Models
{
    public class DiscordUser : IdentityUser
    {
        public string Discriminator { get; set; }
        public string AvatarHash { get; set; }
    }
}
