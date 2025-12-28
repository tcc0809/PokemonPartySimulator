using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPartySimulator.Classes
{
    internal class Pokemon
    {
        internal int PokemonID { get; set; }
        internal string Name_CH { get; set; }
        internal string Name_EN { get; set; }
        internal string Type1 { get; set; }
        internal string Type2 { get; set; }

        // 種族值
        internal int Base_Total { get; set; }
        internal int HP { get; set; }
        internal int Attack { get; set; }
        internal int Defense { get; set; }
        internal int Special { get; set; }
        internal int Speed { get; set; }
    }
}
