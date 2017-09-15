using GrapeCity.Win.MultiRow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS_V1.BL;
using WMS_V1.DL;
using WMS_V1.UI;

namespace WMS_V1
{
    public partial class JutyuEntry : Form
    {
        public enum enumShoinName : int
        {
            通常 = 1,
            返品,
            値引,
            諸経費,
            摘要,
            メモ,
            小中計 = 8,
            消費税

        }

        public enum enumTradeDiv : int
        {
            掛売上 = 1,
            現金売上,
            サンプル,
            都度請求
        }
        public JutyuEntry()
        {
            InitializeComponent();
            CustomToolStripRenderer r = new CustomToolStripRenderer();
            r.RoundedEdges = false;
            toolStrip1.Renderer = r;
        }

        void ctrl_LostFocus(object sender, EventArgs e) //this two event for change active control back color
        {
            var ctrl = sender as Control;
            if (ctrl.Tag is Color)
                ctrl.BackColor = (Color)ctrl.Tag;
        }

        void ctrl_GotFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.FromArgb(255, 255, 181);
            toolStripBtnControl(ctrl.Name);
        }

        private void JutyuEntry_Load(object sender, EventArgs e)
        {

            gcMultiRow1.RowsDefaultHeaderCellStyle.SelectionBackColor = Color.FromArgb(176, 245, 212);
            gcMultiRow1.RowsDefaultHeaderCellStyle.SelectionForeColor = Color.Black;
            foreach (Control ctrl in this.panel1.Controls)
            {
                if (ctrl.Name != "gcMultiRow1")
                {
                    ctrl.GotFocus += ctrl_GotFocus;
                    ctrl.LostFocus += ctrl_LostFocus;
                }
            }

            gcMultiRow1.ShortcutKeyManager.Register(new FunctionKeyAction(Keys.Enter), Keys.Enter);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(KeyEvent);
            gcDate1.Value = DateTime.Now;
            txtlblStatus.Text = "新規";

            //axAcroPDF1.LoadFile(@"C:\Users\sakita\Documents\資料.pdf");

        }

        internal void Open()
        {
            throw new NotImplementedException();
        }

        public void clearall()
        {
            //lblUriageID.Text = "";
            //lblDenpyoSerialID.Text = "";
            txtDenpyoBango.Text = "";
            //lblDenpyoBango.Text = "";
            txtUserCode.Text = "";
            txtUserName.Text = "";
            txtTradeDivCode.Text = "";
            txtTradeDivName.Text = "";
            txtTaxImpCode.Text = "";
            txtlTaxImpName.Text = "";

            //textBox7.Text = "";
            textBox10.Text = "";


            txtTantoCode.Text = "";
            txtTantoName.Text = "";

            //txtTokuiAC.Text = "";
            txtPricePercent.Text = "";
            txtUnitsPriceType.Text = "";

            //footer

            AllTotal.Text = "";
            TaxTotal.Text = "";
            AmtTotal.Text = "";
            CostTotal.Text = "";
            AmtCostMinus.Text = "";
            TaxPercent.Text = "";


            gcDate1.Value = DateTime.Now;

            txtlblStatus.Text = "新規";
            txtlblStatus.ForeColor = Color.Blue;


        }

