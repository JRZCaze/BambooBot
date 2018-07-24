using Bamboo_Bot.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo_Bot.Data
{
    class DataSets
    {
        public static int StartingCurrency = 5;
        public static int BigJackpot = 5;
        public static int SmallJackpot = 3;
        public static int SlotMachineCost = -1;

        public static void InitialiseDataSet()
        {
            IntegerVariables();
            StringVariables();
            DataLists.InitialiseDataLists();
        }
        //ints
        public static void IntegerVariables()
        {
        }
        //strings
        public static void StringVariables()
        {
            
        }
    }
}
