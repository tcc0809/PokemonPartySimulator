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
            this.pbPokemon = new System.Windows.Forms.PictureBox();
            this.labName = new System.Windows.Forms.Label();
            this.labPlus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPokemon
            // 
            this.pbPokemon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbPokemon.Location = new System.Drawing.Point(0, 0);
            this.pbPokemon.Name = "pbPokemon";
            this.pbPokemon.Size = new System.Drawing.Size(262, 104);
            this.pbPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPokemon.TabIndex = 0;
            this.pbPokemon.TabStop = false;
            // 
            // labName
            // 
            this.labName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labName.Location = new System.Drawing.Point(96, 126);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(66, 24);
            this.labName.TabIndex = 1;
            this.labName.Text = "Name";
            this.labName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labPlus
            // 
            this.labPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labPlus.AutoSize = true;
            this.labPlus.Font = new System.Drawing.Font("微軟正黑體", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labPlus.Location = new System.Drawing.Point(80, 6);
            this.labPlus.Name = "labPlus";
            this.labPlus.Size = new System.Drawing.Size(121, 120);
            this.labPlus.TabIndex = 2;
            this.labPlus.Text = "+";
            this.labPlus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucTeamSlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labName);
            this.Controls.Add(this.labPlus);
            this.Controls.Add(this.pbPokemon);
            this.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucTeamSlot";
            this.Size = new System.Drawing.Size(262, 150);
            ((System.ComponentModel.ISupportInitialize)(this.pbPokemon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPokemon;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labPlus;
    }
}
