using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonPartySimulator.Model_Layer
{
    internal struct StatBar
    {
        // C# 變數名稱要跟你的 TextBox 名稱對應 (例如 txtHP)
        internal Panel Control { get; set; }  // 對應的 UI 控制項 (TextBox, PictureBox...)
        internal int TargetValue { get; set; }  // 目標數值 (例如 255)
        internal int CurrentValue { get; set; } // 當前數值 (從 0 開始跑)
        internal int MaxPixelWidth { get; set; } // 欄位最大像素寬度 (例如 300)

        // 讓你知道哪個欄位
        internal string Name { get; set; }
        internal Control ValueControl;
    }
}
