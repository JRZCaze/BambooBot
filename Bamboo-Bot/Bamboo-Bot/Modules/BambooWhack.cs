using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo_Bot.Modules
{
    public class BambooWhack : ModuleBase<SocketCommandContext>
    {
        [Command("BambooWhack")]
        public async Task BambooWhackAsync()
        {
            await ReplyAsync("A panda has suffered immense damage");
            await Context.Client.SetGameAsync("Panda abuse simulator");
        }

        [Command("BambooWhack")]
        public async Task BambooWhackPersonAsync(string name)
        {
            await ReplyAsync($"{name} has suffered immense damage");
        }

        [Command("BambooWhack")]
        public async Task BambooWhackPersonAsync(SocketGuildUser user)
        {
            await ReplyAsync($"{user.Mention} has suffered immense damage");
        }
    }
}
