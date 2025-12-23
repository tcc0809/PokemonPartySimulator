using PokemonPartySimulator.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                slots[i].SlotClicked += OnSlotClicked; // 訂閱剛才寫的自訂事件
            }
        }

        private void OnSlotClicked(object sender, EventArgs e)
        {
            // 1. 取得被點擊的格子
            ucTeamSlot clickedSlot = sender as ucTeamSlot;
            if (clickedSlot == null) return;

            // 2. 判斷是空位才開啟
            if (clickedSlot.PokemonID == -1)
            {
                // --- 這裡開始是「重複使用視窗」的邏輯 ---

                // 檢查：如果視窗還沒建立，或是之前被意外銷毀了，才 new 一次
                if (_selectForm == null || _selectForm.IsDisposed)
                {
                    // 只有「第一次」執行這行時會卡頓 (因為要產生大量控制項)
                    _selectForm = new frmPokemonSelect();
                }

                // (選用) 如果你有寫 ResetForm，可以在這裡呼叫，確保每次打開都像新的
                // _selectForm.ResetForm(); 

                // 顯示視窗
                if (_selectForm.ShowDialog() == DialogResult.OK)
                {
                    // 這裡改成用 _selectForm 來抓資料
                    string key = _selectForm.SelectedPokemonID.ToString() + ".png";

                    // 防呆：確認圖是否存在
                    Image img = null;
                    if (imageListPM.Images.ContainsKey(key))
                    {
                        img = imageListPM.Images[key];
                    }

                    // 更新 UI
                    clickedSlot.SetPokemon(
                        _selectForm.SelectedPokemonID,
                        _selectForm.SelectedPokemonName,
                        img
                    );
                }
                // 程式結束後，_selectForm 依然活著，下次再點就會跳過 new 的步驟，直接 ShowDialog
            }
            else
            {
                // 處理編輯或移除的邏輯 (這部分維持原樣)
                DialogResult result = MessageBox.Show("要移除這隻寶可夢嗎？", "編輯", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    clickedSlot.ClearSlot();
                }
            }
        }


        private void btnPK1_Click(object sender, EventArgs e)
        {
            frmPokemonSelect f = new frmPokemonSelect();
            f.ShowDialog();
        }
    }
}
