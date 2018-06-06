namespace SMMS
{
    partial class StaffsView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.staffsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UpdateBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.DelBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AddBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.staffsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMDBDataSet = new SMMS.SMDBDataSet();
            this.staffsTableAdapter = new SMMS.SMDBDataSetTableAdapters.staffsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.staffsMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(892, 684);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // staffsMenuStrip
            // 
            this.staffsMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.staffsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateBtn,
            this.DelBtn,
            this.AddBtn});
            this.staffsMenuStrip.Name = "staffsMenuStrip";
            this.staffsMenuStrip.Size = new System.Drawing.Size(109, 76);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(108, 24);
            this.UpdateBtn.Text = "修改";
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // DelBtn
            // 
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(108, 24);
            this.DelBtn.Text = "删除";
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(108, 24);
            this.AddBtn.Text = "新增";
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // staffsBindingSource
            // 
            this.staffsBindingSource.DataMember = "staffs";
            this.staffsBindingSource.DataSource = this.sMDBDataSet;
            // 
            // sMDBDataSet
            // 
            this.sMDBDataSet.DataSetName = "SMDBDataSet";
            this.sMDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // staffsTableAdapter
            // 
            this.staffsTableAdapter.ClearBeforeFill = true;
            // 
            // StaffsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StaffsView";
            this.Size = new System.Drawing.Size(892, 684);
            this.Load += new System.EventHandler(this.StaffsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.staffsMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.staffsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource staffsBindingSource;
        private SMDBDataSet sMDBDataSet;
        private SMDBDataSetTableAdapters.staffsTableAdapter staffsTableAdapter;
        private System.Windows.Forms.ContextMenuStrip staffsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem UpdateBtn;
        private System.Windows.Forms.ToolStripMenuItem DelBtn;
        private System.Windows.Forms.ToolStripMenuItem AddBtn;
    }
}
