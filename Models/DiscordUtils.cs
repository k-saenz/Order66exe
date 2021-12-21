using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using System.Collections.Immutable;
using Discord.WebSocket;

namespace Order66exe.Models
{
    public class DiscordUtils
    {

        //private readonly ulong CLIENT_ID = 0;
        //private readonly string REDIRECT_URL = "https://order66exe.com/";
        //private readonly string CLIENT_SECRET = "";

        //private readonly ulong GUILD_ID = 688917645139116290;

        //string guildDesc = "";

        private DiscordSocketClient Client { get; set; }
        private SocketGuild Guild { get; set; }

        private SocketGuildUser User { get; set; }

        private GuildProperties guild = new GuildProperties();

        public string GetOwnerUsername()
        {
            SocketGuildUser ownerUser = Guild.Owner;

            string owner = ownerUser.Username;

            return owner;
        }

        public List<string> GetAdmins()
        {
            return null;
        }

    }
}
