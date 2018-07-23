using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo_Bot.Modules
{
    public class FeedMe : ModuleBase<SocketCommandContext>
    {
        [Command("Feed")]
        public async Task FeedMeAsync()
        {
            await ReplyAsync("Feeding Panda's");

            await Context.Client.SetGameAsync("Watching over panda's");
        }

        [Command("Feed")]
        public async Task FeedMeAsync(string name)
        {
            await ReplyAsync($"Feeding {name}");

            await Context.Client.SetGameAsync($"Watching over {name}");
        }

        [Command("Feed")]
        public async Task FeedMeAsync(SocketGuildUser user)
        {
            await ReplyAsync($"Feeding {user.Mention}");
        }
    }
}
