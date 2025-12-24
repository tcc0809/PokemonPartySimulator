namespace PokemonPartySimulator.Presentation_Layer
{
    partial class frmTeamLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTeams = new System.Windows.Forms.DataGridView();
            this.btnLoadTeam = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTeams
            // 
            this.dgvTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeams.Location = new System.Drawing.Point(16, 17);
            this.dgvTeams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTeams.Name = "dgvTeams";
            this.dgvTeams.RowTemplate.Height = 24;
            this.dgvTeams.Size = new System.Drawing.Size(1035, 490);
            this.dgvTeams.TabIndex = 0;
            // 
            // btnLoadTeam
            // 
            this.btnLoadTeam.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLoadTeam.Location = new System.Drawing.Point(848, 515);
            this.btnLoadTeam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadTeam.Name = "btnLoadTeam";
            this.btnLoadTeam.Size = new System.Drawing.Size(203, 98);
            this.btnLoadTeam.TabIndex = 1;
            this.btnLoadTeam.Text = "載入隊伍";
            this.btnLoadTeam.UseVisualStyleBackColor = true;
            this.btnLoadTeam.Click += new System.EventHandler(this.btnLoadTeam_Click);
            // 
            // frmTeamLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 638);
            this.Controls.Add(this.btnLoadTeam);
            this.Controls.Add(this.dgvTeams);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmTeamLoad";
            this.Text = "frmTeamLoad";
            this.Load += new System.EventHandler(this.frmTeamLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTeams;
        private System.Windows.Forms.Button btnLoadTeam;
    }
}