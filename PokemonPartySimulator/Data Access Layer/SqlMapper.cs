using PokemonPartySimulator.Model_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPartySimulator.Data_Access_Layer
{
    internal static class SqlMapper
    {
        // 將 DataRow 轉換為 TeamMember 物件
        internal static TeamMember ToTeamMember(DataRow row)
        {
            if (row == null) return null;

            return new TeamMember
            {
                SlotIndex = Convert.ToInt32(row["SlotIndex"]),
                PokemonID = Convert.ToInt32(row["PokemonID"]),
                // 這裡的 Name 是為了 UI 顯示方便，資料庫裡沒有這欄，所以先給空字串
                // 之後再由 Manager 去填入
                Name = "",
                Move1_ID = Convert.ToInt32(row["Move1_ID"]),
                Move2_ID = Convert.ToInt32(row["Move2_ID"]),
                Move3_ID = Convert.ToInt32(row["Move3_ID"]),
                Move4_ID = Convert.ToInt32(row["Move4_ID"]),
                ItemID = row["Item"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["Item"]),
                AbilityID = row["Ability"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["Ability"])
            };
        }

        // 將 DataRow 轉換為 Pokemon 物件
        internal static Pokemon ToPokemon(DataRow row)
        {
            if (row == null) return null;

            return new Pokemon
            {
                PokemonID = Convert.ToInt32(row["PokemonID"]),
                Name_CH = row["Name_CH"].ToString(),
                Name_EN = row["Name_EN"].ToString(),
                Type1 = row["Type1"].ToString(),
                Type2 = row["Type2"].ToString(),
                Base_Total = Convert.ToInt32(row["Base_Total"]),
                HP = Convert.ToInt32(row["HP"]),
                Attack = Convert.ToInt32(row["Attack"]),
                Defense = Convert.ToInt32(row["Defense"]),
                Special = Convert.ToInt32(row["Special"]),
                Speed = Convert.ToInt32(row["Speed"])
            };
        }
    }
}
