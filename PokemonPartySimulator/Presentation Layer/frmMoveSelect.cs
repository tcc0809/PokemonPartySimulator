using PokemonPartySimulator.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace PokemonPartySimulator.Presentation_Layer
{
    public partial class frmMoveSelect : Form
    {
        private int _pokemonID;

        // 公開屬性：讓主視窗讀取選了什麼招式
        // 如果沒選，預設為 0 (或 null，看你 DB 設定)
        public int Move1_ID { get; private set; } = 0;
        public int Move2_ID { get; private set; } = 0;
        public int Move3_ID { get; private set; } = 0;
        public int Move4_ID { get; private set; } = 0;
        public frmMoveSelect(int pokemonID)
        {
            InitializeComponent();
            _pokemonID = pokemonID;
            //this.Load += (s, e) => {
            //    splitContainer1.SplitterDistance = splitContainer1.Width / 2;
            //};
        }


        // 封裝一個方法來綁定，減少重複程式碼
        private void BindComboBox(ComboBox cbo, DataTable sourceTable)
        {
            // 這裡要 new 一個新的 BindingSource，否則會產生combox全部一起改變的問題！
            BindingSource bs = new BindingSource();
            bs.DataSource = sourceTable; // 這裡可以共用同一個 DataTable 沒關係

            cbo.DataSource = bs;
            cbo.DisplayMember = "Name_CH"; // 顯示中文招式名
            cbo.ValueMember = "MoveID";    // 實際上選到的是 ID

            // 設置 ComboBox 可以接受空值
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList; // (或 DropDown)

            cbo.SelectedIndex = -1;        // 預設不選
        }
        private DataTable GetMovesByPokemonID(int id)
        {
            // 使用 ADO.NET
            string sql = @"
                SELECT M.MoveID, M.Name_CH, M.Type, M.Power, M.Accuracy 
                FROM Move M 
                JOIN PokemonMoveMapping PMM ON M.MoveID = PMM.MoveID 
                WHERE PMM.PokemonID = @PID";
            //雙引號前的@作用是：告訴編譯器，請把雙引號內的所有內容，都當作「普通字元」來處理，不要轉義 (Escape)。
            //如果「沒有」 @ (一般字串)你的 SQL 裡面所有的反斜線 \ 都會被視為 C# 的轉義字元
            //加了@後，有換行、有間隔， SQL 語法結構較清晰。


            // 2. 準備參數 (把 id 塞給 @PID)
            SqlParameter param = new SqlParameter("@PID", id);

            // 3. 使用 DBHelper 撈取資料
            // (這裡假設 DBHelper 已經正確設定並可使用)
            DataTable dt = DBHelper.GetDataTable(sql, param);

            //  4. 插入「空招式」選項 

            // 4.1. 創建一個新行 (Row)
            DataRow emptyRow = dt.NewRow();

            // 4.2. 設定值 (MoveID=0 代表空，Name_CH="---" 或 "(無)")
            // 確保這裡的欄位名稱 "MoveID" 和 "Name_CH" 與 SQL SELECT 出來的欄位名稱完全一致
            emptyRow["MoveID"] = 0;
            emptyRow["Name_CH"] = "--- (無招式) ---";

            // 4.3. 插入到 DataTable 的最前面 (索引 0)
            dt.Rows.InsertAt(emptyRow, 0);

            // 5. 回傳帶有「空招式」選項的 DataTable
            return dt;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 取得使用者選的 ID (需轉型)
            // 使用 ?. 運算子防止當使用者選 null 時報錯
            Move1_ID = (cbMove1.SelectedValue as int?) ?? 0;
            Move2_ID = (cbMove2.SelectedValue as int?) ?? 0;
            Move3_ID = (cbMove3.SelectedValue as int?) ?? 0;
            Move4_ID = (cbMove4.SelectedValue as int?) ?? 0;
            //int? (或 Nullable<int>)：這是 C# 的**「可空值型別」，
            //它允許 int 這種本來不能是 null 的數值型別，現在可以**是 null
            //as 運算子會嘗試把左邊的 object 轉型成右邊的型別(int?)。
            //轉型成功：回傳轉型後的值（例如 85）。
            //轉型失敗(例如 SelectedValue 是 null)：回傳 null。
            //使用 as 運算子比直接用 (int)強制轉型更安全，因為失敗時它回傳 null，而不是報錯

            //這一步的結果： 如果有選，回傳 int 值；如果沒選，回傳 null。

            // 2. ★★★ 檢查重複的邏輯 (使用 LINQ) ★★★

            // A. 建立一個包含所有招式 ID 的列表
            List<int> selectedMoves = new List<int> { Move1_ID, Move2_ID, Move3_ID, Move4_ID };

            // B. 過濾掉空值 (0)，只留下真正有選的招式 ID
            var chosenMoves = selectedMoves.Where(id => id != 0).ToList();

            // C. 使用 LINQ 判斷：選中的招式數量 是否 大於 
            //    「去重後的招式數量」
            int chosenCount = chosenMoves.Count();
            int distinctCount = chosenMoves.Distinct().Count();

            if (chosenCount != distinctCount)
            {
                // 證明有重複！
                MessageBox.Show("隊伍配置不能選擇重複的招式！請重新選擇。", "配招錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 阻止視窗關閉
            }
            // 3. 確保總數是 4，不足的用 0 補滿
            while (chosenMoves.Count < 4)
            {
                chosenMoves.Add(0);
            }
            this.Move1_ID = chosenMoves[0];
            this.Move2_ID = chosenMoves[1];
            this.Move3_ID = chosenMoves[2];
            this.Move4_ID = chosenMoves[3];
            // 3. 如果沒重複，就可以關閉視窗

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void LoadAvailableMoves()
        {
            // 1. 撈資料
            DataTable dtMoves = GetMovesByPokemonID(_pokemonID);

            // 如果這隻寶可夢沒招式 (例如資料庫還沒建好)，就防呆一下
            if (dtMoves.Rows.Count == 0)
            {
                MessageBox.Show("這隻寶可夢還沒有設定招式資料！");
                return;
            }

            // 2. 綁定資料給 4 個 ComboBox
            // ★★★ 關鍵：必須使用 BindingSource 來隔離，否則會連動 ★★★
            BindComboBox(cbMove1, dtMoves);
            BindComboBox(cbMove2, dtMoves);
            BindComboBox(cbMove3, dtMoves);
            BindComboBox(cbMove4, dtMoves);

            // (選用) 預設選取不同的招式，或是第一招選第一個，其他留空
            cbMove1.SelectedIndex = 0;
            cbMove2.SelectedIndex = -1; // -1 代表不選
        }

        private void frmMoveSelect_Load(object sender, EventArgs e)
        {
            LoadAvailableMoves();
        }
    }
}
