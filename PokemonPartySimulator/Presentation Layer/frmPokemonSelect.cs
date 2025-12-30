using PokemonPartySimulator.Business_Logic_Layer;
using PokemonPartySimulator.Data_Access_Layer;
using PokemonPartySimulator.Model_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

//使用 TableAdapter。
//優點：因為要顯示大量資料列表，DataSet 幫你把資料一次拉到記憶體 (DataTable)，然後用 DataView 做篩選，
//這樣做搜尋功能（如 ApplyFilter）非常快，不用每次打字都去問資料庫。
namespace PokemonPartySimulator.Presentation_Layer
{
    public partial class frmPokemonSelect : Form
    {

        private List<StatBar> _statBars; // 追蹤所有 6 個數值的列表

        // 1. 建立一個公開屬性，用來讓主視窗讀取選到的 ID
        public int SelectedPokemonID { get; private set; } = -1;
        // 用來儲存其他的基本資料，方便主視窗不用馬上再查一次 DB (選擇性)
        public string SelectedPokemonName { get; private set; }

        public frmPokemonSelect()
        {
            InitializeComponent();
            pokemonDataTableAdapter.Fill(pokemonPartySimulatorDataSet.PokemonData);
 
            cbType.DataSource = TypeHelper.GetAllChineseTypes();
            cbType.SelectedIndex = 0; // 預設選 "全部屬性"
            txtSearch.Text = "";
            ApplyFilter();
        }
        private void ApplyFilter()
        {
            // 1. 取得輸入
            string searchText = txtSearch.Text.Trim();
            string selectedChineseType = cbType.SelectedItem?.ToString() ?? "全部屬性";

            List<string> filterParts = new List<string>();

            // 2. 名字條件 (記得括號！)
            // 邏輯：(中文名包含 OR 英文名包含)
            if (!string.IsNullOrEmpty(searchText))
            {
                filterParts.Add($" (Name_CH LIKE '%{searchText}%' OR Name_EN LIKE '%{searchText}%') ");
            }

            // 3. 屬性條件 (記得括號！)
            // 邏輯：(Type1是.. OR Type2是..)
            if (selectedChineseType != "全部屬性")
            {
                string typeEN = TypeHelper.ToEnglish(selectedChineseType);
                if (!string.IsNullOrEmpty(typeEN))
                {
                    filterParts.Add($" (Type1 = '{typeEN}' OR Type2 = '{typeEN}') ");
                }
            }

            // 4. 組合條件 (用 AND 連接)
            // 最終字串會像： (名字..) AND (屬性..)
            string finalFilter = filterParts.Count > 0 ? string.Join(" AND ", filterParts) : null;

            DataView view = new DataView(pokemonPartySimulatorDataSet.PokemonData);
            view.RowFilter = finalFilter; // 設定過濾條件

            // 6. 重畫介面
            RefreshPokemonList(view);
        }
        private void RefreshPokemonList(DataView view)
        {
            // 1. 【重要】先清空目前的畫面，不然搜尋結果會疊加上去
            LayoutPanelPS.SuspendLayout();
            LayoutPanelPS.Controls.Clear();

            Control firstClick = null; // 用來存第一個

            // 2. 跑迴圈
            foreach (DataRowView rowView in view)
            {
                // (1) 在迴圈開頭只呼叫一次 Mapper，把資料轉成物件
                Pokemon pm = SqlMapper.ToPokemon(rowView.Row);

                Panel pnlItem = new Panel();
                pnlItem.Size = new Size(160, 74);
                pnlItem.BorderStyle = BorderStyle.FixedSingle;
                pnlItem.Tag = pm.PokemonID;

                PictureBox pbx = new PictureBox();
                pbx.Size = new Size(64, 64);
                pbx.SizeMode = PictureBoxSizeMode.Zoom;
                pbx.Tag = pm.PokemonID; // 存 ID

                // (2) 修正 imageKey，直接拿物件的 ID
                string imageKey = $"{pm.PokemonID}.png";

                if (imageListPokemon.Images.ContainsKey(imageKey))
                {
                    pbx.Image = imageListPokemon.Images[imageKey];
                }
                else
                {
                    pbx.Image = null;
                }
                pbx.Location = new Point(2, 2);

                Label lblName = new Label();
                lblName.Text = pm.Name_CH; // 直接從物件拿名字
                lblName.AutoSize = true;
                lblName.Location = new Point(74, 10);
                lblName.Tag = pm.PokemonID; // 存 ID
                lblName.Font = new Font(this.Font.FontFamily, 11);

                if (firstClick == null)
                {
                    firstClick = pnlItem;
                }

                pnlItem.Click += Item_Click;
                pbx.Click += Item_Click;
                lblName.Click += Item_Click;

                // 將 UI 元件加入 Panel
                pnlItem.Controls.Add(pbx);
                pnlItem.Controls.Add(lblName);

                // 將 Panel 加入 LayoutPanel
                LayoutPanelPS.Controls.Add(pnlItem);
            }

            // 3. 模擬點擊第一個
            if (firstClick != null)
            {
                // 這行會直接觸發 BtnSelect_Click 事件
                // 就像使用者真的用滑鼠點了一下第一顆按鈕一樣
                // 圖片會載入，Timer 動畫也會開始跑！
                Item_Click(firstClick, EventArgs.Empty);
            }
            else
            {
                // ⭐ 【關鍵新增】如果 firstClick 是 null，代表搜尋不到任何資料
                // 這時候必須「手動清空」右邊的詳細資料
                ClearDetails();
            }
            LayoutPanelPS.ResumeLayout();
        }
        private void Item_Click(object sender, EventArgs e)
        {
            // 1. 因為 sender 可能是 Panel, Label 或 PictureBox
            //    它們的共同父類別是 Control，所以轉成 Control 即可
            Control clickedControl = (Control)sender;

            // 2. 從 Tag 取出 ID (因為每個都塞了 Tag)
            if (clickedControl.Tag != null)
            {
                int pokemonIDSelect = (int)clickedControl.Tag;

                // 3. 執行Show邏輯
                ShowPokemonDetails(pokemonIDSelect);
            }
        }

