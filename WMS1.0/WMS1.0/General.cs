using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using HBTOKLib;
//using YHCSK;

namespace WMS_V1
{
    
    public class General
    {
        public static string DBPath = System.IO.Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName.ToString() + @"\Local\WMS";
        public static string DBPathFile = DBPath + "\\DB.txt";
        public static string DBPathFile2 = DBPath + "\\DB2.txt";

        public static HBODDSLib.Application g_objOdds { get; set; }


        //CYayoiHanbaiCommonSdk cyayoiHanbaiCommonSdk = new CYayoiHanbaiCommonSdk();
        SdkCallback Callback = new SdkCallback();

        bool bOpened;

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI992124882!@#$";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI992124882!@#$";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


        public static string getCon1()
        {
            string con = "";

            if (File.Exists(DBPathFile))
            {
                string[] db = File.ReadAllLines(DBPathFile);

                if (db.Length > 4)
                    con = "Data Source=" + db[0] + ";Initial Catalog=" + db[3] + ";User ID=" + db[1] + ";Password=" + db[2];
            }

            return con;
        }


        public static string getCon2()
        {
            string con = "";

            if (File.Exists(DBPathFile2))
            {
                string[] db = File.ReadAllLines(DBPathFile);

                if (db.Length > 4)
                    con = "Data Source=" + db[0] + ";Initial Catalog=" + db[3] + ";User ID=" + db[1] + ";Password=" + db[2];
            }

            return con;
        }

        public static string getServerName()
        {
            string ret = "";

            if (File.Exists(General.DBPathFile))
            {

                string[] lines = File.ReadAllLines(General.DBPathFile);

                if (lines != null)
                    ret = lines[0];

            }
            return ret;
        }

        public static string getDBName()
        {
            string ret = "";

            if (File.Exists(General.DBPathFile))
            {

                string[] lines = File.ReadAllLines(General.DBPathFile);

                if (lines != null)
                    ret = lines[3];

            }
            return ret.Trim();
        }

        public static string getSysUserName()
        {
            string ret = "";

            if (File.Exists(General.DBPathFile))
            {

                string[] lines = File.ReadAllLines(General.DBPathFile);

                if (lines != null)
                    ret = lines[1];

            }
            return ret;
        }

        public static string getSysPassword()
        {
            string ret = "";

            if (File.Exists(General.DBPathFile))
            {

                string[] lines = File.ReadAllLines(General.DBPathFile);

                if (lines != null)
                    ret = lines[2];

            }
            return ret;
        }

        public static string getYayoiUsername()
        {
            string ret = "";

            if (File.Exists(General.DBPathFile))
            {

                string[] lines = File.ReadAllLines(General.DBPathFile);

                if (lines != null)
                    ret = lines[4];

            }
            return ret;
        }

        public static string getYayoiPassword()
        {
            string ret = "";

            if (File.Exists(General.DBPathFile))
            {

                string[] lines = File.ReadAllLines(General.DBPathFile);

                if (lines != null)
                    ret = lines[5];

            }
            return ret;
        }



        public static bool IsServerConnected(string svName, string User, string PW)
        {
            string connetionString = "Data Source=" + svName + ";User ID=" + User + ";Password=" + PW;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public void SaveYayoiSDK(string filepath, int yayoiNo)
        {
            try
            {
            //    cyayoiHanbaiCommonSdk.Initialize(-1);
            //    cyayoiHanbaiCommonSdk.SetServerName(getServerName());
            //    cyayoiHanbaiCommonSdk.SetSysUserName(getSysUserName());
            //    cyayoiHanbaiCommonSdk.SetSysPassword(getSysPassword());
            //    cyayoiHanbaiCommonSdk.SetDataName(getDBName());
            //    cyayoiHanbaiCommonSdk.SetLoginUserName(getYayoiUsername());
            //    cyayoiHanbaiCommonSdk.SetLoginUserPwd(getYayoiPassword());

            //    cyayoiHanbaiCommonSdk.SetSdkCallBack(Callback);

            //    this.bOpened = cyayoiHanbaiCommonSdk.Open();

            //    if (bOpened == true)
            //    {
            //        cyayoiHanbaiCommonSdk.SetTextFileName(filepath);
            //        cyayoiHanbaiCommonSdk.SetTextType(1);
            //        cyayoiHanbaiCommonSdk.SetStartLine(1);
            //        cyayoiHanbaiCommonSdk.SetObjectType(yayoiNo);
            //        cyayoiHanbaiCommonSdk.SetAutoDemban(1);
            //        cyayoiHanbaiCommonSdk.SetWritingMode(2);

            //        if (cyayoiHanbaiCommonSdk.IsExecute(yayoiNo))
            //        {
            //            if (cyayoiHanbaiCommonSdk.Import())
            //            {
            //                MessageBox.Show("インポート成功");
            //            }
            //            else
            //            {
            //                MessageBox.Show("インポート失敗 .");
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("実行権限が無い");
            //        }
            //    }

            //    else
            //    {
            //        MessageBox.Show("データベースのオープンに失敗しました。");
            //    }
            
            //cyayoiHanbaiCommonSdk.Close();
            //cyayoiHanbaiCommonSdk.Terminate();
        }
            catch (Exception ex)
            {
                //cyayoiHanbaiCommonSdk.Close();
                //cyayoiHanbaiCommonSdk.Terminate();
              
            }

}
            }

    }

   


