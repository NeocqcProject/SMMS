using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMMS
{
    public partial class SearchGoods : Form
    {
        public static SearchGoods _instance;
        public SearchGoods()
        {
            InitializeComponent();
            _instance = this;
        }

        private void SearchGoods_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void SearchResult_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void SearhBtn_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)
            {
                MessageBox.Show(comboBox1.SelectedIndex.ToString());
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                MessageBox.Show(comboBox1.SelectedIndex.ToString());
            }
        }
    }
}
