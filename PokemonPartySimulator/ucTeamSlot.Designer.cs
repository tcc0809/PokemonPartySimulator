namespace PokemonPartySimulator
{
    partial class ucTeamSlot
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTeamSlot));
            this.pbPokemon = new System.Windows.Forms.PictureBox();
            this.labName = new System.Windows.Forms.Label();
            this.labPlus = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.labMove1 = new System.Windows.Forms.Label();
            this.labMove2 = new System.Windows.Forms.Label();
            this.labMove3 = new System.Windows.Forms.Label();
            this.labMove4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPokemon
            // 
            this.pbPokemon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbPokemon.Location = new System.Drawing.Point(0, 0);
            this.pbPokemon.Margin = new System.Windows.Forms.Padding(0);
            this.pbPokemon.Name = "pbPokemon";
            this.pbPokemon.Size = new System.Drawing.Size(260, 104);
            this.pbPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPokemon.TabIndex = 0;
            this.pbPokemon.TabStop = false;
            // 
            // labName
            // 
            this.labName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labName.Location = new System.Drawing.Point(95, 124);
            this.labName.Margin = new System.Windows.Forms.Padding(0);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(66, 24);
            this.labName.TabIndex = 1;
            this.labName.Text = "Name";
            this.labName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labPlus
            // 
            this.labPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labPlus.Font = new System.Drawing.Font("微軟正黑體", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labPlus.Location = new System.Drawing.Point(0, 104);
            this.labPlus.Margin = new System.Windows.Forms.Padding(0);
            this.labPlus.Name = "labPlus";
            this.labPlus.Size = new System.Drawing.Size(260, 44);
            this.labPlus.TabIndex = 2;
            this.labPlus.Text = "+";
            this.labPlus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.ForeColor = System.Drawing.Color.Transparent;
            this.btnDelete.Location = new System.Drawing.Point(3, 106);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(43, 41);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // labMove1
            // 
            this.labMove1.AutoSize = true;
            this.labMove1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labMove1.Location = new System.Drawing.Point(177, 23);
            this.labMove1.Margin = new System.Windows.Forms.Padding(0);
            this.labMove1.Name = "labMove1";
            this.labMove1.Size = new System.Drawing.Size(82, 19);
            this.labMove1.TabIndex = 4;
            this.labMove1.Text = "labMove1";
            // 
            // labMove2
            // 
            this.labMove2.AutoSize = true;
            this.labMove2.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labMove2.Location = new System.Drawing.Point(177, 49);
            this.labMove2.Margin = new System.Windows.Forms.Padding(0);
            this.labMove2.Name = "labMove2";
            this.labMove2.Size = new System.Drawing.Size(82, 19);
            this.labMove2.TabIndex = 5;
            this.labMove2.Text = "labMove2";
            // 
            // labMove3
            // 
            this.labMove3.AutoSize = true;
            this.labMove3.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labMove3.Location = new System.Drawing.Point(177, 75);
            this.labMove3.Margin = new System.Windows.Forms.Padding(0);
            this.labMove3.Name = "labMove3";
            this.labMove3.Size = new System.Drawing.Size(82, 19);
            this.labMove3.TabIndex = 6;
            this.labMove3.Text = "labMove3";
            // 
            // labMove4
            // 
            this.labMove4.AutoSize = true;
            this.labMove4.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labMove4.Location = new System.Drawing.Point(177, 101);
            this.labMove4.Margin = new System.Windows.Forms.Padding(0);
            this.labMove4.Name = "labMove4";
            this.labMove4.Size = new System.Drawing.Size(82, 19);
            this.labMove4.TabIndex = 7;
            this.labMove4.Text = "labMove4";
            // 
            // ucTeamSlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labMove4);
            this.Controls.Add(this.labMove3);
            this.Controls.Add(this.labMove2);
            this.Controls.Add(this.labMove1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.labPlus);
            this.Controls.Add(this.pbPokemon);
            this.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucTeamSlot";
            this.Size = new System.Drawing.Size(260, 148);
            ((System.ComponentModel.ISupportInitialize)(this.pbPokemon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPokemon;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labPlus;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label labMove1;
        private System.Windows.Forms.Label labMove2;
        private System.Windows.Forms.Label labMove3;
        private System.Windows.Forms.Label labMove4;
    }
}
