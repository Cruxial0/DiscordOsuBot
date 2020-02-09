using BotTools;
using BotTools.Handlers;
using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using osu_api;

namespace DiscordOsuBot
{
    public interface IDependencyMap
    {
        void Add<T>(T obj) where T : class;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bot starting...", Console.ForegroundColor = ConsoleColor.Yellow);
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        internal static CommandHandler handler;
        internal static DiscordSocketClient client;
        internal static CancellationTokenSource cancelSrc = new CancellationTokenSource();
        public static osuAPI api;

        public async Task MainAsync()
        {
            Permissions.Load();

            client = new DiscordSocketClient();

            handler = new CommandHandler(client, "o!");

            await client.SetGameAsync("osu! Stats", "", ActivityType.Watching);
            await client.LoginAsync(TokenType.Bot, Secret.token);
            await client.StartAsync();

            api = new osuAPI(Secret.apiKey);

            osu.GetAPI();

            Console.WriteLine("Bot Started Sucessfully!", Console.ForegroundColor = ConsoleColor.Green);

            await Task.Delay(-1, cancelSrc.Token);
        }
    }
}
