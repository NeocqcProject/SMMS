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
    public partial class GetMoneyView : UserControl
    {
        public static GetMoneyView _instance;
        public DataGridView GoodsGridView;
        public string markID;
        public GetMoneyView()
        {
            InitializeComponent();
            _instance = this;
            GoodsGridView = dataGridView1;
        }
        

        private void GetMoneyView_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchGoods._instance.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void GetNewMakeID()
        {
            string sql = "select * from sales";
            if (MainForm._instance.oleDb.State != ConnectionState.Open)
            {
                MainForm._instance.oleDb.Open();
            }
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, MainForm._instance.oleDb); //创建适配对象
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds, "sales");
            int max = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if(max <Int32.Parse(ds.Tables[0].Rows[i][1].ToString()))
                {
                    max = Int32.Parse(ds.Tables[0].Rows[i][1].ToString());
                }
            }

            markID = (max+1).ToString();
            MessageBox.Show(markID);

            MainForm._instance.oleDb.Close();
        }

        private void UpdateGoodsList()
        {
            string sql = "select * from sales where markID='" + markID + "'";
            if (MainForm._instance.oleDb.State != ConnectionState.Open)
            {
                MainForm._instance.oleDb.Open();
            }
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, MainForm._instance.oleDb); //创建适配对象
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds, "sales");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "sales";
        }


        public void AddGood(string GID,string GName,string price)
        {//依据序号查找商品，生成详单
            if (dataGridView1.Rows.Count == 0)
            {
                GetNewMakeID();
            }

            string sql = "insert into sales (markID,GID,GName,SNumbers,SumPrice,SalerID) values ";
            sql += "(" + markID + "," + GID +",'"+ GName + "',1," + price + ",'" + LoginSystem._instance.currentUserId + "')";

            MainForm._instance.RunASql(sql);
            UpdateGoodsList();


            //int index = dataGridView1.Rows.Add();
            //dataGridView1.Rows[index].Cells[1].Value = markID;


            //todo显示新加的商品，可以修改数目，06/11：不实现修改数目，模拟扫码


            //生成sql
            /*string sql = "insert into staffs values (";

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
            */
        }
    }
}
