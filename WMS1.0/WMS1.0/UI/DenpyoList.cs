using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS_V1.BL;
using WMS_V1.DL;
//using  WMS_V1.BL.BLJutyu;

namespace WMS_V1.UI
{
    public partial class DenpyoList : Form
    {
        DAUriageDenpyo DA = new DAUriageDenpyo();
        public DenpyoList()
        {
            InitializeComponent();
        }

        private void DenpyoList_Load(object sender, EventArgs e)
        {
            DataTable dt = DA.getUriagedenpyobyRowCount("order by A desc");
            loadList(dt);

            ListViewItem item = listView1.Items[0];
            label1.Text = item.SubItems[6].Text;

            btnNext.Enabled = true;
            btnBack.Enabled = false;
        }

        private void loadList(DataTable dt)
        {
            listView1.Items.Clear();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {


                    if (dt != null)
                    {

                        foreach (DataRow dr in dt.Rows)
                        {
                            ListViewItem item = new ListViewItem(Convert.ToDateTime(dr["C"]).ToString("yyyy/MM/dd"));
                            item.SubItems.Add(Convert.ToInt64(dr["D"]).ToString("00000000"));
                            item.SubItems.Add(dr["F"].ToString());
                            item.SubItems.Add(dr["G"].ToString());
                            if (Convert.ToDecimal(dr["O"]) == 0)
                            {
                                item.SubItems.Add(dr["O"].ToString());
                            }
                            else
                            {
                                item.SubItems.Add(Convert.ToDecimal(dr["O"]).ToString("#,###"));
                            }
                            item.SubItems.Add(dr["T"].ToString());
                            item.SubItems.Add(dr["A"].ToString());
                            listView1.Items.Add(item);

                        }

                        // this.listView1.Scrollable = false;
                        //  ShowScrollBar(this.listView1.Handle, (int)SB_VERT, true);
                        listView1.Refresh();
                    }

                    listView1.Focus();



                }

            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            JutyuEntry f2 = Application.OpenForms["JutyuEntry"] as JutyuEntry;
            if (f2 != null && listView1.SelectedItems.Count > 0)
            {

                ListViewItem item = listView1.SelectedItems[0];
                BLJutyu bl = new BLJutyu();


                //bl.fillDenpyo(Convert.ToInt64(item.SubItems[6].Text));
                fillDenpyo(Convert.ToInt64(item.SubItems[6].Text));

                this.Close();


            }
        }