        private void ShowPokemonDetails(int pokemonID)
        {

            // 3. 取得圖片的 Key (名稱)
            string imageKey = $"{pokemonID}.png";

            // 4. 從 ImageList 載入大圖到 PictureBox 

            if (imageListPokemon.Images.ContainsKey(imageKey))
            {
                pictureBoxLarge.Image = imageListPokemon.Images[imageKey];
            }
            else pictureBoxLarge.Image = null;// 防呆

            var currentRow = pokemonPartySimulatorDataSet.PokemonData.FindByPokemonID(pokemonID);

            if (currentRow != null)
            {
                // 3. 手動填入 TextBox (因為繞過了 BindingSource)
                // 這樣做不會受 Filter 影響
                pokemonIDTextBox.Text = currentRow.PokemonID.ToString();
                name_ENTextBox.Text = currentRow.Name_EN;
                name_CHTextBox.Text = currentRow.Name_CH;
                labLargeName.Text = currentRow.Name_CH;
                labTotal.Text = currentRow.Base_Total.ToString();
                labHP.Text = currentRow.HP.ToString();
                labATK.Text = currentRow.Attack.ToString();
                labDEF.Text = currentRow.Defense.ToString();
                labSP.Text = currentRow.Special.ToString();
                labSpeed.Text = currentRow.Speed.ToString();

                // 翻譯屬性
                txtType1.Text = TypeHelper.ToChinese(currentRow.Type1);
                txtType2.Text = TypeHelper.ToChinese(currentRow.Type2);

                // 4. 血條動畫初始化 (物件化後邏輯不變，只是資料來源改成 currentRow)
                _statBars = new List<StatBar>
                    {
                        new StatBar { Control = pnlTotal, TargetValue = currentRow.Base_Total, Name = "Base_Total", ValueControl = labTotal },
                        new StatBar { Control = pnlHP, TargetValue = currentRow.HP, Name = "HP", ValueControl = labHP },
                        new StatBar { Control = pnlATK, TargetValue = currentRow.Attack, Name = "Attack", ValueControl = labATK },
                        new StatBar { Control = pnlDEF, TargetValue = currentRow.Defense, Name = "Defense", ValueControl = labDEF },
                        new StatBar { Control = pnlSP, TargetValue = currentRow.Special, Name = "Special", ValueControl = labSP },
                        new StatBar { Control = pnlSpeed, TargetValue = currentRow.Speed, Name = "Speed", ValueControl = labSpeed },
                    };
                // ⭐ 將所有血條視覺上「歸零」
                // 如果不加這段，切換寶可夢時，血條可能會從上一次的長度繼續跑，或者卡住
                foreach (var bar in _statBars)
                {
                    bar.Control.Size = new Size(0, bar.Control.Size.Height);
                }
                timerStatus.Start();
            }
        

        }

