using PokemonPartySimulator.Business_Logic_Layer;
using PokemonPartySimulator.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PokemonPartySimulator.Presentation_Layer
{
    public partial class frmTeamEditor : Form
    {
        private int? _loadedTeamID = null; // 記錄現在是編輯哪一個隊伍，?代表可以是空值

        private frmPokemonSelect _selectForm;
        private TeamMember[] currentTeam = new TeamMember[6];
        private ucTeamSlot[] _slots;


        public frmTeamEditor()
        {
            InitializeComponent();
            InitializeCommonLogic();
            UpdatePlusVisibility();
            this.Load += (s, e) => {
                splitContainer1.SplitterDistance = splitContainer1.Width / 2;
            };
        }

        // 編輯模式的多載建構子
        // 後面的 : this()，這代表「先執行無參數建構子，再執行自己」
        public frmTeamEditor(int teamID) : this()
        {
            // 因為有 : this()，所以 InitializeComponent 和 InitializeCommonLogic 都跑過了
            _loadedTeamID = teamID;
            LoadTeamData(teamID);
            // 這裡只需要寫讀取邏輯
        }

        private void InitializeCommonLogic()
        {
            _slots = new ucTeamSlot[] { slot0, slot1, slot2, slot3, slot4, slot5 };

            for (int i = 0; i < _slots.Length; i++)
            {
                _slots[i].SlotIndex = i;
                _slots[i].SlotClicked += OnSlotClicked;
                _slots[i].RemoveClicked += OnRemoveClicked;
                _slots[i].SlotMouseEnter += OnMouseEnter; // 確保這裡有名稱對應
                _slots[i].SlotMouseLeave += OnMouseLeave;
                _slots[i].Cursor = Cursors.Hand;
            }
        }
        private void UpdatePlusVisibility()
        {
            // 先找出目前有幾隻怪
            int count = currentTeam.Count(m => m != null && m.PokemonID > 0);

            for (int i = 0; i < _slots.Length; i++)
            {
                if (i < count)
                {
                    // 已經有怪的格子：顯示圖片和名字 (這部分 SetPokemon 會處理)
                    _slots[i].Visible = true;
                }
                else if (i == count)
                {
                    // 「緊接著」怪物的下一個空位：顯示 + 號
                    _slots[i].Visible = true;
                    _slots[i].ClearSlot(); // 確保它是 + 號狀態
                }
                else
                {
                    // 剩下的空位：直接隱藏，不讓使用者點
                    _slots[i].Visible = false;
                }
            }
        }
        private void ReorganizeTeam()
        {
            // 1. 使用 LINQ 取出目前所有「非空」的寶可夢資料
            var activeMembers = currentTeam
                .Where(m => m != null && m.PokemonID > 0)
                .ToList();

            // 2. 徹底清空目前的 UI 與 陣列 (重置狀態)
            // 這裡我們不呼叫 ClearAllSlots 是為了避免清掉 TeamName
            foreach (var slot in _slots) slot.ClearSlot();
            Array.Clear(currentTeam, 0, currentTeam.Length);

            // 3. 把活著的成員依序放回補位後的索引 (0, 1, 2...)
            for (int i = 0; i < activeMembers.Count; i++)
            {
                var member = activeMembers[i];

                // ★ 重要：更新資料內部的 SlotIndex
                member.SlotIndex = i;
                currentTeam[i] = member;

                // 4. 同步刷新 UI
                UpdateSlotUI(i, member);
            }
            UpdatePlusVisibility();
        }

        // 輔助方法：根據資料更新特定格子的 UI
        private void UpdateSlotUI(int index, TeamMember data)
        {
            string imgKey = data.PokemonID.ToString() + ".png";
            Image img = imageListPM.Images.ContainsKey(imgKey) ? imageListPM.Images[imgKey] : null;

            // 更新格子基本資訊
            _slots[index].SetPokemon(data.PokemonID, data.Name, img);

            // 更新招式 (從 Manager 查名字)
            string m1 = TeamManager.GetMoveNameByID(data.Move1_ID);
            string m2 = TeamManager.GetMoveNameByID(data.Move2_ID);
            string m3 = TeamManager.GetMoveNameByID(data.Move3_ID);
            string m4 = TeamManager.GetMoveNameByID(data.Move4_ID);
            _slots[index].SetMoves(m1, m2, m3, m4);
        }
        private void LoadTeamData(int teamID)
        {
            // 1. 透過 Manager 取得物件化的清單 (不用再寫 SQL 或 DataTable 了)
            var members = TeamManager.GetTeamMembers(teamID);

            // 2. 清空目前的 UI 與 陣列 (重置狀態)
            foreach (var slot in _slots) slot.ClearSlot();
            Array.Clear(currentTeam, 0, currentTeam.Length);

            // 3. 填充資料並更新 UI
            foreach (var m in members)
            {
                currentTeam[m.SlotIndex] = m;
                UpdateSlotUI(m.SlotIndex, m); // 這個方法內部會去呼叫 TeamManager 查招式名
            }

            // 4.刷新+號出現畫面
            UpdatePlusVisibility();
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            ucTeamSlot enterSlot = sender as ucTeamSlot;
            Font oldFont = enterSlot.Font;
            enterSlot.Font = new Font(oldFont, oldFont.Style | FontStyle.Bold);
            enterSlot.BackColor = Color.LightCyan;

        }
        private void OnMouseLeave(object sender, EventArgs e)
        {
            ucTeamSlot leaveSlot = sender as ucTeamSlot;
            Font oldFont = leaveSlot.Font;
            leaveSlot.Font = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);

            leaveSlot.BackColor = Color.AliceBlue;

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
                ReorganizeTeam();
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
                    // 選怪成功後更新 UI 
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
                    currentTeam[slotIndex] = new TeamMember
                    {
                        SlotIndex = slotIndex,
                        PokemonID = _selectForm.SelectedPokemonID,
                        Name = _selectForm.SelectedPokemonName,
                        Move1_ID = 0,
                        Move2_ID = 0,
                        Move3_ID = 0,
                        Move4_ID = 0
                    };
                    UpdatePlusVisibility();
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
                        string m1Name = TeamManager.GetMoveNameByID(moveForm.Move1_ID);
                        string m2Name = TeamManager.GetMoveNameByID(moveForm.Move2_ID);
                        string m3Name = TeamManager.GetMoveNameByID(moveForm.Move3_ID);
                        string m4Name = TeamManager.GetMoveNameByID(moveForm.Move4_ID);

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

        private void btnPK1_Click(object sender, EventArgs e)
        {
            frmPokemonSelect f = new frmPokemonSelect();
            f.ShowDialog();
        }
        private void btnClearTeam_Click(object sender, EventArgs e)
        {
            // 1. 清空記憶體陣列
            // 方式 A：直接重新 new 一個 (最快)
            currentTeam = new TeamMember[6];

            // 方式 B：如果你想保留陣列物件只是清空內容
            // Array.Clear(currentTeam, 0, currentTeam.Length);

            // 2. 清空 UI 控制項 (善用我們之前寫的 _slots 陣列)
            foreach (var slot in _slots)
            {
                slot.ClearSlot(); // 呼叫 ucTeamSlot 內部的清空邏輯
            }

            // 3. 其他 UI 重置
            txtTeamName.Text = "";
            _loadedTeamID = null; // 變回「新增模式」
            UpdatePlusVisibility();
        }
        private void btnSaveTeam_Click(object sender, EventArgs e)
        {
            // 1. 取得與檢查輸入 (UI 層的職責)
            string teamName = txtTeamName.Text.Trim();
            if (string.IsNullOrEmpty(teamName))
            {
                MessageBox.Show("請輸入隊伍名稱！"); return;
            }

            if (currentTeam.Count(m => m != null && m.PokemonID > 0) == 0)
            {
                MessageBox.Show("隊伍至少需要一隻寶可夢！"); return;
            }

            try
            {
                // 2. 呼叫 Manager 進行存檔 (Business Logic 層的職責)
                // 把 currentID, teamName, currentTeam 陣列全部丟給它
                int savedID = TeamManager.SaveTeam(teamName, _loadedTeamID, currentTeam);

                if (savedID > 0)
                {
                    _loadedTeamID = savedID; // 更新目前視窗為編輯模式
                    MessageBox.Show($"隊伍 [{teamName}] 儲存成功！");
                }
            }
            catch (Exception ex)
            {
                // 3. 處理錯誤顯示 (UI 層的職責)
                MessageBox.Show(ex.Message, "儲存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //新版SaveTeam寫法，使用交易機制，確保新增隊伍跟成員能同時成功或失敗
        //這個交易涉及多次呼叫 ，因此無法DBHelper 裡獨立完成，所以把邏輯拉回 SaveTeam 裡面。使用 ADO.NET 原始碼來實作 Transaction
        //但由於最終物件化這邊的功能又直接被我搬到TeamManager裡面，因此這邊註解留作複習用
        //private int SaveTeam(string teamName)
        //{
        //    int newTeamID = -1;
        //    string connStr = Properties.Settings.Default.PokemonPartySimulatorConnectionString;

        //    // -----------------------------------------------------
        //    // 使用 ADO.NET 原始碼來實作 Transaction
        //    // -----------------------------------------------------
        //    using (SqlConnection conn = new SqlConnection(connStr))
        //    {
        //        conn.Open();
        //        // 1. 開始交易
        //        SqlTransaction transaction = conn.BeginTransaction();

        //        try
        //        {
        //            if (_loadedTeamID.HasValue)
        //            {
        //                // 1. 更新 Team 表的名字
        //                string sqlUpdateTeam = "UPDATE Team SET TeamName = @Name WHERE TeamID = @TID";
        //                using (SqlCommand cmd = new SqlCommand(sqlUpdateTeam, conn, transaction))
        //                {
        //                    cmd.Parameters.AddWithValue("@Name", teamName);
        //                    cmd.Parameters.AddWithValue("@TID", _loadedTeamID.Value);
        //                    cmd.ExecuteNonQuery();
        //                }

        //                // 2. 刪除舊的 TeamMember (砍掉重練是最簡單的方法)
        //                string sqlDeleteMembers = "DELETE FROM TeamMember WHERE TeamID = @TID";
        //                using (SqlCommand cmd = new SqlCommand(sqlDeleteMembers, conn, transaction))
        //                {
        //                    cmd.Parameters.AddWithValue("@TID", _loadedTeamID.Value);
        //                    cmd.ExecuteNonQuery();
        //                }

        //                // 將 newTeamID 設為舊的 ID，後面的 foreach 就會自動用舊 ID 寫入新的成員
        //                newTeamID = _loadedTeamID.Value;
        //            }
        //            else
        //            {
        //                // A. 寫入 Team 表 (ExecuteScalar)
        //                string sqlInsertTeam = @"
        //                INSERT INTO Team (TeamName, CreatedDate) 
        //                VALUES (@Name, GETDATE());
        //                SELECT SCOPE_IDENTITY();
        //                 ";
        //                using (SqlCommand cmd = new SqlCommand(sqlInsertTeam, conn, transaction)) // 將 transaction 傳入
        //                {
        //                    cmd.Parameters.AddWithValue("@Name", teamName);

        //                    // 執行並取得新 ID
        //                    object result = cmd.ExecuteScalar();

        //                    if (result == null || result == DBNull.Value) throw new Exception("Team ID 取得失敗");
        //                    newTeamID = Convert.ToInt32(result);
        //                }
        //            }

        //            // B. 寫入 TeamMember 表 (ExecuteNonQuery)
        //            string sqlInsertMember = @"
        //                INSERT INTO TeamMember (TeamID, SlotIndex, PokemonID, Move1_ID, Move2_ID, Move3_ID, Move4_ID, Item, Ability) 
        //                VALUES (@TeamID, @SlotIndex, @PID, @M1, @M2, @M3, @M4, @Item, @Ability);
        //               ";

        //            foreach (var member in currentTeam)
        //            {
        //                if (member == null || member.PokemonID <= 0) continue;

        //                using (SqlCommand cmd = new SqlCommand(sqlInsertMember, conn, transaction)) // 將 transaction 傳入
        //                {

        //                    // --- 🚨 測試用髒數據注入 🚨 ---
        //                    // 故意在儲存噴火龍時，讓它傳送一個不存在的 MoveID=9999
        //                    //if (member.PokemonID == 6) // 假設噴火龍的 ID 是 6
        //                    //{
        //                    //    member.Move1_ID = 9999;
        //                    //}

        //                    // 準備參數 (這裡用 AddWithValue 比較簡潔，但 Add 方式更嚴謹)
        //                    cmd.Parameters.AddWithValue("@TeamID", newTeamID);
        //                    cmd.Parameters.AddWithValue("@SlotIndex", member.SlotIndex);
        //                    cmd.Parameters.AddWithValue("@PID", member.PokemonID);
        //                    cmd.Parameters.AddWithValue("@M1", member.Move1_ID);
        //                    cmd.Parameters.AddWithValue("@M2", member.Move2_ID);
        //                    cmd.Parameters.AddWithValue("@M3", member.Move3_ID);
        //                    cmd.Parameters.AddWithValue("@M4", member.Move4_ID);

        //                    // 處理 Item/Ability 的 NULL 值 (它們可以 NULL)
        //                    cmd.Parameters.AddWithValue("@Item", DBNull.Value); //
        //                    cmd.Parameters.AddWithValue("@Ability", DBNull.Value); //




        //                    cmd.ExecuteNonQuery(); // 執行寫入
        //                }
        //            }

        //            // 2. 所有步驟都成功：提交交易 (Commit)
        //            transaction.Commit();
        //            return newTeamID;
        //        }
        //        catch (Exception ex)
        //        {
        //            // 3. 任何步驟失敗：回溯交易 (Rollback)
        //            transaction.Rollback();
        //            MessageBox.Show("隊伍儲存發生錯誤，資料已回溯。\n" + ex.Message, "交易失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return -1; // 回傳失敗
        //        }
        //    }
        //}

        /*舊版寫法，不使用交易機制，可能發生隊伍有建起來但隊伍成員沒有成功建立的情況
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
