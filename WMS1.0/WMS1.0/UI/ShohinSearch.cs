using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS_V1.DL;

namespace WMS_V1.UI
{
  
    public partial class ShohinSearch : Form
    {
        public string itemform;
        public string CustomerCode { get; set; }

        public ShohinSearch()
        {
            InitializeComponent();
        }

        private void ShohinSearch_Load(object sender, EventArgs e)
        {
            loadList("ｱ", 1);
        }

        private void loadList(string D, int callFlag)
        {
            this.Cursor = Cursors.WaitCursor;

            DAShoinDaicho shoinDaicho = new DAShoinDaicho();
            DataTable dt = null;

            if (callFlag == 0)
            {
                dt = shoinDaicho.getShoinDiacho();
            }
            else if (callFlag == 1)
            {
                dt = shoinDaicho.getShoinDiachobyD(D);
            }
            else if (callFlag == 3)
            {

                string[] arr = new string[3];
                arr[0] = D.Substring(0, D.IndexOf("#"));
                arr[1] = D.Substring(D.IndexOf("#") + 1, 1);
                arr[2] = "where  " + arr[1] + "='" + arr[0] + "'";


                dt = shoinDaicho.getShoinDiachobyBuriichi(arr[2]);

            }
            else
            {
                dt = shoinDaicho.getShoinDiachobyDFromat2(D);
            }

            listView1.Items.Clear();

            if (dt != null)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["B"].ToString());
                    item.SubItems.Add(dr["C"].ToString());
                    item.SubItems.Add(dr["E"].ToString());
                    item.SubItems.Add(dr["J"].ToString());
                    item.SubItems.Add(dr["K"].ToString());
                    item.SubItems.Add(dr["F"].ToString());
                    item.SubItems.Add(Convert.ToInt64(dr["Z"]).ToString("#,###"));
                    listView1.Items.Add(item);
                }
                listView1.Refresh();
            }

            this.Cursor = Cursors.Arrow;

        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

            if (itemform == "ItemForm")
            {


                Form Fc = Application.OpenForms["Item_Master"];
                if (Fc != null)
                {
                    Fc.Close();
                    Item_Master itemmaster = new Item_Master();
                    ListViewItem item = listView1.SelectedItems[0];
                  
                    string code = item.SubItems[0].Text;
                   
                    itemmaster.code = code;
                
                    itemmaster.Show();

                    this.Close();

                }
            }
            else
            {
                JutyuEntry f2 = Application.OpenForms["JutyuEntry"] as JutyuEntry;
                if (f2 != null && listView1.SelectedItems.Count > 0)
                {
                    ListViewItem item = listView1.SelectedItems[0];
                    //f2.callShoindiacho(item.SubItems[0].Text);
                    string code = item.SubItems[0].Text;
                    Item_Master itemmaster = new Item_Master();
                    DataTable dt = itemmaster.LoadItemData(code);
                    if (dt.Rows.Count > 0)
                    {
                        f2.gcMultiRow1.CurrentRow.Cells["txtCode"].Value = dt.Rows[0]["B"].ToString();
                        f2.gcMultiRow1.CurrentRow.Cells["txtName"].Value = dt.Rows[0]["C"].ToString();
                        f2.gcMultiRow1.CurrentRow.Cells["txtQty"].Value = dt.Rows[0]["L"].ToString();
                        f2.gcMultiRow1.CurrentRow.Cells["txtUnitsPrice"].Value = dt.Rows[0]["F"].ToString();
                        f2.gcMultiRow1.CurrentRow.Cells["txtTax"].Value = dt.Rows[0]["H"].ToString();
                        string H = dt.Rows[0]["H"].ToString();

                        if (H == "1")
                        {
                            f2.gcMultiRow1.CurrentRow.Cells["txtTax"].Value = "課税";
                        }
                        else if (H == "2")
                        {
                            f2.gcMultiRow1.CurrentRow.Cells["txtTax"].Value = "課税(自)";
                        }
                        else if (H == "3")
                        {
                            f2.gcMultiRow1.CurrentRow.Cells["txtTax"].Value = "";
                        }
                        else
                        {
                            f2.gcMultiRow1.CurrentRow.Cells["txtTax"].Value = "";
                        }

                    }
                    this.Close();

                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            loadList("[ｱ-ｵ]", 1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            loadList("[ｶ-ｺ]", 1);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            loadList("[サ-ｿ]", 1);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            loadList("[タ-ﾄ]", 1);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            loadList("[ナ-ﾉ]", 1);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            loadList("[ハ-ﾎ]", 1);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            loadList("[マ-ﾓ]", 1);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            loadList("[ヤ-ﾖ]", 1);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            loadList("[ラ-ﾝ]", 1);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            loadList("[ワ-ﾛ]", 1);
        }

        private void btnABC_Click(object sender, EventArgs e)
        {
            loadList("[A-Z]", 1);
        }

        private void btn123_Click(object sender, EventArgs e)
        {
            loadList("[0-9]", 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadlsitbox("N");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadlsitbox("O");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadlsitbox("P");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadlsitbox("Q");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadlsitbox("R");
        }

        private void loadlsitbox(string ext)
        {
            int burinNo = 0;

            switch (ext)
            {
                case "N":
                    burinNo = 11;
                    break;
                case "O":
                    burinNo = 12;
                    break;
                case "P":
                    burinNo = 13;
                    break;
                case "Q":
                    burinNo = 14;
                    break;
                case "R":
                    burinNo = 15;
                    break;
            }




            DABunrui bunrui = new DABunrui();
            DataTable dt = bunrui.getBunruibyColumn(ext, burinNo);

            listBox1.DataSource = null;
            listBox1.DataSource = dt;
            listBox1.DisplayMember = "C";
            listBox1.ValueMember = "B";
            listBox1.Refresh();
        }

    }
}
