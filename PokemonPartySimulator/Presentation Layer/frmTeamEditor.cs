using PokemonPartySimulator.Classes;
using PokemonPartySimulator.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PokemonPartySimulator.Presentation_Layer
{
    public partial class frmTeamEditor : Form
    {
        private frmPokemonSelect _selectForm;
        private TeamMemberData[] currentTeam = new TeamMemberData[6];
        public frmTeamEditor()
        {
            InitializeComponent();
            ucTeamSlot[] slots = { slot0, slot1, slot2, slot3, slot4, slot5 };

            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].SlotIndex = i; // 確保索引正確
                slots[i].SlotClicked += OnSlotClicked; // 訂閱加寶可夢事件
                slots[i].RemoveClicked += OnRemoveClicked;//訂閱移除事件
            }
        }
        private void OnRemoveClicked(object sender, EventArgs e)
        {
            // 3. 轉型取得是被點的那個控制項 (跟 OnSlotClicked 邏輯一樣)
            ucTeamSlot clickedSlot = sender as ucTeamSlot;
            if (clickedSlot == null) return;

            // 4. 執行清空邏輯 (刪除確認)
            DialogResult result = MessageBox.Show(
                $"確定要從隊伍中移除 {clickedSlot.Name} 嗎？",
                "確認移除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                clickedSlot.ClearSlot();  // 呼叫你寫在 ucTeamSlot 裡的清空方法

                // 清空 currentTeam 陣列
                currentTeam[clickedSlot.SlotIndex] = null;
            }
        }
        private void OnSlotClicked(object sender, EventArgs e)
        {
            ucTeamSlot clickedSlot = sender as ucTeamSlot;
            if (clickedSlot == null) return;

            // 判斷現在是「空位」還是「已有寶可夢」
            if (clickedSlot.PokemonID == -1)
            {
                // Case A: 空位 -> 開啟選擇視窗 (用 _selectForm)
                // 這段程式碼在你的 if 區塊裡面

                if (_selectForm == null || _selectForm.IsDisposed)
                {
                    _selectForm = new frmPokemonSelect();
                }

                if (_selectForm.ShowDialog() == DialogResult.OK)
                {
                    // ★★★ 將選怪成功後更新 UI 的邏輯放在這裡面 ★★★

                    // 1. 載入圖片 (img 變數在這裡宣告並賦值)
                    string imgKey = _selectForm.SelectedPokemonID.ToString() + ".png";
                    Image img = imageListPM.Images.ContainsKey(imgKey) ? imageListPM.Images[imgKey] : null;

                    // 2. 更新 UI
                    clickedSlot.SetPokemon(
                        _selectForm.SelectedPokemonID,
                        _selectForm.SelectedPokemonName,
                        img
                    );

                    // 3. (選用) 這裡可以給一個預設招式 (例如四個空招式)
                    clickedSlot.SetMoves("(無)", "(無)", "(無)", "(無)");

                    // 4.新增成員到 currentTeam 陣列
                    int slotIndex = clickedSlot.SlotIndex;
                    currentTeam[slotIndex] = new TeamMemberData
                    {
                        SlotIndex = slotIndex,
                        PokemonID = _selectForm.SelectedPokemonID,
                        Name = _selectForm.SelectedPokemonName,
                        Move1_ID = 0,
                        Move2_ID = 0,
                        Move3_ID = 0,
                        Move4_ID = 0
                    };
                }
            }
            else // (clickedSlot.PokemonID != -1)
            {
                // Case B: 已有寶可夢 -> 編輯配招 (用 moveForm)

                using (frmMoveSelect moveForm = new frmMoveSelect(clickedSlot.PokemonID))
                {
                    if (moveForm.ShowDialog() == DialogResult.OK)
                    {
                        // 1. 查中文名稱
                        string m1Name = GetMoveNameByID(moveForm.Move1_ID);
                        string m2Name = GetMoveNameByID(moveForm.Move2_ID);
                        string m3Name = GetMoveNameByID(moveForm.Move3_ID);
                        string m4Name = GetMoveNameByID(moveForm.Move4_ID);

                        // 2. 更新 UI (假設你已經在 ucTeamSlot 裡加入了 SetMoves 方法)
                        clickedSlot.SetMoves(m1Name, m2Name, m3Name, m4Name);

                        //  3. 【重要】更新 currentTeam 陣列裡的招式 ID
                        int slotIndex = clickedSlot.SlotIndex;

                        // 確保格子裡真的有東西
                        if (currentTeam[slotIndex] != null)
                        {
                            currentTeam[slotIndex].Move1_ID = moveForm.Move1_ID;
                            currentTeam[slotIndex].Move2_ID = moveForm.Move2_ID;
                            currentTeam[slotIndex].Move3_ID = moveForm.Move3_ID;
                            currentTeam[slotIndex].Move4_ID = moveForm.Move4_ID;
                        }
                    }
                }
            }
        }
        private string GetMoveNameByID(int moveID)
        {
            if (moveID == 0) return "(無)"; // 處理空值

            // 使用你寫好的 DBHelper 來查表
            string sql = "SELECT Name_CH FROM Move WHERE MoveID = @ID";
            SqlParameter param = new SqlParameter("@ID", moveID);

            DataTable dt = DBHelper.GetDataTable(sql, param);

            if (dt.Rows.Count > 0)
            {
                // 回傳中文名稱
                return dt.Rows[0]["Name_CH"].ToString();
            }
            return "(錯誤)"; // 防呆
        }

        private void btnPK1_Click(object sender, EventArgs e)
        {
            frmPokemonSelect f = new frmPokemonSelect();
            f.ShowDialog();
        }

        private void btnSaveTeam_Click(object sender, EventArgs e)
        {
            // 1. 取得隊伍名稱 
            string teamName = txtTeamName.Text.Trim();
            if (string.IsNullOrEmpty(teamName))
            {
                MessageBox.Show("請輸入隊伍名稱！", "警告");
                return;
            }

            // 2. 檢查隊伍成員：至少要有一隻寶可夢
            if (currentTeam.Count(m => m != null && m.PokemonID != -1) == 0)
            {
                MessageBox.Show("隊伍至少需要一隻寶可夢！", "警告");
                return;
            }

            // 執行存檔作業
            int newTeamID = SaveTeam(teamName);

            if (newTeamID > 0)
            {
                MessageBox.Show($"隊伍 [{teamName}] 儲存成功！TeamID: {newTeamID}", "成功");
                // TODO: 存檔成功後，清空畫面或進入讀取模式
            }
            else
            {
                MessageBox.Show("隊伍儲存失敗，請檢查所有輸入值與連線是否正常。", "錯誤");
            }
        }
        //新版SaveTeam寫法，使用交易機制，確保新增隊伍跟成員能同時成功或失敗
        //由於這個交易涉及多次呼叫 ，因此無法DBHelper 裡獨立完成，所以把邏輯拉回 SaveTeam 裡面。使用 ADO.NET 原始碼來實作 Transaction
        private int SaveTeam(string teamName)
        {
            int newTeamID = -1;
            string connStr = Properties.Settings.Default.PokemonPartySimulatorConnectionString;

            // -----------------------------------------------------
            // 使用 ADO.NET 原始碼來實作 Transaction
            // -----------------------------------------------------
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                // 1. 開始交易
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // A. 寫入 Team 表 (ExecuteScalar)
                    string sqlInsertTeam = @"
                        INSERT INTO Team (TeamName, CreatedDate) 
                        VALUES (@Name, GETDATE());
                        SELECT SCOPE_IDENTITY();
                         ";
                    using (SqlCommand cmd = new SqlCommand(sqlInsertTeam, conn, transaction)) // 將 transaction 傳入
                    {
                        cmd.Parameters.AddWithValue("@Name", teamName);

                        // 執行並取得新 ID
                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value) throw new Exception("Team ID 取得失敗");
                        newTeamID = Convert.ToInt32(result);
                    }

                    // B. 寫入 TeamMember 表 (ExecuteNonQuery)
                    string sqlInsertMember = @"
                        INSERT INTO TeamMember (TeamID, SlotIndex, PokemonID, Move1_ID, Move2_ID, Move3_ID, Move4_ID, Item, Ability) 
                        VALUES (@TeamID, @SlotIndex, @PID, @M1, @M2, @M3, @M4, @Item, @Ability);
                       ";

                    foreach (var member in currentTeam)
                    {
                        if (member == null || member.PokemonID <= 0) continue;

                        using (SqlCommand cmd = new SqlCommand(sqlInsertMember, conn, transaction)) // 將 transaction 傳入
                        {

                            // --- 🚨 測試用髒數據注入 🚨 ---
                            // 故意在儲存噴火龍時，讓它傳送一個不存在的 MoveID=9999
                            if (member.PokemonID == 6) // 假設噴火龍的 ID 是 6
                            {
                                member.Move1_ID = 9999;
                            }

                            // 準備參數 (這裡用 AddWithValue 比較簡潔，但 Add 方式更嚴謹)
                            cmd.Parameters.AddWithValue("@TeamID", newTeamID);
                            cmd.Parameters.AddWithValue("@SlotIndex", member.SlotIndex);
                            cmd.Parameters.AddWithValue("@PID", member.PokemonID);
                            cmd.Parameters.AddWithValue("@M1", member.Move1_ID);
                            cmd.Parameters.AddWithValue("@M2", member.Move2_ID);
                            cmd.Parameters.AddWithValue("@M3", member.Move3_ID);
                            cmd.Parameters.AddWithValue("@M4", member.Move4_ID);

                            // 處理 Item/Ability 的 NULL 值 (它們可以 NULL)
                            cmd.Parameters.AddWithValue("@Item", DBNull.Value); //
                            cmd.Parameters.AddWithValue("@Ability", DBNull.Value); //




                            cmd.ExecuteNonQuery(); // 執行寫入
                        }
                    }

                    // 2. 所有步驟都成功：提交交易 (Commit)
                    transaction.Commit();
                    return newTeamID;
                }
                catch (Exception ex)
                {
                    // 3. 任何步驟失敗：回溯交易 (Rollback)
                    transaction.Rollback();
                    MessageBox.Show("隊伍儲存發生錯誤，資料已回溯。\n" + ex.Message, "交易失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1; // 回傳失敗
                }
            }
        }
        //舊版寫法，不使用交易機制，可能發生隊伍有建起來但隊伍成員沒有成功建立的情況
        /*
        private int SaveTeam(string teamName)
        {
            int newTeamID = -1;

            // -----------------------------------------------------
            // A. 階段一：寫入 Team 表，並取得新 ID (ExecuteScalar)
            // -----------------------------------------------------
            string sqlInsertTeam = @"
                INSERT INTO Team (TeamName, CreatedDate) 
                VALUES (@Name, GETDATE());
                SELECT SCOPE_IDENTITY(); -- 這一行回傳新產生的 ID
                 ";
            SqlParameter paramName = new SqlParameter("@Name", teamName);

            object result = DBHelper.ExecuteScalar(sqlInsertTeam, paramName);

            // 檢查回傳值：如果回傳不是 null 且不是 DBNull (成功了)
            if (result != null && result != DBNull.Value)
            {
                // ExecuteScalar 回傳 object，轉型為 int
                newTeamID = Convert.ToInt32(result);
            }

            // 如果 Team 寫入失敗，直接回傳 -1，中止後續操作
            if (newTeamID <= 0) return -1;


            // -----------------------------------------------------
            // B. 階段二：寫入 TeamMember 表 (ExecuteNonQuery)
            // -----------------------------------------------------
            string sqlInsertMember = @"
                         INSERT INTO TeamMember (
                            TeamID, SlotIndex, PokemonID, Move1_ID, Move2_ID, 
                            Move3_ID, Move4_ID, Item, Ability
                             ) 
                            VALUES (
                            @TeamID, @SlotIndex, @PID, @M1, @M2, 
                            @M3, @M4, @Item, @Ability
                           );";

            // 遍歷 6 個隊伍成員
            foreach (var member in currentTeam)
            {
                // 排除空位 (null 或 PokemonID <= 0)
                if (member == null || member.PokemonID <= 0) continue;

                // 準備參數 (使用 List<SqlParameter> 方便處理)
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@TeamID", newTeamID),
                    new SqlParameter("@SlotIndex", member.SlotIndex),
                    new SqlParameter("@PID", member.PokemonID),
                    new SqlParameter("@M1", member.Move1_ID),
                    new SqlParameter("@M2", member.Move2_ID),
                    new SqlParameter("@M3", member.Move3_ID),
                    new SqlParameter("@M4", member.Move4_ID),
                    //尚未實作
                    new SqlParameter("@Item", DBNull.Value),
                    new SqlParameter("@Ability", DBNull.Value)
                };

                // 執行 INSERT
                DBHelper.ExecuteNonQuery(sqlInsertMember, parameters.ToArray());
                // 如果你需要知道有沒有成功，可以檢查回傳值（> 0 代表成功）
            }

            // 兩階段都成功，回傳新的 TeamID
            return newTeamID;
        }
        */
    }
}
