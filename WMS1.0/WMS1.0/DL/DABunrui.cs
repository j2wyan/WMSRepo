using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WMS_V1.DL
{
   public class DABunrui
    {
        public DataTable getBunruibyColumn(string ext, int BurinNo)
        {
            DataTable dt = null;

            SqlConnection clsConn = new SqlConnection(General.getCon1());
            try
            {
                clsConn.Open();
                string select_query = " select A,  B+'#" + ext + "' AS B,C from BUNRUI where A=" + BurinNo + " and  B  in (select distinct " + ext + " from [SHOHINDAICHO] )";
                SqlDataAdapter dadapter = new SqlDataAdapter(select_query, clsConn);
                DataSet dset = new DataSet();

                dadapter.Fill(dset, "table");
                dt = dset.Tables[0];
                clsConn.Close();

            }
            catch (Exception)
            {
                clsConn.Close();
            }
            return dt;
        }
    }
}
