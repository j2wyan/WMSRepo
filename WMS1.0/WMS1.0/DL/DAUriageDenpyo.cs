using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WMS_V1.DL
{
  public  class DAUriageDenpyo
    {
        public DataTable getUriagedenpyobyRowCount(string sql)
        {

            DataTable dt = null;

            SqlConnection clsConn = new SqlConnection(General.getCon1());
            try
            {
                clsConn.Open();
                string select_query = "select top   100 * from URIAGEDEMPYO   " + sql;
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

        public DataTable getUriagedenpyo(long denpyoID)
        {
            
            DataTable dt = null;

            SqlConnection clsConn = new SqlConnection(General.getCon1());
            try
            {
                clsConn.Open();
                string select_query = "select * from URIAGEDEMPYO  where A =" + denpyoID;
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
