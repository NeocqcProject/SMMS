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
    public partial class LoginSystem : Form
    {
        public static LoginSystem _instance;

        public LoginSystem()
        {
            InitializeComponent();
            _instance = this;
        }

        private string userId;
        private string userName;
        private string userPwd;
        private bool RStaff;
        private bool RVIP;
        private bool RStock;
        private bool RSales;


        private void LoginSystem_Load(object sender, EventArgs e)
        {
            MainForm._instance.Hide();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            userId = textBoxAccount.Text;
            userPwd = textBoxPwd.Text;

            if (Login(userId, userPwd))
            {
                this.Hide();
                MainForm._instance.Show();
            }
            else
            {
                //
            }

        }

        private bool Login(string userId, string pwd)
        {
            string sql = "select * from staffs where SID = '" + userId + "'";
            if (MainForm._instance.oleDb.State != ConnectionState.Open)
            {
                MainForm._instance.oleDb.Open();
            }
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, MainForm._instance.oleDb); //创建适配对象
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds, "staffs");
            Console.WriteLine(ds.Tables[0].Rows[0]["SPwd"]);
            if (ds.Tables[0].Rows[0]["SPwd"].ToString() == pwd)
            {
                MainForm._instance.oleDb.Close();
                MessageBox.Show("success login");
                return true;
            }
            else
            {
                MainForm._instance.oleDb.Close();
                MessageBox.Show("failed to login");
                return false;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginSystem_Shown(object sender, EventArgs e)
        {
            MainForm._instance.Hide();
        }

        private void LoginSystem_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm._instance.Close();
        }
    }


}
