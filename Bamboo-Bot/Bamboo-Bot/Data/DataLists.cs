using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo_Bot.Lists
{
    class DataLists
    {
        public static List<string> Facts = new List<string>();
        public static List<int> ForageResultsValues = new List<int>();
        public static List<string> ForageResults = new List<string>();


        public static void InitialiseDataLists()
        {
            InitialiseFactData();
        }

        public static void InitialiseFactData()
        {
            Facts.Add("Pandas are BIG eaters – every day they fill their tummies for up to 12 hours, shifting up to 12 kilograms of bamboo!");
            Facts.Add("The giant panda’s scientific name is Ailuropoda melanoleuca, which means “black and white cat-foot”.");
            Facts.Add("Giant pandas grow to between 1.2m and 1.5m, and weigh between 75kg and 135kg. Scientists aren’t sure how long pandas live in the wild, but in captivity they live to be around 30 years old.");
            Facts.Add("Baby pandas are born pink and measure about 15cm – that’s about the size of a pencil! They are also born blind and only open their eyes six to eight weeks after birth.");
            Facts.Add("It’s thought that these magnificent mammals are solitary animals, with males and females only coming together briefly to mate. Recent research, however, suggests that giant pandas occasionally meet outside of breeding season, and communicate with each other through scent marks and calls.");
            Facts.Add("Family time! Female pandas give birth to one or two cubs every two years. Cubs stay with their mothers for 18 months before venturing off on their own!");
            Facts.Add("Unlike most other bears, pandas do not hibernate. When winter approaches, they head lower down their mountain homes to warmer temperatures, where they continue to chomp away on bamboo!");
            Facts.Add("Sadly, these beautiful bears are endangered, and it’s estimated that only around 1,000 remain in the wild. That’s why we need to do all we can to protect them!");
            Facts.Add("Giant pandas (often referred to as simply “pandas”) are black and white bears. In the wild, they are found in thick bamboo forests, high up in the mountains of central China – you can check out our cool facts about China, here!");
            //Facts.Add("");

            ForageResults.Add("Well done little panda. You have found 10 bamboo sticks");
            ForageResultsValues.Add(10);
            ForageResults.Add("As you were foraging you fell of a tree. You lost 30 bamboo sticks because of your fat ass");
            ForageResultsValues.Add(-30);
            ForageResults.Add("While you were foraging a wild snek appeared. You lost 3 bamboo sticks while defending yourself. At least you're alive!");
            ForageResultsValues.Add(-3);
            ForageResults.Add("While foraging you found a golden froot worth 40 bamboo sticks. You lucky fuck!");
            ForageResultsValues.Add(40);
        }
    }
}
