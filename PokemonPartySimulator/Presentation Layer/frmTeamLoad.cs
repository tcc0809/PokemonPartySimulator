using PokemonPartySimulator.Data_Access_Layer;
using System;
using System.Data;
using System.Windows.Forms;

namespace PokemonPartySimulator.Presentation_Layer
{
    public partial class frmTeamLoad : Form
    {
        public int SelectedTeamID { get; private set; } = -1; // 回傳給主視窗
        public frmTeamLoad()
        {
            InitializeComponent();
            this.Load += (s, e) => {
                splitContainer1.SplitterDistance = splitContainer1.Width / 2;
            };
        }
        private void frmTeamLoad_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'pokemonPartySimulatorDataSet.Team' 資料表。您可以視需要進行移動或移除。
            this.teamTableAdapter.Fill(this.pokemonPartySimulatorDataSet.Team);
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            // SQL: SELECT TeamID, TeamName, CreatedDate FROM Team;
            DataTable dtTeams = DBHelper.GetDataTable("SELECT TeamID, TeamName, CreatedDate FROM Team ORDER BY CreatedDate DESC");

            // 綁定到 DataGridView
            dgvTeams.DataSource = dtTeams;
            dgvTeams.Columns["TeamID"].Visible = false; // 隱藏 ID
        }

        private void btnLoadTeam_Click(object sender, EventArgs e)
        {
            if (dgvTeams.CurrentRow != null)
            {
                SelectedTeamID = Convert.ToInt32(dgvTeams.CurrentRow.Cells["TeamID"].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("請先選擇一個隊伍！");
            }
        }

        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            if (dgvTeams.CurrentRow == null) return; //沒選就刪那就沒功能

            int teamID = Convert.ToInt32(dgvTeams.CurrentRow.Cells["TeamID"].Value);
            string teamName = dgvTeams.CurrentRow.Cells["TeamName"].Value.ToString();
            DialogResult result = MessageBox.Show($"確定要刪除隊伍 [{teamName}] 嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (result == DialogResult.Yes)
            {
                // 執行刪除 (這裡我們可以用剛才學到的交易機制，或是分兩次 ExecuteNonQuery)
                DBHelper.DeleteTeam(teamID);

                // 3. 重新整理 DataGridView 畫面
                RefreshGrid();
            }
        }
    }
}
