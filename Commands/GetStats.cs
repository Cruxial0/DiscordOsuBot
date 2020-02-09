using BotTools.Interfaces;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordOsuBot.Commands
{
    public class GetStats : IDiscordCommand
    {
        public string Name => "getStats";

        public string Help => "Gets the osu! stats of the targeted user.";

        public string Syntax => "-getStats (username)";

        public string Permission => "default";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            if(parameters.Length != 1)
            {
                await msg.Channel.SendMessageAsync($"**Wrong command usage!** `{Syntax}`");
                return;
            }

            osu.GetStats(parameters[0], msg);
        }
    }
}
