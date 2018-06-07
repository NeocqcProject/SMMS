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
    public partial class SalesView : UserControl
    {
        public static SalesView _instance;
        public SalesView()
        {
            InitializeComponent();
            _instance = this;
        }

        private void SalesView_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(GetMoneyView._instance);
            GetMoneyView._instance.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(RecordsView._instance);
            RecordsView._instance.Show();
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(this.BackColor);
        }
    }
}
