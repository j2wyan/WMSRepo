using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS_V1.UI;

namespace WMS_V1
{
    public partial class Item_Master : Form
    {
        public string txtyCode { get; set; }
        public string code;
        public Item_Master()
        {
            InitializeComponent();
           
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (this.Size == new Size(1360, 575))
            {
                this.Size = new Size(820, 575);
            }
            else
            {
                this.Size = new Size(1360, 575);
            }

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            
        }


        public void LoadItem()
        {
            DataTable dt = LoadItemData(code);
            if(dt.Rows.Count > 0)
            {
                //string YCode = dt.Rows[0]["B"].ToString();
                txtYCode.Text = dt.Rows[0]["B"].ToString();
                txtyName.Text = dt.Rows[0]["C"].ToString();
                txtyFurigame.Text = dt.Rows[0]["D"].ToString();
                txtE.Text = dt.Rows[0]["E"].ToString();
                txtL.Text = dt.Rows[0]["L"].ToString();
                txtM.Text = dt.Rows[0]["M"].ToString();
                
              


                string H = dt.Rows[0]["H"].ToString();

                if (H == "1")
                {
                    txtH.Text = "課税";
                }
                else if (H == "2")
                {
                    txtH.Text = "課税(自)";
                }
                else if (H == "3")
                {
                    txtH.Text = "";
                }
                else
                {
                    txtH.Text = "";
                }



                txtN.Text = dt.Rows[0]["N"].ToString();

                txtO.Text = dt.Rows[0]["O"].ToString();
                txtP.Text = dt.Rows[0]["P"].ToString();
                txtQ.Text = dt.Rows[0]["Q"].ToString();
                txtR.Text = dt.Rows[0]["R"].ToString();
                txtY.Text = dt.Rows[0]["Y"].ToString();
                txtI.Text = dt.Rows[0]["I"].ToString();
                txtW.Text = dt.Rows[0]["W"].ToString();
                txtX.Text = dt.Rows[0]["X"].ToString();
                txtS.Text = dt.Rows[0]["S"].ToString();



                txtZ.Text = dt.Rows[0]["Z"].ToString();
                txtAA.Text = dt.Rows[0]["AA"].ToString();
                txtAB.Text = dt.Rows[0]["AB"].ToString();
                txtAC.Text = dt.Rows[0]["AC"].ToString();
                txtAD.Text = dt.Rows[0]["AD"].ToString();
                txtAE.Text = dt.Rows[0]["AE"].ToString();
                txtAF.Text = dt.Rows[0]["AF"].ToString();
                txtAG.Text = dt.Rows[0]["AG"].ToString();
                txtAH.Text = dt.Rows[0]["AH"].ToString();
                txtAI.Text = dt.Rows[0]["AI"].ToString();
            }
        }



        public DataTable LoadItemData(string itemID)
        {
            DataTable dt = null;
            SqlConnection con = new SqlConnection(General.getCon1());

            try
            {
                con.Open();
                
                string selectQuery = "Select B ,C , D , E, F,  L , M , H , N , O , P, Q , R ,Y, I , W , X , V , S , Z , AA , AB , AC , AD , AE , AF , AG , AH , AI From SHOHINDAICHO where B = '" + itemID + "'  Order by B ";

                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, con);
                DataSet ds = new DataSet();

                adapter.Fill(ds, "ItemList");
                dt = ds.Tables[0];
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }

            return dt;
        }

     

        private void Item_Master_Load(object sender, EventArgs e)
        {
            LoadItem();

        }
       
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //if (!Application.OpenForms.OfType<Item_DetailList>().Any())
            //{
            //    Item_DetailList Itemlist = new Item_DetailList();
            //    Itemlist.MdiParent = this.MdiParent;
            //    Itemlist.Show();
            //}
          
            if(!Application.OpenForms.OfType<ShohinSearch>().Any())
            {
                ShohinSearch search = new ShohinSearch();
                search.MdiParent = this.MdiParent;
                search.itemform = "ItemForm";
                search.Show();
              
                
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
