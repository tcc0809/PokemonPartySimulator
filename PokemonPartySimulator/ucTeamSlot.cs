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
        
        public int PokemonID { get; private set; } = -1;
        // private set (封裝)：外部（主視窗）不能直接修改 ID（例如不能寫 slot1.PokemonID = 5），必須透過你提供的 SetPokemon 或 ClearSlot 方法來改。
        // 這樣保證了 UI 和數據永遠同步，不會出現「ID 改了但圖片沒變」的 Bug。
        // -1 代表空位，預設為1代表還沒選。

        // 定義自訂事件，讓主視窗訂閱
        public event EventHandler SlotClicked;
        public event EventHandler RemoveClicked;
        public event EventHandler SlotMouseEnter;
        public event EventHandler SlotMouseLeave;


        public string Move1_Name { get; private set; } = "";
        public string Move2_Name { get; private set; } = "";
        public string Move3_Name { get; private set; } = "";
        public string Move4_Name { get; private set; } = "";

        // 新增：更新招式的方法 (注意：這裡的 Name 來自 DB 查詢結果)
        internal void SetMoves(string name1, string name2, string name3, string name4)
        {
            this.Move1_Name = name1;
            this.Move2_Name = name2;
            this.Move3_Name = name3;
            this.Move4_Name = name4;

            // 更新 UI 上的 Label
            labMove1.Text = name1;
            labMove2.Text = name2;
            labMove3.Text = name3;
            labMove4.Text = name4;

            // 確保它們是可見的
            labMove1.Visible = !string.IsNullOrEmpty(name1);
            labMove2.Visible = !string.IsNullOrEmpty(name2);
            labMove3.Visible = !string.IsNullOrEmpty(name3);
            labMove4.Visible = !string.IsNullOrEmpty(name4);
        }
        public ucTeamSlot()
        {
            InitializeComponent();
            // 把內部所有東西的 Click 都綁定到同一個觸發器
            this.Click += TriggerClick;
            pbPokemon.Click += TriggerClick;
            labName.Click += TriggerClick;
            labPlus.Click += TriggerClick;
            labMove1.Click += TriggerClick;
            labMove2.Click += TriggerClick;
            labMove3.Click += TriggerClick;
            labMove4.Click += TriggerClick;

            // 把內部所有東西的 MouseEnter 都綁定到同一個觸發器
            this.MouseEnter += TriggerMouseEnter;
            pbPokemon.MouseEnter += TriggerMouseEnter;
            labName.MouseEnter += TriggerMouseEnter;
            labPlus.MouseEnter += TriggerMouseEnter;
            labMove1.MouseEnter += TriggerMouseEnter;
            labMove2.MouseEnter += TriggerMouseEnter;
            labMove3.MouseEnter += TriggerMouseEnter;
            labMove4.MouseEnter += TriggerMouseEnter;

            // 把內部所有東西的 MouseLeave 都綁定到同一個觸發器
            this.MouseLeave += TriggerMouseLeave;
            pbPokemon.MouseLeave += TriggerMouseLeave;
            labName.MouseLeave += TriggerMouseLeave;
            labPlus.MouseLeave += TriggerMouseLeave;
            labMove1.MouseLeave += TriggerMouseLeave;
            labMove2.MouseLeave += TriggerMouseLeave;
            labMove3.MouseLeave += TriggerMouseLeave;
            labMove4.MouseLeave += TriggerMouseLeave;

            btnDelete.Click += btnRemove_Click;
            // 初始化為空狀態
            ClearSlot();
        }
        // 統一觸發事件
        private void TriggerMouseEnter(object sender, EventArgs e)
        {
            SlotMouseEnter?.Invoke(this, e);
        }
        private void TriggerMouseLeave(object sender, EventArgs e)
        {
            SlotMouseLeave?.Invoke(this, e);
        }



        
        private void TriggerClick(object sender, EventArgs e)
        {
            SlotClicked?.Invoke(this, e);
            //?.：這是 Null 檢查運算子。意思是「如果有人訂閱 (+=) 了這個事件，才執行；如果沒人訂閱（是 null），就什麼都不做，防止程式崩潰」。
            //this：把 UserControl 自己 當作 sender 傳出去。這樣主視窗收到事件時，sender 就會是 ucTeamSlot，而不是裡面的 pbPokemon 或 labName。
            //Invoke：「喚起」、「調用」 或 「執行」
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // 2. 觸發這個事件
            // 使用 ?.Invoke() 安全地通知所有訂閱者
            RemoveClicked?.Invoke(this, e);

            // 注意：這裡只負責「發通知」，不負責「清空」
            // 清空邏輯要留給主視窗 frmTeamEditor 執行！
        }

        // 設定這格的資料
        public void SetPokemon(int id, string name, Image img)
        {
            this.PokemonID = id;

            // UI 切換
            labPlus.Visible = false;       // 隱藏 + 號
            pbPokemon.Visible = true;      // 顯示圖片
            labName.Visible = true;        // 顯示名字
            btnDelete.Visible = true;

            pbPokemon.Image = img;
            labName.Text = name;
        }

        // 清空這格
        public void ClearSlot()
        {
            this.PokemonID = -1;

            // UI 切換
            labPlus.Visible = true;        // 顯示 + 號
            pbPokemon.Visible = false;     // 隱藏圖片
            labName.Visible = false;       // 隱藏名字
            btnDelete.Visible = false;

            pbPokemon.Image = null;
            labName.Text = "";

            this.BackColor = Color.White ; // 回復空位顏色

            this.Move1_Name = this.Move2_Name = this.Move3_Name = this.Move4_Name = "";
            labMove1.Text = labMove2.Text = labMove3.Text = labMove4.Text = "";
        }
    }
}
