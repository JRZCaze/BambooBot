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
        List<string> team = new List<string>();
        System.Net.WebClient wc = new System.Net.WebClient();
        string Team1;

        [Command("LoLCustom")]
        public async Task FeedMeAsync(int TeamA, int TeamB)
        {
            Team1 = "";
            byte[] raw = wc.DownloadData("http://www.yoursite.com/resource/file.htm");
            string webData = System.Text.Encoding.UTF8.GetString(raw);
            Json.RecievedDataConverter(webData);

            //team.Add("Illoai");
            //team.Add("Zac");
            foreach (string champions in team)
            {
                Team1 = Team1 +"-"+champions; 
            }

            await ReplyAsync($"{Team1}");
        }
    }
}
