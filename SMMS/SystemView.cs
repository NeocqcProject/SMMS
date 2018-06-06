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
    public partial class SystemView : UserControl
    {
        public static SystemView _instance;
        public SystemView()
        {
            InitializeComponent();
            _instance = this;
        }

        private void SystemView_Load(object sender, EventArgs e)
        {

        }
    }
}
