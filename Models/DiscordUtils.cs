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
        /*****************
         * DEPRICATED, BOT WILL NO LONGER START WITH APP
         * CREATE API AND HOST ON AZURE
         * MAKE REQUESTS FROM THERE
         *****************/

        private static DiscordSocketClient _client = new DiscordSocketClient();
        private static SocketGuild _guild;
        private static SocketGuildUser _user;

        public DiscordUtils() { }

        public DiscordUtils(ulong guildId, ulong userId)
        {
            _guild = _client.GetGuild(guildId);
            _user = _guild.GetUser(userId);
        }

        public DiscordUtils(ulong guildId)
        {
            _guild = _client.GetGuild(guildId);
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
            if (_user.Roles.Any(r => r.Id == 690944722557993051))
            {
                return true;
            }
            return false;
        }

        public List<SocketRole> GetGuildRoles()
        {
            var guildroles = _guild.Roles;

            List<SocketRole> roles = new();

            foreach (var item in guildroles)
            {
                if (item.IsEveryone || !item.IsHoisted)
                {
                    continue;
                }
                roles.Add(item);
                
            }

            return roles;
        }

        public IEnumerable<SocketGuildUser> GetAdmins(ulong adminId)
        {
            var adminrole = _guild.GetRole(adminId);

            foreach (var item in adminrole.Members)
            {
                Console.WriteLine("Avatar Id: " + item.AvatarId + "\n" +
                    "Avatar Url" + item.GetGuildAvatarUrl() + "\n" +
                    "username: " + item.Username);
            }

            return adminrole.Members;
        }
    }
}
