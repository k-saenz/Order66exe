using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using System.Collections.Immutable;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;

namespace Order66exe.Models
{
    public class DiscordUtils
    {

        private static DiscordSocketClient _client = new DiscordSocketClient();
        private static SocketGuild _guild;
        private static SocketGuildUser _user;

        public DiscordUtils(ulong guildId, ulong userId)
        {
            //_guild returning null atm ?????
            _guild = _client.GetGuild(guildId);
            _user = _guild.GetUser(userId);
        }

        public static async Task StartBot(string token)
        {
            await _client.LoginAsync(TokenType.Bot, token);

            await _client.StartAsync();
        }

        public List<string> UserRoles()
        {
            var roles = _user.Roles;

            List<string> stringRoles = new List<string>();

            foreach (var item in roles)
            {
                stringRoles.Add(item.Name);
            }

            return stringRoles;
        }

        public bool IsAdmin()
        {
            List<string> roles = UserRoles();

            string adminRole = "sandwich overlords";

            if (!roles.Contains(adminRole))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
