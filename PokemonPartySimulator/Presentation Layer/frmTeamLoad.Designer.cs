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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTeams = new System.Windows.Forms.DataGridView();
            this.btnLoadTeam = new System.Windows.Forms.Button();
            this.btnDeleteTeam = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pokemonPartySimulatorDataSet = new PokemonPartySimulator.PokemonPartySimulatorDataSet();
            this.teamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.teamTableAdapter = new PokemonPartySimulator.PokemonPartySimulatorDataSetTableAdapters.TeamTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pokemonPartySimulatorDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTeams
            // 
            this.dgvTeams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeams.BackgroundColor = System.Drawing.Color.White;
            this.dgvTeams.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTeams.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTeams.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTeams.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTeams.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvTeams.Location = new System.Drawing.Point(0, 0);
            this.dgvTeams.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dgvTeams.Name = "dgvTeams";
            this.dgvTeams.ReadOnly = true;
            this.dgvTeams.RowHeadersWidth = 72;
            this.dgvTeams.RowTemplate.Height = 30;
            this.dgvTeams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeams.Size = new System.Drawing.Size(1184, 636);
            this.dgvTeams.TabIndex = 0;
            // 
            // btnLoadTeam
            // 
            this.btnLoadTeam.BackColor = System.Drawing.Color.White;
            this.btnLoadTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadTeam.FlatAppearance.BorderSize = 0;
            this.btnLoadTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadTeam.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLoadTeam.Location = new System.Drawing.Point(0, 0);
            this.btnLoadTeam.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoadTeam.Name = "btnLoadTeam";
            this.btnLoadTeam.Size = new System.Drawing.Size(590, 115);
            this.btnLoadTeam.TabIndex = 1;
            this.btnLoadTeam.Text = "載入隊伍";
            this.btnLoadTeam.UseVisualStyleBackColor = false;
            this.btnLoadTeam.Click += new System.EventHandler(this.btnLoadTeam_Click);
            // 
            // btnDeleteTeam
            // 
            this.btnDeleteTeam.BackColor = System.Drawing.Color.White;
            this.btnDeleteTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteTeam.FlatAppearance.BorderSize = 0;
            this.btnDeleteTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTeam.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDeleteTeam.Location = new System.Drawing.Point(0, 0);
            this.btnDeleteTeam.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteTeam.Name = "btnDeleteTeam";
            this.btnDeleteTeam.Size = new System.Drawing.Size(589, 115);
            this.btnDeleteTeam.TabIndex = 2;
            this.btnDeleteTeam.Text = "刪除隊伍";
            this.btnDeleteTeam.UseVisualStyleBackColor = false;
            this.btnDeleteTeam.Click += new System.EventHandler(this.btnDeleteTeam_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 496);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteTeam);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnLoadTeam);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 115);
            this.splitContainer1.SplitterDistance = 589;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            // 
            // pokemonPartySimulatorDataSet
            // 
            this.pokemonPartySimulatorDataSet.DataSetName = "PokemonPartySimulatorDataSet";
            this.pokemonPartySimulatorDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // teamBindingSource
            // 
            this.teamBindingSource.DataMember = "Team";
            this.teamBindingSource.DataSource = this.pokemonPartySimulatorDataSet;
            // 
            // teamTableAdapter
            // 
            this.teamTableAdapter.ClearBeforeFill = true;
            // 
            // frmTeamLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.dgvTeams);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmTeamLoad";
            this.Text = "讀取隊伍";
            this.Load += new System.EventHandler(this.frmTeamLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pokemonPartySimulatorDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTeams;
        private System.Windows.Forms.Button btnLoadTeam;
        private System.Windows.Forms.Button btnDeleteTeam;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private PokemonPartySimulatorDataSet pokemonPartySimulatorDataSet;
        private System.Windows.Forms.BindingSource teamBindingSource;
        private PokemonPartySimulatorDataSetTableAdapters.TeamTableAdapter teamTableAdapter;
    }
}