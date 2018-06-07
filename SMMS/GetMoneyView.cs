using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMMS
{
    public partial class GetMoneyView : UserControl
    {
        public static GetMoneyView _instance;
        public DataGridView GoodsGridView;
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
    }
}
