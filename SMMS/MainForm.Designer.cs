namespace SMMS
{
    partial class MainForm
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
            this.StaffsBtn = new System.Windows.Forms.Button();
            this.VipBtn = new System.Windows.Forms.Button();
            this.StockBtn = new System.Windows.Forms.Button();
            this.SalesBtn = new System.Windows.Forms.Button();
            this.windowsGroup = new System.Windows.Forms.GroupBox();
            this.buttonBox = new System.Windows.Forms.GroupBox();
            this.buttonBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StaffsBtn
            // 
            this.StaffsBtn.Location = new System.Drawing.Point(8, 13);
            this.StaffsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.StaffsBtn.Name = "StaffsBtn";
            this.StaffsBtn.Size = new System.Drawing.Size(165, 59);
            this.StaffsBtn.TabIndex = 0;
            this.StaffsBtn.Text = "员工管理";
            this.StaffsBtn.UseVisualStyleBackColor = true;
            this.StaffsBtn.Click += new System.EventHandler(this.StaffsBtn_Click);
            // 
            // VipBtn
            // 
            this.VipBtn.Location = new System.Drawing.Point(8, 80);
            this.VipBtn.Margin = new System.Windows.Forms.Padding(4);
            this.VipBtn.Name = "VipBtn";
            this.VipBtn.Size = new System.Drawing.Size(165, 59);
            this.VipBtn.TabIndex = 2;
            this.VipBtn.Text = "会员管理";
            this.VipBtn.UseVisualStyleBackColor = true;
            this.VipBtn.Click += new System.EventHandler(this.VipBtn_Click);
            // 
            // StockBtn
            // 
            this.StockBtn.Location = new System.Drawing.Point(8, 147);
            this.StockBtn.Margin = new System.Windows.Forms.Padding(4);
            this.StockBtn.Name = "StockBtn";
            this.StockBtn.Size = new System.Drawing.Size(165, 59);
            this.StockBtn.TabIndex = 3;
            this.StockBtn.Text = "库存管理";
            this.StockBtn.UseVisualStyleBackColor = true;
            this.StockBtn.Click += new System.EventHandler(this.StockBtn_Click);
            // 
            // SalesBtn
            // 
            this.SalesBtn.Location = new System.Drawing.Point(8, 214);
            this.SalesBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SalesBtn.Name = "SalesBtn";
            this.SalesBtn.Size = new System.Drawing.Size(165, 59);
            this.SalesBtn.TabIndex = 4;
            this.SalesBtn.Text = "销售管理";
            this.SalesBtn.UseVisualStyleBackColor = true;
            this.SalesBtn.Click += new System.EventHandler(this.SalesBtn_Click);
            // 
            // windowsGroup
            // 
            this.windowsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.windowsGroup.AutoSize = true;
            this.windowsGroup.Location = new System.Drawing.Point(187, 0);
            this.windowsGroup.Margin = new System.Windows.Forms.Padding(4);
            this.windowsGroup.Name = "windowsGroup";
            this.windowsGroup.Padding = new System.Windows.Forms.Padding(4);
            this.windowsGroup.Size = new System.Drawing.Size(1045, 714);
            this.windowsGroup.TabIndex = 5;
            this.windowsGroup.TabStop = false;
            this.windowsGroup.Paint += new System.Windows.Forms.PaintEventHandler(this.windowsGroup_Paint);
            this.windowsGroup.Enter += new System.EventHandler(this.windowsGroup_Enter);
            // 
            // buttonBox
            // 
            this.buttonBox.Controls.Add(this.SalesBtn);
            this.buttonBox.Controls.Add(this.StaffsBtn);
            this.buttonBox.Controls.Add(this.StockBtn);
            this.buttonBox.Controls.Add(this.VipBtn);
            this.buttonBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonBox.Location = new System.Drawing.Point(0, 0);
            this.buttonBox.Name = "buttonBox";
            this.buttonBox.Size = new System.Drawing.Size(180, 743);
            this.buttonBox.TabIndex = 0;
            this.buttonBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 743);
            this.Controls.Add(this.buttonBox);
            this.Controls.Add(this.windowsGroup);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "xx超市管理系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.buttonBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StaffsBtn;
        private System.Windows.Forms.Button VipBtn;
        private System.Windows.Forms.Button StockBtn;
        private System.Windows.Forms.Button SalesBtn;
        private System.Windows.Forms.GroupBox windowsGroup;
        private System.Windows.Forms.GroupBox buttonBox;
    }
}

