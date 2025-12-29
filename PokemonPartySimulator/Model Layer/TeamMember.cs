using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPartySimulator.Model_Layer
{
    internal class TeamMember
    {
        internal int SlotIndex { get; set; } // 0~5
        internal int PokemonID { get; set; }
        internal string Name { get; set; }
        // 預留招式 ID，之後選招式用
        internal int Move1_ID { get; set; }
        internal int Move2_ID { get; set; }
        internal int Move3_ID { get; set; }
        internal int Move4_ID { get; set; }

        // 預留以後擴充
        internal int? ItemID { get; set; }
        internal int? AbilityID { get; set; }
    }

}
