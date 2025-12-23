using PokemonPartySimulator.Presentation_Layer;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(65, 204, 212, 230);
        }
        private void labSelect(Label targetLabel)
        {
            pbBall.Location = new Point(targetLabel.Location.X + 90, targetLabel.Location.Y-13);
            pbBall.Visible = true;

            Font oldFont = targetLabel.Font;
            targetLabel.Font = new Font(oldFont, oldFont.Style | FontStyle.Bold);
        }

        private void labNew_MouseEnter(object sender, EventArgs e)
        {
            labSelect(labNew);
        }

        private void labLoad_MouseEnter(object sender, EventArgs e)
        {
            labSelect(labLoad);
        }

        private void labRight_MouseEnter(object sender, EventArgs e)
        {
            labSelect(labRight);
        }

        private void labClose_MouseEnter(object sender, EventArgs e)
        {
            labSelect(labClose);
        }
        private void labLeave(Label targetLabel)
        {
            pbBall.Visible = false;

            Font oldFont = targetLabel.Font;

            // 核心邏輯：AND 上 (NOT 粗體)
            // 1. FontStyle.Bold 前面加上 ~ (NOT，取反，把 粗體 那一位元從 1 變成 0)
            // 2. 用 & (AND) 運算：只有原本是 1 且取反後是 1 的位元才會保留，粗體的那一位元就會強制變成 0
            targetLabel.Font = new Font(oldFont,oldFont.Style & ~FontStyle.Bold);
        }
        private void labNew_MouseLeave(object sender, EventArgs e)
        {
            labLeave(labNew);
        }
        private void labLoad_MouseLeave(object sender, EventArgs e)
        {
            labLeave(labLoad);
        }

        private void labRight_MouseLeave(object sender, EventArgs e)
        {
            labLeave(labRight);
        }
        private void labClose_MouseLeave(object sender, EventArgs e)
        {
            labLeave(labClose);
        }

        private void labNew_Click(object sender, EventArgs e)
        {
            frmTeamEditor NewTeam= new frmTeamEditor();
            NewTeam.Show();
        }

        private void labLoad_Click(object sender, EventArgs e)
        {
            frmTeamLoad LoadTeam = new frmTeamLoad();
            LoadTeam.Show();
        }

        private void labRight_Click(object sender, EventArgs e)
        {
            MessageBox.Show("    免責聲明：\n\n    本專案為個人練習與學術用途（C# WinForm 與 SQL 資料庫實作），非商業專案。\n    所有寶可夢相關的圖片、名稱、數據等素材，\n    其版權皆屬於 Nintendo、Creatures Inc. 以及 GAME FREAK Inc. 所有。\n    若有侵權疑慮請聯繫開發者，將立即下架相關內容。\n\n    Disclaimer:\n    This project is for educational and personal portfolio purposes only.\n    All Pokémon images, names, and related media are intellectual property of \n    Nintendo, Creatures Inc., and GAME FREAK Inc.\n    No copyright infringement is intended.");
        }

        private void labClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
