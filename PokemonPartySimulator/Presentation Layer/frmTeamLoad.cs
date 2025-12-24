using PokemonPartySimulator.Data_Access_Layer;
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
    public partial class frmTeamLoad : Form
    {
        public int SelectedTeamID { get; private set; } = -1; // 回傳給主視窗
        public frmTeamLoad()
        {
            InitializeComponent();
        }
        private void frmTeamLoad_Load(object sender, EventArgs e)
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
        }


    }
}
