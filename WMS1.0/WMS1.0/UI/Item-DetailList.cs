using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS_V1.UI
{
    public partial class Item_DetailList : Form
    {
        public Item_DetailList()
        {
            InitializeComponent();
        }

        private void Item_DetailList_Load(object sender, EventArgs e)
        {
            LoadItemList();
        }

        private void LoadItemList()
        {
            DataTable dt = LoadItemData();

            if (dt.Rows.Count > 0)
            {

                //DataTable dtClone = dt.Clone();
                //for (int i = 0; i < dtClone.Columns.Count; i++)
                //{
                //    if (dtClone.Columns["AP"].DataType != typeof(string))
                //        dtClone.Columns["AP"].DataType = typeof(string);
                //}



                //foreach (DataRow dr in dt.Rows)
                //{

                    //    string AP = Convert.ToString(dr["AP"]);

                    //    if (AP == "1")
                    //    {

                    //        dr["AP"] = "商品2";
                    //    }
                    //    //else if (AP == "2")
                    //    {
                    //        dr[2] = "商品2";
                    //    }
                    //else
                    //{
                    //        dr[2] = "商品3";
                    //    }
                    //}
                    
                    gcMultiRow1.DataSource = dt;

                //}
            }
        }
        


        public DataTable LoadItemData()
        {
            DataTable dt = null;
            SqlConnection con = new SqlConnection(General.getCon1());

            try
            {
                con.Open();

                string selectQuery = "Select B ,C , AP , D , L , M , H , N , O , P, Q , R , I , W , X , V , S , Z , AA , AB , AC , AD , AE , AF , AG , AH , AI From SHOHINDAICHO Order by B";

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

        private void gcMultiRow1_CellContentDoubleClick(object sender, GrapeCity.Win.MultiRow.CellEventArgs e)
        {
            Form Fc = Application.OpenForms["Item_Master"];
            if (Fc != null)
            {
                Fc.Close();
                Item_Master itemmaster = new Item_Master();
                itemmaster.txtyCode = Convert.ToString(gcMultiRow1.CurrentRow.Cells["txtCode"].Value);
                itemmaster.Show();
            }
            else
            {
                Item_Master itemmaster = new Item_Master();
                itemmaster.txtyCode = Convert.ToString(gcMultiRow1.CurrentRow.Cells["txtDemban"].Value);
                itemmaster.Show();
            }


            //Item_Master master = new Item_Master();
            //master.txtyCode = gcMultiRow1.CurrentRow.Cells["txtCode"].Value.ToString();
        }
    }
}
    