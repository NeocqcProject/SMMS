﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SMMS
{
    public partial class StockView : UserControl
    {
        public static StockView _instance;
        public StockView()
        {
            InitializeComponent();
            _instance = this;
        }
        public string currentSelectedSNo;

        public void UpdateDBView()
        {
            string sql = "select * from goods_stock";
            if (MainForm._instance.oleDb.State != ConnectionState.Open)
            {
                MainForm._instance.oleDb.Open();
            }
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, MainForm._instance.oleDb); //创建适配对象
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds, "goods_stock");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "goods_stock";

            dataGridView1.Columns[0].HeaderText = "商品编号";
            dataGridView1.Columns[1].HeaderText = "商品名称";

            MainForm._instance.oleDb.Close();
            GetSNos();
        }

        public string[] GetSNos()
        {
            string[] SNos = new String[dataGridView1.Rows.Count];
            //MessageBox.Show(this.dataGridView1.Rows[0].Cells[0].Value.ToString());
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                SNos[i] += this.dataGridView1.Rows[i].Cells[0].Value.ToString();
            }

            return SNos;
        }

        private void StockView_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            dataGridView1.ClearSelection();
            UpdateDBView();

            //this.Size = MainForm._Instance.mainBox.Size;
            //this.Anchor = AnchorStyles.Top;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.ColumnIndex > -1 && e.RowIndex > -1)  //点击的是鼠标右键，并且不是表头
            {
                //右键选中单元格
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                currentSelectedSNo = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                //MessageBox.Show(currentSelectedSNo);
                this.stockMenuStrip.Show(MousePosition.X, MousePosition.Y); //MousePosition.X, MousePosition.Y 是为了让菜单在所选行的位置显示
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            StockUpdate stockUpdate = new StockUpdate(currentSelectedSNo);
            stockUpdate.Show();
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("是否要删除货号为" + currentSelectedSNo + "的记录", "删除员工信息", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                string sql = "delete from goods_stock where GID='" + currentSelectedSNo + "';";
                MainForm._instance.RunASql(sql);
                StockView._instance.UpdateDBView();
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            StockUpdate stockUpdate = new StockUpdate();
            stockUpdate.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
