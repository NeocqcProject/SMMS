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
    public partial class StockUpdate : Form
    {
        private string currentSelectedGID;
        public static StockUpdate _instance;
        private bool isAdd;

        public StockUpdate()
        {//新增
            InitializeComponent();
            currentSelectedGID = null;
            isAdd = true;
            _instance = this;
        }

        public StockUpdate(string SNo)
        {//修改
            InitializeComponent();
            currentSelectedGID = SNo;
            _instance = this;
            isAdd = false;
        }

        private void StockUpdate_Load(object sender, EventArgs e)
        {
            if (isAdd)
            {
                _instance.Text = "新增库存信息(一次只能添加一条)";
                dataGridView1.AllowUserToAddRows = true;
            }
            else
            {
                _instance.Text = "修改库存信息";
                dataGridView1.AllowUserToAddRows = false;
            }
            //MessageBox.Show(currentSelectedGID);
            string sql = "select * from goods_stock where GID='" + currentSelectedGID + "'";
            if (MainForm._instance.oleDb.State != ConnectionState.Open)
            {
                MainForm._instance.oleDb.Open();
            }
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, MainForm._instance.oleDb); //创建适配对象
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds, "goods_stock");
            this.dataGridView1.DataSource = ds;
            this.dataGridView1.DataMember = "goods_stock";

            MainForm._instance.oleDb.Close();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("必填信息不能为空");
                return;
            }

            if (dataGridView1.Rows.Count > 2)
            {
                MessageBox.Show("一次只允许新增一条");
                StockUpdate_Load(null, null);
                return;
            }

            string sql;

            if (isAdd)
            {
                foreach (var no in StockView._instance.GetSNos())
                {
                    if (no == dataGridView1.Rows[0].Cells[0].Value.ToString())
                    {
                        MessageBox.Show("该货号存在！");
                        return;
                    }
                }
                sql = "insert into goods_stock values (";

                foreach (DataGridViewCell dgvc in dataGridView1.Rows[0].Cells)
                {

                    if (dataGridView1.Columns[dgvc.ColumnIndex].Name.ToString().ToArray<char>()[0] == 'R')
                    {//Administrator 不加引号
                        if (dgvc.Value.ToString() != "True")
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
                sql = "update goods_stock set ";

                foreach (DataGridViewCell dgvc in dataGridView1.Rows[0].Cells)
                {

                    if (dgvc.ColumnIndex == 0)
                    {//跳过工号

                    }
                    else
                    {
                        if (dataGridView1.Columns[dgvc.ColumnIndex].Name.ToString() == "GName")
                        {//文本加引号
                            sql += dataGridView1.Columns[dgvc.ColumnIndex].Name.ToString() +
                            " = '" + dgvc.Value.ToString() + "' ";
                        }
                        else
                        {
                            sql += dataGridView1.Columns[dgvc.ColumnIndex].Name.ToString() +
                            " = " + dgvc.Value.ToString() + " ";
                        }

                        if (dgvc.ColumnIndex < dataGridView1.Columns.Count - 1)
                        {
                            sql += ",";
                        }
                        else { }
                    }
                }
                sql += " where GID = '" + dataGridView1.Rows[0].Cells[0].Value.ToString()+"'";
            }
            //MessageBox.Show(sql);


            MainForm._instance.RunASql(sql);
            StockView._instance.UpdateDBView();
            StockUpdate._instance.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CancelBtn_Click_1(object sender, EventArgs e)
        {
            StockUpdate._instance.Close();
        }
    }
}
