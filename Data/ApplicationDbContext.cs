using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Order66exe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order66exe.Data
{
    public class ApplicationDbContext : IdentityDbContext<DiscordUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
