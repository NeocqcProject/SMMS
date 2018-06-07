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
        public string makeID;
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

            makeID = (max+1).ToString();
            MessageBox.Show(makeID);

            MainForm._instance.oleDb.Close();
        }

        public void AddGood()
        {//依据序号查找商品，生成详单
            if (dataGridView1.Rows.Count == 0)
            {
                GetNewMakeID();
            }

            //todo显示新加的商品，可以修改数目

        }
    }
}