        private void ClearDetails()
        {
            // 1. 清空所有文字框
            pokemonIDTextBox.Text = "";
            name_ENTextBox .Text = "";
            name_CHTextBox.Text = "";
            txtType1.Text = "";
            txtType2.Text = "";
            labTotal.Text = "";
            labHP.Text = "";
            labATK.Text = "";
            labDEF.Text = "";
            labSP.Text = "";
            labSpeed.Text = "";
            labLargeName.Text = "";
            // 2. 清空圖片
            pictureBoxLarge.Image = null;

            // 3. 清空並停止血條動畫
            // 停止 Timer
            timerStatus.Stop();

            // 讓所有血條歸零
            if (_statBars != null)
            {
                foreach (var bar in _statBars)
                {
                    // 把長度設為 0
                    bar.Control.Size = new Size(0, bar.Control.Size.Height);

                    // 讓數字跟著歸零位置或隱藏
                    int newX = bar.Control.Location.X + 5;
                    bar.ValueControl.Location = new Point(newX, bar.ValueControl.Location.Y);
                }
            }
        }

        private void frmPokemonSelect_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'pokemonPartySimulatorDataSet.PokemonData' 資料表。您可以視需要進行移動或移除。
            ApplyFilter();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            bool allFinished = true; // 追蹤所有動畫是否都已完成
            //int stepSize = 10;       // 每次增加的步長 (可調整，數字越大，跑越快)

            // ⭐ 你的介面血條最長可以是多少像素？
            const int MAX_BAR_PIXEL_WIDTH = 270;
            // ⭐ 你的寶可夢總數值上限是多少？ (Base Total Max)
            const int GLOBAL_MAX_STAT_VALUE = 700; // 假設 Base Total 上限為 600

            // 遍歷列表中的每一個 StatBar
            for (int i = 0; i < _statBars.Count; i++)
            {
                // 1. 【核心】取出 Struct 的複本 (以便修改)
                StatBar bar = _statBars[i];

                if (bar.CurrentValue < bar.TargetValue)
                {
                    allFinished = false; // 只要有一個還在跑，就不能停 Timer

                    // 2. 計算步長：數值越大，跑越快 (防止動畫太慢)
                    // 讓步長至少為 1
                    int dynamicStep = bar.TargetValue / 50 + 1;

                    // 3. 更新當前值
                    bar.CurrentValue += dynamicStep;

                    // 4. 防止超過目標值
                    if (bar.CurrentValue > bar.TargetValue)
                    {
                        bar.CurrentValue = bar.TargetValue;
                    }

                    // 5. 【轉換成像素寬度】: 比例計算
                    // 將數值 (0~600) 轉換成像素 (0~300)
                    int newWidth = (int)((double)bar.CurrentValue / GLOBAL_MAX_STAT_VALUE * MAX_BAR_PIXEL_WIDTH);

                    // 6. 更新畫面
                    // 使用原本的 "Control" (Panel)
                    bar.Control.Size = new Size(newWidth, bar.Control.Size.Height);

                    // 計算新座標：血條的 X + 血條的寬度 + 5
                    int newX = bar.Control.Location.X + bar.Control.Width + 5;

                    // 使用新的 "ValueControl" (Label) 來設定位置
                    bar.ValueControl.Location = new Point(newX, bar.ValueControl.Location.Y);

                    // 7. 【重要】將修改後的 Struct 複本寫回列表 (因為 struct 是值型別)
                    _statBars[i] = bar;

                }

            }

            // 8. 檢查是否全部完成
            if (allFinished)
            {
                timerStatus.Stop(); // 停止計時器
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnJoinTeam_Click(object sender, EventArgs e)
        {
            // 嘗試將文字轉成數字，成功會回傳 true 且把值塞入變數 id
            if (int.TryParse(pokemonIDTextBox.Text, out int id))
            {
                this.SelectedPokemonID = id;
                this.SelectedPokemonName = name_CHTextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // 轉型失敗（例如文字框是空的），顯示警告
                MessageBox.Show("請先選擇寶可夢！");
            }
        }

        // frmPokemonSelect.cs 內部

        internal void ResetSearch()
        {
            // 1. 清空搜尋文字框
            txtSearch.Text = "";

            // 2. 將屬性下拉選單設回第一個 ("全部屬性")
            if (cbType.Items.Count > 0)
            {
                cbType.SelectedIndex = 0;
            }

            // 3. 手動呼叫一次過濾邏輯，讓列表恢復顯示全部 151 隻
            ApplyFilter();

            // 4. 每次打開都回到最上面，重置捲軸
            LayoutPanelPS.AutoScrollPosition = new Point(0, 0);
        }
    }
}
