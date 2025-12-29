using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPartySimulator.Model_Layer
{
    internal class Move
    {
        internal int MoveID { get; set; }
        internal string Name_CH { get; set; }
        internal string Name_EN { get; set; }
        internal string Type { get; set; }
        internal int Power { get; set; }
        internal int Accuracy { get; set; }
    }
}
