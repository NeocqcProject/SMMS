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
    public partial class SearchVip : Form
    {
        public static SearchVip _instance;
        public string currentSelectedID;
        public SearchVip()
        {
            InitializeComponent();
            _instance = this;
        }

        private void SearchVip_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            ShowAllVips();
        }

        public void ShowAllVips()
        {
            string sql = "select * from vip";
            if (MainForm._instance.oleDb.State != ConnectionState.Open)
            {
                MainForm._instance.oleDb.Open();
            }
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, MainForm._instance.oleDb); //创建适配对象
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds, "vip");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "vip";

            MainForm._instance.oleDb.Close();
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void SearhBtn_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {//ID
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入会员编号");
                }
                SearchVipByID(textBox1.Text);

            }
            else if (comboBox1.SelectedIndex == 1)
            {//名字
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入会员名");
                }
                SearchVipByName(textBox1.Text);

            }
        }

        private void SearchVipByID(string token)
        {
            string sql = "select * from vip where ID = " + token + "";
            if (MainForm._instance.oleDb.State != ConnectionState.Open)
            {
                MainForm._instance.oleDb.Open();
            }
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, MainForm._instance.oleDb); //创建适配对象
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds, "vip");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "vip";

            dataGridView1.Columns[0].HeaderText = "会员ID";
            dataGridView1.Columns[1].HeaderText = "会员名称";

            MainForm._instance.oleDb.Close();
            //GetSNos();
        }

        private void SearchVipByName(string token)
        {
            string sql = "select * from vip where VName like '%" + token + "%'";
            if (MainForm._instance.oleDb.State != ConnectionState.Open)
            {
                MainForm._instance.oleDb.Open();
            }
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, MainForm._instance.oleDb); //创建适配对象
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds, "vip");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "vip";

            dataGridView1.Columns[0].HeaderText = "会员ID";
            dataGridView1.Columns[1].HeaderText = "会员名称";

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

                SearchVip._instance.Hide();
                GetMoneyView._instance.SetVip(currentSelectedID,
                    this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()); //name
            }
        }


    }
}
