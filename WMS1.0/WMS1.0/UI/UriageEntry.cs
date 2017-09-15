using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS_V1.BL;
using GrapeCity.Win.MultiRow;
using WMS_V1.UI;
using OkhenTest.UI;

namespace WMS_V1
{
   
    public partial class UriageEntry : Form
    {

        const int _frmID = 1;
        public UriageEntry()
        {
            InitializeComponent();
        }


        void ctrl_LostFocus(object sender, EventArgs e) //this two event for change active control back color
        {
            var ctrl = sender as Control;
            if (ctrl.Tag is Color)
                ctrl.BackColor = (Color)ctrl.Tag;//color change //this is also change 
        }

        void ctrl_GotFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.FromArgb(255, 255, 181);
            toolStripBtnControl(ctrl.Name);
        }

        private void textbox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Yellow;
        }

        private void textbox1_LostFocus(object sender, EventArgs e)
        {
            textBox1.BackColor = SystemColors.Control;
        }

        private void UriageEntry_Load(object sender, EventArgs e)
        {
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





 
              // オブジェクトの生成
            HBODDSLib.Application objOdds = new HBODDSLib.Application();
           
            string strPath;

            try
            {

                 strPath = objOdds.strCurrentDataPath;
              
                objOdds.SetCurrentData(strPath);
        
               

               

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("Message:" + ex.Message + Environment.NewLine + "ErrorCode:&H" + string.Format(ex.ErrorCode.ToString("X")));
                return;
            }

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


        private void HandleEnter(string gridName)
        {
            GcMultiRow grid = (GcMultiRow)this.Controls.Find(gridName, true).FirstOrDefault();
             grid.CurrentCell.Value = grid.CurrentCell.EditedFormattedValue;
            grid.EndEdit();
            switch (grid.CurrentCell.Name)
            {
                case "txtShoinCode":
                    break;
            }
        }

        private void toolStripBtnControl(string CtrlName)
        {
            switch (CtrlName)
            {
                case "txtUserCode":
                  //  toolStripLabel5.Enabled = true;
                    break;

                case "txtCode":
                 
                    break;

                case "txtSokoCode":
                  
                    break;
                case "txtDenpyoBango":
                  
                    break;

                default:

                 
                    break;
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//search
        {
            TokuiSearch _tokui = new TokuiSearch();
            _tokui.Show();

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (txtTokuiCode.Focused)
            {
                TokuiSearch _tokui = new TokuiSearch();
                _tokui.FormId = _frmID;
                _tokui.MdiParent = this.MdiParent;
                _tokui.Show();
            }
            else if (txtTantoshaCode.Focused)
            {
                TantoshaSearch _tantosah = new TantoshaSearch();
                _tantosah.FormId = _frmID;
                _tantosah.MdiParent = this.MdiParent;
                _tantosah.Show();
            }
        }


        public void fillTokuisaki(string code, string name)
        {
            txtTokuiCode.Text = code;
            txtTokuiName.Text = name;
        }

        public void fillTantosha(string code, string name)
        {
            txtTantoshaCode.Text = code;
            txtTantoShaName.Text = name;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

        }
    }
}
