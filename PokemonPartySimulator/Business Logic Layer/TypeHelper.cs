using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonPartySimulator.Model_Layer;


namespace PokemonPartySimulator.Business_Logic_Layer
{
    internal static class TypeHelper
    {
        // 核心字典：中文 (Key) -> 英文 (Value)
        // 根據你資料庫的實際內容，英文部分要注意大小寫 (例如 "fire" 還是 "Fire")
        internal static readonly Dictionary<string, string> _typeMap = new Dictionary<string, string>
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

        // 屬性相剋字典
        // 1. 定義第一世代屬性相性字典 [攻擊方, [防禦方, 倍率]]
        private static readonly Dictionary<string, Dictionary<string, double>> TypeChart = new Dictionary<string, Dictionary<string, double>>
        {
            ["一般"] = new Dictionary<string, double> { ["岩石"] = 0.5, ["幽靈"] = 0 },
            ["格鬥"] = new Dictionary<string, double> { ["一般"] = 2, ["飛行"] = 0.5, ["毒"] = 0.5, ["岩石"] = 2, ["蟲"] = 0.5, ["幽靈"] = 0, ["超能力"] = 0.5, ["冰"] = 2 },
            ["飛行"] = new Dictionary<string, double> { ["格鬥"] = 2, ["岩石"] = 0.5, ["蟲"] = 2, ["草"] = 2, ["電"] = 0.5 },
            ["毒"] = new Dictionary<string, double> { ["毒"] = 0.5, ["地面"] = 0.5, ["岩石"] = 0.5, ["蟲"] = 2, ["幽靈"] = 0.5, ["草"] = 2 },
            ["地面"] = new Dictionary<string, double> { ["飛行"] = 0, ["毒"] = 2, ["岩石"] = 2, ["蟲"] = 0.5, ["火"] = 2, ["草"] = 0.5, ["電"] = 2 },
            ["岩石"] = new Dictionary<string, double> { ["格鬥"] = 0.5, ["飛行"] = 2, ["地面"] = 0.5, ["蟲"] = 2, ["火"] = 2, ["冰"] = 2 },
            ["蟲"] = new Dictionary<string, double> { ["格鬥"] = 0.5, ["飛行"] = 0.5, ["毒"] = 2, ["幽靈"] = 0.5, ["火"] = 0.5, ["草"] = 2, ["超能力"] = 2 },
            ["幽靈"] = new Dictionary<string, double> { ["一般"] = 0, ["超能力"] = 0, ["幽靈"] = 2 }, // Gen 1 特有：幽靈對超能力無效
            ["火"] = new Dictionary<string, double> { ["岩石"] = 0.5, ["蟲"] = 2, ["火"] = 0.5, ["水"] = 0.5, ["草"] = 2, ["冰"] = 2, ["龍"] = 0.5 },
            ["水"] = new Dictionary<string, double> { ["地面"] = 2, ["岩石"] = 2, ["火"] = 2, ["水"] = 0.5, ["草"] = 0.5, ["龍"] = 0.5 },
            ["草"] = new Dictionary<string, double> { ["飛行"] = 0.5, ["毒"] = 0.5, ["地面"] = 2, ["岩石"] = 2, ["蟲"] = 0.5, ["火"] = 0.5, ["水"] = 2, ["草"] = 0.5, ["龍"] = 0.5 },
            ["電"] = new Dictionary<string, double> { ["飛行"] = 2, ["地面"] = 0, ["水"] = 2, ["草"] = 0.5, ["電"] = 0.5, ["龍"] = 0.5 },
            ["超能力"] = new Dictionary<string, double> { ["格鬥"] = 2, ["毒"] = 2, ["超能力"] = 0.5 },
            ["冰"] = new Dictionary<string, double> { ["飛行"] = 2, ["地面"] = 2, ["水"] = 0.5, ["草"] = 2, ["冰"] = 0.5, ["龍"] = 2 },
            ["龍"] = new Dictionary<string, double> { ["龍"] = 2 }
        };