        public void clearGrid()
        {
            gcMultiRow1.Rows.Clear();
            gcMultiRow1.ClearSelection();
        }



        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtPDF.Text = openFileDialog1.FileName;
                //axAcroPDF1.src = openFileDialog1.FileName;
                //axAcroPDF1.LoadFile(openFileDialog1.FileName);

            }

            //if (this.Size == new Size(1622, 22))
            //{
            //    this.Size = new Size(928, 22);
            //}
            //else
            //{
            this.Size = new Size(1622, 22);
            //}


            //showPDF();
        }

        private void showPDF()
        {
            try
            {
                //string filePath = @"C:\Users\thiri\Documents\Visual Studio 2010\Projects\Prime\Prime\Resources\manual.pdf";
                //System.Diagnostics.Process.Start("IExplore.exe", filePath);

                string path = Path.Combine(Directory.GetCurrentDirectory(), "\\Resources\\資料.pdf");
                Process P = new Process

                {
                    StartInfo = { FileName = "AcroRd32.exe", Arguments = path }
                };

                P.Start();

                //string path = Application.StartupPath.ToString() + "\\PDF\\manual.pdf";
                //string adobeReaderPath = @"C:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe";
                //System.Diagnostics.Process.Start("adobeReaderPath.exe", path);
                //System.Diagnostics.Process.Start( path);
                //string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                //System.Diagnostics.Process.Start(appPath + "\\Resources\\manual.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void toolStripBtnControl(string CtrlName)
        {
            switch (CtrlName)
            {
                case "txtUserCode":
                    toolStripLabel5.Enabled = true;
                    break;

                case "txtCode":
                    toolStripLabel5.Enabled = true;
                    break;

                case "txtSokoCode":
                    toolStripLabel5.Enabled = true;
                    break;
                case "txtDenpyoBango":
                    toolStripLabel5.Enabled = true;
                    break;

                default:

                    toolStripLabel5.Enabled = false;
                    break;
            }
        }

        public void GridEvent(Keys keyCode, string Name)
        {
            switch (keyCode)
            {

                case Keys.Enter:

                    HandleEnter(Name);
                    break;


                case Keys.F3:
                    //callRefForm(Name);
                    break;


                default:
                    throw new NotSupportedException();
            }
        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            //this.IsMdiContainer = true;
            //PrintJutyu printjutyu = new PrintJutyu();
            //printjutyu.MdiParent = this;
            //printjutyu.Show();

            PrintJutyu printjutyu = new PrintJutyu();


            Form Frm = Application.OpenForms["printjutyu"];
            if (Frm != null)
                Frm.Close();
            printjutyu.ShowDialog();
        }

        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) //setting
            {
                //toolStripButton2_Click(sender, e);

            }
            else if (e.KeyCode == Keys.F2) //setting
            {
                //tSPNew_Click(sender, e);

            }

            else if (e.KeyCode == Keys.F5) //print
            {
                //tspPrint_Click(sender, e);

            }
            else if (e.KeyCode == Keys.F6) //serch
            {
                //tspDenpyoSearch_Click(sender, e);
            }

            else if (e.KeyCode == Keys.F8) //ref
            {
                toolStripLabel5_Click(sender, e);

            }

            else if (e.KeyCode == Keys.F9) //delete
            {
                //stpDelete_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F12) //save
            {
                //tspSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)//escp
            {
                //toolStripButton6_Click_1(sender, e);
            }
        }


        private void HandleEnter(string gridName)
        {
            GcMultiRow grid = (GcMultiRow)this.Controls.Find(gridName, true).FirstOrDefault();
            // grid.CurrentCell.Value = grid.CurrentCell.EditedFormattedValue;
            //grid.EndEdit();
            //switch (grid.CurrentCell.Name)
            //{

            //    case "txtShoinCode":


            //        string val = BLDenpyoEntry.getshoinName(grid.CurrentCell.EditedFormattedValue.ToString());
            //        if (val != "")
            //        {



            //            if (grid.CurrentCell.EditedFormattedValue.ToString() == "5" || grid.CurrentCell.EditedFormattedValue.ToString() == "6" || grid.CurrentCell.EditedFormattedValue.ToString() == "3")
            //            {
            //                DenpyoUISupport UI = new DenpyoUISupport();
            //                UI.clearGridOneRow(grid);
            //            }
            //            if (grid.CurrentCell.EditedFormattedValue.ToString() == "2")
            //            {
            //                if (gcMultiRow1.CurrentRow.Cells["txtUnitsPrice"].Value != null)
            //                {
            //                    if (!gcMultiRow1.CurrentRow.Cells["txtUnitsPrice"].Value.ToString().Equals("") && !gcMultiRow1.CurrentRow.Cells["txtQty"].EditedFormattedValue.ToString().Equals(""))
            //                    {
            //                        gcMultiRow1.CurrentRow.Cells["txtQty"].Value = Convert.ToDecimal(gcMultiRow1.CurrentRow.Cells["txtQty"].Value) * (-1);
            //                        qty_amtMultiply();
            //                        taxTotalCalc(Convert.ToInt32(txtTaxImpCode.Text));

            //                        DenpyoUISupport.changeMinusColor(gcMultiRow1, gcMultiRow1.CurrentRow.Index);



            //                    }
            //                }
            //            }
            //            if (grid.CurrentCell.EditedFormattedValue.ToString() == "1")
            //            {
            //                if (gcMultiRow1.CurrentRow.Cells["txtUnitsPrice"].Value != null)
            //                {
            //                    if (!gcMultiRow1.CurrentRow.Cells["txtUnitsPrice"].Value.ToString().Equals("") && !gcMultiRow1.CurrentRow.Cells["txtQty"].EditedFormattedValue.ToString().Equals(""))
            //                    {
            //                        if (Convert.ToDecimal(gcMultiRow1.CurrentRow.Cells["txtQty"].Value) < 0)
            //                        {
            //                            gcMultiRow1.CurrentRow.Cells["txtQty"].Value = Convert.ToDecimal(gcMultiRow1.CurrentRow.Cells["txtQty"].Value) * (-1);
            //                        }
            //                        qty_amtMultiply();
            //                        taxTotalCalc(Convert.ToInt32(txtTaxImpCode.Text));

            //                        DenpyoUISupport.changeMinusColor(gcMultiRow1, gcMultiRow1.CurrentRow.Index);



            //                    }
            //                }
            //            }
            //            grid.CurrentRow.Cells["txtShoinName"].Value = val;

            //            SendKeys.Send("{Tab}");
            //        }
            //        else
            //        {
            //            grid.CurrentCell.Value = null;

            //            grid.CurrentRow.Cells["txtShoinName"].Value = "";
            //        }
            //        break;

            //    case "txtCode":

            //        if (grid.CurrentRow.Cells["txtShoinCode"].DisplayText == "5" || grid.CurrentRow.Cells["txtShoinCode"].DisplayText == "6")
            //        {

            //            grid.CurrentCell = grid.CurrentRow.Cells["txtName"];
            //        }
            //        else
            //        {

            //            if (grid.CurrentRow.Cells["txtCode"].Value != "" || grid.CurrentRow.Cells["txtCode"].Value != null)
            //            {
            //                if (fillShoindiacho(grid.CurrentRow.Cells["txtCode"].Value.ToString()))
            //                {
            //                    SendKeys.Send("{Tab}");
            //                }

            //            }
            //        }

            //        break;


            //    case "txtName":

            //        if (grid.CurrentRow.Cells["txtShoinCode"].DisplayText == "5" || grid.CurrentRow.Cells["txtShoinCode"].DisplayText == "6")
            //        {


            //            if (grid.CurrentRow.Cells["txtShoinCode"].DisplayText == "6")
            //            {
            //                grid.CurrentRow.Cells["txtName"].Style.ForeColor = Color.Blue;
            //            }
            //            else
            //            {
            //                grid.CurrentRow.Cells["txtName"].Style.ForeColor = Color.Black;
            //            }



            //            grid.CurrentCell = grid.Rows[grid.CurrentRow.Index + 1].Cells["txtShoinCode"];
            //        }


            //        break;


            //    case "txtSokoCode":


            //        if (grid.CurrentRow.Cells["txtShoinCode"].DisplayText == "2" || grid.CurrentRow.Cells["txtShoinCode"].DisplayText == "3")
            //        {
            //            grid.CurrentRow.Cells["txtQty"].Value = "-";
            //            SendKeys.Send("{Tab}");
            //        }
            //        else
            //        {
            //            SendKeys.Send("{Tab}");
            //        }





            //        break;
            //    case "txtQty":

            //        if (gcMultiRow1.CurrentRow.Cells["txtUnitsPrice"].Value != null)
            //        {
            //            if (!gcMultiRow1.CurrentRow.Cells["txtUnitsPrice"].Value.ToString().Equals("") && !gcMultiRow1.CurrentRow.Cells["txtQty"].EditedFormattedValue.ToString().Equals(""))
            //            {

            //                qty_amtMultiply();
            //                taxTotalCalc(Convert.ToInt32(txtTaxImpCode.Text));

            //                DenpyoUISupport.changeMinusColor(gcMultiRow1, gcMultiRow1.CurrentRow.Index);



            //            }
            //        }


            //        SendKeys.Send("{Tab}");

            //        break;

            //    case "txtCost":

            //        DenpyoUISupport.changeMinusColor(gcMultiRow1, gcMultiRow1.CurrentRow.Index);
            //        SendKeys.Send("{Tab}");
            //        break;

            //    case "txtUnitsPrice":

            //        if (!gcMultiRow1.CurrentRow.Cells["txtUnitsPrice"].Value.ToString().Equals("") && !gcMultiRow1.CurrentRow.Cells["txtQty"].EditedFormattedValue.ToString().Equals(""))
            //        {

            //            qty_amtMultiply();
            //            taxTotalCalc(Convert.ToInt32(txtTaxImpCode.Text));
            //            DenpyoUISupport.changeMinusColor(gcMultiRow1, gcMultiRow1.CurrentRow.Index);
            //            SendKeys.Send("{Tab}");

            //        }
            //        break;


            //    case "txtAmount":

            //        DenpyoUISupport.changeMinusColor(gcMultiRow1, gcMultiRow1.CurrentRow.Index);
            //        if (!Enumerable.Range(5, 6).Contains(Convert.ToInt32(grid.CurrentRow.Cells["txtShoinCode"].Value)))
            //        {
            //            gcMultiRow1.CurrentRow.Cells["txtTax"].Value = "課税  8.0 %";
            //        }
            //        SendKeys.Send("{Tab}");
            //        break;


            //    case "txtRemark":

            //        SendKeys.Send("{Tab}");
            //        break;


            //}

        }


        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            if (txtUserCode.Focused)
            {
                TokuiSearch toki = new TokuiSearch();

                toki.ShowDialog();
            }
            //else if (txtTantoCode.Focused)
            //{
            //    TantouSearch tanto = new TantouSearch();
            //    tanto.ShowDialog();

                //}
            else if (txtDenpyoBango.Focused)
            {
                DenpyoList list = new DenpyoList();
                list.ShowDialog();

            }

            else if (this.ActiveControl.GetType().Namespace == "GrapeCity.Win.MultiRow")
            {
                if (gcMultiRow1.CurrentCell.Name == "txtCode")
                {
                    ShohinSearch shoinsearch = new ShohinSearch();
                    shoinsearch.CustomerCode = txtUserCode.Text.Trim();
                    shoinsearch.ShowDialog();
                }
                else if (gcMultiRow1.CurrentCell.Name == "txtSokoCode")
                {
                    //SokoSearch sokosearch = new SokoSearch();
                    //sokosearch.ShowDialog();
                }
            }

        }



        #region FillMethod

        public void fillTokuisaki(string code, string Name)
        {
            tokuiClear();
            try
            {
                txtUserCode.Text = code;
                txtUserName.Text = Name;
                DATokui tokui = new DATokui();
                DataTable dt = tokui.getTokuibyCode(code.Trim());


                txtTradeDivCode.Text = dt.Rows[0]["Z"] == null ? "" : dt.Rows[0]["Z"].ToString();
                txtTradeDivName.Text = dt.Rows[0]["Z"] == null ? "" : Convert.ToString((enumTradeDiv)Convert.ToInt32(dt.Rows[0]["Z"]));


                txtTaxImpCode.Text = dt.Rows[0]["AE"] == null ? "" : dt.Rows[0]["AE"].ToString();  //tax
                txtlTaxImpName.Text = dt.Rows[0]["AE"] == null ? "" : BLJutyu.convertTaxname((Convert.ToInt32(dt.Rows[0]["AE"])));


                DATantosha tantosha = new DATantosha();
                DataTable dtTanto = tantosha.getTantoshabyCode(dt.Rows[0]["AN"].ToString());

                if (dtTanto != null)
                {
                    txtTantoCode.Text = dtTanto.Rows[0]["B"].ToString();
                    txtTantoName.Text = dtTanto.Rows[0]["C"].ToString();
                }

                //lblTaxRound.Text = dt.Rows[0]["AL"].ToString();
                //lblAmountRound.Text = dt.Rows[0]["AM"].ToString();

                //txtTokuiAC
                DataTable dt2 = tokui.getTokuibyCode(dt.Rows[0]["AC"].ToString());

                //if (dt2 != null)
                //{
                //    txtTokuiAC.Text = dt2.Rows[0]["C"].ToString();
                //}

                txtUnitsPriceType.Text = ((WMS_V1.BL.BLJutyu.enumTokuiPriceType)Convert.ToInt32(dt.Rows[0]["AA"])).ToString();
                txtPricePercent.Text = Convert.ToInt32(dt.Rows[0]["AA"]).ToString() + " %";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        #endregion


        public void tokuiClear()
        {
            txtUserCode.Text = "";
            txtUserName.Text = "";



            txtTradeDivCode.Text = "";
            txtTradeDivName.Text = "";


            txtTaxImpCode.Text = "";  //tax
            txtlTaxImpName.Text = "";

            txtTantoCode.Text = "";
            txtTantoName.Text = "";


            //lblTaxRound.Text = "";
            //lblAmountRound.Text = "";

            //txtTokuiAC.Text = "";

        }

        public void callShoindiacho(string code)
        {
            gcMultiRow1.CurrentRow.Cells["txtCode"].Value = code;
            SendKeys.Send("{ENTER}");
            gcMultiRow1.Focus();
        }

        public void showLable(decimal Amttotal, decimal taxTotal, decimal costTotal, int taxName)
        {
            if (Amttotal == 0 && taxTotal == 0 && costTotal == 0)
            {
                taxName = 99;

            }



            switch (taxName)
            {

                case 1:
                    AmtTotal.Text = Amttotal.ToString("#,###");
                    TaxTotal.Text = taxTotal.ToString("#,###");
                    AmtCostMinus.Text = Convert.ToDecimal(Amttotal - costTotal).ToString("#,###");
                    CostTotal.Text = costTotal.ToString("#,###");
                    AllTotal.Text = Convert.ToDecimal(Amttotal + taxTotal).ToString("#,###");

                    if (Amttotal != 0)
                        TaxPercent.Text = ((Amttotal - costTotal) / Amttotal) * 100 <= 0 ? "%" : Math.Round(((Amttotal - costTotal) / Amttotal) * 100, 1, MidpointRounding.AwayFromZero).ToString() + " %";
                    break;


                case 2:
                    AmtTotal.Text = Amttotal.ToString("#,###");
                    TaxTotal.Text = "";
                    AmtCostMinus.Text = Convert.ToDecimal(Amttotal - costTotal).ToString("#,###");
                    CostTotal.Text = costTotal.ToString("#,###");
                    AllTotal.Text = Convert.ToDecimal(Amttotal + taxTotal).ToString("#,###");

                    if (Amttotal != 0)
                        TaxPercent.Text = ((Amttotal - costTotal) / Amttotal) * 100 <= 0 ? "%" : Math.Round(((Amttotal - costTotal) / Amttotal) * 100, 1, MidpointRounding.AwayFromZero).ToString() + " %";
                    break;

                case 4://no

                    AmtTotal.Text = Amttotal.ToString("#,###");
                    TaxTotal.Text = "0";
                    AmtCostMinus.Text = Convert.ToDecimal(Amttotal - costTotal).ToString("#,###");
                    CostTotal.Text = costTotal.ToString("#,###");
                    AllTotal.Text = Convert.ToDecimal(Amttotal).ToString("#,###");

                    if (Amttotal != 0)
                        TaxPercent.Text = ((Amttotal - costTotal) / Amttotal) * 100 <= 0 ? "%" : Math.Round(((Amttotal - costTotal) / Amttotal) * 100, 1, MidpointRounding.AwayFromZero).ToString() + " %";
                    break;

                case 5://uchi

                    AmtTotal.Text = (Amttotal - taxTotal).ToString("#,###");
                    TaxTotal.Text = taxTotal.ToString("#,###");
                    AmtCostMinus.Text = Convert.ToDecimal((Amttotal - taxTotal) - costTotal).ToString("#,###");
                    CostTotal.Text = costTotal.ToString("#,###");
                    AllTotal.Text = Convert.ToDecimal(Amttotal).ToString("#,###");

                    if (Amttotal != 0)
                        TaxPercent.Text = (((Amttotal - taxTotal) - costTotal) / (Amttotal - taxTotal)) * 100 <= 0 ? "%" : Math.Round((((Amttotal - taxTotal) - costTotal) / (Amttotal - taxTotal)) * 100, 1, MidpointRounding.AwayFromZero).ToString() + " %";
                    break;

                case 99://free line

                    AmtTotal.Text = "0";
                    TaxTotal.Text = "0";
                    AmtCostMinus.Text = "";
                    CostTotal.Text = "";
                    AllTotal.Text = "0";

                    TaxPercent.Text = "%";
                    break;

            }



            AmtTotal.ForeColor = DenpyoUISupport.checkColor(Amttotal);
            TaxTotal.ForeColor = DenpyoUISupport.checkColor(taxTotal);

            if (!AmtCostMinus.Text.Equals(""))
            {
                AmtCostMinus.ForeColor = DenpyoUISupport.checkColor(Convert.ToDecimal(AmtCostMinus.Text));
            }

            CostTotal.ForeColor = DenpyoUISupport.checkColor(costTotal);

            if (!AllTotal.Text.Equals(""))
            {
                AllTotal.ForeColor = DenpyoUISupport.checkColor(Convert.ToDecimal(AllTotal.Text));
            }




        }

    }
}
