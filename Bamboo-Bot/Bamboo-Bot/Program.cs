using Discord.Commands;
using Discord.WebSocket;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Discord;
using System.Runtime.Remoting.Contexts;
using Bamboo_Bot.Lists;
using Bamboo_Bot.Classes;
using Bamboo_Bot.Data;

namespace Bamboo_Bot
{
    class Program : ModuleBase<SocketCommandContext>
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        public static List<PlayerConfig> PlayerList;
        public static DiscordSocketClient Client;
        private CommandService Commands;
        private IServiceProvider Services;
        private ServiceCollection _service;

        public async Task RunBotAsync()
        {
            PlayerList = new List<PlayerConfig>();

            Client = new DiscordSocketClient();
            Commands = new CommandService();
            _service = new ServiceCollection();

            _service.AddSingleton(Client);
            _service.AddSingleton(Commands);
            Services = _service.BuildServiceProvider();

            string botToken = "NDY4ODU1NTM1MzY2ODMyMTQ0.Di_bDQ.RYIAr3wMTOnAgat1wRhvvpj6iz4";

            //event subscriptions
            Client.Log += Log;

            DataSets.InitialiseDataSet();

            await RegisterCommandsAsync();

            await Client.LoginAsync(TokenType.Bot, botToken);

            await Client.StartAsync();

            await Task.Delay(-1);
        }

        private async Task UserDataChecker(SocketGuildUser user)
        {

        }

        private async Task AnnounceUserJoined(SocketGuildUser user)
        {
            var guild = user.Guild;
            var channel = guild.DefaultChannel;
            await channel.SendMessageAsync($"Hello + {user.Mention}");
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);

            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            Client.MessageReceived += HandleCommandAync;

            await Commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message is null || message.Author.IsBot) return;

            int argPos = 0;

            if (message.HasStringPrefix("Bamboo!", ref argPos) || message.HasMentionPrefix(Client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(Client, message);

                var result = await Commands.ExecuteAsync(context, argPos, Services);

                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}
