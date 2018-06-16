namespace SMMS
{
    partial class VipUpdate
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
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.IDtextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NametextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PhoneNumtextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PointtextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TimetextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(371, 453);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(100, 29);
            this.CancelBtn.TabIndex = 8;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Location = new System.Drawing.Point(95, 453);
            this.ConfirmBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(100, 29);
            this.ConfirmBtn.TabIndex = 7;
            this.ConfirmBtn.Text = "确认";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "会员号";
            // 
            // IDtextBox
            // 
            this.IDtextBox.Location = new System.Drawing.Point(189, 47);
            this.IDtextBox.Name = "IDtextBox";
            this.IDtextBox.Size = new System.Drawing.Size(233, 25);
            this.IDtextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "姓名";
            // 
            // NametextBox
            // 
            this.NametextBox.Location = new System.Drawing.Point(189, 149);
            this.NametextBox.Name = "NametextBox";
            this.NametextBox.Size = new System.Drawing.Size(233, 25);
            this.NametextBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "联系方式";
            // 
            // PhoneNumtextBox
            // 
            this.PhoneNumtextBox.Location = new System.Drawing.Point(189, 206);
            this.PhoneNumtextBox.Name = "PhoneNumtextBox";
            this.PhoneNumtextBox.Size = new System.Drawing.Size(233, 25);
            this.PhoneNumtextBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "当前积分";
            // 
            // PointtextBox
            // 
            this.PointtextBox.Location = new System.Drawing.Point(189, 263);
            this.PointtextBox.Name = "PointtextBox";
            this.PointtextBox.Size = new System.Drawing.Size(233, 25);
            this.PointtextBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "创建时间";
            // 
            // TimetextBox
            // 
            this.TimetextBox.Location = new System.Drawing.Point(189, 102);
            this.TimetextBox.Name = "TimetextBox";
            this.TimetextBox.Size = new System.Drawing.Size(233, 25);
            this.TimetextBox.TabIndex = 18;
            // 
            // VipUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 514);
            this.Controls.Add(this.TimetextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PointtextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PhoneNumtextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NametextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IDtextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ConfirmBtn);
            this.Name = "VipUpdate";
            this.Text = "VipUpdate";
            this.Load += new System.EventHandler(this.VipUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IDtextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NametextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PhoneNumtextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PointtextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TimetextBox;
    }
}