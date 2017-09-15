using GrapeCity.Win.MultiRow;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using WMS_V1.DL;

namespace WMS_V1.BL
{
    public class BLJutyu
    {
        public enum enumTokuiPriceType : int
        {
            上代 = 1,
            売上単価１,
            売上単価２,
            売上単価３,
            売上単価４,
            売上原価

        }
        public static string convertTaxname(int val)
        {
            string ret = "";
            switch (val)
            {


                case 1:

                    ret = "外税/伝票計";//all soto
                    break;
                case 2:

                    ret = "外税/請求時";//soto
                    break;
                case 3:

                    //  ret = "内税";
                    break;

                case 4:

                    ret = "輸出(免税)";//no tax
                    break;
                case 5:

                    ret = "内税/総額";//uchi
                    break;
                case 6:

                    // ret = "内税/請求時";
                    break;
                case 7:

                    //  ret = "外税/請求時調整";
                    break;

                case 9:

                    //  ret = "外税/手入力";
                    break;

            }

            return ret;
        }


        public void fillDenpyo(long denpyoID)
        {

            DAUriageDenpyo da = new DAUriageDenpyo();
            DataTable dt = da.getUriagedenpyo(denpyoID);


            JutyuEntry f2 = new JutyuEntry();
        

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
                    f2.txtUnitsPriceType.Text = ((enumTokuiPriceType)Convert.ToInt32(dt2.Rows[0]["AA"])).ToString();
                    f2.txtPricePercent.Text = Convert.ToInt32(dt2.Rows[0]["AB"]).ToString() + " %";
                }


                f2.txtTradeDivCode.Text = dt.Rows[0]["E"].ToString();  //tradecode
                f2.txtTradeDivName.Text = Convert.ToString((WMS_V1.JutyuEntry.enumTradeDiv)Convert.ToInt32(dt.Rows[0]["E"]));


                f2.txtTaxImpCode.Text = dt.Rows[0]["L"].ToString();//taxcode
                f2.txtlTaxImpName.Text = convertTaxname(Convert.ToInt32(dt.Rows[0]["L"]));//taxname


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



    }

        public class DenpyoUISupport
        {
            public static void changeMinusColor(GcMultiRow grid, int currentIndex)
            {

                if (!grid.Rows[currentIndex].Cells["txtQty"].DisplayText.Equals(""))
                {
                    try
                    {
                        if (Convert.ToDecimal(grid.Rows[currentIndex].Cells["txtQty"].Value) < 0)
                        {
                            grid.Rows[currentIndex].Cells["txtQty"].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            grid.Rows[currentIndex].Cells["txtQty"].Style.ForeColor = Color.Black;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }

                if (!grid.Rows[currentIndex].Cells["txtCost"].DisplayText.Equals(""))
                {
                    try
                    {
                        if (Convert.ToDecimal(grid.Rows[currentIndex].Cells["txtCost"].Value) < 0)
                        {
                            grid.Rows[currentIndex].Cells["txtCost"].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            grid.Rows[currentIndex].Cells["txtCost"].Style.ForeColor = Color.Black;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }


                if (!grid.Rows[currentIndex].Cells["txtUnitsPrice"].DisplayText.Equals(""))
                {
                    try
                    {
                        if (Convert.ToDecimal(grid.Rows[currentIndex].Cells["txtUnitsPrice"].Value) < 0)
                        {
                            grid.Rows[currentIndex].Cells["txtUnitsPrice"].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            grid.Rows[currentIndex].Cells["txtUnitsPrice"].Style.ForeColor = Color.Black;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }



                if (!grid.Rows[currentIndex].Cells["txtAmount"].DisplayText.Equals(""))
                {
                    try
                    {
                        if (Convert.ToDecimal(grid.Rows[currentIndex].Cells["txtAmount"].Value) < 0)
                        {
                            grid.Rows[currentIndex].Cells["txtAmount"].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            grid.Rows[currentIndex].Cells["txtAmount"].Style.ForeColor = Color.Black;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }

            }



            public static Color checkColor(decimal amt)
            {
                if (amt >= 0)

                    return Color.Black;
                else
                    return Color.Red;

            }



            public void clearGridOneRow(GcMultiRow grid)
            {
                for (int i = 2; i < 18; i++)
                {
                    grid.CurrentRow.Cells[i].Value = null;
                }
            }
        }
    }


    

