using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPartySimulator.Classes
{
    public class TeamMemberData
    {
        public int SlotIndex { get; set; } // 0~5
        public int PokemonID { get; set; }
        public string Name { get; set; }
        // 預留招式 ID，之後選招式用
        public int Move1_ID { get; set; }
        public int Move2_ID { get; set; }
        public int Move3_ID { get; set; }
        public int Move4_ID { get; set; }
    }
}
