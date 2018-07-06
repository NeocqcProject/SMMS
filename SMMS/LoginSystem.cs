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

        public string currentUserId;
        public string currentUserName;
        public string currentUserPwd;
        public bool RStaff;
        public bool RVIP;
        public bool RStock;
        public bool RSales;


        private void LoginSystem_Load(object sender, EventArgs e)
        {
            MainForm._instance.Hide();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {

            currentUserId = textBoxAccount.Text;
            currentUserPwd = textBoxPwd.Text;

            if (Login(currentUserId, currentUserPwd))
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

                currentUserId = ds.Tables[0].Rows[0]["SID"].ToString();
                currentUserName = ds.Tables[0].Rows[0]["SName"].ToString();

                if(ds.Tables[0].Rows[0]["RStaff"].ToString()=="True") {RStaff = true;}
                else {RStaff = false;}

                if (ds.Tables[0].Rows[0]["RVIP"].ToString() == "True") {RVIP = true;}
                else {RVIP = false;}

                if (ds.Tables[0].Rows[0]["RStock"].ToString() == "True") {RStock = true;}
                else {RStock = false;}

                if (ds.Tables[0].Rows[0]["RSales"].ToString() == "True") {RSales = true;}
                else {RSales = false;}
                MessageBox.Show("welcome  " +currentUserName);

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