        // 2. 取得單一攻擊對單一防禦的倍率
        public static double GetEffectiveness(string attackerType, string defenderType)
        {
            if (attackerType == "None" || defenderType == "None") return 1.0;

            // 如果字典裡有定義該攻擊屬性對該防禦屬性的特殊倍率，就回傳；否則回傳 1.0 (一般傷害)
            if (TypeChart.ContainsKey(attackerType) && TypeChart[attackerType].ContainsKey(defenderType))
            {
                return TypeChart[attackerType][defenderType];
            }
            return 1.0;
        }

        // 3. 計算全隊弱點分析 (這會統計哪些屬性打進來最痛)
        public static Dictionary<string, int> AnalyzeTeamWeaknesses(IEnumerable<TeamMember> team)
        {
            var weaknessScore = new Dictionary<string, int>(); // [屬性, 隊伍怕它的指數]
            var allTypes = new[] { "一般", "格鬥", "飛行", "毒", "地面", "岩石", "蟲", "幽靈", "火", "水", "草", "電", "超能力", "冰", "龍" };

            foreach (var type in allTypes) weaknessScore[type] = 0;

            foreach (var member in team)
            {
                if (member == null || member.PokemonID <= 0) continue;

                var pm = TeamManager.GetPokemonByID(member.PokemonID);
                if (pm == null) continue;

                foreach (var attackerType in allTypes)
                {
                    // 計算雙重屬性的相乘效果 (例如：地面打噴火龍，1.0x0=0)
                    double eff1 = GetEffectiveness(attackerType, ToChinese(pm.Type1));
                    double eff2 = GetEffectiveness(attackerType, ToChinese(pm.Type2));
                    double totalEff = eff1 * eff2;

                    if (totalEff > 1.0) weaknessScore[attackerType]++; // 隊伍中有一隻怕這個屬性，分數+1
                    if (totalEff < 1.0) weaknessScore[attackerType]--; // 隊伍中有一隻抗這個屬性，分數-1
                }
            }
            return weaknessScore;
        }

        // 功能 1: 給中文，回傳英文 (給資料庫搜尋用)
        internal static string ToEnglish(string chineseType)
        {
            if (_typeMap.ContainsKey(chineseType))
            {
                return _typeMap[chineseType];
            }
            return ""; // 找不到就回傳空字串
        }

        // 功能 2: 給英文，回傳中文 (如果你要從資料庫讀出來顯示在介面上)
        internal static string ToChinese(string englishType)
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
        internal static List<string> GetAllChineseTypes()
        {
            List<string> list = new List<string>();
            list.Add("全部屬性"); // 加一個預設選項
            list.AddRange(_typeMap.Keys.ToList());
            return list;
        }

        // 功能 4: 屬性分析
        internal static Dictionary<string, int> AnalyzeTeamTypes(IEnumerable<TeamMember> team)
        {
            var distribution = new Dictionary<string, int>();

            foreach (var member in team)
            {
                if (member == null || member.PokemonID <= 0) continue;

                // 這裡需要透過 TeamManager 拿到 Pokemon 的完整資訊 (才有 Type1, Type2)
                var pokemon = TeamManager.GetPokemonByID(member.PokemonID);

                // 統計屬性 1
                AddTypeToCount(distribution, pokemon.Type1);
                // 統計屬性 2 (如果有)
                if (!string.IsNullOrEmpty(pokemon.Type2) && pokemon.Type2 != "None")
                {
                    AddTypeToCount(distribution, pokemon.Type2);
                }
            }
            return distribution;
        }

        internal static void AddTypeToCount(Dictionary<string, int> dict, string typeEN)
        {
            if (string.IsNullOrEmpty(typeEN)) return;

            // 轉成中文方便顯示層直接用
            string typeCH = ToChinese(typeEN);

            if (dict.ContainsKey(typeCH)) dict[typeCH]++;
            else dict[typeCH] = 1;
        }
    }
}
