﻿using System;
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

        private string currentUserId;
        private string currentUserName;
        private string currentUserPwd;
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
                MessageBox.Show("success login");

                currentUserId = ds.Tables[0].Rows[0]["SID"].ToString();
                currentUserName = ds.Tables[0].Rows[0]["SName"].ToString();
                if(ds.Tables[0].Rows[0]["RStaff"].ToString()=="true") {RStaff = true;}
                else {RStaff = false;}

                if (ds.Tables[0].Rows[0]["RVIP"].ToString() == "true") {RVIP = true;}
                else {RVIP = false;}

                if (ds.Tables[0].Rows[0]["RStock"].ToString() == "true") {RStock = true;}
                else {RStock = false;}

                if (ds.Tables[0].Rows[0]["RSales"].ToString() == "true") {RSales = true;}
                else {RSales = false;}

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
