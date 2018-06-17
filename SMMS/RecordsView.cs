using System;
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
    public partial class RecordsView : UserControl
    {
        public static RecordsView _instance;
        public RecordsView()
        {
            InitializeComponent();
            _instance = this;
        }

        private void RecordsView_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Date.Format = DateTimePickerFormat.Custom;
            this.Date.CustomFormat = "yyyy-MM-dd";
            this.Date2.Format = DateTimePickerFormat.Custom;
            this.Date2.CustomFormat = "yyyy-MM-dd";
            ClearBtn_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {//确认查询
            string sql = "select * from sales where ";
            if (UserID.Text != "")
            {
                sql += "SalerID='" + UserID.Text + "' ";
            }
            if (VIPID.Text != "")
            {
                if (UserID.Text != "")
                {
                    sql += "and ";
                }

                sql += "VipID='" + VIPID.Text + "' ";
            }
            if (Good.Text != "")
            {
                if (UserID.Text != "" || VIPID.Text != "")
                {
                    sql += "and ";
                }

                if (comboBox1.SelectedIndex == 0)
                {//ID
                    sql += "GID = '" + Good.Text + "' ";
                }
                else if (comboBox1.SelectedIndex == 1)
                {//名字
                    sql+= "GName like '%" + Good.Text + "%' ";
                }
            }
            if (Date.Checked == true && Date2.Checked == true)
            {
                if (UserID.Text != "" || VIPID.Text != "" || Good.Text != "")
                {
                    sql += "and ";
                }
                sql += "SDate between #" + Date.Value.ToShortDateString() + " 00:00:00# And #" + Date2.Value.ToShortDateString() + " 23:59:59# ";

            }
            if (UserID.Text == "" && 
                VIPID.Text == "" &&
                Date.Checked == false &&
                Date2.Checked == false &&
                Good.Text == "")
            {
                sql = "select * from sales";
            }
            if (MainForm._instance.oleDb.State != ConnectionState.Open)
            {
                MainForm._instance.oleDb.Open();
            }
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, MainForm._instance.oleDb); //创建适配对象
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds, "sales");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "sales";

            //dataGridView1.Columns[0].HeaderText = "工号";
            //dataGridView1.Columns[1].HeaderText = "姓名";

            MainForm._instance.oleDb.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            this.UserID.Text = "";
            this.VIPID.Text = "";
            this.Date.Checked = false;
            this.Date2.Checked = false;
            this.Good.Text = "";
            this.comboBox1.SelectedIndex = 0;

            string sql = "select * from sales";
            if (MainForm._instance.oleDb.State != ConnectionState.Open)
            {
                MainForm._instance.oleDb.Open();
            }
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, MainForm._instance.oleDb); //创建适配对象
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds, "sales");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "sales";

            //dataGridView1.Columns[0].HeaderText = "工号";
            //dataGridView1.Columns[1].HeaderText = "姓名";

            MainForm._instance.oleDb.Close();
        }



    }
}
