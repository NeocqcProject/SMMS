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
            string sql = "select * from goods";
            if (MainForm._instance.oleDb.State != ConnectionState.Open)
            {
                MainForm._instance.oleDb.Open();
            }
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, MainForm._instance.oleDb); //创建适配对象
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds, "goods");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "goods";

            dataGridView1.Columns[0].HeaderText = "序号";
            dataGridView1.Columns[1].HeaderText = "商品名";

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


    }
}
