using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bamboo_Bot.Lists;

namespace Bamboo_Bot.Modules
{
    public class Trivia : ModuleBase<SocketCommandContext>
    {
        [Command("Trivia")]
        public async Task BambooWhackAsync()
        {
            Random rng = new Random();
            int value = rng.Next(DataLists.Facts.Count);            
            await ReplyAsync(DataLists.Facts[value]);
            await Context.Client.SetGameAsync("Telling interesting facts");
        }
    }
}
