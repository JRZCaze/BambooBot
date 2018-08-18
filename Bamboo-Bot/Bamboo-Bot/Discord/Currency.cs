using Bamboo_Bot.Classes;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo_Bot.Discord
{
    public class Currency : ModuleBase<SocketCommandContext>
    {
        [Command("MyCurrency")]
        public async Task BambooWhackAsync()
        {
            if (Players.IsValidPlayer(Context.User.Id))
            {
                string myCurrency = Program.PlayerList[Players.FindPlayer(Context.User.Id)].Cash.ToString();
                await ReplyAsync($"You have {myCurrency} credits");
            }
            else
            {
                await ReplyAsync("You haven't joined the panda squad yet");
            }
        }

        public static void MutateCurrency(ulong userId, int CurrencyMutation)
        {
            for (int i = 0; i < Program.PlayerList.Count; i++)
            {
                if (Program.PlayerList[i].ID == userId)
                {
                    Program.PlayerList[i].Cash += CurrencyMutation;
                }
            }
        }
        public static bool CanAfford(ulong userId, int CurrencyMutation)
        {
            for (int i = 0; i < Program.PlayerList.Count; i++)
            {
                if (Program.PlayerList[i].ID == userId)
                {
                    if ((Program.PlayerList[i].Cash + CurrencyMutation >= 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void CurrencyBelowZeroFix(ulong userId)
        {
            for (int i = 0; i < Program.PlayerList.Count; i++)
            {
                if (Program.PlayerList[i].ID == userId & Program.PlayerList[i].Cash < 0)
                {
                    Program.PlayerList[i].Cash = 0;
                }
            }
        }
    }
}
