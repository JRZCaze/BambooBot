using Bamboo_Bot.Data;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo_Bot.Modules
{
    public class LeagueOfLegendsTeamBuilder : ModuleBase<SocketCommandContext>
    {
        public static string[] champions;
        System.Net.WebClient wc = new System.Net.WebClient();
        string Game;

        [Command("LoLCustom")]
        public async Task FeedMeAsync(int red, int blue)
        {
            Game = "";
            byte[] raw = wc.DownloadData("http://www.simonvandoorne.com/index.php/actions/teamBuilder/handler/test?red=" + red + "&blue=" + blue);
            string webData = System.Text.Encoding.UTF8.GetString(raw);
            Json.RecievedDataConverter(webData);

            foreach (string champion in champions)
            {
                Game = Game + " "+champion; 
            }

            await ReplyAsync($"{Game}");
        }
    }
}
