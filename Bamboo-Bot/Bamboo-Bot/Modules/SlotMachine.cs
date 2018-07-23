using Bamboo_Bot.Data;
using Bamboo_Bot.Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo_Bot.Modules
{
    public class SlotMachine : ModuleBase<SocketCommandContext>
    {
        static readonly string[] slotMachineItems = new string[] { "🍊", "🍇", "🍓", "🍆", "💎", "🍋", "🔔", "💸" };
        //static readonly string[] slotMachineItems = new string[] { "1", "2", "3", "4", "5", "6", "7", "8" };

        [Command("Slotmachine")]
        public async Task BambooWhackAsync()
        {
            if (Currency.CanAfford(Context.User.Id, DataSets.SlotMachineCost))
            {
                Currency.MutateCurrency(Context.User.Id, DataSets.SlotMachineCost);
                Random rng = new Random();
                string[] slotMachineResult = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    int value = rng.Next(slotMachineItems.Length);
                    slotMachineResult[i] = slotMachineItems[value];
                }
                await ReplyAsync(($"{slotMachineResult[0]} {slotMachineResult[1]} {slotMachineResult[2]}"));// add a check system

                if (slotMachineResult[1] == slotMachineResult[2] || slotMachineResult[1] == slotMachineResult[0])
                {
                    if (slotMachineResult[1] == slotMachineResult[2] && slotMachineResult[1] == slotMachineResult[0])
                    {
                        Currency.MutateCurrency(Context.User.Id, DataSets.BigJackpot);
                        await ReplyAsync("Jackpot");
                        //add coins
                    }
                    else
                    {
                        Currency.MutateCurrency(Context.User.Id, DataSets.SmallJackpot);
                        await ReplyAsync("Small pot");
                        //add coins
                    }
                }
            }
        }
    }
}
