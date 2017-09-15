using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS_V1.DL;
using WMS_V1.UI;


namespace WMS_V1.UI
{
   
    public partial class TokuiSearch : Form
    {
       

       // private HBODDSLib.Application _objOdds;

        public int FormId { get; set; }
        public TokuiSearch()
        {
            InitializeComponent();
        }

        private void TokuiSearch_Load(object sender, EventArgs e)
        {
            loadfrm();
        }

        private void loadfrm()
        {
            ComboSearch.Items.Clear();
            ComboSearch.Items.Add("検索コード");
            ComboSearch.Items.Add("コード");
            ComboSearch.Items.Add("名称");
            ComboSearch.Items.Add("住所");
            ComboSearch.Items.Add("TEL");
            ComboSearch.SelectedIndex = 2;

            ListView.Columns.Add("コード", 50);
            ListView.Columns.Add("名称", 350);
            ListView.Columns.Add("〒", 100);
            ListView.Columns.Add("住所", 300);
            ListView.Columns.Add("TEL", 150);

        }


        private void loadcbo(DataTable dt)
        {


        
        }

        private void loadcbotantosha(DataTable dt)
        {

        }

       
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            filltext();
        }

        private void filltext()
        {

            if (FormId == 1)
            {
                UriageEntry frm = Application.OpenForms["UriageEntry"] as UriageEntry;
                if (frm != null && ListView.SelectedItems.Count > 0)
                {

                    frm.fillTokuisaki(ListView.SelectedItems[0].SubItems[0].Text, ListView.SelectedItems[0].SubItems[1].Text);
                    this.Close();


                }

            }
            else
            {
                //JutyuEntry f2 = Application.OpenForms["JutyuEntry"] as JutyuEntry;
                //if (f2 != null && listView1.SelectedItems.Count > 0)
                //{

                //    f2.fillTokuisaki(listView1.SelectedItems[0].Text.Substring(0, 10), listView1.SelectedItems[0].Text.Substring(10, listView1.SelectedItems[0].Text.Trim().Length));
                //    this.Close();


                //}
            }
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            search();
        }
        private void search()
        {
            HBTOKLib.Tokui tokui;
       

            try
            {

                tokui = General.g_objOdds.Tok;
                tokui.ClearJoken();

                switch (ComboSearch.SelectedIndex)
                {
                    case 0:
                        tokui.SetJokenKcode(TextSearch.Text);
                        break;
                    case 1:
                        tokui.SetJokenCode(TextSearch.Text);
                        break;
                    case 2:
                        tokui.SetJokenName(TextSearch.Text, 2);
                        break;
                    case 3:
                        tokui.SetJokenAdd(TextSearch.Text, 2);
                        break;
                    case 4:
                        tokui.SetJokenTel(TextSearch.Text);
                        break;
                }


                Array aryData = tokui.Read();

                loadlist(aryData);



            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("Message:" + ex.Message + Environment.NewLine + "ErrorCode:&H" + string.Format(ex.ErrorCode.ToString("X")));
                return;
            }

        }


        void loadlist(Array aryData)
        {
            ListViewItem tmpListViewItem;
            for (long l = aryData.GetLowerBound(0); l <= aryData.GetUpperBound(0); l++)
            {
                tmpListViewItem = new ListViewItem(((HBTOKLib.arrayReadData)aryData.GetValue(l)).pbstrCode.ToString());
                tmpListViewItem.SubItems.Add((((HBTOKLib.arrayReadData)aryData.GetValue(l)).pbstrNm1 + (" " + ((HBTOKLib.arrayReadData)aryData.GetValue(l)).pbstrNm2)).TrimEnd());
                tmpListViewItem.SubItems.Add(((HBTOKLib.arrayReadData)aryData.GetValue(l)).pbstrZip);
                tmpListViewItem.SubItems.Add((((HBTOKLib.arrayReadData)aryData.GetValue(l)).pbstrAdd1 + (" " + ((HBTOKLib.arrayReadData)aryData.GetValue(l)).pbstrAdd2)).TrimEnd());
                tmpListViewItem.SubItems.Add(((HBTOKLib.arrayReadData)aryData.GetValue(l)).pbstrTel);
                ListView.Items.Add(tmpListViewItem);
            }

        }



        private void btn1_Click(object sender, EventArgs e)
        {
            DATokui tokui = new DATokui();
            DataTable dt = tokui.getTokuibyKana("[ｱ-ｵ]");
           // listLoad(dt);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            DATokui tokui = new DATokui();
            DataTable dt = tokui.getTokuibyKana("[ｶ-ｺ]");
           // listLoad(dt);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            DATokui tokui = new DATokui();
            DataTable dt = tokui.getTokuibyKana("[サ-ｿ]");
           // listLoad(dt);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            DATokui tokui = new DATokui();
            DataTable dt = tokui.getTokuibyKana("[タ-ﾄ]");
           // listLoad(dt);
        }

        private void btn5_Click(object sender, EventArgs e)
        {

            DATokui tokui = new DATokui();
            DataTable dt = tokui.getTokuibyKana("[ナ-ﾉ]");
           // listLoad(dt);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            DATokui tokui = new DATokui();
            DataTable dt = tokui.getTokuibyKana("[ハ-ﾎ]");
           // listLoad(dt);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            DATokui tokui = new DATokui();
            DataTable dt = tokui.getTokuibyKana("[マ-ﾓ]");
           // listLoad(dt);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            DATokui tokui = new DATokui();
            DataTable dt = tokui.getTokuibyKana("[ヤ-ﾖ]");
           // listLoad(dt);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            DATokui tokui = new DATokui();
            DataTable dt = tokui.getTokuibyKana("[ラ-ﾝ]");
           // listLoad(dt);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            DATokui tokui = new DATokui();
            DataTable dt = tokui.getTokuibyKana("[ワ-ﾛ]");
           // listLoad(dt);
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            DATokui tokui = new DATokui();
            DataTable dt = tokui.getTokuibyKana("[A-Z]");
            //listLoad(dt);
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            DATokui tokui = new DATokui();
            DataTable dt = tokui.getTokuibyKana("[0-9]");
           // listLoad(dt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            filltext();
        }







        //public void filltext()
        //{

        //    if (FormId == 11)
        //    {

        //        DenpyoSearch f2 = Application.OpenForms["DenpyoSearch"] as DenpyoSearch;
        //        if (f2 != null && listView1.SelectedItems.Count > 0)
        //        {

        //            f2.fillTokuisaki(listView1.SelectedItems[0].Text.Substring(0, 10), listView1.SelectedItems[0].Text.Substring(10, listView1.SelectedItems[0].Text.Trim().Length));
        //            this.Close();


        //        }
        //    }
        //    else
        //    {
        //        DenpyoEntry f2 = Application.OpenForms["DenpyoEntry"] as DenpyoEntry;
        //        if (f2 != null && listView1.SelectedItems.Count > 0)
        //        {

        //            f2.fillTokuisaki(listView1.SelectedItems[0].Text.Substring(0, 10), listView1.SelectedItems[0].Text.Substring(10, listView1.SelectedItems[0].Text.Trim().Length));
        //            this.Close();


        //        }
        //    }
        //}



    }

   
}
