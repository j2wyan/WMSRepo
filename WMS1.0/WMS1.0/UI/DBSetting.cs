using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using YHCSK;

namespace WMS_V1.UI
{
    public partial class DBSetting : Form
    {
        //CYayoiHanbaiCommonSdk cyayoiHanbaiCommonSdk = new CYayoiHanbaiCommonSdk();
        //SdkCallback HanbaiCallback = new SdkCallback();
        bool bOpened;

        public DBSetting()
        {
            InitializeComponent();
        }

        private void DBSetting_Load(object sender, EventArgs e)
        {
            DBLoad();
        }



        private void gcTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gcTabControl1.SelectedIndex == 0)
            {
                DBLoad();
            }
            else
            {
                SystemDBLoad();
            }
        }


        private void DBLoad()
        {
            if (File.Exists(General.DBPath + "\\DB.txt"))
            {
                string[] lines = File.ReadAllLines(General.DBPath + "\\DB.txt");

                cboyserver.Text = lines[0];
                txtyuser.Text = lines[1];
                txtypassword.Text = lines[2];
                cboydb.Text = lines[3];
                cboyloginuser.Text = lines[4];
                txtyloginpw.Text = lines[5];
            }
        }

        private void SystemDBLoad()
        {
            if (File.Exists(General.DBPath + "\\DB2.txt"))
            {

                string[] lines = File.ReadAllLines(General.DBPath + "\\DB2.txt");



                cbosserver.Text = lines[0];
                txtsuser.Text = lines[1];
                txtspw.Text = lines[2];
                cbosdb.Text = lines[3];


            }
        }


        List<String> serverList = null;
        private void cboyserver_Click(object sender, EventArgs e)
        {
            if (cboyserver.Items.Count < 2)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (serverList == null)
                    serverList = ServerName();
                cboyserver.DataSource = null;
                cboyserver.DataSource = serverList;
                Cursor.Current = Cursors.Default;
            }
        }

        public List<String> ServerName()
        {
            List<String> ServerName = new List<string>();
            SqlDataSourceEnumerator servers = SqlDataSourceEnumerator.Instance;
            DataTable serversTable = servers.GetDataSources();

            foreach (DataRow row in serversTable.Rows)
            {
                string serverName = row[0].ToString();

                try
                {
                    if (row[1].ToString() != "")
                    {
                        serverName += "\\" + row[1].ToString();
                    }
                }
                catch
                { }
                ServerName.Add(serverName);
            }

            serverList = ServerName;
            return ServerName;

        }

        private void cboydb_Click(object sender, EventArgs e)
        {
            if (General.IsServerConnected(cboyserver.Text, txtyuser.Text, txtypassword.Text))
            {
                Cursor.Current = Cursors.WaitCursor;
                cboydb.DataSource = null;


                List<String> db = getDataBaseName(cboyserver.Text, txtyuser.Text, txtypassword.Text);
                cboydb.DataSource = db;
                //cboydb.DisplayMember = "Name";
                //cboydb.ValueMember = "Version";

                cboydb.Refresh();
                Cursor.Current = Cursors.Default;
                cboyloginuser.Text = string.Empty;
                txtyloginpw.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please check userName and Password");
            }
        }


        public List<String> getDataBaseName(string SVName, string User, string PW)
        {
            List<String> database = new List<string>();

            String con = "Data Source=" + SVName + ";User ID =" + User + ";Password=" + PW;

            SqlConnection sqlConn = new SqlConnection(con);
            sqlConn.Open();

            DataTable tblDatabase = sqlConn.GetSchema("Databases");

            sqlConn.Close();

            foreach (DataRow row in tblDatabase.Rows)
            {
                if (Convert.ToInt32(row[1]) > 4)
                {
                    String strDatabaseName = row["database_name"].ToString();
                    database.Add(strDatabaseName);

                }
            }
            return database;
        }

        private void cboyloginuser_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboyloginuser.DataSource == null)
                {
                    DataTable dt = cboUserBinding(cboyserver.Text, cboydb.Text, txtyuser.Text, txtypassword.Text);
                    if (dt.Rows.Count > 0)
                    {
                        cboyloginuser.DataSource = dt;
                        cboyloginuser.DisplayMember = "UserName";
                        cboyloginuser.ValueMember = "UserName";
                    }
                }


            }
            catch (Exception)
            {

            }
        }

        public DataTable cboUserBinding(string SVName, string DbName, string User, string PW)
        {

            DataTable dt = null;
            string connect = "Data Source=" + SVName + ";Initial Catalog=" + DbName + ";User ID=" + User + ";Password=" + PW + "";
            SqlConnection con = new SqlConnection(connect);
            try
            {
                con.Open();
                string select_query = "select UserName from Users Order by Id";
                SqlDataAdapter adap = new SqlDataAdapter(select_query, con);

                DataSet dset = new DataSet();
                adap.Fill(dset, "UserList");
                dt = dset.Tables[0];
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }

            return dt;
        }

        private void btnyok_Click(object sender, EventArgs e)
        {
            if (General.IsServerConnected(cboyserver.Text, txtyuser.Text, txtypassword.Text))
            {


                if (!Directory.Exists(General.DBPath))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(General.DBPath);
                        using (StreamWriter sw = File.CreateText(General.DBPath + "\\DB.txt"))
                        {
                            sw.WriteLine(cboyserver.Text);
                            sw.WriteLine(txtyuser.Text);
                            sw.WriteLine(txtypassword.Text);
                            sw.WriteLine(cboydb.Text);
                            sw.WriteLine(cboyloginuser.Text);
                            sw.WriteLine(txtyloginpw.Text);
                            sw.WriteLine(cboydb.SelectedValue.ToString());
                            sw.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else
                {

                    string[] lines = File.ReadAllLines(General.DBPath + "\\DB.txt");



                    lines[0] = cboyserver.Text;
                    lines[1] = txtyuser.Text;
                    lines[2] = txtypassword.Text;
                    lines[3] = cboydb.Text;
                    lines[4] = cboyloginuser.Text;
                    lines[5] = txtyloginpw.Text;
                    if (cboydb.SelectedValue != null)
                    {
                        lines[6] = cboydb.SelectedValue.ToString();
                    }

                    File.WriteAllLines(General.DBPath + "\\DB.txt", lines);

                }

                MessageBox.Show("保存しました。");

                if (File.Exists(General.DBPath + "\\DB.txt") && File.Exists(General.DBPath + "\\DB2.txt"))
                {
                    Application.Restart();
                }
            }
            else
            {
                MessageBox.Show("ユーザー名またはパスワードを確認して下さい。");
            }
        }

        private void cbosserver_Click(object sender, EventArgs e)
        {
            sserverClickClear();
            if (cbosserver.Items.Count < 2)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (serverList == null)
                    serverList = serverNames();
                cbosserver.DataSource = null;
                cbosserver.DataSource = serverList;
                Cursor.Current = Cursors.Default;
            }
        }


        private void sserverClickClear()
        {
            txtspw.Text = string.Empty;
            txtsuser.Text = string.Empty;
            cbosdb.DataSource = null;
            cbosdb.Text = string.Empty;

        }

        private void cbosdb_Click(object sender, EventArgs e)
        {
            if (General.IsServerConnected(cbosserver.Text, txtsuser.Text, txtspw.Text))
            {
                Cursor.Current = Cursors.WaitCursor;
                cboydb.DataSource = null;



                List<String> db = getDBName(cbosserver.Text, txtsuser.Text, txtspw.Text);
                cbosdb.DataSource = db;

                cbosdb.Refresh();

                Cursor.Current = Cursors.Default;

            }
            else
            {
                MessageBox.Show("ユーザー名またはパスワードが違います。");
            }
        }

        public List<String> serverNames()
        {
            List<String> ServerNames = new List<String>();

            SqlDataSourceEnumerator servers = SqlDataSourceEnumerator.Instance;
            DataTable serversTable = servers.GetDataSources();

            foreach (DataRow row in serversTable.Rows)
            {
                string serverName = row[0].ToString();

                try
                {

                    if (row[1].ToString() != "")
                    {

                        serverName += "\\" + row[1].ToString();

                    }


                }
                catch
                {


                }

                ServerNames.Add(serverName);
            }

            serverList = ServerNames;

            return ServerNames;
        }

        public List<String> getDBName(string SVName, string User, string PW)
        {
            List<String> databases = new List<String>();


            String strConn = "Data Source=" + SVName + ";User ID=" + User + ";Password=" + PW;

            //create connection
            SqlConnection sqlConn = new SqlConnection(strConn);

            //open connection
            sqlConn.Open();

            //get databases
            DataTable tblDatabases = sqlConn.GetSchema("Databases");

            //close connection
            sqlConn.Close();

            //add to list
            foreach (DataRow row in tblDatabases.Rows)
            {
                if (Convert.ToInt32(row[1]) > 4)
                {
                    String strDatabaseName = row["database_name"].ToString();

                    databases.Add(strDatabaseName);
                }


            }
            return databases;
        }

        private void btnsok_Click(object sender, EventArgs e)
        {
            if (General.IsServerConnected(cboyserver.Text, txtyuser.Text, txtypassword.Text))
            {
                if (!Directory.Exists(General.DBPath))
                {
                    System.IO.Directory.CreateDirectory(General.DBPath);
                }

                if (!File.Exists(General.DBPath + "\\DB2.txt"))
                {
                    try
                    {

                        using (StreamWriter sw = File.CreateText(General.DBPath + "\\DB2.txt"))
                        {
                            sw.WriteLine(cbosserver.Text);
                            sw.WriteLine(txtsuser.Text);
                            sw.WriteLine(txtspw.Text);
                            sw.WriteLine(cbosdb.Text);

                            sw.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else
                {

                    string[] lines = File.ReadAllLines(General.DBPath + "\\DB2.txt");
                    lines[0] = cbosserver.Text;
                    lines[1] = txtsuser.Text;
                    lines[2] = txtspw.Text;
                    lines[3] = cbosdb.Text;


                    File.WriteAllLines(General.DBPath + "\\DB2.txt", lines);

                }

                MessageBox.Show("保存しました。");

                if (File.Exists(General.DBPath + "\\DB.txt") && File.Exists(General.DBPath + "\\DB2.txt"))
                {
                    Application.Restart();
                }
            }
            else
            {
                MessageBox.Show("ユーザー名またはパスワードを確認して下さい。");
            }

        }

        private void cboyloginuser_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboyloginuser.DataSource = null;
        }
    }
}