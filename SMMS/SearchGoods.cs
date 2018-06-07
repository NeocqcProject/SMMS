using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMMS
{
    public partial class SearchGoods : Form
    {
        public static SearchGoods _instance;
        public string currentSelectedID;
        public SearchGoods()
        {
            InitializeComponent();
            _instance = this;
        }

        private void SearchGoods_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void SearchResult_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void SearhBtn_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)
            {//编号
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入商品编号");
                }
                SearchGoodsByID(textBox1.Text);

            }
            else if(comboBox1.SelectedIndex == 1)
            {//名字
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入商品名称");
                }
                SearchGoodsByName(textBox1.Text);

            }
            //GetMoneyView._instance.GoodsGridView.Rows.Add();
        }

        private void SearchGoodsByID(string token)
        {
            string sql = "select * from goods_stock where GID = '"+ token + "'";
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
            //GetSNos();
        }

        private void SearchGoodsByName(string token)
        {
            string sql = "select * from goods_stock where GName like '%" + token + "%'";
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
            //GetSNos();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.ColumnIndex > -1 && e.RowIndex > -1)  //点击的是鼠标右键，并且不是表头
            {
                //右键选中单元格
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                currentSelectedID = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                //MessageBox.Show(currentSelectedID);

                SearchGoods._instance.Hide();
                GetMoneyView._instance.AddGood();
            }
        }
    }
}
