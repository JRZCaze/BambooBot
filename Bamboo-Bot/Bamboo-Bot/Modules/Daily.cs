using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bamboo_Bot.Modules;
using Bamboo_Bot.Lists;
using Bamboo_Bot.Discord;

namespace Bamboo_Bot.Modules
{
    public class Daily : ModuleBase<SocketCommandContext>
    {
        [Command("Foraging")]
        public async Task BambooWhackAsync()
        {
            if (Players.IsValidPlayer(Context.User.Id))
            {
                int pos = Players.FindPlayer(Context.User.Id);
                if (Program.PlayerList[pos].LastDaily.AddDays(1) < DateTime.Now)
                {
                    Random rng = new Random();
                    int value = rng.Next(DataLists.ForageResults.Count);
                    await ReplyAsync(DataLists.ForageResults[value]);
                    Currency.MutateCurrency(Context.User.Id, DataLists.ForageResultsValues[value]);
                    Currency.CurrencyBelowZeroFix(Context.User.Id);
                    Program.PlayerList[pos].LastDaily = DateTime.Now;
                }
                else
                {
                    await ReplyAsync("Daily not yet available");
                }
            }
        }
    }
}
