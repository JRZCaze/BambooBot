using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo_Bot.Classes
{
    public class PlayerConfig
    {
        public ulong ID { get; set; }

        public int Cash { get; set; }

        public string Title { get; set; }

        //public int Food { get; set; }

        public DateTime LastDaily { get; set; }

        //public Level Level { get; set; }
    }
}