        public void fillDenpyo(long denpyoID)
        {

            DAUriageDenpyo da = new DAUriageDenpyo();
            DataTable dt = da.getUriagedenpyo(denpyoID);


            JutyuEntry f2 = Application.OpenForms["JutyuEntry"] as JutyuEntry;


            if (f2 != null && dt.Rows.Count > 0)
            {
                f2.clearall();
                f2.clearGrid();


                //f2.lblStatus.Text = "修正";
                //f2.lblStatus.ForeColor = Color.Red;


                f2.gcDate1.Value = Convert.ToDateTime(dt.Rows[0]["C"]);//date

                //f2.lblUriageID.Text = denpyoID.ToString();
                //f2.lblDenpyoSerialID.Text = dt.Rows[0]["A"].ToString();//SerialID

                f2.txtDenpyoBango.Text = Convert.ToInt64(dt.Rows[0]["D"]).ToString("00000000");//bango
                f2.txtDenpyoBango.Text = Convert.ToInt64(dt.Rows[0]["D"]).ToString("00000000");//bango


                f2.txtUserCode.Text = dt.Rows[0]["F"].ToString();//customer code
                f2.txtUserName.Text = dt.Rows[0]["G"].ToString();//customer name
                //tokuisaki AC is H in uriagedenpyo
                DATokui tokui = new DATokui();
                DataTable dt2 = tokui.getTokuibyCode(dt.Rows[0]["H"].ToString());

                if (dt2 != null)
                {
                    //f2.txtTokuiAC.Text = dt2.Rows[0]["C"].ToString();
                    //f2.txtUnitsPriceType.Text = ((enumTokuiPriceType)Convert.ToInt32(dt2.Rows[0]["AA"])).ToString();
                    //f2.txtPricePercent.Text = Convert.ToInt32(dt2.Rows[0]["AB"]).ToString() + " %";
                }


                f2.txtTradeDivCode.Text = dt.Rows[0]["E"].ToString();  //tradecode
                f2.txtTradeDivName.Text = Convert.ToString((WMS_V1.JutyuEntry.enumTradeDiv)Convert.ToInt32(dt.Rows[0]["E"]));


                f2.txtTaxImpCode.Text = dt.Rows[0]["L"].ToString();//taxcode
              //  f2.txtlTaxImpName.Text = convertTaxname(Convert.ToInt32(dt.Rows[0]["L"]));//taxname


                //f2.lblTaxRound.Text = dt.Rows[0]["M"].ToString();// taxround
                //f2.lblAmountRound.Text = dt.Rows[0]["N"].ToString();//amountround



                //Uriage J is tantoCode
                DATantosha tantosha = new DATantosha();
                DataTable dtTanto = tantosha.getTantoshabyCode(dt.Rows[0]["J"].ToString());

                if (dtTanto != null)
                {
                    f2.txtTantoCode.Text = dtTanto.Rows[0]["B"].ToString();
                    f2.txtTantoName.Text = dtTanto.Rows[0]["C"].ToString();
                }



                //fillGridView

                decimal totalCost = 0;

                DADenpyomeisai meisai = new DADenpyomeisai();
                DataTable dtmeisai = meisai.getdempyoMeisaibyC(denpyoID);

                f2.gcMultiRow1.Rows.Clear();
                if (dtmeisai.Rows.Count > 0)
                {

                    for (int i = 0; i < dtmeisai.Rows.Count; i++)
                    {
                        f2.gcMultiRow1.Rows.Add();

                         f2.txtSokoCode.Text = dtmeisai.Rows[i]["O"].ToString();
                        

                         f2.txtSokoName.Text = dtmeisai.Rows[i]["SOKONAME"].ToString();



                        f2.gcMultiRow1.Rows[i].Cells["txtCode"].Value = dtmeisai.Rows[i]["N"].ToString();

                        if (Convert.ToInt32(dtmeisai.Rows[i]["L"]).Equals(6))
                        {
                            f2.gcMultiRow1.Rows[i].Cells["txtName"].Style.ForeColor = Color.Blue;
                        }
                        else
                        {
                            f2.gcMultiRow1.Rows[i].Cells["txtName"].Style.ForeColor = Color.Black;
                        }


                        f2.gcMultiRow1.Rows[i].Cells["txtName"].Value = dtmeisai.Rows[i]["P"].ToString();
                        f2.gcMultiRow1.Rows[i].Cells["txtShoinDiachoF"].Value = dtmeisai.Rows[i]["X"].ToString();//unitsName


                        f2.gcMultiRow1.Rows[i].Cells["txtUnitsPrice"].Value = Convert.ToDecimal(dtmeisai.Rows[i]["Y"]) == 0 ? "" : Convert.ToDecimal(dtmeisai.Rows[i]["Y"]).ToString("#,###");


                        if (dtmeisai.Rows[i]["Z"].ToString().Contains("."))
                        {
                            f2.gcMultiRow1.Rows[i].Cells["txtCost"].Value = Convert.ToDecimal(dtmeisai.Rows[i]["Z"]) == 0 ? "" : Convert.ToDecimal(dtmeisai.Rows[i]["Z"]).ToString("#,###.##");
                        }
                        else
                        {
                            f2.gcMultiRow1.Rows[i].Cells["txtCost"].Value = Convert.ToDecimal(dtmeisai.Rows[i]["Z"]) == 0 ? "" : Convert.ToDecimal(dtmeisai.Rows[i]["Z"]).ToString("#,###");
                        }



                        f2.gcMultiRow1.Rows[i].Cells["txtQty"].Value = Convert.ToDecimal(dtmeisai.Rows[i]["W"]) == 0 ? "" : dtmeisai.Rows[i]["W"].ToString();


                        f2.gcMultiRow1.Rows[i].Cells["txtAmount"].Value = Convert.ToDecimal(dtmeisai.Rows[i]["AA"]) == 0 ? "" : Convert.ToDecimal(dtmeisai.Rows[i]["AA"]).ToString("#,###");// to ask AF cloumn

                        f2.gcMultiRow1.Rows[i].Cells["txtShoinCode"].Value = dtmeisai.Rows[i]["L"].ToString();

                        f2.gcMultiRow1.Rows[i].Cells["txtShoinName"].Value = ((WMS_V1.JutyuEntry.enumShoinName)Convert.ToInt32(dtmeisai.Rows[i]["L"])).ToString();

                        f2.gcMultiRow1.Rows[i].Cells["txtRemark"].Value = dtmeisai.Rows[i]["AC"].ToString();

                        //f2.gcMultiRow1.Rows[i].Cells["txtSokoCode"].Value = dtmeisai.Rows[i]["O"].ToString();


                        //find sokoName

                        //f2.gcMultiRow1.Rows[i].Cells["txtSokoName"].Value = dtmeisai.Rows[i]["SOKONAME"].ToString();

                        //totalcost

                        totalCost += Convert.ToDecimal(dtmeisai.Rows[i]["AE"]);


                        DenpyoUISupport.changeMinusColor(f2.gcMultiRow1, i);

                        //tax name show is fixed
                        if (!Enumerable.Range(5, 6).Contains(Convert.ToInt32(dtmeisai.Rows[i]["L"])))
                        {
                            f2.gcMultiRow1.Rows[i].Cells["txtTax"].Value = "課税  8.0 %";
                        }

                    }
                }




                //footer

                f2.showLable(Convert.ToDecimal(dt.Rows[0]["P"]), Convert.ToDecimal(dt.Rows[0]["Q"]), totalCost, Convert.ToInt32(dt.Rows[0]["L"]));

            }


        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listView1_DoubleClick(sender, e);
            }
        }
    }
}
