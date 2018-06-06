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

        }
    }
}
