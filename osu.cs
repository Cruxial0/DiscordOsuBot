using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using osu_api;

namespace DiscordOsuBot
{
    public class osu
    {
        internal static osuAPI api;

        public static void GetAPI()
        {
            api = Program.api;
        }

        public static void GetStats(string user, SocketUserMessage msg)
        {
            User osuUser = api.GetUser(user, Mode.osu);

            PostStats(osuUser, msg);
        }

        private static void PostStats(User osuUser, SocketUserMessage msg)
        {
            EmbedBuilder eb = new EmbedBuilder();
            EmbedFooterBuilder efb = new EmbedFooterBuilder();

            eb.Title = $"Stats for {osuUser.username}";

            eb.AddField("pp", $"{osuUser.pp_raw}");
            eb.AddField("Rank", $"#{osuUser.pp_rank}");
            eb.AddField("Level", $"#{osuUser.level}");
            eb.AddField("Rank", $"#{osuUser.pp_rank}");
            eb.AddField("Country", $"#{osuUser.country}");

            eb.WithCurrentTimestamp();

            eb.ImageUrl = $"http://s.ppy.sh/a/{osuUser.user_id}";
            eb.Url = $"https://osu.ppy.sh/users/{osuUser.user_id}";

            efb.IconUrl = msg.Author.GetAvatarUrl();

            eb.WithFooter(efb);

            var embed = eb.Build();

            msg.Channel.SendMessageAsync(embed: embed);
        }
    }
}
