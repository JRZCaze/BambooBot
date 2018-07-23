using Bamboo_Bot.Classes;
using Bamboo_Bot.Data;
using Discord.Commands;
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
    public class Players : ModuleBase<SocketCommandContext>
    {
        [Command("Join")]
        public async Task JoinDatabase() // gets cleared when run again, needs changeing
        {
            bool AlreadyJoined = false;
            for (int i = 0; i < Program.PlayerList.Count; i++)
            {
                if (Program.PlayerList[i].ID == Context.User.Id)
                {
                    AlreadyJoined = true;
                }
            }
            if (!AlreadyJoined)
            {
                PlayerConfig user = new PlayerConfig();
                user.ID = Context.User.Id;
                user.Cash = DataSets.StartingCurrency;
                Program.PlayerList.Add(user);
                await ReplyAsync($"{Context.User.Username} joined");
            }
            else
            {
                await ReplyAsync($"{Context.User.Username} already joined");
            }
        }

        [Command("Currency")]
        public async Task MutateCurrency(SocketGuildUser user, int mutation)
        {
            //if (Context.User.Id == AdminId)
            //{
            if (IsValidPlayer(user.Id))
            {
                Program.PlayerList[FindPlayer(user.Id)].Cash += mutation;
                if (Program.PlayerList[FindPlayer(user.Id)].Cash < 0)
                {
                    Program.PlayerList[FindPlayer(user.Id)].Cash = 0;
                }

            }
            //}
        }

        public static bool IsValidPlayer(ulong userId)
        {
            for (int i = 0; i < Program.PlayerList.Count; i++)
            {
                if (Program.PlayerList[i].ID == userId)
                {
                    return true;
                }
            }
            return false;
        }

        public static int FindPlayer(ulong userId)
        {
            for (int i = 0; i < Program.PlayerList.Count; i++)
            {
                if (Program.PlayerList[i].ID == userId)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
