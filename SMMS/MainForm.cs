using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SMMS
{
    public partial class MainForm : Form
    {
        public static MainForm _instance;

        public MainForm()
        {
            InitializeComponent();
            _instance = this;
        }

        //public SalesView salesView;
        //public StaffsView staffsView;
        //public StockView stockView;
        //public SystemView systemView;
        //public VipView vipView;
        //public LoginSystem loginWindow;
        public GroupBox mainBox; 

        public OleDbConnection oleDb;

        private void InitializeForm()
        {
            new SalesView();
            new StaffsView();
            new StockView();
            new SystemView();
            new VipView();
            new LoginSystem();
            new GetMoneyView();
            new RecordsView();
            new SearchGoods();
            new SearchVip();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //windows
            InitializeForm();
            mainBox = this.windowsGroup;

            //DataBase
            oleDb = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\桌面\安全驾驶\大三下\软件工程\大作业相关\SMDB.mdb");

            LoginSystem._instance.Show();
        }

        public bool RunASql(string sql)
        {//运行一条sql语句
            if(oleDb.State != ConnectionState.Open)
            {
                oleDb.Open();
            }
            OleDbCommand oleDbCommand = new OleDbCommand(sql,oleDb);
            oleDbCommand.ExecuteNonQuery();

            oleDb.Close();
            return true;
        }

        private void StaffsBtn_Click(object sender, EventArgs e)
        {

            windowsGroup.Controls.Clear();
            windowsGroup.Controls.Add(StaffsView._instance);
            StaffsView._instance.Show();
            StaffsView._instance.UpdateDBView();
        }

        private void SystemBtn_Click(object sender, EventArgs e)
        {
            windowsGroup.Controls.Clear();
            windowsGroup.Controls.Add(SystemView._instance);
            SystemView._instance.Show();
        }

        private void VipBtn_Click(object sender, EventArgs e)
        {
            windowsGroup.Controls.Clear();
            windowsGroup.Controls.Add(VipView._instance);
            VipView._instance.Show();
            VipView._instance.UpdateDBView();
        }

        private void StockBtn_Click(object sender, EventArgs e)
        {
            windowsGroup.Controls.Clear();
            windowsGroup.Controls.Add(StockView._instance);
            StockView._instance.Show();
            StockView._instance.UpdateDBView();
        }

        private void SalesBtn_Click(object sender, EventArgs e)
        {
            windowsGroup.Controls.Clear();
            windowsGroup.Controls.Add(SalesView._instance);
            SalesView._instance.Show();
        }

        private void windowsGroup_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(this.BackColor);
        }

        private void windowsGroup_Enter(object sender, EventArgs e)
        {

        }
    }
}
