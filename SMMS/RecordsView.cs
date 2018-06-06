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
    public partial class RecordsView : UserControl
    {
        public static RecordsView _instance;
        public RecordsView()
        {
            InitializeComponent();
            _instance = this;
        }

        private void RecordsView_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}
