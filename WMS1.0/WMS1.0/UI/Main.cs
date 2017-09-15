using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS_V1.UI;

namespace WMS_V1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Odds_Load()
        {
            HBODDSLib.Application objOdds = new HBODDSLib.Application();
            try
            {
                string strPath = objOdds.strCurrentDataPath;

                objOdds.SetCurrentData(strPath);

                General.g_objOdds = objOdds;
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("Message:" + ex.Message + Environment.NewLine + "ErrorCode:&H" + string.Format(ex.ErrorCode.ToString("X")));
                return;
            }

        }

      

        private void Main_Load_1(object sender, EventArgs e)
        {
            Odds_Load();
            this.IsMdiContainer = true;
            Navigation frm = new Navigation();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ナビゲーターToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            Navigation frm = new Navigation();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 受注伝票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            JutyuEntry jutyu = new JutyuEntry();
            jutyu.MdiParent = this;
            jutyu.Show();
        }

        private void 商品台帳ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            Item_Master Item = new Item_Master();
            Item.MdiParent = this;
            Item.Show();
        }

        private void 委託伝票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            SokoEntry Soko = new SokoEntry();
            Soko.MdiParent = this;
            Soko.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            UriageEntry Uriage = new UriageEntry();
            Uriage.MdiParent = this;
            Uriage.Show();
        }

        private void 事業所情報ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CompanyInfo companyinfo = new CompanyInfo();
            companyinfo.MdiParent = this;
            companyinfo.Show();
        }

        private void ユーザー管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            UserManagement user = new UserManagement();
            user.MdiParent = this;
            user.Show();
        }

        private void 開くToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            DataSelect dataselect = new DataSelect();
            dataselect.MdiParent = this;
            dataselect.Show();
        }

        private void 商品価格表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ProductsPriceEntry productsPriceEntry = new ProductsPriceEntry();
            productsPriceEntry.MdiParent = this;
            productsPriceEntry.Show();
        }

        private void 商品リストToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ProductList productlist = new ProductList();
            productlist.MdiParent = this;
            productlist.Show();
        }

        private void 商品元帳ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ProductMototyo productmoto = new ProductMototyo();
            productmoto.MdiParent = this;
            productmoto.Show();

        }

        private void 在庫一覧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            Zaikoichiran zaikoichiran = new Zaikoichiran();
            zaikoichiran.MdiParent = this;
            zaikoichiran.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            Zaikosuii zaikosuii = new Zaikosuii();
            zaikosuii.MdiParent = this;
            zaikosuii.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ItakuPrint itakuprint = new ItakuPrint();
            itakuprint.MdiParent = this;
            itakuprint.Show();
        }

        private void 生産管理表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            SeisanKanri seisankanri = new SeisanKanri();
            seisankanri.MdiParent = this;
            seisankanri.Show();
        }

        private void 入金一括登録ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            NyukinIkkatsu nyuukinnikkatsu = new NyukinIkkatsu();
            nyuukinnikkatsu.MdiParent = this;
            nyuukinnikkatsu.Show();
        }
    }
}
