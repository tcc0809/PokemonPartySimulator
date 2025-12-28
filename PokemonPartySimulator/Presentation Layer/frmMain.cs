using PokemonPartySimulator.Presentation_Layer;
using System;
using System.Drawing;
using System.Windows.Forms;
//主要資料流使用 Typed DataSet (TableAdapter) 進行快速開發與記憶體操作，
//但在特定複雜查詢或精準讀取時，混用了原生 ADO.NET 以優化效能。
namespace PokemonPartySimulator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(65, 204, 212, 230);
            // 1. 把所有需要「移入特效」的 Label 整理成一個陣列
            Label[] menuLabels = { labNew, labLoad, labRight, labClose }; // 假設你有這三個

            // 2. 用迴圈統一訂閱 (+=)
            foreach (Label lab in menuLabels)
            {
                lab.MouseEnter += labSelect; // 訂閱「滑鼠移入」
                lab.MouseLeave += labLeave; // 訂閱「滑鼠移出」

                lab.Cursor = Cursors.Hand;
            }
        }

        private void labSelect(object sender, EventArgs e)
        {
            Label targetLabel = (Label) sender;
            pbBall.Location = new Point(targetLabel.Location.X + 90, targetLabel.Location.Y-13);
            pbBall.Visible = true;

            Font oldFont = targetLabel.Font;
            targetLabel.Font = new Font(oldFont, oldFont.Style | FontStyle.Bold);
        }
        private void labLeave(object sender, EventArgs e)
        {
            Label targetLabel = (Label)sender;
            Font oldFont = targetLabel.Font;
            pbBall.Visible = false;
            // AND 上 (NOT 粗體)
            // 1. FontStyle.Bold 前面加上 ~ (NOT，取反，把 粗體 那一位元從 1 變成 0)
            // 2. 用 & (AND) 運算：只有原本是 1 且取反後是 1 的位元才會保留，粗體的那一位元就會強制變成 0
            targetLabel.Font = new Font(oldFont,oldFont.Style & ~FontStyle.Bold);
        }
 

        private void labNew_Click(object sender, EventArgs e)
        {
            frmTeamEditor NewTeam= new frmTeamEditor();
            NewTeam.Show();
        }

        private void labLoad_Click(object sender, EventArgs e)
        {
            using (frmTeamLoad loadForm = new frmTeamLoad())
            {
                if (loadForm.ShowDialog() == DialogResult.OK)
                {
                    int teamID = loadForm.SelectedTeamID;

                    // 開啟編輯器視窗，並傳入 TeamID (呼叫多載的建構子)
                    using (frmTeamEditor editorForm = new frmTeamEditor(teamID))
                    {
                        editorForm.ShowDialog();
                    }
                }
            }
        }

        private void labRight_Click(object sender, EventArgs e)
        {
            MessageBox.Show("    免責聲明：\n\n    本專案為個人練習與學術用途（C# WinForm 與 SQL 資料庫實作），非商業專案。\n    所有寶可夢相關的圖片、名稱、數據等素材，\n    其版權皆屬於 Nintendo、Creatures Inc. 以及 GAME FREAK Inc. 所有。\n    若有侵權疑慮請聯繫開發者，將立即下架相關內容。" +
                "\n\n    Disclaimer:\n    This project is for educational and personal portfolio purposes only.\n    All Pokémon images, names, and related media are intellectual property of \n    Nintendo, Creatures Inc., and GAME FREAK Inc.\n    No copyright infringement is intended." +
                "\n\n    Trash icon created by Freepik Flaticon");
        }

        private void labClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
