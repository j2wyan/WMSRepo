using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS_V1;

namespace OkhenTest.UI
{
    public partial class TantoshaSearch : Form
    {

        public int FormId { get; set; }
        public TantoshaSearch()
        {
            InitializeComponent();
        }

        private void TantoshaSearch_Load(object sender, EventArgs e)
        {
            loadfrm();
        }

        private void loadfrm()
        {
            comboBoxSearch.Items.Clear();
            comboBoxSearch.Items.Add("検索コード");
            comboBoxSearch.Items.Add("コード");
            comboBoxSearch.Items.Add("名称");
            comboBoxSearch.SelectedIndex = 0;

            ListView.Columns.Add("コード", 150);
            ListView.Columns.Add("名称", 400);
        }


        private void filltext()
        {

            if (FormId == 1)
            {

                UriageEntry frm = Application.OpenForms["UriageEntry"] as UriageEntry;
                if (frm != null && ListView.SelectedItems.Count > 0)
                {

                    frm.fillTantosha(ListView.SelectedItems[0].SubItems[0].Text, ListView.SelectedItems[0].SubItems[1].Text);
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

        private void search()
        {
            HBBUNLib.Bunrui bunrui; 


            try
            {

                bunrui = General.g_objOdds.Tan;
                bunrui.ClearJoken();

                switch (comboBoxSearch.SelectedIndex)
                {
                    case 0:
                        bunrui.SetJokenKcode(TextSearch.Text);
                        break;
                    case 1:
                        bunrui.SetJokenOutCode(Convert.ToInt32(TextSearch.Text));
                        break;
                    case 2:
                        bunrui.SetJokenName(TextSearch.Text, 2);
                        break;

                }


                Array aryData = bunrui.Read();

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
                tmpListViewItem = new ListViewItem(((HBBUNLib.arrayReadData)aryData.GetValue(l)).plCode.ToString());
                tmpListViewItem.SubItems.Add(((HBBUNLib.arrayReadData)aryData.GetValue(l)).pbstrName);
                ListView.Items.Add(tmpListViewItem);
            }

        }

        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            filltext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            filltext();
        }
    }
}
