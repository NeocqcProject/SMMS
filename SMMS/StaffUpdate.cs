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
    public partial class StaffUpdate : Form
    {
        private string currentSelectedSID;
        public static StaffUpdate _instance;
        private bool isAdd;

        public StaffUpdate()
        {//新增
            InitializeComponent();
            currentSelectedSID = null;
            isAdd = true;
            _instance = this;
        }

        public StaffUpdate(string SNo)
        {//修改
            InitializeComponent();
            currentSelectedSID = SNo;
            _instance = this;
            isAdd = false;
        }

        private void StaffUpdate_Load(object sender, EventArgs e)
        {
            if(isAdd)
            {
                _instance.Text = "新增员工信息(一次只能添加一条)";
                dataGridView1.AllowUserToAddRows = true;
            }
            else
            {
                _instance.Text = "修改员工信息";
                dataGridView1.AllowUserToAddRows = false;
            }
            MessageBox.Show(currentSelectedSID);
            string sql = "select * from staffs where SID='" + currentSelectedSID + "'";
            if (MainForm._instance.oleDb.State != ConnectionState.Open)
            {
                MainForm._instance.oleDb.Open();
            }
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, MainForm._instance.oleDb); //创建适配对象
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds,"staffs");
            this.dataGridView1.DataSource = ds;
            this.dataGridView1.DataMember = "staffs";

            MainForm._instance.oleDb.Close();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows[0].Cells[0].Value ==null)
            {
                MessageBox.Show("必填信息不能为空");
                return;
            }

            if(dataGridView1.Rows.Count>1)
            {
                MessageBox.Show("一次只允许新增一条");
                StaffUpdate_Load(null, null);
                return;
            }

            string sql;

            if (isAdd)
            {
                foreach(var no in StaffsView._instance.GetSNos())
                {
                    if (no == dataGridView1.Rows[0].Cells[0].Value.ToString())
                    {
                        MessageBox.Show("该工号已存在！");
                        return;
                    }
                }
                sql = "insert into staffs values (";

                foreach (DataGridViewCell dgvc in dataGridView1.Rows[0].Cells)
                {

                    if (dataGridView1.Columns[dgvc.ColumnIndex].Name.ToString().ToArray<char>()[0] == 'R')
                    {//Administrator 不加引号
                        if(dgvc.Value.ToString()!="True")
                        {
                            dgvc.Value = false;
                        }
                        sql += " " + dgvc.Value.ToString() + " ";
                    }
                    else
                    {
                        sql += " '" + dgvc.Value.ToString() + "' ";
                    }

                    if (dgvc.ColumnIndex < dataGridView1.Columns.Count - 1)
                    {
                        sql += ",";
                    }
                    else { }
                }
                sql += ")";
            }
            else
            {
                sql = "update staffs set ";

                foreach (DataGridViewCell dgvc in dataGridView1.Rows[0].Cells)
                {

                    if (dgvc.ColumnIndex == 0)
                    {//跳过工号

                    }
                    else
                    {
                        if (dataGridView1.Columns[dgvc.ColumnIndex].Name.ToString().ToArray<char>()[0] == 'R')
                        {//权限 不加引号
                            sql += dataGridView1.Columns[dgvc.ColumnIndex].Name.ToString() +
                            " = " + dgvc.Value.ToString() + " ";
                        }
                        else
                        {
                            sql += dataGridView1.Columns[dgvc.ColumnIndex].Name.ToString() +
                            " = '" + dgvc.Value.ToString() + "' ";
                        }

                        if (dgvc.ColumnIndex < dataGridView1.Columns.Count - 1)
                        {
                            sql += ",";
                        }
                        else { }
                    }
                }
                sql += " where SID = '" + dataGridView1.Rows[0].Cells[0].Value.ToString() + "'";
            }
                //MessageBox.Show(sql);


            MainForm._instance.RunASql(sql);
            StaffsView._instance.UpdateDBView();
            StaffUpdate._instance.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            StaffUpdate._instance.Close();
        }
    }
}
