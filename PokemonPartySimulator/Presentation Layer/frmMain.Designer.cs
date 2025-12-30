    namespace PokemonPartySimulator
{
    partial class frmMain
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbBall = new System.Windows.Forms.PictureBox();
            this.labClose = new System.Windows.Forms.Label();
            this.labNew = new System.Windows.Forms.Label();
            this.labRight = new System.Windows.Forms.Label();
            this.labLoad = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBall)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(407, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 61);
            this.label1.TabIndex = 5;
            this.label1.Text = "寶可夢組隊模擬器";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pbBall);
            this.panel1.Controls.Add(this.labClose);
            this.panel1.Controls.Add(this.labNew);
            this.panel1.Controls.Add(this.labRight);
            this.panel1.Controls.Add(this.labLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel1.Location = new System.Drawing.Point(0, 694);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1224, 69);
            this.panel1.TabIndex = 4;
            // 
            // pbBall
            // 
            this.pbBall.BackColor = System.Drawing.Color.Transparent;
            this.pbBall.Image = ((System.Drawing.Image)(resources.GetObject("pbBall.Image")));
            this.pbBall.Location = new System.Drawing.Point(245, 7);
            this.pbBall.Margin = new System.Windows.Forms.Padding(4);
            this.pbBall.Name = "pbBall";
            this.pbBall.Size = new System.Drawing.Size(52, 67);
            this.pbBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBall.TabIndex = 4;
            this.pbBall.TabStop = false;
            this.pbBall.Visible = false;
            // 
            // labClose
            // 
            this.labClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labClose.AutoSize = true;
            this.labClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labClose.Location = new System.Drawing.Point(1040, 21);
            this.labClose.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labClose.Name = "labClose";
            this.labClose.Size = new System.Drawing.Size(96, 27);
            this.labClose.TabIndex = 3;
            this.labClose.Text = "結束程式";
            this.labClose.Click += new System.EventHandler(this.labClose_Click);
            // 
            // labNew
            // 
            this.labNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labNew.AutoSize = true;
            this.labNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labNew.Location = new System.Drawing.Point(121, 21);
            this.labNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labNew.Name = "labNew";
            this.labNew.Size = new System.Drawing.Size(96, 27);
            this.labNew.TabIndex = 0;
            this.labNew.Text = "新增隊伍";
            this.labNew.Click += new System.EventHandler(this.labNew_Click);
            // 
            // labRight
            // 
            this.labRight.AutoSize = true;
            this.labRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labRight.Location = new System.Drawing.Point(733, 21);
            this.labRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labRight.Name = "labRight";
            this.labRight.Size = new System.Drawing.Size(96, 27);
            this.labRight.TabIndex = 2;
            this.labRight.Text = "權利聲明";
            this.labRight.Click += new System.EventHandler(this.labRight_Click);
            // 
            // labLoad
            // 
            this.labLoad.AutoSize = true;
            this.labLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labLoad.Location = new System.Drawing.Point(427, 21);
            this.labLoad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labLoad.Name = "labLoad";
            this.labLoad.Size = new System.Drawing.Size(96, 27);
            this.labLoad.TabIndex = 1;
            this.labLoad.Text = "讀取隊伍";
            this.labLoad.Click += new System.EventHandler(this.labLoad_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1224, 763);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "寶可夢組隊模擬器";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbBall;
        private System.Windows.Forms.Label labClose;
        private System.Windows.Forms.Label labNew;
        private System.Windows.Forms.Label labRight;
        private System.Windows.Forms.Label labLoad;
    }
}

