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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pbBall);
            this.panel1.Controls.Add(this.labClose);
            this.panel1.Controls.Add(this.labNew);
            this.panel1.Controls.Add(this.labRight);
            this.panel1.Controls.Add(this.labLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel1.Location = new System.Drawing.Point(0, 904);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1961, 97);
            this.panel1.TabIndex = 4;
            // 
            // pbBall
            // 
            this.pbBall.BackColor = System.Drawing.Color.Transparent;
            this.pbBall.Image = ((System.Drawing.Image)(resources.GetObject("pbBall.Image")));
            this.pbBall.Location = new System.Drawing.Point(385, 8);
            this.pbBall.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pbBall.Name = "pbBall";
            this.pbBall.Size = new System.Drawing.Size(82, 88);
            this.pbBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBall.TabIndex = 4;
            this.pbBall.TabStop = false;
            this.pbBall.Visible = false;
            // 
            // labClose
            // 
            this.labClose.AutoSize = true;
            this.labClose.Location = new System.Drawing.Point(1633, 28);
            this.labClose.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labClose.Name = "labClose";
            this.labClose.Size = new System.Drawing.Size(155, 43);
            this.labClose.TabIndex = 3;
            this.labClose.Text = "結束程式";
            this.labClose.Click += new System.EventHandler(this.labClose_Click);
            // 
            // labNew
            // 
            this.labNew.AutoSize = true;
            this.labNew.Location = new System.Drawing.Point(190, 28);
            this.labNew.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labNew.Name = "labNew";
            this.labNew.Size = new System.Drawing.Size(155, 43);
            this.labNew.TabIndex = 0;
            this.labNew.Text = "新增隊伍";
            this.labNew.Click += new System.EventHandler(this.labNew_Click);
            // 
            // labRight
            // 
            this.labRight.AutoSize = true;
            this.labRight.Location = new System.Drawing.Point(1152, 28);
            this.labRight.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labRight.Name = "labRight";
            this.labRight.Size = new System.Drawing.Size(155, 43);
            this.labRight.TabIndex = 2;
            this.labRight.Text = "權利聲明";
            this.labRight.Click += new System.EventHandler(this.labRight_Click);
            // 
            // labLoad
            // 
            this.labLoad.AutoSize = true;
            this.labLoad.Location = new System.Drawing.Point(671, 28);
            this.labLoad.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labLoad.Name = "labLoad";
            this.labLoad.Size = new System.Drawing.Size(155, 43);
            this.labLoad.TabIndex = 1;
            this.labLoad.Text = "讀取隊伍";
            this.labLoad.Click += new System.EventHandler(this.labLoad_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1961, 1001);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbBall;
        private System.Windows.Forms.Label labClose;
        private System.Windows.Forms.Label labNew;
        private System.Windows.Forms.Label labRight;
        private System.Windows.Forms.Label labLoad;
    }
}

