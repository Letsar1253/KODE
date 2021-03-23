using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    public class ParseJSON
    {
        public Items[] recipes { get; set; }

    }

    public class Items
    {
        public string uuid { get; set; }
        public int lastUpdated { get; set; }
        public string name { get; set; }
        public string[] images { get; set; }
        public string description { get; set; }
        public string instructions { get; set; }
        public int difficulty { get; set; }
    }
}
