using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonPartySimulator
{
    public partial class ucTeamSlot : UserControl
    {
        // 暫存資料
        public int SlotIndex { get; set; } // 這是第幾格 (0-5)
        public int PokemonID { get; private set; } = -1; // -1 代表空位

        // 定義一個自訂事件，讓主視窗訂閱
        public event EventHandler SlotClicked;

        public ucTeamSlot()
        {
            InitializeComponent();
            // 重點：把內部所有東西的 Click 都綁定到同一個觸發器
            this.Click += TriggerClick;
            pbPokemon.Click += TriggerClick;
            labName.Click += TriggerClick;
            labPlus.Click += TriggerClick;

            // 初始化為空狀態
            ClearSlot();
        }

        // 統一觸發事件
        private void TriggerClick(object sender, EventArgs e)
        {
            // 呼叫外部訂閱的方法 (通知主視窗：我被點了)
            SlotClicked?.Invoke(this, e);
        }

        // 設定這格的資料
        public void SetPokemon(int id, string name, Image img)
        {
            this.PokemonID = id;

            // UI 切換
            labPlus.Visible = false;       // 隱藏 + 號
            pbPokemon.Visible = true;      // 顯示圖片
            labName.Visible = true;        // 顯示名字

            pbPokemon.Image = img;
            labName.Text = name;

            // 可以順便改背景色讓它看起來像有選中
            this.BackColor = Color.White;
        }

        // 清空這格
        public void ClearSlot()
        {
            this.PokemonID = -1;

            // UI 切換
            labPlus.Visible = true;        // 顯示 + 號
            pbPokemon.Visible = false;     // 隱藏圖片
            labName.Visible = false;       // 隱藏名字

            pbPokemon.Image = null;
            labName.Text = "";

            this.BackColor = Color.LightGray; // 回復空位顏色
        }
    }
}
