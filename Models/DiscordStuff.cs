using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Discord;

namespace Order66exe.Models
{
    public class DiscordStuff : IUser
    {
        public string AvatarId => throw new NotImplementedException();

        public string Discriminator => throw new NotImplementedException();

        public ushort DiscriminatorValue => throw new NotImplementedException();

        public bool IsBot => throw new NotImplementedException();

        public bool IsWebhook => throw new NotImplementedException();

        public string Username => throw new NotImplementedException();

        public UserProperties? PublicFlags => throw new NotImplementedException();

        public DateTimeOffset CreatedAt => throw new NotImplementedException();

        public ulong Id => throw new NotImplementedException();

        public string Mention => throw new NotImplementedException();

        public IActivity Activity => throw new NotImplementedException();

        public UserStatus Status => throw new NotImplementedException();

        public IImmutableSet<ClientType> ActiveClients => throw new NotImplementedException();

        public IImmutableList<IActivity> Activities => throw new NotImplementedException();

        public string GetAvatarUrl(ImageFormat format = ImageFormat.Auto, ushort size = 128)
        {
            throw new NotImplementedException();
        }

        public string GetDefaultAvatarUrl()
        {
            throw new NotImplementedException();
        }

        public Task<IDMChannel> GetOrCreateDMChannelAsync(RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
    }
}
