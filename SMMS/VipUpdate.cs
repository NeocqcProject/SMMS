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
    public partial class VipUpdate : Form
    {
        private string currentSelectedID;
        public static VipUpdate _instance;
        private bool isAdd;

        public VipUpdate()
        {
            InitializeComponent();
            currentSelectedID = "0";
            isAdd = true;
            _instance = this;
        }

        public VipUpdate(string ID)
        {//修改
            InitializeComponent();
            currentSelectedID = ID;
            _instance = this;
            isAdd = false;
        }

        private void VipUpdate_Load(object sender, EventArgs e)
        {

            if (isAdd)
            {
                _instance.Text = "新增会员信息(一次只能添加一条)";
                TimetextBox.Text = "系统自动生成";
                IDtextBox.Text = "系统自动生成";
            }
            else
            {
                _instance.Text = "修改会员信息";

                //MessageBox.Show(currentSelectedSID);
                string sql = "select * from vip where ID=" + currentSelectedID + "";
                if (MainForm._instance.oleDb.State != ConnectionState.Open)
                {
                    MainForm._instance.oleDb.Open();
                }
                OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, MainForm._instance.oleDb); //创建适配对象
                DataSet ds = new DataSet();
                dbDataAdapter.Fill(ds, "vip");
                for(int i = 0; i<ds.Tables[0].Rows.Count;i++)
                {
                    if(ds.Tables[0].Rows[i][0].ToString()==currentSelectedID)
                    {
                        IDtextBox.Text = ds.Tables[0].Rows[i][0].ToString();
                        NametextBox.Text = ds.Tables[0].Rows[i][1].ToString();
                        PhoneNumtextBox.Text = ds.Tables[0].Rows[i][2].ToString();
                        TimetextBox.Text = ds.Tables[0].Rows[i][3].ToString();
                        PointtextBox.Text = ds.Tables[0].Rows[i][4].ToString();
                        break;
                    }
                }
                MainForm._instance.oleDb.Close();
            }
            TimetextBox.ReadOnly = true;
            IDtextBox.ReadOnly = true;
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {

            string sql;

            if (isAdd)
            {
                sql = "insert into vip (VName,PhoneNumber,Point) values ('" + NametextBox.Text +
                     "','" + PhoneNumtextBox.Text +
                     "'," + PointtextBox.Text + ")";
            }
            else
            {
                sql = "update vip set VName='" + NametextBox.Text +
                    "',PhoneNumber='"+ PhoneNumtextBox.Text + 
                    "',Point='"+ PointtextBox.Text + 
                    "' where ID ="+IDtextBox.Text;
            }
            MainForm._instance.RunASql(sql);
            VipView._instance.UpdateDBView();
            VipUpdate._instance.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            VipUpdate._instance.Close();
        }
    }
}
