using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPartySimulator.Business_Logic_Layer
{
    public static class TypeHelper
    {
        // 核心字典：中文 (Key) -> 英文 (Value)
        // 根據你資料庫的實際內容，英文部分要注意大小寫 (例如 "fire" 還是 "Fire")
        private static readonly Dictionary<string, string> _typeMap = new Dictionary<string, string>
        {
            { "一般", "Normal" },
            { "火", "Fire" },
            { "水", "Water" },
            { "草", "Grass" },
            { "電", "Electric" },
            { "冰", "Ice" },
            { "格鬥", "Fighting" },
            { "毒", "Poison" },
            { "地面", "Ground" },
            { "飛行", "Flying" },
            { "超能力", "Psychic" },
            { "蟲", "Bug" },
            { "岩石", "Rock" },
            { "幽靈", "Ghost" },
            { "龍", "Dragon" },
        };

        // 功能 1: 給中文，回傳英文 (給資料庫搜尋用)
        public static string ToEnglish(string chineseType)
        {
            if (_typeMap.ContainsKey(chineseType))
            {
                return _typeMap[chineseType];
            }
            return ""; // 找不到就回傳空字串
        }

        // 功能 2: 給英文，回傳中文 (如果你要從資料庫讀出來顯示在介面上)
        public static string ToChinese(string englishType)
        {
            // 反向搜尋：找 Value 對應的 Key
            // 注意：這裡用了 Linq，記得上方要 using System.Linq;
            // 忽略大小寫比較 (IgnoreCase) 以防資料庫是 "fire" 但字典是 "Fire"
            var pair = _typeMap.FirstOrDefault(x => x.Value.Equals(englishType, System.StringComparison.OrdinalIgnoreCase));

            return pair.Key ?? englishType; 
            // 如果找不到中文，就直接顯示原本的英文。這兩個問號 ?? 叫做 「空值接合運算子」 (Null-Coalescing Operator)。
            // 它的意思是：「如果有值就用左邊的，如果是 null 就用右邊的。
        }

        // 功能 3: 取得所有中文屬性列表 (用來填入 ComboBox) 
        public static List<string> GetAllChineseTypes()
        {
            List<string> list = new List<string>();
            list.Add("全部屬性"); // 加一個預設選項
            list.AddRange(_typeMap.Keys.ToList());
            return list;
        }
    }
}
