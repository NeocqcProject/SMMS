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
    public partial class StockView : UserControl
    {
        public static StockView _instance;
        public StockView()
        {
            InitializeComponent();
            _instance = this;
        }

        private void StockView_Load(object sender, EventArgs e)
        {

        }
    }
}