    //public class SysDBConnection
    //{
    //    public static string getConnection1()
    //    {
    //        string ret = "";

    //        if (File.Exists(General.DBPathFile2))
    //        {

    //            string[] lines = File.ReadAllLines(General.DBPathFile2);

    //            if (lines.Length > 2)
    //                ret = "Data Source=" + lines[0] + ";User ID=" + lines[1] + ";Password=" + lines[2];


    //        }
    //        return ret;
    //    }

    //    public static string getConnection2()
    //    {
    //        string ret = "";

    //        if (File.Exists(General.DBPathFile2))
    //        {

    //            string[] lines = File.ReadAllLines(General.DBPathFile2);

    //            if (lines.Length == 4)
    //                ret = "Data Source=" + lines[0] + ";Initial Catalog=" + lines[3] + ";User ID=" + lines[1] + ";Password=" + lines[2];


    //        }
    //        return ret;
    //    }

    //    public static string getServerName()
    //    {
    //        string ret = "";

    //        if (File.Exists(General.DBPathFile2))
    //        {

    //            string[] lines = File.ReadAllLines(General.DBPathFile2);

    //            if (lines != null)
    //                ret = lines[0];

    //        }
    //        return ret.Trim();
    //    }

    //    public static string getDBName()
    //    {
    //        string ret = "";

    //        if (File.Exists(General.DBPathFile2))
    //        {

    //            string[] lines = File.ReadAllLines(General.DBPathFile2);


    //            if (lines != null)
    //                ret = lines[3];

    //        }
    //        return ret.Trim();
    //    }

    //    public static string getUserName()
    //    {
    //        string ret = "";

    //        if (File.Exists(General.DBPathFile2))
    //        {

    //            string[] lines = File.ReadAllLines(General.DBPathFile2);


    //            if (lines != null)
    //                ret = lines[1];

    //        }
    //        return ret;
    //    }

    //    public static string getPassword()
    //    {
    //        string ret = "";

    //        if (File.Exists(General.DBPathFile2))
    //        {

    //            string[] lines = File.ReadAllLines(General.DBPathFile2);


    //            if (lines != null)
    //                ret = lines[2];

    //        }
    //        return ret;
    //    }
    //}




    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        public CustomToolStripRenderer() { }


        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            //you may want to change this based on the toolstrip's dock or layout style
            //LinearGradientMode mode = LinearGradientMode.Horizontal;
            //LinearGradientMode mode = LinearGradientMode.ForwardDiagonal;
            //LinearGradientMode mode = LinearGradientMode.BackwardDiagonal;
            LinearGradientMode mode = LinearGradientMode.Vertical;

            //using (LinearGradientBrush b = new LinearGradientBrush(e.AffectedBounds, ColorTable.MenuStripGradientBegin, ColorTable.MenuStripGradientEnd, mode))
            //{
            //    e.Graphics.FillRectangle(b, e.AffectedBounds);
            //}

            using (LinearGradientBrush b = new LinearGradientBrush(e.AffectedBounds, Color.White, Color.LightGray, mode))
            {
                e.Graphics.FillRectangle(b, e.AffectedBounds);
            }

        }


        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderButtonBackground(e);
            }
            else
            {

                //Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);

                //e.Graphics.FillRectangle(Brushes.DarkSeaGreen, rectangle);
                //e.Graphics.DrawRectangle(Pens.White, rectangle);



                // if (e.Item.Name == "theNameOfMyToolStripMenuItem")
                // {
                //Image backgroundImage = global::WMS_V1.Properties.Resources.gray;
                //e.Graphics.DrawImage(backgroundImage, 0, 0, e.Item.Width, e.Item.Height);
                // }
                //  else
                //{
                //base.OnRenderMenuItemBackground(e);
                // }



            }
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderDropDownButtonBackground(e);
            }
            else
            {

                //Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);

                //e.Graphics.FillRectangle(Brushes.DarkSeaGreen, rectangle);
                //e.Graphics.DrawRectangle(Pens.White, rectangle);


               // Image backgroundImage = global::WMS_V1.Properties.Resources.gray;
                //e.Graphics.DrawImage(backgroundImage, 0, 0, e.Item.Width, e.Item.Height);


            }
        }


    }

