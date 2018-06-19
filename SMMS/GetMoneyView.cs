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
        public string VipID;
        private List<string> goodsList;
        private int sum;
        public GetMoneyView()
        {
            InitializeComponent();
            _instance = this;
            GoodsGridView = dataGridView1;
            sum = 0;
            goodsList = new List<string>();
            VipID = null;
        }
        

        private void GetMoneyView_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            userText.Text = LoginSystem._instance.currentUserId +" " + LoginSystem._instance.currentUserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchGoods._instance.Show();
            SearchGoods._instance.ShowAllGoods();
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
            MainForm._instance.oleDb.Close();

            goodsList = new List<string>();
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

            if (goodsList.Exists(delegate (string s) { return s == GID; }))
            {
                string sql = "update sales set  SumPrice = (SumPrice/SNumbers)*(SNumbers+1),SNumbers= SNumbers+1 where GID='" + GID+ "' and markID='"+markID+"'";
                MainForm._instance.RunASql(sql);
            }
            else
            {
                string sql = "insert into sales (markID,GID,GName,SNumbers,SumPrice,SalerID) values ";
                sql += "(" + markID + "," + GID + ",'" + GName + "',1," + price + ",'" + LoginSystem._instance.currentUserId + "')";
                MainForm._instance.RunASql(sql);

                if(VipID!=null)
                {//已经有会员信息，直接更新
                    sql = "update sales set VipID='" + VipID + "' where markID='" + markID + "'";
                    MainForm._instance.RunASql(sql);
                }

                goodsList.Add(GID);
            }

            UpdateGoodsList();
            sum = 0;
            for (int i = 0; i<dataGridView1.RowCount;i++)
            {
                sum += Int32.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
            }
            label2.Text = sum.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {//清空
            string sql;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                sql= "delete * from sales where SID="+dataGridView1.Rows[i].Cells[0].Value.ToString();
                MainForm._instance.RunASql(sql);
            }

            NewList();
        }

        private void button3_Click(object sender, EventArgs e)
        {//结算
            string sql;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                //更新货物数量
                sql = "update goods_stock set Numbers=Numbers-"+  dataGridView1.Rows[i].Cells[4].Value.ToString() + " where GID='" + dataGridView1.Rows[i].Cells[2].Value.ToString()+"'";
                MainForm._instance.RunASql(sql);
                //更新积分
                if (dataGridView1.Rows[i].Cells[7].Value.ToString() != "")
                {
                    sql = "update vip set Point=Point+" + dataGridView1.Rows[i].Cells[5].Value.ToString() + " where ID=" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "";
                    MainForm._instance.RunASql(sql);
                }
            }

            NewList();
        }

        private void NewList()
        {
            GetNewMakeID();
            UpdateGoodsList();
            label2.Text = "0";
            VipText.Text = "无";
            VipID = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SearchVip._instance.Show();
            SearchVip._instance.ShowAllVips();
        }

        public void SetVip(string ID,string VipName)
        {
            VipID = ID;
            VipText.Text = VipID+"  "+VipName;
            string sql;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                sql = "update sales set VipID='" + VipID + "' where markID='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'";
                MainForm._instance.RunASql(sql);
            }

            UpdateGoodsList();
        }

    }
}
